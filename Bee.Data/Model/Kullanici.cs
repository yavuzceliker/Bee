using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bee.Data.Model
{
    [Table("Kullanici")]
    public class Kullanici
    {

        [Key]
        public int id { get; set; }

        [Required]
        public string tc { get; set; }

        [Required]
        public string adSoyad { get; set; }

        [Required]
        public string mail { get; set; }

        [Required]
        public string iletisimTel { get; set; }

        [Required]
        public string sifre { get; set; }

        [Required]
        public string yetki { get; set; }

        [Required]
        public string fotograf   { get; set; }
    }
}