using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Bee.Data.Model
{
    
        [Table("DurumListesi")]
        public class DurumListesi
        {
            [Key]
            public int id { get; set; }

            [Required]
            public string kovanId { get; set; }

            [Required]
            public string muayeneId { get; set; }

            [Required]
            public string uygulamaId { get; set; }

            [Required]
            public DateTime eklemeTarihi { get; set; }

        }
    
}