using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bee.Data.Model
{
    [Table("AnaMemesi")]
    public class AnaMemesi
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string anaMemesiDurumu { get; set; }

        [Required]
        public int kovanId { get; set; }

        [Required]
        public int muayeneId { get; set; }

    }
}
