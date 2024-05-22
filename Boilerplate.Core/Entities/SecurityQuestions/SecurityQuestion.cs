using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Boilerplate.Core.Entities.SecurityQuestions
{
    [Table("security_questions")]
    public partial class SecurityQuestion : BaseEntityUpdate
    {
        [Required]
        [StringLength(255)]
        [Column("question")]
        public string Question { get; set; }

        [StringLength(255)]
        [Column("question_ar")]
        public string QuestionAr { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        [InverseProperty(nameof(UserSecurityQuestion.SecurityQuestion))]

        public virtual ICollection<UserSecurityQuestion> UserSecurityQuestions { get; set; }
    }
}
