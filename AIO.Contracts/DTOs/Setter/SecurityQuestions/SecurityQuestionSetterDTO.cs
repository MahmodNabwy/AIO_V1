using AIO.Contracts.Bases;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AIO.Contracts.DTOs.Setter.SecurityQuestions
{
    public class SecurityQuestionSetterDTO : BaseUpdateSetterDTO
    {
        [Display(Name = "question")]
        public string Question { get; set; }
        [Display(Name = "questionAr")]
        public string QuestionAr { get; set; }

    }
}