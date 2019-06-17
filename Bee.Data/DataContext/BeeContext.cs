using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bee.Data.Model;
using System.Data.Entity;

namespace Bee.Data.DataContext
{
    public class BeeContext : DbContext
    {
        public DbSet<Koloni> Koloni { get;set; }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Uygulama> Uygulama { get; set; }
        public DbSet<DurumListesi> DurumListesi { get; set; }
        public DbSet<Muayene> Muayene { get; set; }
        public DbSet<YeniIslem> YeniIslem { get; set; }
        public DbSet<Cins> Cins { get; set; }

    }
}
