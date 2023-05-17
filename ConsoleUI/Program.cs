
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//Solid
//Open Closed Principle : Yaptığın yazılıma yeni bir prensip ekliyorsan mevcuttaki hiçbir koduna dokunamazsın.
ProductManager productManager = new ProductManager(new EfProductDal());

foreach (var item in productManager.GetByUnitPrice(10,100))
{
    Console.WriteLine(item.ProductName + "||" + item.UnitPrice);
}