using Boilerplate.Contracts.DTOs.Setter.SecurityQuestions;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Boilerplate.Contracts.DTOs.Auth.Getter.SecurityQuestions
{
    public class UserSecurityQuestionGetterDTO : UserSecurityQuestionSetterDTO
    {
        [Display(Name = "userName")]
        public string UserName { get; set; }
        [Display(Name = "securityQuestion")]
        public long SecurityQuestion { get; set; }
    }
}