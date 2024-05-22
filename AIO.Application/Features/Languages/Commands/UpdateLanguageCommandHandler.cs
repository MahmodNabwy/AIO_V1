using AutoMapper;
using AIO.Contracts.Features.Languages.Commands;
using AIO.Contracts.Features.Languages.DTOs.Getter.Language;
using AIO.Contracts.Interfaces.Custom;
using AIO.Core.Bases;
using AIO.Core.Entities.Languages;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AIO.Application.Features.Languages.Commands
{
    public class UpdateLanguageCommandHandler : BaseService<CreateLanguageCommandHandler>, IRequestHandler<UpdateLanguageCommand, IHolderOfDTO>
    {
        public UpdateLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            ILogger<CreateLanguageCommandHandler> logger, IHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {

        }
        public async Task<IHolderOfDTO> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var oldObj = _unitOfWork.Language.Find(q => q.Id == request.Id);
                if (oldObj != null)
                {

                    var dbSetterDTO = _mapper.Map<Language>(request);
                    dbSetterDTO.LanguageTranslations = UpdateRelatedData(dbSetterDTO.LanguageTranslations, oldObj.Id);
                    if (dbSetterDTO.LanguageTranslations.Count() > 0)
                        foreach (var translation in dbSetterDTO.LanguageTranslations)
                            AddUpdateTranslationDefaultData(translation);
                    var oData = await _unitOfWork.Language.UpdateAsync(dbSetterDTO);
                    lIndicators.Add(_unitOfWork.Complete() > 0);
                    _holderOfDTO.Add(Res.Response, _mapper.Map<LanguageDataGetterDTO>(oData));
                    _logger.LogInformation(Res.message, Res.Updated);
                }
                else
                    NotFoundError(lIndicators);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }
        #region Helper Method
        private ICollection<LanguageTranslation> UpdateRelatedData(ICollection<LanguageTranslation> update, int id)
        {
            var oldObj = _unitOfWork.LanguageTranslation.FindAllNoTrack(q => q.LanguageId == id);
            var updatedData = update.Where(q => q.Id != 0).ToList();
            RemoveRelatedData(oldObj, updatedData);
            AddNewRelatedData(update, id);
            return updatedData;
        }
        private void AddNewRelatedData(ICollection<LanguageTranslation> update, int id)
        {
            var NewData = update.Where(q => q.Id == 0).ToList();
            foreach (var item in NewData)
            {
                AddCreateData(item);
                item.LanguageId = id;
            }
            _unitOfWork.LanguageTranslation.AddRange(NewData);
            _unitOfWork.Complete();
        }
        private void RemoveRelatedData(IEnumerable<LanguageTranslation> oldObj, ICollection<LanguageTranslation> updated)
        {
            var DeletedData = new List<LanguageTranslation>();
            foreach (var item in oldObj)
            {
                var obj = updated.FirstOrDefault(q => q.Id == item.Id);
                if (obj == null)
                    DeletedData.Add(item);
            }
            if (DeletedData != null || DeletedData.Count() > 0)
            {
                _unitOfWork.LanguageTranslation.DeleteRange(DeletedData);
                _unitOfWork.Complete();
            }
        }
        private void AddUpdateTranslationDefaultData(LanguageTranslation dbSetterDTO)
        {
            var oldObj = _unitOfWork.LanguageTranslation.Find(q => q.Id == dbSetterDTO.Id);
            if (oldObj != null)
            {
                dbSetterDTO.CreatedBy = oldObj.CreatedBy;
                dbSetterDTO.CreatedAt = oldObj.CreatedAt;
                AddUpdateData(dbSetterDTO);
            }
        }
        #endregion
    }
}
