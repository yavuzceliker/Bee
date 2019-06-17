using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bee.Data.Model
{
    [Table("BesinCesidi")]
    public class BesinCesidi
    {
        [Key]
        public int besinId { get; set; }

        [Required]
        public string besinAdi { get; set; }


    }
}
