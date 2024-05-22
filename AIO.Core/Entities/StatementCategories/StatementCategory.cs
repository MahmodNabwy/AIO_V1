using AIO.Core.Entities.Categories;
using AIO.Core.Entities.Owners;
using AIO.Core.Entities.Statements;
using AIO.Core.Entities.Taxes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.StatementCategories
{
    [Table("statement_category")]
    public class StatementCategory : BaseEntityUpdate
    {
        [Required(ErrorMessage = "Statement Id is required")]
        [Column("statement_id")]
        public int StatementId { get; set; }


        [Required(ErrorMessage = "Category Id is required")]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Total Price is required")]
        [Column("total_price")]
        public decimal TotalPrice { get; set; }


        [ForeignKey(nameof(StatementId))]
        public virtual Statement Statement { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}
