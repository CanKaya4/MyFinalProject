
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
    ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

    var result = productManager.GetProductDetails();
    if (result.Success == true)
    {
        foreach (var item in productManager.GetProductDetails().Data)
        {
            Console.WriteLine(item.ProductName + "||" + item.CategoryName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }


}

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
    foreach (var item in categoryManager.GetAll().Data)
    {
        Console.WriteLine(item.CategoryName);
    }
}

static void OrderTest()
{
    OrderManager orderManager = new OrderManager(new EfOrderDal());
    Console.WriteLine(orderManager.GetById(2).EmployeeId);
}