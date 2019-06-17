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
    public class KullaniciRepository : IKullaniciRepository

    {
        private readonly Bee.Data.DataContext.BeeContext _context = new Bee.Data.DataContext.BeeContext();

        public void Say()
        {
            _context.Kullanici.Count();
        }

        public void Sil(int id)
        {
            var Kullanici = IDCek(id);
            if (Kullanici != null)
            {
                _context.Kullanici.Remove(Kullanici);
            }
        }

        public Kullanici KosulluTekDegerCek(Expression<Func<Kullanici, bool>> expression)
        {
            return _context.Kullanici.FirstOrDefault(expression);
        }

        public IEnumerable<Kullanici> TumunuCek()
        {
            return _context.Kullanici.Select(x => x);
        }

        public Kullanici IDCek(int id)
        {
            return _context.Kullanici.FirstOrDefault(x => x.id == id);
        }

        public IQueryable<Kullanici> KosulluTumunuCek(Expression<Func<Kullanici, bool>> expresion)
        {
            return _context.Kullanici.Where(expresion);
        }

        public void Ekle(Kullanici obj)
        {
            _context.Kullanici.Add(obj);
        }

        public void Kaydet()
        {
            _context.SaveChanges();
        }

        public void Guncelle(Kullanici obj)
        {
            _context.Kullanici.AddOrUpdate(obj);
        }
    }
}

