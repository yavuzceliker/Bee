using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bee.Data.Model    
{
    [Table("Cins")]
    public class Cins
    {
        [Key]
        public int cinsId { get; set; }

        public string cinsAdi { get; set; }
    }
}
