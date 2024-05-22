using AutoMapper;
using Boilerplate.Contracts.DTOs.Setter.Files;
using Boilerplate.Contracts.Enums;
using Boilerplate.Contracts.Helpers;
using Boilerplate.Contracts.Interfaces.Custom;
using Boilerplate.Core.Entities;
using Boilerplate.Core.Entities.Auth;
using Boilerplate.Core.IServices.Custom;
using Boilerplate.Shared.Consts;
using Boilerplate.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;

namespace Boilerplate.Core.Bases
{
    public class BaseService<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IHolderOfDTO _holderOfDTO;
        protected readonly ICulture _culture;
        private readonly IHostEnvironment _environment;
        private readonly IHttpContextAccessor _HtpContextAccessor;
        protected readonly ILogger<T> _logger;
        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ILogger<T> logger = null, ICulture culture = null, IHostEnvironment environment = null
           , IHttpContextAccessor HttpContextAccessor = null)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _holderOfDTO = holderOfDTO;
            _culture = culture;
            _environment = environment;
            _HtpContextAccessor = HttpContextAccessor;
            UserDetails.userId = GetUserId();
            _logger = logger;
        }
        protected string GetUserId()
        {
            string UserId = "";
            string AccessToken = "";
            try
            {
                if (_HtpContextAccessor != null && _HtpContextAccessor.HttpContext != null && _HtpContextAccessor.HttpContext.Request != null && _HtpContextAccessor.HttpContext.Request.Headers != null)
                    AccessToken = _HtpContextAccessor.HttpContext.Request.Headers["Authorization"];
                if (!string.IsNullOrEmpty(AccessToken))
                {
                    var tok = AccessToken.Replace("Bearer ", "").Replace("bearer ", "");
                    var jwttoken = new JwtSecurityTokenHandler().ReadJwtToken(tok);
                    UserId = jwttoken.Claims.First(claim => claim.Type == "uid").Value;
                }
                return UserId;
            }
            catch (Exception ex)
            {
                return UserId;
            }
        }
        protected string GetUserEmail()
        {
            string UserEmail = "";
            string AccessToken = "";
            try
            {
                if (_HtpContextAccessor != null && _HtpContextAccessor.HttpContext != null && _HtpContextAccessor.HttpContext.Request != null && _HtpContextAccessor.HttpContext.Request.Headers != null)
                    AccessToken = _HtpContextAccessor.HttpContext.Request.Headers["Authorization"];
                if (!string.IsNullOrEmpty(AccessToken))
                {
                    var tok = AccessToken.Replace("Bearer ", "").Replace("bearer ", "");
                    var jwttoken = new JwtSecurityTokenHandler().ReadJwtToken(tok);
                    UserEmail = jwttoken.Claims.First(claim => claim.Type == "email").Value;
                }
                return UserEmail;
            }
            catch (Exception ex)
            {
                return UserEmail;
            }
        }
        protected void AddCreateData(BaseEntityWithUpdate Entity)
        {
            Entity.UpdatedAt = Entity.CreatedAt = DateTime.Now;
            Entity.CreatedBy = Entity.UpdatedBy = GetUserId();
        }
        protected void AddUpdateData(BaseEntityWithUpdate Entity)
        {
            Entity.UpdatedAt = DateTime.Now;
            Entity.UpdatedBy = GetUserId();
        }
        protected void AddHistoricalDataOfUser(User user)
        {
            user.CreatedBy = user.UpdatedBy = GetUserId();
            user.CreatedAt = user.UpdatedAt = DateTime.Now;
        }
        #region Messages
        protected bool CheckPublish(bool isPublish, int status, List<bool> lIndicators)
        {
            if (isPublish && status != (int)Status.Approve)
            {
                CannotPublish(lIndicators);
                return true;
            }
            return false;
        }
        protected void ErrorMessage(List<bool> lIndicators, string message)
        {
            _holderOfDTO.Add(Res.message, message);
            _logger.LogError(Res.message, message);
            lIndicators.Add(false);
        }
        protected IHolderOfDTO ErrorMessage(string message)
        {
            _holderOfDTO.Add(Res.state, false);
            _holderOfDTO.Add(Res.message, message);
            _logger.LogError(Res.message, message);
            return _holderOfDTO;
        }
        protected void ExceptionError(List<bool> lIndicators, string message)
        {
            _holderOfDTO.Add(Res.message, "Something Bad happened, Please contact Administrator!");
            _logger.LogError(Res.message, message);
            lIndicators.Add(false);
        }
        protected void NotFoundError(List<bool> lIndicators)
        {
            ErrorMessage(lIndicators, Res.RecNotFound);
        }
        protected void CannotPublish(List<bool> lIndicators)
        {
            ErrorMessage(lIndicators, Res.CannotPublish);
        }
        protected void ItemAlreadyFound(List<bool> lIndicators)
        {
            ErrorMessage(lIndicators, _culture.SharedLocalizer["This item is already found"].Value);
        }
        #endregion
        protected async Task<IHolderOfDTO> GetUserIdAsync(UserManager<User> userManager, string refreshToken)
        {
            IHolderOfDTO internalHolder = new HolderOfDTO();
            // Check if Refresh Token is Empty
            if (string.IsNullOrEmpty(refreshToken))
            {
                internalHolder.Add(Res.state, false);
                internalHolder.Add(Res.message, "Refresh Token is required!");
                return internalHolder;
            }
            // Get User by any Refresh Token Even if it is Inactive 
            var user = await userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.RefreshToken == refreshToken));

            if (user == null)
            {
                internalHolder.Add(Res.state, false);
                internalHolder.Add(Res.message, "Invalid token");
                return internalHolder;
            }
            if (user.IsBanned)
            {
                internalHolder.Add(Res.state, false);
                internalHolder.Add(Res.message, "User is Inactive!");
                return internalHolder;

            }
            var currentUserRefreshToken = user.RefreshTokens.Single(t => t.RefreshToken == refreshToken);
            if (!currentUserRefreshToken.IsActive)
            {
                internalHolder.Add(Res.state, false);
                internalHolder.Add(Res.message, "Inactive token");
                return internalHolder;
            }

            internalHolder.Add(Res.state, true);
            internalHolder.Add(Res.uid, user.Id);
            return internalHolder;
        }
        #region Files
        public async Task<UploadFileSetterDTO> AddFile(IFormFile file, string[] filePath)
        {
            var uploadSetterDTO = new UploadFileSetterDTO();
            uploadSetterDTO.File = file;
            uploadSetterDTO.FilePathList = filePath;
            return await GetUploadedFile(uploadSetterDTO);
        }
        public async Task<UploadFileSetterDTO> GetUploadedFile(UploadFileSetterDTO fileSetterDTO)
        {
            try
            {
                if (fileSetterDTO is not null)
                {
                    fileSetterDTO.FileName = fileSetterDTO.File.FileName;
                    if (fileSetterDTO.File is not null && fileSetterDTO.File.Length > 0)
                    {
                        var holder = await UploadFileAsync(fileSetterDTO);
                        bool isUploaded = (bool)holder[Res.state];
                        fileSetterDTO.FilePath = (string)holder[Res.filePath];
                        fileSetterDTO.FileType = (string)holder[Res.fileType];
                        fileSetterDTO.FileSize = (string)holder[Res.fileSize];
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return fileSetterDTO;
        }
        protected async Task<IHolderOfDTO> UploadFileAsync(UploadFileSetterDTO fileSetterDTO)
        {
            var holder = new HolderOfDTO();
            List<bool> lIndicator = new List<bool>();
            try
            {
                if (fileSetterDTO.File is not null && fileSetterDTO.File.Length > 0)
                {
                    string extention = Path.GetExtension(fileSetterDTO.File.FileName).ToLower();
                    if (fileSetterDTO.FilePathList.Length > 0)
                    {
                        string dir = @"wwwroot\" + fileSetterDTO.FilePathList[0] + "\\" + fileSetterDTO.FilePathList[1];
                        if (!Directory.Exists(dir))
                            Directory.CreateDirectory(dir);

                        string fileName = Guid.NewGuid().ToString() + extention;
                        string path = Path.Combine(fileSetterDTO.FilePathList[0], fileSetterDTO.FilePathList[1], fileName);
                        var filePath = Path.Combine(_environment.ContentRootPath, dir, fileName);
                        using var fileStream = new FileStream(filePath, FileMode.Create);
                        await fileSetterDTO.File.CopyToAsync(fileStream);
                        var size = fileSetterDTO.File.Length.ToString();
                        var type = fileSetterDTO.File.ContentType;
                        var FinalPath = String.Format("/{0}/{1}/{2}", fileSetterDTO.FilePathList[0], fileSetterDTO.FilePathList[1], fileName);
                        holder.Add(Res.filePath, FinalPath);
                        holder.Add(Res.fileType, type);
                        holder.Add(Res.fileSize, size);
                        lIndicator.Add(true);
                    }
                    else
                        lIndicator.Add(false);
                }
                else
                    lIndicator.Add(false);
            }
            catch (Exception ex)
            {
                holder.Add(Res.message, ex.Message);
                holder.Add(Res.error, ex.InnerException);
                lIndicator.Add(false);
            }
            holder.Add(Res.state, lIndicator.All(x => x));
            return holder;
        }

        protected async Task<IHolderOfDTO> UploadFileAsync(FileSetterDTO fileSetterDTO, string fileType)
        {
            var holder = new HolderOfDTO();
            List<bool> lIndicator = new List<bool>();
            try
            {
                if (fileSetterDTO.file is not null && fileSetterDTO.file.Length > 0)
                {
                    List<string> FileExtentions = FileExtention(fileType);
                    string extention = Path.GetExtension(fileSetterDTO.file.FileName).ToLower();
                    if (FileExtentions.Count > 0 && FileExtentions.Contains(extention))
                    {
                        if (!string.IsNullOrEmpty(fileSetterDTO.filePath))
                        {
                            string dir = @"wwwroot\" + fileSetterDTO.filePath;
                            if (!Directory.Exists(dir))
                                Directory.CreateDirectory(dir);

                            string fileName = $"{fileSetterDTO.id}{extention}";
                            string path = Path.Combine(fileSetterDTO.filePath, fileName);
                            var filePath = Path.Combine(_environment.ContentRootPath, dir, fileName);
                            using var fileStream = new FileStream(filePath, FileMode.Create);
                            await fileSetterDTO.file.CopyToAsync(fileStream);
                            holder.Add(Res.filePath, path);
                            lIndicator.Add(true);
                        }
                        else
                            lIndicator.Add(false);
                    }
                    else
                        lIndicator.Add(false);
                }
                else
                    lIndicator.Add(false);
            }
            catch (Exception ex)
            {
                holder.Add(Res.message, ex.Message);
                holder.Add(Res.error, ex.InnerException);
                lIndicator.Add(false);
            }
            holder.Add(Res.state, lIndicator.All(x => x));
            return holder;
        }

        protected bool DeleteFile(string filePath)
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    var fileDir = @"wwwroot" + filePath;
                    if (File.Exists(fileDir))
                        File.Delete(fileDir);
                }
                lIndicator.Add(true);
            }
            catch (Exception ex)
            {
                lIndicator.Add(false);
            }
            return lIndicator.All(x => x);
        }

        private List<string> FileExtention(string fileType)
        {
            switch (fileType)
            {
                case FileTypes.Image:
                    return new List<string> { ".jpg", ".jpeg", ".png", ".gif" };
                    break;

                default:
                    return new List<string>();
                    break;
            }
        }
        #endregion

    }
}
