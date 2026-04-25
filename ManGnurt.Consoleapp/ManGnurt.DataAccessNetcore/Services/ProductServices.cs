using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.Dbcontext;
using ManGnurt.DataAccessNetcore.Enums;
using ManGnurt.DataAccessNetcore.IServices;
using ManGnurt.DataAccessNetcore.RequestData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.Services
{
    public class ProductServices : IProductServices, IProductRepository
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

        //public  async Task<List<Product>> Product_Getlist_EfCore(Product_GetListRequestData requestData)
        //{
        //    var list = new List<Product>();
        //    try
        //    {
        //        list =  _dbContext.product.ToList();

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return list;

        //}
        public async Task<List<Product>> Product_Getlist_EfCore(Product_GetListRequestData requestData)
        {
            // 1. Khởi tạo danh sách rỗng
            var list = new List<Product>();
            try
            {
                // 2. Tạo Queryable
                var query = _dbContext.product.AsQueryable();

                if (requestData != null)
                {
                    if (requestData.ProductID.HasValue && requestData.ProductID.Value > 0)
                    {
                        query = query.Where(x => x.ProductID == requestData.ProductID.Value);
                    }
                    else if (requestData.ListProductID != null && requestData.ListProductID.Any(id => id > 0))
                    {
                        var validIds = requestData.ListProductID.Where(id => id > 0).ToList();
                        query = query.Where(x => validIds.Contains(x.ProductID));
                    }
                }

                // 3. Thực thi truy vấn và gán kết quả vào biến list
                list = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                // Bạn có thể xử lý log lỗi ở đây nếu cần trước khi throw
                throw;
            }

            // 4. Return biến list
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

        public async Task<ReturnData> Product_Update_EfCore(Product_UpdateRequestData requestData)
        {
            var returnData = new ReturnData();
            try 
            {
                if (requestData==null || requestData.ProductID <= 0)
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_ID_NOT_VALID;
                    returnData.ResponseMessage = "Product ID is not valid.";
                    return returnData;
                }
                var  product = await _dbContext.product.FindAsync(requestData.ProductID);
                if (product == null)
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_ID_NOT_VALID;
                    returnData.ResponseMessage = "Product ID is not valid.";
                    return returnData;
                }
                // cập nhật dữ liệu
                product.ProductName = requestData.ProductName;
                product.ProductImage = requestData.ProductImage;    
                product.ProductPrice = requestData.ProductPrice;
                product.CategoryID = requestData.CategoryID;
                var result =await _dbContext.SaveChangesAsync();
                if (result > 0)
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_INSERT_SUCCESS;
                    returnData.ResponseMessage = "Product update success";
                }
                else
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_ID_NOT_VALID;
                    returnData.ResponseMessage = "Product update failed";
                }
            }
            catch (Exception ex)
            {
                returnData.ResponseCode = (int)ProductManager_Status.EXCEPTION;
                returnData.ResponseMessage = "Hệ thống gặp lỗi: " + ex.Message;
            }
            return returnData;


        }
        public async Task<ReturnData> Product_Delete_EfCore(Product_DeleteRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                var product = await _dbContext.product.FindAsync(requestData.ProductID);
                if (product == null)
                {
                    returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_ID_NOT_VALID;
                    returnData.ResponseMessage = "Product ID is not valid.";
                    return returnData;
                }
                _dbContext.product.Remove(product);
                await _dbContext.SaveChangesAsync();
                returnData.ResponseCode = (int)ProductManager_Status.PRODUCT_INSERT_SUCCESS;
                returnData.ResponseMessage = "Product delete success";
                return returnData;

            }
            catch (Exception ex)
            {
                returnData.ResponseCode = (int)ProductManager_Status.EXCEPTION;
                returnData.ResponseMessage = "Hệ thống gặp lỗi: " + ex.Message;
                return returnData;
            }
        }
    }
}
