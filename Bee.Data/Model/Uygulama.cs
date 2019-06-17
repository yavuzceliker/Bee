using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bee.Data.Model
{
   
        [Table("Uygulama")]
        public class Uygulama
        {
            [Key]
            public int id { get; set; }

            [Required]
            public string kovanId { get; set; }

            [Required]
            public string uygulamaId { get; set; }

            [Required]
            public string anaVerme { get; set; }

            [Required]
            public string cerceveAlma { get; set; }

            [Required]
            public string cerceveVerme { get; set; }

            [Required]
            public string ilaclama { get; set; }

            [Required]
            public string fizikselOnarim { get; set; }

            [Required]
            public string besinVerme { get; set; }

            [Required]
            public string birlestirme { get; set; }

            [Required]
            public string bolme { get; set; }

            [Required]
            public string ballikAlma { get; set; }

            [Required]
            public string balHasadi { get; set; }

            [Required]
            public DateTime eklemeTarihi { get; set; }

        
    }
}
