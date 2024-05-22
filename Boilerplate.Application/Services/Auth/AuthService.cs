using AutoMapper;
using Boilerplate.Contracts.DTOs.Auth.Getter.ForgetPassword;
using Boilerplate.Contracts.DTOs.Auth.Getter.Users;
using Boilerplate.Contracts.DTOs.Auth.Setter;
using Boilerplate.Contracts.DTOs.Auth.Setter.ForgetPassword;
using Boilerplate.Contracts.DTOs.Auth.Setter.Roles.RoleUser;
using Boilerplate.Contracts.Interfaces.Custom;
using Boilerplate.Contracts.IServices.Services.Auth;
using Boilerplate.Contracts.IServices.Services.EmailSenderService;
using Boilerplate.Contracts.IServices.Services.EncryptionAndDecryption;
using Boilerplate.Contracts.IServices.Services.Permissions;
using Boilerplate.Core.Bases;
using Boilerplate.Core.Entities.Auth;
using Boilerplate.Core.IServices.Custom;
using Boilerplate.Shared.Consts;
using Boilerplate.Shared.Helpers;
using Boilerplate.Shared.Interfaces;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Boilerplate.Application.Services.Auth
{
    public class AuthService : BaseService<AuthService>, IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSenderService _emailSender;
        private readonly IServer _server;
        private readonly IPermissionService _PermissionService;
        private readonly IUserService _userService;
        private readonly IEncryptionAndDecryptionService _encryptionAndDecryptionService;
        public const string numbers = "0123456789";
        const int maxFailedLogins = 5;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, IHolderOfDTO holderOfDTO, ICulture culture, IHostEnvironment environment, RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager, IEmailSenderService emailSender, IServer server, IUserService userService, IHttpContextAccessor httpContextAccessor,
            IPermissionService PermissionService, IEncryptionAndDecryptionService encryptionAndDecryptionService, ILogger<AuthService> logger)
            : base(unitOfWork, mapper, holderOfDTO, logger, culture, environment, httpContextAccessor)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _emailSender = emailSender;
            _userService = userService;
            _server = server;
            _PermissionService = PermissionService;
            _encryptionAndDecryptionService = encryptionAndDecryptionService;
        }

        public async Task<IHolderOfDTO> RegisterUserAsync(UserRegisterSetterDTO setterDTO)
        {
            if (string.IsNullOrEmpty(setterDTO.Email))
                return ErrorMessage(_culture.SharedLocalizer["Email is required"].Value);
            if (!ObjectUtils.IsValidEmail(setterDTO.Email))
                return ErrorMessage(_culture.SharedLocalizer["Email is not correct"].Value);
            if (await _userManager.FindByEmailAsync(setterDTO.Email) is not null)
                return ErrorMessage(_culture.SharedLocalizer["Email is already registered"].Value);
            if (!string.IsNullOrEmpty(setterDTO.Username) && await _userManager.FindByNameAsync(setterDTO.Username) is not null)
                return ErrorMessage(_culture.SharedLocalizer["Username is already registered"].Value);

            var user = _mapper.Map<User>(setterDTO);
            //To Do Update
            // await _userService.AddHistoricalDataOfUser(user);
            var resultUser = await _userManager.CreateAsync(user, setterDTO.Password);
            if (!resultUser.Succeeded)
                return _userService.FailedToAddOrUpdateUser(resultUser);
            _logger.LogInformation(Res.message, Res.Added);
            _holderOfDTO.Add(Res.state, true);
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> LoginAsync(UserLoginSetterDTO setterDTO)
        {
            _holderOfDTO.Clear();
            var user = await getUserAsync(setterDTO.PersonalKey);
            if (user.AccessFailedCount >= maxFailedLogins)
                return ErrorMessage("Account locked due to too many failed login attempts, contact support."); ;
            if (user is null || !await _userManager.CheckPasswordAsync(user, setterDTO.Password))
            {
                UpdateFailedLoginCount(user);
                return ErrorMessage(_culture.SharedLocalizer["Personal Key or Password is incorrect"].Value);
            }
            if (user.IsBanned)
                return ErrorMessage(_culture.SharedLocalizer["User is Inactive"].Value);

            _logger.LogInformation(Res.message, LogMessages.Login);
            return await BuildUserAuthAsync(user);
        }
        public async Task<IHolderOfDTO> LoginAdminAsync(UserLoginSetterDTO setterDTO)
        {
            var user = await getUserAsync(setterDTO.PersonalKey);
            _holderOfDTO.Clear();
            if (user.AccessFailedCount >= maxFailedLogins)
                return ErrorMessage("Account locked due to too many failed login attempts, contact support."); ;
            if (user is null || !await _userManager.CheckPasswordAsync(user, setterDTO.Password))
            {
                UpdateFailedLoginCount(user);
                return ErrorMessage(_culture.SharedLocalizer["Personal Key or Password is incorrect"].Value);
            }
            if (user.IsBanned)
                return ErrorMessage(_culture.SharedLocalizer["User is Inactive"].Value);

            _logger.LogInformation(Res.message, LogMessages.Login);
            return await BuildAdminAuthAsync(user);
        }
        public async Task<IHolderOfDTO> ChangePasswordAsync(ChangePasswordSetterDTO changePasswordSetterDTO)
        {
            var user = await _userManager.FindByIdAsync(GetUserId());

            if (user == null || user.IsBanned)
                return ErrorMessage(_culture.SharedLocalizer["User is Inactive"].Value);
            if (!await _userManager.CheckPasswordAsync(user, changePasswordSetterDTO.OldPassword))
                return ErrorMessage(_culture.SharedLocalizer["Old Password is incorrect"].Value);
            var result = await _userManager.ChangePasswordAsync(user, changePasswordSetterDTO.OldPassword, changePasswordSetterDTO.NewPassword);
            if (!result.Succeeded)
                return _userService.FailedToAddOrUpdateUser(result);

            _holderOfDTO.Add(Res.state, true);
            _holderOfDTO.Add(Res.isConfirmed, true);
            _logger.LogInformation(Res.message, LogMessages.ChangePassword);
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> ForgotPasswordAsync(ForgetPasswordSetterDTO setterDTO)
        {
            if (ObjectUtils.IsValidEmail(setterDTO.Email))
            {
                var user = _unitOfWork.Users.Find(q => q.Email == setterDTO.Email, disableTracking: false);
                if (user != null)
                {
                    bool status = await UpdateUserWithResetData(user);
                    if (status)
                    {
                        await SendResetCodeEmail(user);
                        var forgetPassword = new ForgetPasswordGetterDTO();
                        GetOutPutParameters(user, forgetPassword);
                    }
                    _logger.LogInformation(Res.message, LogMessages.ForgetPassword);
                    return _holderOfDTO;
                }
                else
                    return ErrorMessage(_culture.SharedLocalizer["User is Inactive"].Value);
            }
            else
                return ErrorMessage(_culture.SharedLocalizer["Email is not correct"].Value);
        }
        public async Task<IHolderOfDTO> EnterResetCodeAsync(ResetCodeSetterDTO setterDTO)
        {
            try
            {
                var user = _unitOfWork.Users.Find(q => q.Id == setterDTO.UserId, disableTracking: false);
                if (user != null)
                {
                    if (user.ResetCode != null && user.ResetCode == setterDTO.ResetCode)
                    {
                        if (DateTime.Now <= user.ResetTime)
                        {
                            user.ResetCode = null;
                            user.IsVerified = true;
                            await _unitOfWork.Users.UpdateAsync(user);
                            _holderOfDTO.Add(Res.state, _unitOfWork.Complete() > 0);
                            _logger.LogInformation(Res.message, LogMessages.ResetCode);
                            return _holderOfDTO;
                        }
                        else
                            return ErrorMessage(_culture.SharedLocalizer["Reset code Timeout"].Value);
                    }
                    else
                        return ErrorMessage(_culture.SharedLocalizer["Invalid reset code"].Value);
                }
                else
                    return ErrorMessage(Res.NotFound);
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }
        public async Task<IHolderOfDTO> ResetPasswordAsync(ResetPasswordSetterDTO setterDTO)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(setterDTO.UserId); ;
                if (user != null && user.IsVerified)
                {
                    user.IsVerified = false;
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, setterDTO.Password);
                    var result = await _userManager.UpdateAsync(user);
                    _logger.LogInformation(Res.message, LogMessages.ResetPassword);
                    _holderOfDTO.Add(Res.state, true);
                    return _holderOfDTO;
                }
                else
                    return ErrorMessage(Res.NotFound);
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }
        public async Task<IHolderOfDTO> AddUserToRoleAsync(RoleUserSetterDTO userRoleSetterDTO)
        {
            var user = await _userManager.FindByIdAsync(userRoleSetterDTO.UserId);
            var roleName = await getRoleNameAsync(userRoleSetterDTO.RoleId);
            if (user is null || roleName is null)
                return ErrorMessage(_culture.SharedLocalizer["Invalid user ID or Role"].Value);
            if (await _userManager.IsInRoleAsync(user, roleName))
                return ErrorMessage(_culture.SharedLocalizer["User already assigned to this role"].Value);
            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded)
                return ErrorMessage(_culture.SharedLocalizer["Something went wrong when tring to add role to user"].Value);
            _holderOfDTO.Add(Res.state, true);
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> GetRoleUsersAsync(string roleName)
        {
            var lUsers = await _userManager.GetUsersInRoleAsync(roleName);
            if (lUsers is null || lUsers.Count() == 0)
                return ErrorMessage(_culture.SharedLocalizer["This role does not have users"].Value);
            _holderOfDTO.Add(Res.Response, _mapper.Map<IEnumerable<UserSetterDTO>>(lUsers));
            _holderOfDTO.Add(Res.state, true);
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> AutoLoginAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(GetUserId());
                if (user.IsBanned)
                    return ErrorMessage(_culture.SharedLocalizer["User is Inactive"].Value);
                _logger.LogInformation(Res.message, LogMessages.Login);
                return await BuildUserAuthAsync(user);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> AutoLoginAdminAsync()
        {
            List<bool> lIndicators = new List<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(GetUserId());
                if (user.IsBanned)
                {
                    ErrorMessage(lIndicators, _culture.SharedLocalizer["User is Inactive"].Value);
                    return _holderOfDTO;
                }
                _logger.LogInformation(Res.message, LogMessages.Login);
                return await BuildAdminAuthAsync(user);
            }
            catch (Exception ex)
            {
                ExceptionError(lIndicators, ex.Message);
            }
            _holderOfDTO.Add(Res.state, lIndicators.All(x => x));
            return _holderOfDTO;
        }
        public async Task<IHolderOfDTO> RefreshTokensAsync(string refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
                return ErrorMessage(_culture.SharedLocalizer["Refresh Token is required"].Value);
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.RefreshToken == refreshToken));
            if (user == null)
                return ErrorMessage(_culture.SharedLocalizer["Invalid token"].Value);
            if (user.IsBanned)
                return ErrorMessage(_culture.SharedLocalizer["User is Inactive"].Value);
            if (!await _userManager.IsEmailConfirmedAsync(user))
                return await sendEmailConfirmationCodeAsync(user);
            return await BuildUserAuthAsync(user);
        }
        public async Task<IHolderOfDTO> AutoLoginAsync(string refreshToken)
        {
            return await RefreshTokensAsync(refreshToken);
        }
        public async Task<IHolderOfDTO> EmailConfirmationAsync(EmailConfirmationSetterDTO emailConfirmationSetterDTO)
        {
            var user = await getUserAsync(emailConfirmationSetterDTO.PersonalKey);
            if (user == null)
            {
                _holderOfDTO.Add(Res.state, false);
                _holderOfDTO.Add(Res.message, _culture.SharedLocalizer["Invalid Personal Key"].Value);
                return _holderOfDTO;
            }
            if (user.IsBanned)
            {
                _holderOfDTO.Add(Res.state, false);
                _holderOfDTO.Add(Res.message, _culture.SharedLocalizer["User is Inactive"].Value);
                return _holderOfDTO;

            }
            if (string.IsNullOrEmpty(emailConfirmationSetterDTO.TokenCode) || emailConfirmationSetterDTO.TokenCode.Length != 6)
            {
                _holderOfDTO.Add(Res.state, false);
                _holderOfDTO.Add(Res.message, _culture.SharedLocalizer["Invalid Code"].Value);
                return _holderOfDTO;
            }

            // Get Current ResetPasswordToken by Code
            var currentResetPasswordToken = user.ValidationTokens.SingleOrDefault(t => t.Code == emailConfirmationSetterDTO.TokenCode);

            if (currentResetPasswordToken is null || !currentResetPasswordToken.IsActive)
            {
                _holderOfDTO.Add(Res.state, false);
                _holderOfDTO.Add(Res.message, _culture.SharedLocalizer["Invalid or Inactive Code"].Value);
                return _holderOfDTO;
            }

            var result = await _userManager.ConfirmEmailAsync(user, currentResetPasswordToken.Token);
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                    errors += $"{error.Description},";
                errors = errors.Remove(errors.Length - 1, 1);
                _holderOfDTO.Add(Res.state, false);
                _holderOfDTO.Add(Res.message, errors);
                return _holderOfDTO;
            }
            var holderResult = await BuildUserAuthAsync(user);
            return holderResult;
        }
        public async Task<IHolderOfDTO> ResendEmailConfirmationCodeAsync(PersonalKeySetterDTO setterDTO)
        {
            var user = await getUserAsync(setterDTO.PersonalKey);
            if (user == null)
            {
                _holderOfDTO.Add(Res.state, false);
                _holderOfDTO.Add(Res.message, _culture.SharedLocalizer["Invalid personal key"].Value);
                return _holderOfDTO;
            }
            if (!await _userManager.IsEmailConfirmedAsync(user))
                return await sendEmailConfirmationCodeAsync(user);

            _holderOfDTO.Add(Res.state, true);
            _holderOfDTO.Add(Res.isConfirmed, true);
            return _holderOfDTO;
        }

        #region Helper Methods
        private void UpdateFailedLoginCount(User? user)
        {
            user.AccessFailedCount++;
            var oData = _unitOfWork.Users.Update(user);
            _unitOfWork.Complete();
        }
        private async Task<IHolderOfDTO> CheckBeforeLogin(User user, string password)
        {
            _holderOfDTO.Clear();
            if (user.AccessFailedCount >= maxFailedLogins)
                return ErrorMessage("Account locked due to too many failed login attempts, contact support."); ;

            if (user is null || !await _userManager.CheckPasswordAsync(user, password))
            {
                UpdateFailedLoginCount(user);
                return ErrorMessage(_culture.SharedLocalizer["Personal Key or Password is incorrect"].Value);
            }
            if (user.IsBanned)
                return ErrorMessage(_culture.SharedLocalizer["User is Inactive"].Value);

            _logger.LogInformation(Res.message, LogMessages.Login);
            return _holderOfDTO;
        }
        private async Task<User> getUserAsync(string personalKey)
        {
            User user = null;
            if (ObjectUtils.IsPhoneNumber(personalKey))
            {
                user = await _userManager.Users.Where(x => x.PhoneNumber == personalKey).SingleOrDefaultAsync();
            }
            else if (ObjectUtils.IsValidEmail(personalKey))
            {
                user = await _userManager.FindByEmailAsync(personalKey);
            }
            else
            {
                user = await _userManager.FindByNameAsync(personalKey);
            }
            return user;
        }
        private async Task<IHolderOfDTO> sendEmailConfirmationCodeAsync(User user)
        {
            if (user.ValidationTokens == null)
                user.ValidationTokens = new List<UserValidationToken>();
            user.ValidationTokens.Clear();

            // send code to email
            var messageContent = "";// $"Your Email Confirmation Code is :/* {userEmailConfirmationToken.Code}*/";
            var message = new Message(new string[] { user.Email }, "Boilerplate App, Email Confirmation Code", messageContent, null);
            try
            {
                _emailSender.SendEmailAsync(message);
            }
            catch (Exception ex)
            {

            }
            if (!_holderOfDTO.ContainsKey(Res.state))
                _holderOfDTO.Add(Res.state, true);
            //_holderOfDTO.Add(Res.isConfirmed, false);
            _holderOfDTO.Add(Res.id, user.Id);
            return _holderOfDTO;
        }
        private async Task<string> getRoleNameAsync(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role is not null)
                return role.Name;
            return null;
        }
        private async Task<JwtSecurityToken> CreateAccessTokenAsync(User user)
        {
            // Get User Claims
            var userClaims = await _userManager.GetClaimsAsync(user);
            // Get User Roles and add its to User Claims
            var userRoles = (List<string>)await _userManager.GetRolesAsync(user);
            userClaims.Add(new Claim("roles", "Anonamouse"));
            userClaims.Add(new Claim("roles", "Anonamouse"));
            if (userRoles is not null && userRoles.Count() > 0)
            {
                foreach (var userRole in userRoles)
                    userClaims.Add(new Claim("roles", userRole));
            }

            // Add Some User Claims
            var claims = new[]
            {
                new Claim("uid", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Name, user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }
            .Union(userClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTKeys.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: JWTKeys.Issuer,
                audience: JWTKeys.Audience,
                claims: claims,
                expires: DateTime.Now.AddHours(JWTKeys.DurationInHours),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
        private async Task<IHolderOfDTO> BuildUserAuthAsync(User user)
        {
            var jwtSecurityToken = await CreateAccessTokenAsync(user);
            //to Do Update
            // if (user.SubscriptionTypeId == null)
            {
                _holderOfDTO.Clear();
                return ErrorMessage(_culture.SharedLocalizer["Only EndUser account can login"].Value);
            }
            var existUser = _mapper.Map<UserAuthGetterDTO>(user);
            existUser.AccessToken = _encryptionAndDecryptionService.EncryptData(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));
            existUser.AccessTokenExpiration = jwtSecurityToken.ValidTo;
            _holderOfDTO.Add(Res.state, true);
            _holderOfDTO.Add(Res.isConfirmed, true);
            _holderOfDTO.Add(Res.Response, existUser);
            return _holderOfDTO;
        }
        private async Task<IHolderOfDTO> BuildAdminAuthAsync(User user)
        {
            var rolesList = (List<string>)await _userManager.GetRolesAsync(user);
            var permissionList = await _PermissionService.GetPermissionByRolesName(rolesList);
            if (permissionList.Count == 0)
            {
                _holderOfDTO.Clear();
                return ErrorMessage(_culture.SharedLocalizer["Only admin account can login"].Value);
            }
            var jwtSecurityToken = await CreateAccessTokenAsync(user);
            var existUser = _mapper.Map<AdminAuthGetterDTO>(user);
            existUser.AccessToken = _encryptionAndDecryptionService.EncryptData(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken));
            existUser.AccessTokenExpiration = jwtSecurityToken.ValidTo;
            existUser.Roles = rolesList;
            existUser.Permissions = permissionList;

            _holderOfDTO.Add(Res.state, true);
            _holderOfDTO.Add(Res.isConfirmed, true);
            _holderOfDTO.Add(Res.Response, existUser);
            return _holderOfDTO;

        }
        public string GenerateResetCode()
        {
            Random rnd = new Random();
            int size = 6;
            char[] code = new char[size];
            for (int i = 0; i < size; i++)
            {
                code[i] = numbers[rnd.Next(numbers.Length)];
            }
            return new string(code);
        }
        async Task<bool> UpdateUserWithResetData(User user)
        {
            user.ResetCode = GenerateResetCode();
            user.ResetTime = DateTime.Now.AddHours(1);
            await _unitOfWork.Users.UpdateAsync(user);
            return _unitOfWork.Complete() > 0;
        }
        private void GetOutPutParameters(User user, ForgetPasswordGetterDTO forgetPassword)
        {
            forgetPassword.UserId = user.Id;
            forgetPassword.ResetTime = user.ResetTime;
            _holderOfDTO.Add(Res.Response, forgetPassword);
            _holderOfDTO.Add(Res.state, true);
            _holderOfDTO.Add(Res.message, _culture.SharedLocalizer["Reset code has been sent to your email"]);
        }
        private async Task SendResetCodeEmail(User user)
        {
            var messageContent = $"{_culture.SharedLocalizer["Your Reset Code is "].Value} : {user.ResetCode}";
            var message = new Message(new string[] { user.Email }, _culture.SharedLocalizer[EmailMessages.ResetPasswordEmail].Value, messageContent, null);
            await _emailSender.SendEmailAsync(message);
        }
        public string buildProfileImagePath(string path)
        {
            var adresses = _server.Features.Get<IServerAddressesFeature>().Addresses.ToList();
            if (!string.IsNullOrEmpty(path))
            {
                var uri = path.Replace(@"\", @"/");
                if (adresses is not null && adresses.Count() > 0)
                {
                    return $"{adresses[0]}/{uri}";
                }
                return uri;
            }
            else
                return $"{adresses[0]}/Images/NoProfile.png";
        }
        private async Task<IHolderOfDTO> SendWelcomeEmailAsync(User user, string Password)
        {

            // send code to email
            var messageContent = "<!DOCTYPE html PUBLIC ' -//W3C//DTD HTML 4.0 Transitional//EN' 'http://www.w3.org/TR/REC-html40/loose.dtd'><html lang='en' xmlns='http://www.w3.org/1999/xhtml' xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office' style='height: 100% !important; width: 100% !important; font-family: 'Roboto', sans-serif !important; font-size: 14px; line-height: 24px; font-weight: 400; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0 auto; padding: 0;'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'><meta charset='utf-8'><meta name='viewport' content='width=device-width'><meta http-equiv='X-UA-Compatible' content='IE=edge'><meta name='x-apple-disable-message-reformatting'><title></title><style>@font-face {font-family: 'Roboto'; font-style: normal; font-weight: 400; src: url('https://fonts.gstatic.com/s/roboto/v30/KFOmCnqEu92Fr1Mu4mxP.ttf') format('truetype');}body {margin: 0 auto !important; padding: 0 !important; height: 100% !important; width: 100% !important; font-family: 'Roboto', sans-serif !important; font-size: 14px; margin-bottom: 10px; line-height: 24px; font-weight: 400;}img {-ms-interpolation-mode: bicubic;}</style></head><body width='100%' style='mso-line-height-rule: exactly; height: 100% !important; width: 100% !important; font-family: 'Roboto', sans-serif !important; font-size: 14px; line-height: 24px; font-weight: 400; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0 auto; padding: 0;' bgcolor='#f5f6fa'><center style='width: 100%; background-color: #f5f6fa; text-align: right; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'><table width='100%' border='0' cellpadding='0' cellspacing='0' bgcolor='#f5f6fa' style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; border-spacing: 0 !important; border-collapse: collapse !important; table-layout: fixed !important; margin: 0 auto; padding: 0;'><tbody style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'><tr style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'><td style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; margin: 0; padding: 40px 0;'><table style='width: 100%; max-width: 620px; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; border-spacing: 0 !important; border-collapse: collapse !important; table-layout: fixed !important; margin: 0 auto; padding: 0;'><tbody style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'><tr style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'><td style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; margin: 0; padding: 0 0 25px;' align='center'><a href='#e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855' style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; text-decoration: none; margin: 0; padding: 0;'><img style='height: 40px; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; -ms-interpolation-mode: bicubic; margin: 0; padding: 0;' src='https://admin.digitalhub.com.eg/static/media/logo-dark.235b0ea8.svg' alt='logo'></a><p style='font-size: 14px; color: #000000; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 12px 0 0;'>A Complete Digital Learning and Continual Improvement Platform</p></td></tr></tbody></table><table style='width: 100%; max-width: 620px; text-align: right; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; border-spacing: 0 !important; border-collapse: collapse !important; table-layout: fixed !important; margin: 0 auto; padding: 0;' bgcolor='#ffffff'><tbody style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'><tr style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'><td style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; margin: 0; padding: 30px 30px 15px;'><p style='direction: rtl; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0 0 10px; padding: 0;'>مرحبا، " + user.FirstName + "</p><p style='direction: rtl; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0 0 25px; padding: 0;'><br style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>اسم المستخدم الخاص بك: " + user.UserName + "</p><p style='direction: rtl; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0 0 25px; padding: 0;'><br style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>كلمة المرور : " + "</p><a href='" + EmailMessages.WebsiteLink + "' style='background-color: #FF0059; border-radius: 4px; color: #ffffff; display: inline-block; font-size: 15px; font-weight: 600; line-height: 44px; text-align: center; text-decoration: none; text-transform: uppercase; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0 30px;'>الدخول الى المنصة</a></td></tr><tr style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'><td style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; margin: 0; padding: 0 30px;'><h4 style='font-size: 15px; color: #000000; font-weight: 600; text-transform: uppercase; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0 0 10px; padding: 0;'>أو</h4><p style='direction: rtl; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0 0 10px; padding: 0;'>إذا لم يعمل الزر أعلاه ، فقم بلصق هذا الرابط في متصفح الويب الخاص بك:</p><a href='" + EmailMessages.WebsiteLink + "' style='color: #FF0059; text-decoration: none; word-break: break-all; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>" + EmailMessages.WebsiteLink + "</a></td></tr><tr style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'><td style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; margin: 0; padding: 20px 30px 40px;'><p style='font-size: 13px; line-height: 22px; color: #9ea8bb; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>هذا بريد إلكتروني تم إنشاؤه تلقائيًا ، يرجى عدم الرد على هذا البريد الإلكتروني. إذا واجهت أي مشاكل ، فيرجى الاتصال بنا على help@MacroEconomic.app</p></td></tr></tbody></table><table style='width: 100%; max-width: 620px; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; border-spacing: 0 !important; border-collapse: collapse !important; table-layout: fixed !important; margin: 0 auto; padding: 0;'><tbody style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'><tr style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'><td style='-ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; mso-table-lspace: 0pt !important; mso-table-rspace: 0pt !important; margin: 0; padding: 25px 20px 0;' align='center'><p style='font-size: 13px; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;'>Copyright © 2023 MacroEconomic.app. All rights reserved. </p><p style='font-size: 13px; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 15px 0 0; padding: 0;'>Powered by <a style='color: #FF0059; text-decoration: none; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; margin: 0; padding: 0;' href='https://digitalhub.com.eg'>Digital Hub</a>.</p></td></tr></tbody></table></td></tr></tbody></table> </center></body></html>";
            var message = new Message(new string[] { user.Email }, EmailMessages.NewUserEmail, messageContent, null);
            try
            {
                await _emailSender.SendEmailAsync(message);
            }
            catch (Exception ex)
            {

            }
            if (_holderOfDTO.ContainsKey(Res.state))
                _holderOfDTO.Remove(Res.state);
            _holderOfDTO.Add(Res.state, true);
            _holderOfDTO.Add(Res.id, user.Id);
            return _holderOfDTO;
        }
        private UserRefreshToken GenerateUserRefreshToken(HttpContext? httpContext)
        {
            var randomNumber = new byte[32];
            using var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(randomNumber);
            var ipAdress = RequestUtils.GetClientIPAddress(httpContext);
            var userAgent = RequestUtils.GetClientAgent(httpContext);
            return new UserRefreshToken
            {
                RefreshToken = Convert.ToBase64String(randomNumber),
                CreatedOn = DateTime.UtcNow,
                IpAdress = ipAdress,
                Agent = userAgent,
                ExpiresOn = DateTime.UtcNow.AddDays(10)
            };
        }
        private UserValidationToken GenerateUserValidationToken(HttpContext? httpContext, string resetPasswordToken)
        {
            Random generator = new Random();
            string code = generator.Next(0, 1000000).ToString("D6");
            var ipAdress = RequestUtils.GetClientIPAddress(httpContext);
            var userAgent = RequestUtils.GetClientAgent(httpContext);
            return new UserValidationToken
            {
                Code = code,
                Token = resetPasswordToken,
                CreatedOn = DateTime.UtcNow,
                IpAdress = ipAdress,
                Agent = userAgent,
                ExpiresOn = DateTime.UtcNow.AddHours(2)
            };
        }

        #endregion
    }
}
