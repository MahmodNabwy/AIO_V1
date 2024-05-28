using AIO.Contracts.Enums;
using AIO.Core.Entities.ProjectSuppliers;
using AIO.Core.Entities.SupplierCategories;
using AIO.Core.Entities.SupplierInsurances;
using AIO.Core.Entities.SupplierItems;
using AIO.Core.Entities.SupplierPaymentMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.Suppliers
{
    [Table("supplier")]
    public class Supplier : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Max length is 50 characters")]
        [Column("name")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Adress is required")]
        [StringLength(500, ErrorMessage = "Max length is 500 characters")]
        [Column("address")]
        public string Adress { get; set; }

        [StringLength(500, ErrorMessage = "Max length is 500 characters")]
        [Column("details")]
        public string Details { get; set; }


        [Required(ErrorMessage = "Responsible Person Name is required")]
        [StringLength(50, ErrorMessage = "Max length is 50 characters")]
        [Column("responsible_person_name")]
        public string ResponsiblePersonName { get; set; }

        [Required(ErrorMessage = "Responsible Person Phone is required")]
        [StringLength(50, ErrorMessage = "Max length is 50 characters")]
        [Column("responsible_person_phone")]
        public string ResponsiblePersonPhone { get; set; }


        [Required(ErrorMessage = "Responsible Person Job is required")]
        [StringLength(50, ErrorMessage = "Max length is 50 characters")]
        [Column("responsible_person_job")]
        public string ResponsiblePersonJob { get; set; }


        [Required(ErrorMessage = "Responsible Person Email is required")]
        [StringLength(100, ErrorMessage = "Max length is 100 characters")]
        [Column("responsible_person_email")]
        public string ResponsiblePersonEmail { get; set; }


        [Required(ErrorMessage = "Type  is required")]
        [Column("type_id")]
        public SupplierType TypeId { get; set; }

        public virtual ICollection<ProjectSupplier> ProjectSuppliers { get; set; }
        public virtual ICollection<SupplierCategory> SupplierCategories { get; set; }
        public virtual ICollection<SupplierProjectInsurance> SupplierProjectInsurances { get; set; }
        public virtual ICollection<SupplierProjectItem> SupplierProjectItems { get; set; }
        public virtual ICollection<SupplierProjectPaymentMethod> SupplierPaymentMethods { get; set; }

    }
}
