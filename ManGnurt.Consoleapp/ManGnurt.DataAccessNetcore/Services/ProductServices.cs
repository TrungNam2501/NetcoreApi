using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.Dbcontext;
using ManGnurt.DataAccessNetcore.Enums;
using ManGnurt.DataAccessNetcore.IServices;
using ManGnurt.DataAccessNetcore.RequestData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ManGnurtDbContext _dbContext;
        public ProductServices(ManGnurtDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ProductDTO>> Product_Getlist(Product_GetListRequestData requestData)
        {
            var list = new List<ProductDTO>();
            try { 
                await Task.Yield(); // Simulate async database call

                for (int i = 0; i < 10; i++)
                {
                    list.Add(new ProductDTO
                    {
                        ProductID = i,
                        ProductName = $"Product {i}",
                        ProductImage = $"https://example.com/product{i}.jpg",
                        CategoryID = i % 3,
                        CategoryName = $"Category {i % 3}"
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public  async Task<List<Product>> Product_Getlist_EfCore(Product_GetListRequestData requestData)
        {
            var list = new List<Product>();
            try
            {
                list =  _dbContext.product.ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;

        }

        public async  Task<ReturnData> Product_Insert(Product_InsertRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                // kiểm tra dữ liệu đầu vào
                if (string.IsNullOrEmpty(requestData.ProductName))
                {
                   returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                   returnData.ResponseMessage = "Product name is not valid.";

                    return returnData;
                }
                if(requestData.ProductName.Length > 200)
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Product name is not valid.";
                    return returnData;
                }
                //kiểm tra XXS
                if (!ManGnurt.CommonNetcore.Sercurity.IsSafeFromXSS(requestData.ProductName))
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Product name is not valid.";
                    return returnData;
                }

                //kiểm tra trùng dữ liệu
                // cách 1: sử dụng Any() để kiểm tra trùng dữ liệu
                var isDuplicate = _dbContext.product.Any(p => p.ProductName == requestData.ProductName);


                // cách 2: sử dụng ToList() để lấy tất cả dữ liệu và kiểm tra trùng dữ liệu
                //var isDuplicate = false;
                //var list = _dbContext.product.ToList();
                //if (list.Count>0)
                //{
                //    foreach(var item in list)
                //    {
                //        if (item.ProductName == requestData.ProductName)
                //        {
                //            isDuplicate = true;
                //            break;
                //        }
                //    }

                //}

                if (isDuplicate)
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_NAME_NOT_VALID;
                    returnData.ResponseMessage = "Product name is duplicate";
                    return returnData;
                }
                // thêm dữ liệu vào database
                var product = new Product
                {
                    ProductName = requestData.ProductName,
                    ProductImage = requestData.ProductImage,
                    ProductPrice = requestData.ProductPrice,
                    CategoryID = requestData.CategoryID =1
                };
                _dbContext.product.Add(product);
                _dbContext.SaveChanges();
                returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_INSERT_SUCCESS;
                returnData.ResponseMessage = "Product insert success";
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}
