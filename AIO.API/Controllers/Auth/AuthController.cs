using AIO.API.Bases;
using AIO.Contracts.DTOs.Auth.Setter;
using AIO.Contracts.DTOs.Auth.Setter.ForgetPassword;
using AIO.Contracts.Interfaces.Custom;
using AIO.Contracts.IServices.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AIO.API.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : APIControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IHolderOfDTO holderOfDTO, IAuthService authService) : base(holderOfDTO)
        {
            _authService = authService;
        }

        /// <summary>
        /// User register in site 
        /// </summary>
        /// <returns> User register</returns>
        /// <remarks> User register in site</remarks>
        [AllowAnonymous]
        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegisterSetterDTO userRegisterSetterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            return State(await _authService.RegisterUserAsync(userRegisterSetterDTO));
        }


        //[HttpPost("ResendEmailConfirmationCode")]
        //public async Task<IActionResult> ResendEmailConfirmationCodeAsync([FromBody] PersonalKeySetterDTO personalKeySetterDTO)
        //{
        //    if (!ModelState.IsValid)
        //        return NotValidModelState();

        //    return State(await _authService.ResendEmailConfirmationCodeAsync(personalKeySetterDTO));
        //}

        //[HttpPost("ConfirmEmail")]
        //public async Task<IActionResult> ConfirmEmailAsync([FromBody] EmailConfirmationSetterDTO emailConfirmationSetterDTO)
        //{
        //    if (!ModelState.IsValid)
        //        return NotValidModelState();

        //    _holderOfDTO = await _authService.EmailConfirmationAsync(emailConfirmationSetterDTO);
        //    CheckStateAndSetRefreshToken(HttpContext, _holderOfDTO);

        //    return State(_holderOfDTO);

        //}

        /// <summary>
        /// User can login in site or admin panal
        /// </summary>
        /// <returns> User login</returns>
        /// <remarks> User login in site or admin panal</remarks>
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginSetterDTO userLoginSetterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            _holderOfDTO = await _authService.LoginAsync(userLoginSetterDTO);
            //CheckStateAndSetRefreshToken(HttpContext, _holderOfDTO);

            return State(_holderOfDTO);
        }

        /// <summary>
        /// User can login in admin panal
        /// </summary>
        /// <returns> User login</returns>
        /// <remarks> User login in admin panal</remarks>
        [AllowAnonymous]
        [HttpPost("LoginAdmin")]
        public async Task<IActionResult> LoginAdminAsync([FromBody] UserLoginSetterDTO userLoginSetterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            _holderOfDTO = await _authService.LoginAdminAsync(userLoginSetterDTO);
            // CheckStateAndSetRefreshToken(HttpContext, _holderOfDTO);

            return State(_holderOfDTO);
        }
        /// <summary>
        /// Auto login in site 
        /// </summary>
        /// <returns> User auto login</returns>
        /// <remarks> Auto login in site </remarks>
        [Authorize]
        [HttpPost("AutoLogin")]
        public async Task<IActionResult> AutoLoginAsync()
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            _holderOfDTO = await _authService.AutoLoginAsync();
            return State(_holderOfDTO);
        }

        /// <summary>
        /// Auto login Admin  
        /// </summary>
        /// <returns> User auto login Admin</returns>
        /// <remarks> Auto login Admin  </remarks>
        [Authorize]
        [HttpPost("AutoLoginAdmin")]
        public async Task<IActionResult> AutoLoginAdminAsync()
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            _holderOfDTO = await _authService.AutoLoginAdminAsync();
            return State(_holderOfDTO);
        }

        /// <summary>
        /// User can change password in site or admin panal  
        /// </summary>
        /// <returns> User can change password</returns>
        /// <remarks> User can change password in site or admin panal</remarks>
        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePasswordAsync([FromBody] ChangePasswordSetterDTO changePasswordSetterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            //changePasswordSetterDTO.RefreshToken = changePasswordSetterDTO.RefreshToken ?? Request.Cookies[Res.refreshToken];

            _holderOfDTO = await _authService.ChangePasswordAsync(changePasswordSetterDTO);

            return State(_holderOfDTO);
        }

        /// <summary>
        /// User can forgot password in site or admin panal 
        /// </summary>
        /// <returns> User forgot password</returns>
        /// <remarks> User forgot password in site or admin panal</remarks>
        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgetPasswordSetterDTO setterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            return State(await _authService.ForgotPasswordAsync(setterDTO));
        }

        /// <summary>
        /// User can add reset code in site or admin panal 
        /// </summary>
        /// <returns> User reset code</returns>
        /// <remarks> User can reset code in site or admin panal</remarks>
        [AllowAnonymous]
        [HttpPost("ResetCode")]
        public async Task<IActionResult> ResetCodeAsync([FromBody] ResetCodeSetterDTO setterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            _holderOfDTO = await _authService.EnterResetCodeAsync(setterDTO);

            return State(_holderOfDTO);
        }

        /// <summary>
        /// User can add reset password in site or admin panal 
        /// </summary>
        /// <returns> User reset password</returns>
        /// <remarks> User can reset password in site or admin panal</remarks>
        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordSetterDTO resetPasswordSetterDTO)
        {
            if (!ModelState.IsValid)
                return NotValidModelState();

            _holderOfDTO = await _authService.ResetPasswordAsync(resetPasswordSetterDTO);

            return State(_holderOfDTO);
        }

        //[Authorize]
        //[HttpPost("Logout")]
        //public async Task<IActionResult> LogoutAsync([FromBody] TokenSetterDTO tokenSetterDTO)
        //{
        //    if (!ModelState.IsValid)
        //        return NotValidModelState();
        //    return State(await _authService.LogoutAsync());
        //}

        //private void CheckStateAndSetRefreshToken(HttpContext httpContext, IHolderOfDTO holder)
        //{
        //    UserAuthGetterDTO userAuthDTO = null;
        //    if ((bool)holder[Res.state])
        //    {
        //        if (holder.ContainsKey(Res.isConfirmed) && (bool)holder[Res.isConfirmed] && holder.ContainsKey(Res.oUserAuth))
        //            userAuthDTO = (UserAuthGetterDTO)holder[Res.oUserAuth];
        //    }
        //    if (userAuthDTO is not null && !string.IsNullOrEmpty(userAuthDTO.RefreshToken))
        //    {
        //        var cookieOptions = new CookieOptions
        //        {
        //            HttpOnly = true,
        //            Expires = userAuthDTO.RefreshTokenExpiration.ToUniversalTime()
        //        };
        //        RequestUtils.SetCookie(httpContext, Res.refreshToken, userAuthDTO.RefreshToken, cookieOptions);
        //    }
        //    else
        //        RequestUtils.DeleteCookie(httpContext, Res.refreshToken);
        //}

    }
}
