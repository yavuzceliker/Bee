using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bee.Data.Model
{
     [Table("MuayeneUygulama")]
    public class MuayeneUygulama
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MevcutDurumu { get; set; }

        [Required]
        public string MuayeneDurumu{ get; set; }

        [Required]
        public string UygulamaDurumu { get; set; }

        [Required]
        public string AnaDurumu { get; set; }

        [Required]
        public string BesinDurumu { get; set; }

        [Required]
        public int EksikCerceve { get; set; }

        [Required]
        public string AnaMemesi { get; set; }

        [Required]
        public string YalanciAna { get; set; }

        [Required]
        public string Ogul { get; set; }

        [Required]
        public string BalDurumu { get; set; }

        [Required]
        public string FizikselSorun { get; set; }

        [Required]
        public string Hastalik { get; set; }

        [Required]
        public string Parazit { get; set; }
            
        [Required]
        public string Zararli { get; set; }

        [Required]
        public int KoloniId { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        [Required]
        public string Saat { get; set; }

        [Required]
        public string CerceveAlma { get; set; }

        [Required]
        public string CerceveVerme { get; set; }

        [Required]
        public string Ilaclama { get; set; }

        [Required]
        public string FizikselOnarim { get; set; }

        [Required]
        public string BesinVerme { get; set; }

        [Required]
        public string Birlestirme { get; set; }

        [Required]
        public string Bolme { get; set; }

        [Required]
        public string BallikAlma { get; set; }

        [Required]
        public string BalHasadi { get; set; }




    }
}