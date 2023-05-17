using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context nesnesi : Db tabloları ile proje classlarını ilişkilendirdiğimiz yer .
    //Bu classın ismini Context vermemiz context olduğu anlamına gelmez. Kurduğumuz entitiyframework paketi ile beraber gelen DbContext base sınıfını implemente etmemiz lazım
    public class NorthwindContext:DbContext
    {
        //override ile DbContex base classının içerisinde bulunan OnConfiguring metodunun içerisine kendi db'mizin adresini yazıyoruz.
        //OnConfiguring metoduu : Projen hangi veritabanı ile ilişkili ise onu belirttiğimiz yerdir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Sql server'a yani databasemize nasıl bağlanacağını belirtiyoruz. 
            //Databasemiz Northwind
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }
        // Hangi nesnemiz hangi nesneye karşılık geleceğini dolduracağız. Bunu da DbSet ile yapıyoruz.
        //DbSet içerisine bizim nesnemizi karşısına ise Veritabanı nesnesini yazıyoruz.
        //Yani Product bizim nesnemiz Products Northwind de olan tablo
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
