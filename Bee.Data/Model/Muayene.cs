using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bee.Data.Model
{
        [Table("Muayene")]
        public class Muayene
        {
            [Key]
            public int id { get; set; }

            [Required]
            public string kovanId { get; set; }

            [Required]
            public string muayeneId { get; set; }

            [Required]
            public string mevcutDurumu { get; set; }

            [Required]
            public string anaDurumu { get; set; }

            [Required]
            public string besinDurumu { get; set; }

            [Required]
            public string eksikCerceve { get; set; }

            [Required]
            public string anaMemesi { get; set; }

            [Required]
            public string yalanciAna { get; set; }

            [Required]
            public string ogul { get; set; }

            [Required]
            public string balDurumu { get; set; }

            [Required]
            public string fizikselSorun { get; set; }

            [Required]
            public string hastalik { get; set; }

            [Required]
            public string parazit { get; set; }

            [Required]
            public string zararli { get; set; }

            [Required]
            public string sonmusMu { get; set; }

            [Required]
            public DateTime eklemeTarihi { get; set; }

        }

    
}
