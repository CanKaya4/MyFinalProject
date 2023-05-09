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
        //InMemory(Bellekte) ürün varmış gibi çalışacağımız için burada bir ürün listesi oluşturuyoruz. Ctor ile bu projeyi başlatınca bellekte
        //bir tane ürün listesi oluşturacak
        //Bu List değişkenini Class'ın içerisinde metotların dışarısında tanımladığım için, Bu değişkenlere
        //Global değişkenler denir. Global değişkenler genellikle _ ile başlar.
        List<Product> _products;
        //Ctor : bellekte referans aldığı zaman çalışacak olan blok
        public InMemoryProductDal()
        {
            //Bu bilgiler bize Sql veya Oracle vs veritabanından geliyormuş gibi simüle ediyoruz.
            _products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15 },
                new Product{ProductId=2, CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3 },
                new Product{ProductId=3, CategoryId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2 },
                new Product{ProductId=4, CategoryId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65 },
                new Product{ProductId=5, CategoryId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1 },
            };
        }

        public void add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Bu şekilde yazarsan çalışmaz.
            //Çünkü arayüzden gönderdiğin product'ın bilgilerinin aynı olması önemli değil.
            //eşleşen id'leri bulup o referansı yakalamamız lazım
            //LİNQ dediğimiz bir sistem önümüze çıkıyor
            // Linq :  langue integrated query : Dile gömülü sorgulama
            //Linq ile bu liste bazlı yapıları, sql gibi filtreleyebiliyoruz.
            //Burada link kullanmadığımızı varsayalım.
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            //Linq kullanımı
            //SinleOrDefault : Tek bir eleman bulmaya yarar. Sizin yerinize ürünlere tek tek dolaşmaya yarar.
          Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //where : içindeki şarta uyan her elemanı yeni bir liste haline getirir ve onu döndürür.
           return _products.Where(p=>p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün Id'sine sahip olan listedeki ürünü bul demek.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            
        }
    }
}
