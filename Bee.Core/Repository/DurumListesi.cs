using Bee.Core.Infrastructore;
using Bee.Data.DataContext;
using Bee.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Core.Repository
{
    public class DurumListesiRepository : IDurumListesiRepository

    {
        private readonly Bee.Data.DataContext.BeeContext _context = new Bee.Data.DataContext.BeeContext();

        public void Say()
        {
            _context.DurumListesi.Count();
        }

        public void Sil(int id)
        {
            var DurumListesi = IDCek(id);
            if (DurumListesi != null)
            {
                _context.DurumListesi.Remove(DurumListesi);
            }
        }

        public DurumListesi KosulluTekDegerCek(Expression<Func<DurumListesi, bool>> expression)
        {
            return _context.DurumListesi.FirstOrDefault(expression);
        }

        public IEnumerable<DurumListesi> TumunuCek()
        {
            return _context.DurumListesi.Select(x => x);
        }

        public DurumListesi IDCek(int id)
        {
            return _context.DurumListesi.FirstOrDefault(x => x.id == id);
        }

        public IQueryable<DurumListesi> KosulluTumunuCek(Expression<Func<DurumListesi, bool>> expresion)
        {
            return _context.DurumListesi.Where(expresion);
        }

        public void Ekle(DurumListesi obj)
        {
            _context.DurumListesi.Add(obj);
        }

        public void Kaydet()
        {
            _context.SaveChanges();
        }

        public void Guncelle(DurumListesi obj)
        {
            _context.DurumListesi.AddOrUpdate(obj);
        }
    }
}

