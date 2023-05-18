using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    //Eğer isimlendirmenin sonuna manager var ise, O Business katmanının iş sınıfıdır.
    public class ProductManager : IProductService
    {
        //Soyut nesne ile bağlantı kuracağız.
        //ctrl . ile generate constructor diyoruz.
        IProductDal _productDal;

        //Bu bir constructor
        //ProductManager newlendiğinde bana bir tane IProductDal referansı ver.
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İş kodları

            //Eğer bunu yazarsan Business katmanı tamamen InMemory'e bağımlı olur ve gerçek bir veritabanına geçtiğinde tüm bu kodları değiştirmen gerekir.
            // Bir iş sınıfı başka sınıfları newlemez. Bunun yerine injection yapar Ör satır 13.
            // InMemoryProductDal ınMemoryProductDal = new InMemoryProductDal();
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
