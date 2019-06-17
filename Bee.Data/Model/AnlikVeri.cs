using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bee.Data.Model
{
    [Table("AnlikVeri")]
    public class AnlikVeri
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int agirlik { get; set; }

        [Required]
        public int sicaklik { get; set; }

        [Required]
        public int nem { get; set; }

        [Required]
        public int girisSayisi { get; set; }

        [Required]
        public int cikisSayisi { get; set; }
        

    }
}
