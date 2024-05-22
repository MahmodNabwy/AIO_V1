using AutoMapper;
using AIO.Application.Extentions;
using AIO.Contracts.DTOs.Auth.Getter;
using AIO.Contracts.DTOs.Auth.Getter.Users;
using AIO.Contracts.DTOs.Auth.Setter;
using AIO.Contracts.DTOs.Getter.Lookups;
using AIO.Contracts.DTOs.Setter.Files;
using AIO.Contracts.Filters.Auth;
using AIO.Contracts.Helpers;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.Auth;
using AIO.Contracts.IServices.Services.EmailSenderService;
using AIO.Contracts.IServices.Services.PasswordGeneration;
using AIO.Core.Bases;
using AIO.Core.Entities.Auth;
using AIO.Core.Entities.Departments;
using AIO.Core.IServices.Custom;
using AIO.Shared.Consts;
using AIO.Shared.Helpers;
using AIO.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace AIO.Application.Services.Auth
{
    public class UserService : BaseService<UserService>, IUserService
    {
        private UserManager<User> _userManager;
        private readonly PasswordHasher<User> _hasher = new PasswordHasher<User>();
        private readonly IHostingEnvironment _HostingEnvironment;
        private readonly IPasswordGenerationService _passwordGeneration;
        private readonly IEmailTempleteService _emailTempleteService;


        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture, IHostEnvironment environment, IPasswordGenerationService passwordGeneration,
            IEmailTempleteService emailTempleteService, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnvironment, ILogger<UserService> logger)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _userManager = userManager;
            _HostingEnvironment = hostingEnvironment;
            _passwordGeneration = passwordGeneration;
            _emailTempleteService = emailTempleteService;
        }


        public async Task<IHolderOfDTO> GetAllAsync()
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                List<UserAdminDataGetterDTO> userDataGetterDTOs = new List<UserAdminDataGetterDTO>();
                var query = await _unitOfWork.Users.GetAllUsers();
                foreach (var item in query)
                    userDataGetterDTOs.Add(await SetUserRoles(item));

                _logger.LogInformation(Res.message, Res.DataFetch);
                _holderOfDTO.Add(Res.Response, userDataGetterDTOs);
                lIndicator.Add(true);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicator, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> GetAllAdminUsersAsync()
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                List<UserAdminDataGetterDTO> userDataGetterDTOs = new List<UserAdminDataGetterDTO>();
                var query = await _unitOfWork.Users.GetAllAdminUsers();
                foreach (var item in query)
                    userDataGetterDTOs.Add(await SetUserRoles(item));
                _logger.LogInformation(Res.message, Res.DataFetch);
                _holderOfDTO.Add(Res.Response, userDataGetterDTOs);
                lIndicator.Add(true);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicator, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> GetAllEndUsersAsync()
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                _logger.LogInformation(Res.message, Res.DataFetch);
                _holderOfDTO.Add(Res.Response, _mapper.Map<List<UserDataGetterDTO>>(await _unitOfWork.Users.GetAllEndUsers()));
                lIndicator.Add(true);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicator, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> SearchAsync(UserFilter userFilter)
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                var query = await _unitOfWork.Users.buildUserQueryAsync(userFilter);
                var users = new List<UserAdminDataGetterDTO>();
                foreach (var item in query)
                    users.Add(await SetUserRoles(item));
                int totalCount = await query.CountAsync();
                var page = new Pager();
                page.Set(userFilter.PageSize, userFilter.CurrentPage, totalCount);
                _holderOfDTO.Add(Res.page, page);
                query = query.AddPage(page.Skip, page.PageSize);
                _holderOfDTO.Add(Res.Response, users);
                _logger.LogInformation(Res.message, Res.DataFetch);
                lIndicator.Add(true);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicator, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> GetByIdAsync(string userId)
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                var query = await _unitOfWork.Users.GetUserByIdAdminQuery(userId);
                if (query != null)
                {
                    UserAdminDataGetterDTO user = await SetUserRoles(query);
                    _logger.LogInformation(Res.message, Res.DataFetch);
                    _holderOfDTO.Add(Res.Response, user);
                    lIndicator.Add(true);
                }
                else
                    NotFoundError(lIndicator);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicator, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> GetByRefreshTokenAsync(string token)
        {
            try
            {
                var holder = await GetUserIdAsync(_userManager, token);
                if (!holder.ContainsKey(Res.state) || !(bool)holder[Res.state])
                    return holder;
                var userId = (string)holder[Res.uid];
                return await GetByIdAsync(userId);
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }
        public async Task<IHolderOfDTO> UpdateAsync(UserUpdateSetterDTO updateDTO)
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                //to Do Update
                var user = await _unitOfWork.Users.FirstOrDefaultAsync(q => q.Id == updateDTO.Id /*&& q.SubscriptionTypeId == null*/);

                if (string.IsNullOrEmpty(updateDTO.Email))
                    return ErrorMessage(_culture.SharedLocalizer["Email is required"].Value);
                if (!ObjectUtils.IsValidEmail(updateDTO.Email))
                    return ErrorMessage(_culture.SharedLocalizer["Email is not correct"].Value);
                if (await _userManager.FindByEmailAsync(updateDTO.Email) is not null)
                    return ErrorMessage(_culture.SharedLocalizer["Email is already registered"].Value);
                if (user is not null && user.Id != _userManager.FindByEmailAsync(updateDTO.Email).Result.Id)
                    return ErrorMessage(_culture.SharedLocalizer["Email is already registered"].Value);

                if (user is not null)
                {
                    user.Email = updateDTO.Email;
                    user.NormalizedEmail = updateDTO.Email.ToUpper();
                    user.FirstName = updateDTO.FirstName;
                    user.LastName = updateDTO.LastName;
                    user.Gender = updateDTO.Gender;
                    user.PhoneNumber = updateDTO.PhoneNumber;
                    user.UpdatedBy = GetUserId();
                    user.UpdatedAt = DateTime.Now;
                    var oData = _unitOfWork.Users.Update(user);
                    lIndicator.Add(_unitOfWork.Complete() > 0);
                    UpdateUserGroups(user.Id, updateDTO.Groups);
                    _logger.LogInformation(Res.message, Res.Updated);
                }
                else
                    NotFoundError(lIndicator);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicator, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> AddNewEmployeeAsync(UserSetterDTO setterDTO)
        {
            var generatedPassword = _passwordGeneration.Generate();

            if (string.IsNullOrEmpty(setterDTO.Email))
                return ErrorMessage(_culture.SharedLocalizer["Email is required"].Value);
            if (!ObjectUtils.IsValidEmail(setterDTO.Email))
                return ErrorMessage(_culture.SharedLocalizer["Email is not correct"].Value);
            if (await _userManager.FindByEmailAsync(setterDTO.Email) is not null)
                return ErrorMessage(_culture.SharedLocalizer["Email is already registered"].Value);
            if (!string.IsNullOrEmpty(setterDTO.Username) && await _userManager.FindByNameAsync(setterDTO.Username) is not null)
                return ErrorMessage(_culture.SharedLocalizer["Username is already registered"].Value);

            var user = _mapper.Map<User>(setterDTO);
            user.IsSystem = true;  //Employees are system users
            await AddHistoricalDataOfUser(user);
            var resultUser = await _userManager.CreateAsync(user, generatedPassword);
            if (!resultUser.Succeeded)
                return FailedToAddOrUpdateUser(resultUser);
            _holderOfDTO.Add(Res.id, user.Id.ToString());
            _logger.LogInformation(Res.message, Res.Added);
            _holderOfDTO.Add(Res.state, _unitOfWork.Complete());
            await _emailTempleteService.SendUserPasswordMail($"{user.FirstName} {user.LastName}", user.UserName, generatedPassword, user.Email);
            return _holderOfDTO;
        }

        public IHolderOfDTO FailedToAddOrUpdateUser(IdentityResult resultUser)
        {
            var errors = string.Empty;
            foreach (var error in resultUser.Errors)
                errors += $"{error.Description},";
            errors = errors.Remove(errors.Length - 1, 1);
            _logger.LogError(Res.message, errors);
            _holderOfDTO.Add(Res.state, false);
            _holderOfDTO.Add(Res.message, errors);
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> CheckBeforAddNewUser(string email, string userName)
        {
            await CheckEmail(email);
            await CheckUserName(userName);
            return _holderOfDTO;
        }
        public async Task AddHistoricalDataOfUser(User user)
        {
            user.CreatedBy = user.UpdatedBy = GetUserId();
            user.CreatedAt = user.UpdatedAt = DateTime.Now;
        }
        public async Task<IHolderOfDTO> Delete(string id)
        {
            List<bool> lIndicator = new List<bool>();

            var trans = _unitOfWork.Transaction();
            try
            {
                var user = await _unitOfWork.Users.FirstOrDefaultAsync(q => q.Id == id);
                if (user is not null)
                {
                    await DeleteAllUserRoles(id);
                    _unitOfWork.Users.Delete(id);
                    lIndicator.Add(_unitOfWork.Complete() > 0);
                    if (lIndicator.All(x => x))
                        trans.Commit();
                    else
                        trans.Rollback();
                    _logger.LogInformation(Res.message, Res.Deleted);

                }
                else
                {
                    _holderOfDTO.Add(Res.message, Res.NotFound);
                    _logger.LogError(Res.message, Res.NotFound);
                    lIndicator.Add(false);
                }
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                _logger.LogError(Res.message, ex.Message);
                lIndicator.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> BanUser(string UserId)
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(UserId);
                if (user is not null)
                {
                    user.UpdatedBy = UserId;
                    user.UpdatedAt = DateTime.Now;
                    user.IsBanned = true;
                    var result = await _userManager.UpdateAsync(user);
                    lIndicator.Add(result.Succeeded);
                    _logger.LogInformation(Res.message, Res.Updated);
                }
                else
                {
                    _holderOfDTO.Add(Res.message, Res.NotFound);
                    _logger.LogError(Res.message, Res.NotFound);
                    lIndicator.Add(false);
                }
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                _logger.LogError(Res.message, ex.Message);
                lIndicator.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> ActiveUser(string UserId)
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(UserId);
                if (user is not null)
                {
                    user.UpdatedBy = UserId;
                    user.UpdatedAt = DateTime.Now;
                    user.IsBanned = false;
                    var result = await _userManager.UpdateAsync(user);
                    lIndicator.Add(result.Succeeded);
                    _logger.LogInformation(Res.message, Res.Updated);
                }
                else
                {
                    _holderOfDTO.Add(Res.message, Res.NotFound);
                    _logger.LogError(Res.message, Res.NotFound);
                    lIndicator.Add(false);
                }
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                _logger.LogError(Res.message, ex.Message);
                lIndicator.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> UnlockedUser(string UserId)
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(UserId);
                if (user is not null)
                {
                    user.UpdatedBy = GetUserId();
                    user.UpdatedAt = DateTime.Now;
                    user.AccessFailedCount = 0;
                    var result = await _userManager.UpdateAsync(user);
                    lIndicator.Add(result.Succeeded);
                    _logger.LogInformation(Res.message, Res.Updated);
                }
                else
                {
                    _holderOfDTO.Add(Res.message, Res.NotFound);
                    _logger.LogError(Res.message, Res.NotFound);
                    lIndicator.Add(false);
                }
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                _logger.LogError(Res.message, ex.Message);
                lIndicator.Add(false);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> DeleteProfilePictureAsync(string id)
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user is null)
                {
                    _holderOfDTO.Add(Res.message, "Invalid User");
                    _holderOfDTO.Add(Res.state, false);
                    _holderOfDTO.Add(Res.message, Res.NotFound);
                    _logger.LogError(Res.message, Res.NotFound);
                    return _holderOfDTO;
                }
                bool isDelete = DeleteFile(user.Path);
                if (isDelete)
                {
                    user.Path = null;
                    var result = await _userManager.UpdateAsync(user);
                    lIndicator.Add(result.Succeeded);
                    _logger.LogInformation(Res.message, Res.Deleted);

                }
                lIndicator.Add(isDelete);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicator, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> ProfilePictureAsync(FileSetterDTO fileSetterDTO)
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                if (fileSetterDTO is not null && !string.IsNullOrEmpty(fileSetterDTO.id))
                {
                    fileSetterDTO.filePath = @"\Images\Users\";
                    if (fileSetterDTO.file is not null && fileSetterDTO.file.Length > 0)
                    {
                        var holder = await UploadFileAsync(fileSetterDTO, FileTypes.Image);
                        bool isUploaded = (bool)holder[Res.state];

                        if (isUploaded)
                        {
                            var user = await _userManager.FindByIdAsync(fileSetterDTO.id);
                            if (user is not null)
                            {
                                user.Path = holder[Res.filePath] as string;
                                user.UpdatedBy = fileSetterDTO.id;
                                user.UpdatedAt = DateTime.Now;
                                var result = await _userManager.UpdateAsync(user);
                                lIndicator.Add(result.Succeeded);
                            }
                            else
                                lIndicator.Add(false);
                        }
                        lIndicator.Add(isUploaded);
                    }
                    else
                        lIndicator.Add(false);
                }
                else
                    lIndicator.Add(false);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicator, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;

        }
        public async Task<IHolderOfDTO> GetOnlineUsers(List<string> Ids)
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                List<UserDataGetterDTO> userDataGetterDTOs = new List<UserDataGetterDTO>();
                var query = await _unitOfWork.Users.GetOnlineUsers(Ids);
                foreach (var item in query)
                    userDataGetterDTOs.Add(await SetUserRoles(item));
                // pagination
                _logger.LogInformation(Res.message, Res.DataFetch);
                _holderOfDTO.Add(Res.Response, userDataGetterDTOs);
                lIndicator.Add(true);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicator, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> ProfilePictureRefreshTokenAsync(FileSetterDTO fileSetterDTO)
        {
            try
            {
                var holder = await GetUserIdAsync(_userManager, fileSetterDTO.id);
                if (!holder.ContainsKey(Res.state) || !(bool)holder[Res.state])
                    return holder;

                var userId = (string)holder[Res.uid];
                fileSetterDTO.id = userId;
                return await ProfilePictureAsync(fileSetterDTO);
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                _holderOfDTO.Add(Res.state, false);
                return _holderOfDTO;
            }
        }
        public async Task<IHolderOfDTO> DeleteProfilePictureRefreshTokenAsync(string token)
        {
            try
            {
                var holder = await GetUserIdAsync(_userManager, token);
                if (!holder.ContainsKey(Res.state) || !(bool)holder[Res.state])
                    return holder;

                var userId = (string)holder[Res.uid];
                return await DeleteProfilePictureAsync(userId);
            }
            catch (Exception ex)
            {
                _holderOfDTO.Add(Res.message, ex.Message);
                _holderOfDTO.Add(Res.state, false);
                return _holderOfDTO;
            }
        }
        //public IHolderOfDTO Delete(string id)
        //{
        //    List<bool> lIndicator = new List<bool>();
        //    try
        //    {
        //        _unitOfWork.Users.Delete(id);
        //        lIndicator.Add(_unitOfWork.Complete() > 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        _holderOfDTO.Add(Res.message, ex.Message);
        //        _holderOfDTO.Add(Res.error, ex.InnerException);
        //        lIndicator.Add(false);
        //    }
        //    _holderOfDTO.Add(Res.state, lIndicator.All(x => x));

        //    return _holderOfDTO;
        //}
        //public IHolderOfDTO BanUSersByIDs(List<UserSetterDTO> lPostedUsers)
        //{

        //    List<bool> lIndicator = new List<bool>();
        //    try
        //    {
        //        List<string> lUsersIDs = new List<string>();

        //        lPostedUsers.ForEach(m => { lUsersIDs.Add(m.Id); });
        //        var lUsers = _unitOfWork.Users.SelectUsersByIDs(lUsersIDs); ;

        //        if (lUsers != null && lUsers.Count() != 0)
        //        {
        //            lUsers.ForEach(oStoredUser =>
        //            {
        //                UserSetterDTO oPostedUserVM = lPostedUsers.FirstOrDefault(m => m.Id == oStoredUser.Id);
        //                oStoredUser.IsBanned = oPostedUserVM.IsBanned;
        //            });
        //            bool bUsersBatchUpdated = _unitOfWork.Users.UpdateBatch(lUsers);
        //            _holderOfDTO.Add(Res.lUsers, lUsers);

        //        }
        //        lIndicator.Add(_unitOfWork.Complete() > 0);
        //    }
        //    catch (Exception ex)
        //    {
        //        _holderOfDTO.Add(Res.message, ex.Message);
        //        _holderOfDTO.Add(Res.error, ex.InnerException);
        //        lIndicator.Add(false);
        //    }
        //    _holderOfDTO.Add(Res.state, lIndicator.All(x => x));

        //    return _holderOfDTO;

        //}

        public async Task<IHolderOfDTO> GetProfilePic()
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                var UserId = GetUserId();
                var pic = await _unitOfWork.ProfilePicture.FirstOrDefaultAsync(e => e.UserId == UserId);
                _holderOfDTO.Add(Res.Response, _mapper.Map<ProfilePictureGetterDTO>(pic));
                lIndicator.Add(true);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicator, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;

        }
        public async Task<IHolderOfDTO> GetSecurityQuestionByUsername(string username)
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                var UserQuestion = await _unitOfWork.UserSecurityQuestions.FirstOrDefaultAsync(q => q.User.UserName == username, includes: new string[] { "SecurityQuestion" });
                _holderOfDTO.Add(Res.Response, UserQuestion.SecurityQuestion);
                lIndicator.Add(true);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicator, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> CheckSecurityQuestionAnswer(string username, string securityAnswer)
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                var UserQuestion = await _unitOfWork.UserSecurityQuestions.FirstOrDefaultAsync(q => q.User.UserName == username, includes: new string[] { "SecurityQuestion", "User" });
                var result = _hasher.VerifyHashedPassword(UserQuestion.User, UserQuestion.SecurityAnswer, securityAnswer);
                lIndicator.Add(result == PasswordVerificationResult.Success);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicator, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> SetUserProfilePicture(IFormFile file)
        {
            List<bool> lIndicator = new List<bool>();
            try
            {
                var UserId = GetUserId();
                var dir = _HostingEnvironment.WebRootPath;
                var folderName = Path.Combine("profile");
                var pathToSave = Path.Combine(dir, "storage", folderName);
                if (!Directory.Exists(pathToSave))
                    Directory.CreateDirectory(pathToSave);
                if (file.Length > 0)
                {
                    //var user = await _unitOfWork.Users.FirstOrDefaultAsync(q => q.Id == UserId,
                    //    includes: new string[] { "AnnouncementUsers", "BundleEnrols", "Certificates", "ClassQuizTakes", "ClassUserMeta", "CourseEnrols", "Courses", "Notes", "CourseRating", "UserGroups", "UserInfos", "UserSecurityQuestions", "RefreshTokens", "ValidationTokens" });
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                    var fileName = fileContent.FileName.Trim('"');
                    //var title = " profile";
                    // var originalFileName = Path.GetFileNameWithoutExtension(fileName);
                    var mime = file.ContentType;
                    var file_ext = Path.GetExtension(fileName);
                    var uuid = Guid.NewGuid().ToString();
                    var fileStoreName = "U-" + uuid + file_ext;
                    var fullPath = Path.Combine(pathToSave, fileStoreName);
                    var urlPath = Path.Combine("\\", "storage", folderName, fileStoreName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var profilePicture = new ProfilePicture
                    {
                        Id = 0,
                        UserId = UserId,
                        Title = file.Name.Split(".")[0],
                        Mime = mime,
                        Url = urlPath,
                        FileKey = uuid,
                        CreatedBy = UserId,
                        UpdatedBy = UserId
                    };
                    var profilePic = await _unitOfWork.ProfilePicture.AddAsync(profilePicture);
                    lIndicator.Add(_unitOfWork.Complete() > 0);
                    var user = await _userManager.FindByIdAsync(UserId);
                    if (user is not null)
                    {
                        user.Path = urlPath;
                        user.UpdatedBy = UserId;
                        user.UpdatedAt = DateTime.Now;
                        //user.ProfilePictureId = profilePic.Id;
                        var result = await _userManager.UpdateAsync(user);
                        lIndicator.Add(result.Succeeded);
                    }
                    else
                        lIndicator.Add(false);
                }
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicator, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicator.All(x => x));
            return _holderOfDTO;
        }


        //public async Task<IHolderOfDTO> BannedUser()
        //{
        //    List<bool> lIndicator = new List<bool>();
        //    var log = new LogSystem();
        //    log.Action = Actions.DeleteSoft;
        //    log.ModuleId = (long)Modules.Users;
        //    log.ModuleName = Module.Users;
        //    try
        //    {
        //        var UserId = GetUserId();
        //        var user = await _userManager.FindByIdAsync(UserId);
        //        if (user is not null)
        //        {
        //            user.UpdatedBy = UserId;
        //            user.UpdatedAt = DateTime.Now;
        //            user.IsBanned = true;
        //            var result = await _userManager.UpdateAsync(user);
        //            lIndicator.Add(result.Succeeded);
        //            log.ItemId = user.Id.ToString();
        //            log.Item = user.FullName;
        //        }
        //        else
        //        {
        //            lIndicator.Add(false);
        //            log.ItemId = GetUserId().ToString();
        //            log.Item = Module.Users;
        //            log.IsSuccess = false;
        //            log.Errors.Add(new LogError() { Code = CodeResponse.NotFound.ToString(), Exception = "Item not found", Message = "Item not found" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.ItemId = GetUserId().ToString();
        //        log.Item = Module.Users;
        //        log.Errors.Add(new LogError() { Code = CodeResponse.BadRequest.ToString(), Exception = ex.InnerException.ToString(), Message = ex.Message });
        //        _holderOfDTO.Add(Res.message, ex.Message);
        //        _holderOfDTO.Add(Res.error, ex.InnerException);
        //        lIndicator.Add(false);
        //    }
        //    var state = lIndicator.All(x => x);
        //    log.IsSuccess = state;
        //    AddLogs(log);
        //    _holderOfDTO.Add(Res.state, state);
        //    return _holderOfDTO;
        //}

        #region Helper Methods
        private async Task<UserAdminDataGetterDTO> SetUserRoles(User query)
        {
            var user = _mapper.Map<UserAdminDataGetterDTO>(query);
            var UserRoles = _unitOfWork.UserRoles.FindAll(q => q.UserId == user.Id).Result.Select(q => q.RoleId);
            var roles = await _unitOfWork.Roles.FindAll(x => UserRoles.Contains(x.Id), new[] { "RoleTranslations" });
            user.Roles = _mapper.Map<List<LookupStringGetterDTO>>(roles);
            return user;
        }
        private async Task<bool> DeleteAllUserRoles(string id)
        {
            var userRoles = await _unitOfWork.UserRoles.FindAll(q => q.UserId == id);
            if (userRoles.Any())
            {
                _unitOfWork.UserRoles.DeleteRange(userRoles);
                return _unitOfWork.Complete() > 0;
            }
            return true;
        }
        private void UpdateUserGroups(string id, List<int> groups)
        {
            var ladd = new List<DepartmentUser>();
            var ldelete = _unitOfWork.DepartmentUser.FindAll(q => q.UserId == id).Result.ToList();
            var orginalGroups = ldelete.Select(q => q.DepartmentId).ToList();
            foreach (var item in groups)
            {
                if (!orginalGroups.Contains(item))
                {
                    ladd.Add(new DepartmentUser()
                    {
                        DepartmentId = item,
                        UserId = id
                    });
                }
                else
                {
                    ldelete.RemoveAll(q => q.DepartmentId == item);
                }
            }
            if (ladd.Count() > 0)
            {
                _unitOfWork.DepartmentUser.AddRange(ladd);
                _unitOfWork.Complete();
            }
            if (ldelete.Count() > 0)
            {
                _unitOfWork.DepartmentUser.DeleteRange(ldelete);
                _unitOfWork.Complete();
            }
        }
        private void UpdateUserRoles(string id, List<string> roles)
        {
            var ladd = new List<IdentityUserRole<string>>();
            var ldelete = _unitOfWork.UserRoles.FindAll(q => q.UserId == id).Result.ToList();
            var orginalRoles = ldelete.Select(q => q.RoleId).ToList();
            foreach (var item in roles)
            {
                if (!orginalRoles.Contains(item))
                {
                    ladd.Add(new IdentityUserRole<string>()
                    {
                        RoleId = item,
                        UserId = id
                    });
                }
                else
                {
                    ldelete.RemoveAll(q => q.RoleId == item);
                }
            }
            if (ladd.Count() > 0)
            {
                _unitOfWork.UserRoles.AddRange(ladd);
                _unitOfWork.Complete();
            }
            if (ldelete.Count() > 0)
            {
                _unitOfWork.UserRoles.DeleteRange(ldelete);
                _unitOfWork.Complete();
            }
        }

        public async Task<IHolderOfDTO> CheckUserName(string userName)
        {
            if (!string.IsNullOrEmpty(userName) && await _userManager.FindByNameAsync(userName) is not null)
                return ErrorMessage(_culture.SharedLocalizer["Username is already registered"].Value);
            return _holderOfDTO;
        }

        public async Task<IHolderOfDTO> CheckEmail(string email)
        {
            await CheckEmailValidation(email);
            if (await _userManager.FindByEmailAsync(email) is not null)
                return ErrorMessage(_culture.SharedLocalizer["Email is already registered"].Value);
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> CheckEmail(string email, string userId)
        {
            await CheckEmailValidation(email);
            var user = await _userManager.FindByEmailAsync(email);
            if (user is not null && user.Id != userId)
                return ErrorMessage(_culture.SharedLocalizer["Email is already registered"].Value);
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> CheckEmailValidation(string email)
        {
            if (string.IsNullOrEmpty(email))
                return ErrorMessage(_culture.SharedLocalizer["Email is required"].Value);

            else if (!ObjectUtils.IsValidEmail(email))
                return ErrorMessage(_culture.SharedLocalizer["Email is not correct"].Value);
            return _holderOfDTO;
        }
        #endregion
    }
}
