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

namespace Byzantine.Core.Repository
{
    public class MuayeneUygulamaRepository : IMuayeneUygulamaRepository

    {
        private readonly Bee.Data.DataContext.BeeContext _context = new Bee.Data.DataContext.BeeContext();

        public void Say()
        {
            _context.MuayeneUygulama.Count();
        }

        public void Sil(int id)
        {
            var MuayeneUygulama = IDCek(id);
            if (MuayeneUygulama != null)
            {
                _context.MuayeneUygulama.Remove(MuayeneUygulama);
            }
        }

        public MuayeneUygulama KosulluTekDegerCek(Expression<Func<MuayeneUygulama, bool>> expression)
        {
            return _context.MuayeneUygulama.FirstOrDefault(expression);
        }

        public IEnumerable<MuayeneUygulama> TumunuCek()
        {
            return _context.MuayeneUygulama.Select(x => x);
        }

        public MuayeneUygulama IDCek(int id)
        {
            return _context.MuayeneUygulama.FirstOrDefault(x => x.Id== id);
        }

        public IQueryable<MuayeneUygulama> KosulluTumunuCek(Expression<Func<MuayeneUygulama, bool>> expresion)
        {
            return _context.MuayeneUygulama.Where(expresion);
        }

        public void Ekle(MuayeneUygulama obj)
        {
            _context.MuayeneUygulama.Add(obj);
        }

        public void Kaydet()
        {
            _context.SaveChanges();
        }

        public void Guncelle(MuayeneUygulama obj)
        {
            _context.MuayeneUygulama.AddOrUpdate(obj);
        }
    }
}

