using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void add(TEntity entity)
        {
            //using : Bir class newlendiğinde garbage collector belli aralıklar ile düzenli olarak gelir ve bellekten newlenen classı atar.
            //using içerisine yazdığınız nesneler using bitince anında garbage collector'e gelir der ki beni bellekten at der. Çünkü Context nesnesi biraz pahalı bir nesnedir.
            //IDısposible pattern implementation of c#
            using (TContext context = new TContext())
            {
                //Referansı yakala
                var addedEntity = context.Entry(entity);
                //Yakaladığın referans eklenecek bir nesne
                addedEntity.State = EntityState.Added;
                //ve ekle
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                /*Eğer filter parametresi null ise, tüm ürünleri veritabanından alarak context.Set<Product>().ToList() ifadesini kullanır ve sonuç listesini döndürür.
                Eğer filter parametresi null değilse, context.Set<Product>().Where(filter) ifadesini kullanarak veritabanındaki ürünleri belirli bir filtre ile filtreler ve sonuç listesini döndürür. */
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
