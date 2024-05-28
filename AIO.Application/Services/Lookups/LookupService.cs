using AutoMapper;
using AIO.Contracts.DTOs.Getter.Lookups;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.Lookups;
using AIO.Core.Bases;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AIO.Application.Services.Lookups
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


        public async Task<IHolderOfDTO> GetOwnersAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var query = await _unitOfWork.Owners.FindAllAsync(q => !q.IsDeleted);
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
