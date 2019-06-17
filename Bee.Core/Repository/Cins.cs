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
    public class CinsRepository : ICinsRepository

    {
        private readonly Bee.Data.DataContext.BeeContext _context = new Bee.Data.DataContext.BeeContext();

        public void Say()
        {
            _context.Cins.Count();
        }

        public void Sil(int id)
        {
            var Cins = IDCek(id);
            if (Cins != null)
            {
                _context.Cins.Remove(Cins);
            }
        }

        public Cins KosulluTekDegerCek(Expression<Func<Cins, bool>> expression)
        {
            return _context.Cins.FirstOrDefault(expression);
        }

        public IEnumerable<Cins> TumunuCek()
        {
            return _context.Cins.Select(x => x);
        }

        public Cins IDCek(int id)
        {
            return _context.Cins.FirstOrDefault(x => x.cinsId == id);
        }

        public IQueryable<Cins> KosulluTumunuCek(Expression<Func<Cins, bool>> expresion)
        {
            return _context.Cins.Where(expresion);
        }

        public void Ekle(Cins obj)
        {
            _context.Cins.Add(obj);
        }

        public void Kaydet()
        {
            _context.SaveChanges();
        }

        public void Guncelle(Cins obj)
        {
            _context.Cins.AddOrUpdate(obj);
        }
    }
}

