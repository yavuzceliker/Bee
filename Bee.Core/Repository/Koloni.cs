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
    public class KoloniRepository : IKoloniRepository

    {
        private readonly Bee.Data.DataContext.BeeContext _context = new Bee.Data.DataContext.BeeContext();

        public void Say()
        {
            _context.Koloni.Count();
        }

        public void Sil(int id)
        {
            var Koloni = IDCek(id);
            if (Koloni != null)
            {
                _context.Koloni.Remove(Koloni);
            }
        }

        public Koloni KosulluTekDegerCek(Expression<Func<Koloni, bool>> expression)
        {
            return _context.Koloni.FirstOrDefault(expression);
        }

        public IEnumerable<Koloni> TumunuCek()
        {
            return _context.Koloni.Select(x => x);
        }

        public Koloni IDCek(int id)
        {
            return _context.Koloni.FirstOrDefault(x => x.id == id);
        }

        public IQueryable<Koloni> KosulluTumunuCek(Expression<Func<Koloni, bool>> expresion)
        {
            return _context.Koloni.Where(expresion);
        }

        public void Ekle(Koloni obj)
        {
            _context.Koloni.Add(obj);
        }

        public void Kaydet()
        {
            _context.SaveChanges();
        }

        public void Guncelle(Koloni obj)
        {
            _context.Koloni.AddOrUpdate(obj);
        }
    }
}

