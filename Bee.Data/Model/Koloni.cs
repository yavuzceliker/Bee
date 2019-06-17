using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Bee.Data.Model
{
    [Table("Koloni")]
    public class Koloni
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string kovanId { get; set; }

        [Required]
        public string yerGrupNo { get; set; }

        [Required]
        public int yerSiraNo { get; set; }

        [Required]
        public string anaCins { get; set; }

        [Required]
        public int anaYil { get; set; }

        [Required]
        public string kume { get; set; }

        public int sonBal { get; set; }

        public int puan { get; set; }










    }
}