using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BussinessAspects.Autofac;
using Core.Aspects.Autofac.Validation;
using Business.CCS;
using Core.Utilities.Bussiness;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class ProductManeger : IProductService
    {
        IProductDal _productDal; //Başka bir Dal injection edilemez kuraldır.
        ICategoryService _categoryService;

        public ProductManeger(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //Claim
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //Bir kategoride en fazla 10 ürün olabilir
            //Aynı isimde ürün eklemek yasak
            IResult result =BussinessRules.Run(CheckIfProductNameExist(product.ProductName),
                CheckIfProductCountOfCategory(product.CategoryId));

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.Productadded);
           
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //yetkisi var mı vs gibi sorgulamalar.
            //iş kodları geçtiyse

            //if (DateTime.Now.Hour==22)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategory(int categoryId)
        {
            var result =_productDal.GetAll(p=> p.CategoryId==categoryId).Count;
            if (result>=10)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result =_productDal.GetAll(p=> p.ProductName==productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }
    }
}
