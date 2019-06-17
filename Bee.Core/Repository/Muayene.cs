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
    public class MuayeneRepository : IMuayeneRepository

    {
        private readonly Bee.Data.DataContext.BeeContext _context = new Bee.Data.DataContext.BeeContext();

        public void Say()
        {
            _context.Muayene.Count();
        }

        public void Sil(int id)
        {
            var Muayene = IDCek(id);
            if (Muayene != null)
            {
                _context.Muayene.Remove(Muayene);
            }
        }

        public Muayene KosulluTekDegerCek(Expression<Func<Muayene, bool>> expression)
        {
            return _context.Muayene.FirstOrDefault(expression);
        }

        public IEnumerable<Muayene> TumunuCek()
        {
            return _context.Muayene.Select(x => x);
        }

        public Muayene IDCek(int id)
        {
            return _context.Muayene.FirstOrDefault(x => x.id == id);
        }

        public IQueryable<Muayene> KosulluTumunuCek(Expression<Func<Muayene, bool>> expresion)
        {
            return _context.Muayene.Where(expresion);
        }

        public void Ekle(Muayene obj)
        {
            _context.Muayene.Add(obj);
        }

        public void Kaydet()
        {
            _context.SaveChanges();
        }

        public void Guncelle(Muayene obj)
        {
            _context.Muayene.AddOrUpdate(obj);
        }
    }
}

