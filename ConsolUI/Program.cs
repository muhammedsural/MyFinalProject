using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManeger productManeger = new ProductManeger(new InMemoryProductDal());

            foreach (var item in productManeger.GetAll())
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
