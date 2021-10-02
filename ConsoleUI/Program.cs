using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        //SOLID
        //Open-Closed Principle
        static void Main(string[] args)
        {
            //IProductDal InMemoryProductDal ın referansını tuttuğu için çalışır. IProductDal ı inherit alan bütün yapılar çalışır.
            //ProductTest();
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManeger productManeger = new ProductManeger(new EfProductDal());

            foreach (var product in productManeger.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
