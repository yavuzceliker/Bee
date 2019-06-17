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
    public class UygulamaRepository : IUygulamaRepository

    {
        private readonly Bee.Data.DataContext.BeeContext _context = new Bee.Data.DataContext.BeeContext();

        public void Say()
        {
            _context.Uygulama.Count();
        }

        public void Sil(int id)
        {
            var Uygulama = IDCek(id);
            if (Uygulama != null)
            {
                _context.Uygulama.Remove(Uygulama);
            }
        }

        public Uygulama KosulluTekDegerCek(Expression<Func<Uygulama, bool>> expression)
        {
            return _context.Uygulama.FirstOrDefault(expression);
        }

        public IEnumerable<Uygulama> TumunuCek()
        {
            return _context.Uygulama.Select(x => x);
        }

        public Uygulama IDCek(int id)
        {
            return _context.Uygulama.FirstOrDefault(x => x.id == id);
        }

        public IQueryable<Uygulama> KosulluTumunuCek(Expression<Func<Uygulama, bool>> expresion)
        {
            return _context.Uygulama.Where(expresion);
        }

        public void Ekle(Uygulama obj)
        {
            _context.Uygulama.Add(obj);
        }

        public void Kaydet()
        {
            _context.SaveChanges();
        }

        public void Guncelle(Uygulama obj)
        {
            _context.Uygulama.AddOrUpdate(obj);
        }
    }
}

