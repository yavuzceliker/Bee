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
    public class YeniIslemRepository : IYeniIslemRepository

    {
        private readonly Bee.Data.DataContext.BeeContext _context = new Bee.Data.DataContext.BeeContext();

        public void Say()
        {
            _context.YeniIslem.Count();
        }

        public void Sil(int id)
        {
            var YeniIslem = IDCek(id);
            if (YeniIslem != null)
            {
                _context.YeniIslem.Remove(YeniIslem);
            }
        }

        public YeniIslem KosulluTekDegerCek(Expression<Func<YeniIslem, bool>> expression)
        {
            return _context.YeniIslem.FirstOrDefault(expression);
        }

        public IEnumerable<YeniIslem> TumunuCek()
        {
            return _context.YeniIslem.Select(x => x);
        }

        public YeniIslem IDCek(int id)
        {
            return _context.YeniIslem.FirstOrDefault(x => x.id == id);
        }

        public IQueryable<YeniIslem> KosulluTumunuCek(Expression<Func<YeniIslem, bool>> expresion)
        {
            return _context.YeniIslem.Where(expresion);
        }

        public void Ekle(YeniIslem obj)
        {
            _context.YeniIslem.Add(obj);
        }

        public void Kaydet()
        {
            _context.SaveChanges();
        }

        public void Guncelle(YeniIslem obj)
        {
            _context.YeniIslem.AddOrUpdate(obj);
        }
    }
}

