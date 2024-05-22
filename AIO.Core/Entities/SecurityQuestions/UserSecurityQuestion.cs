using AIO.Core.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AIO.Core.Entities.SecurityQuestions
{
    [Table("user_security_questions")]
    [Index(nameof(SecurityQuestionId), Name = "user_security_question_security_question_id_foreign")]
    [Index(nameof(UserId), Name = "user_security_question_user_id_foreign")]
    public partial class UserSecurityQuestion : BaseEntityUpdate
    {
        [Column("user_id")]
        public string UserId { get; set; }
        [Column("security_question_id")]
        public long SecurityQuestionId { get; set; }
        [StringLength(255)]
        [Column("security_answer")]
        public string SecurityAnswer { get; set; }

        [ForeignKey(nameof(SecurityQuestionId))]
        public virtual SecurityQuestion SecurityQuestion { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
