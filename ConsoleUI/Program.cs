
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

//Solid
//Open Closed Principle : Yaptığın yazılıma yeni bir prensip ekliyorsan mevcuttaki hiçbir koduna dokunamazsın.

ProductTest();

//CategoryTest();


//OrderTest();
static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());

    foreach (var item in productManager.GetProductDetails())
    {
        Console.WriteLine(item.ProductName + "||" + item.CategoryName);
    }
}

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var item in categoryManager.GetAll())
    {
        Console.WriteLine(item.CategoryName);
    }
}

static void OrderTest()
{
    OrderManager orderManager = new OrderManager(new EfOrderDal());
    Console.WriteLine(orderManager.GetById(2).EmployeeId);
}