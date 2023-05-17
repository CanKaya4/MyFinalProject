using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //T'yi sınırlayacağız buna Generic Constraint denir : Generic Kısıt
    //T olarak Veritabanı nesnelerim gelmeli, Örn : Customer, Product veya Category
    // class yazmamızın sebebi ; referans tip olabilir şeklindedir.
    //IEntity : IEntity olabilir veya IEntitiy implemente eden class olabilir
    //new() : newlenebilir olmalı
    public interface IEntityRepository<T> where T : class, IEntity,new()
    {
        //IProductDal veya ICategorydal sınıflarını ve ileride de ekleyeceğim Employee, Customer vs gibi yapıları
        //Tek tek yazmak yerine bunun için generic bir interface oluşturdu,
        //IEntityRepository isminde.
        //Entity yerine ne kullanıyorsak o gelcek örn: ICustomerRepository veya IProductRepository gibi

        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
