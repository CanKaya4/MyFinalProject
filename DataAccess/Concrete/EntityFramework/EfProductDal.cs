using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void add(Product entity)
        {
            //using : Bir class newlendiğinde garbage collector belli aralıklar ile düzenli olarak gelir ve bellekten newlenen classı atar.
            //using içerisine yazdığınız nesneler using bitince anında garbage collector'e gelir der ki beni bellekten at der. Çünkü Context nesnesi biraz pahalı bir nesnedir.
            //IDısposible pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())
            {
                //Referansı yakala
                var addedEntity = context.Entry(entity);
                //Yakaladığın referans eklenecek bir nesne
                addedEntity.State = EntityState.Added;
                //ve ekle
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
           using(NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using(NorthwindContext context = new NorthwindContext())
            {
                /*Eğer filter parametresi null ise, tüm ürünleri veritabanından alarak context.Set<Product>().ToList() ifadesini kullanır ve sonuç listesini döndürür.
                Eğer filter parametresi null değilse, context.Set<Product>().Where(filter) ifadesini kullanarak veritabanındaki ürünleri belirli bir filtre ile filtreler ve sonuç listesini döndürür. */
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
           using(NorthwindContext context = new NorthwindContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
