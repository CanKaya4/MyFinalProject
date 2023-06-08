using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Product product)
        {
            if (product.ProductName.Length>2)
            {
                return new ErrorResult(Messages.ProductNameInValid);
            }
            _productDal.add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları

            //Eğer bunu yazarsan Business katmanı tamamen InMemory'e bağımlı olur ve gerçek bir veritabanına geçtiğinde tüm bu kodları değiştirmen gerekir.
            // Bir iş sınıfı başka sınıfları newlemez. Bunun yerine injection yapar Ör satır 13.
            // InMemoryProductDal ınMemoryProductDal = new InMemoryProductDal();
            return new DataResult(_productDal.GetAll());
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new DataResult(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new DataResult(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new DataResult(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new DataResult(_productDal.GetProductDetails());
        }
    }
}
