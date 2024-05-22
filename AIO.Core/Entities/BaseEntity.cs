using AIO.Contracts.Enums;
using AIO.Contracts.Helpers;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AIO.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; } = 0;
    }

    public abstract class BaseEntityAttachment : BaseEntityWithUpdate
    {
        [Required]
        [Column("uid")]
        [StringLength(36)]
        public string Uid { get; set; }


        [NotMapped]
        private string _Url;
        [Required]
        [Column("url")]
        public string Url { get => _Url.ToHostUrl(); set => _Url = value; }


        [Required]
        [Column("size")]
        [StringLength(255)]
        public string Size { get; set; }

        [Column("media_type")]
        public AIO.Contracts.Enums.MediaType MediaType { get; set; }
    }

    public abstract class BaseEntityWithUpdate : BaseEntity
    {
        [Column("created_by")]
        public string CreatedBy { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_by")]
        public string UpdatedBy { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
    public abstract class BaseEntityUpdate : BaseEntityWithUpdate
    {
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
    }

    public abstract class BaseEntityTranslation : BaseEntityWithUpdate
    {
        [Column("locale")]
        [MaxLength(6)]
        [Required(ErrorMessage = "Locale is required")]
        public string Locale { get; set; }
    }

}