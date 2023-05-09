using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //İsimlendirmesi 
    //I : Interface olduğunu gösteriri
    //Product : Hangi nesnem ile ilgili olduğunu gösterir
    //Dal : ise hangi katman ile ilgili olduğunu gösterir. Data Access Layer
    //Veritabanında yapacağım operasyonları içeren interface
    //Operasyon : Güncelle,Sil,Ekle, Filtrele vs. 
    //Bu interface'i concrete klasöründe iş yapan sınıf haline getireceğiz.
    public interface IProductDal
    {
        //Product nesnemi liste şeklinde tümünü göster 
        List<Product> GetAll();
        void add(Product product);
        void Delete(Product product);
        void Update(Product product);
    }
}
