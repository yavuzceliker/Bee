using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bee.Data.Model
{
    [Table("YeniIslem")]
    public class YavruDurumu
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        public string pupa { get; set; }

        [Required]
        public string larva { get; set; }

        [Required]
        public string yumurta { get; set; }

        [Required]
        public string muayeneId { get; set; }
    }
}
