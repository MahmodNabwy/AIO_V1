using Boilerplate.Contracts.Bases;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Boilerplate.Contracts.DTOs.Setter.SecurityQuestions
{
    public class UserSecurityQuestionSetterDTO : BaseUpdateSetterDTO
    {
        [Display(Name = "user_id")]
        public string UserId { get; set; }
        [Display(Name = "security_question_id")]
        public long SecurityQuestionId { get; set; }
        [Display(Name = "security_answer")]
        public string SecurityAnswer { get; set; }
    }
}