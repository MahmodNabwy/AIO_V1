using AutoMapper;
using Boilerplate.Contracts.DTOs.Getter.Lookups;
using Boilerplate.Contracts.Interfaces.Custom;
using Boilerplate.Contracts.IServices.Services.Lookups;
using Boilerplate.Core.Bases;
using Boilerplate.Core.IServices.Custom;
using Boilerplate.Shared.Consts;
using Boilerplate.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Boilerplate.Application.Services.Lookups
{
    public class LookupService : BaseService<LookupService>, ILookupService
    {
        public LookupService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture,
            IHostEnvironment environment, IHttpContextAccessor httpContextAccessor, ILogger<LookupService> logger)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
        }

        public async Task<IHolderOfDTO> GetDepartmnetsAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Department.FindAllAsync(q => !q.IsDeleted && q.IsActive, new[] { "DepartmentTranslations" });
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<LookupGetterDTO>>(query.ToList()));
                lIndicators.Add(true);
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                lIndicators.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> GetUserAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Users.FindAllAsync(q => !q.IsBanned, null);
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<LookupStringGetterDTO>>(query.ToList()));
                lIndicators.Add(true);
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                lIndicators.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> GetRoleAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Roles.FindAllAsync(q => !q.IsDeleted, null);
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<LookupStringGetterDTO>>(query.ToList()));
                lIndicators.Add(true);
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                lIndicators.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> GetLanguageAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Language.FindAllAsync(q => !q.IsDeleted, new[] { "LanguageTranslations" });
                _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<LookupGetterDTO>>(query.ToList()));
                lIndicators.Add(true);
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                lIndicators.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }

    }
}
