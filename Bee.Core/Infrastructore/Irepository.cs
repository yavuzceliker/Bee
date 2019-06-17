using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Core.Infrastructore
{
    public interface IRepository<T> where T : class
    {
        //Tüm Datamızı Çekiyor
        IEnumerable<T> TumunuCek();

        //Tek Data Döndürür
        T IDCek(int id);

        //Tek değer Expressiona Göre
        T KosulluTekDegerCek(Expression<Func<T, bool>> expression);

        //Expressiona Göre Çok Değer
        IQueryable<T> KosulluTumunuCek(Expression<Func<T, bool>> expresion);

        void Ekle(T obj);

        void Guncelle(T obj);

        void Sil(int id);

        void Say();

        void Kaydet();

    }
}
