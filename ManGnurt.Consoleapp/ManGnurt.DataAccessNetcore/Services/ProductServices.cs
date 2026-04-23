using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.IServices;
using ManGnurt.DataAccessNetcore.RequestData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.Services
{
    public class ProductServices : IProductServices
    {
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
        public async Task<int> Product_Insert(Product_InsertRequestData requestData)
        {
            throw new NotImplementedException();
        }
    }
}
