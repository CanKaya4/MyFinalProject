using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInValid = "Ürün İsmi Geçersiz.";
        public static string MaintenanceTime = "Sistem Bakım Saati.";
        public static string ProductsListed = "Ürünler Listelendi.";
        public static string ProductsGetByCategoryListed = "Ürünler Kategorilere Göre Listelendi.";
        public static string ProductGetByIdListed = "Ürünler Id Numarlarına Göre Listelendi";
        public static string ProductGetByUnitPriceListed = "Ürünler Fiyatlara Göre Listelendi";
        public static string ProductGetProductDetails = "Ürününün detayı listelendi.";
        public static string ProductCountofCategoryError = "Bir kategoride en fazla 10 adet ürün olabilir";
        public static string ProductNameAlreadyExits = "Bu isimde zaten başka bir ürün var.";
        public static string CategoryLimitExceded = "Kategori Limiti Aşıldı";
    }
}
