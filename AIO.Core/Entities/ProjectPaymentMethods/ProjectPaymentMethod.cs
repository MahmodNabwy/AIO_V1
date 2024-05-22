
using AIO.Core.Entities.PaymentMethods;
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
    public class ProjectPaymentMethod
    {

        [Required(ErrorMessage = "Payment Method Id is required")]
        [Column("payment_method_id")]
        public int PaymentMethodId { get; set; }

        [Required(ErrorMessage = "Project Id is required")]
        [Column("project_id")]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }

        [ForeignKey(nameof(PaymentMethodId))]
        public virtual PaymentMethod PaymentMethod { get; set; }
    }
}
