using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Bee.Data.Model
{
    [Table("YeniIslem")]
    public class YeniIslem
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string islemKovanId { get; set; }

        [Required]
        public string isleminAdi { get; set; }

        [Required]
        public string islemKategori { get; set; }

        [Required]
        public string eklenmeTarihi { get; set; }


    }
}