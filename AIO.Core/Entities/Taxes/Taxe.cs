using AIO.Core.Entities.ProjectsTaxes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.Taxes
{
    [Table("taxe")]
    public class Taxe : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(500, ErrorMessage = "Max length is 500 characters")]
        [Column("name")]
        public string Name { get; set; }

        public virtual ICollection<ProjectTaxe> ProjectTaxes { get; set; }
    }
}
