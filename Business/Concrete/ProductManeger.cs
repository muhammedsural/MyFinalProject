using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManeger : IProductService
    {
        IProductDal _ProductDal;

        public ProductManeger(IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İş Kodları yazılır.
            //Yetkisi var mı?
            return _ProductDal.GetAll();
        }
    }
}
