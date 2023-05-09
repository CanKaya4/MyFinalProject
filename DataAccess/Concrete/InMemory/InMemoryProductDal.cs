using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    //İsimlendirme, hangi teknolojiyi kullanıyorsak onunla ilgili oluyor.
    //Bellekte çalışacağımız için InMemoryProductDal şeklinde isimlendirdim.
    //InMemoryProductDal, Abstract klasöründe oluşturduğumuz IProductDal interface'ini implemente eder ve 
    //IProductDal içerisinde bulunan operasyonları da InMemoryProductDal'a çeker.
    public class InMemoryProductDal : IProductDal
    {
        public void add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
