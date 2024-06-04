
using AIO.Contracts.Enums;
using AIO.Core.Entities.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.ProjectPaymentMethods
{
    [Table("project_payment_method")]
    public class ProjectPaymentMethod : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Percentage is required")]
        [Column("percentage")]
        public int Percentage { get; set; }


        [Required(ErrorMessage = "Amount is required")]
        [Column("amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "date is required")]
        [Column("date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "currency is required")]
        [Column("currency")]
        [NotMapped]
        public currency_type currency { get { return Project.currency; } }


        [Required(ErrorMessage = "Payment Method Type is required")]
        [Column("type_id ")]
        public PaymentMethodTypes TypeId { get; set; }

        [Required(ErrorMessage = "Project Id is required")]
        [Column("project_id")]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }

        
    }
}
