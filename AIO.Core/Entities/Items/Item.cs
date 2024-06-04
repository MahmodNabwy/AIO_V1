using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIO.Core.Entities.Items
{
    [Table("items")]
    public class Item : BaseEntityUpdate
    {
        [StringLength(100)]
        [Column("code")]
        public string Code { get; set; }
         
        [Column("description")]
        public string Description { get; set; }

    }
}
