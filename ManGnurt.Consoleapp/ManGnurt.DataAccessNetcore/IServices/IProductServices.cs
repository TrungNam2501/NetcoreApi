using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.RequestData;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.IServices
{
    public interface IProductServices
    {
        /// <summary>
        /// lấy dữ liệu theo kiểu ADO cũ
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<List<ProductDTO>> Product_Getlist(Product_GetListRequestData requestData);


        /// <summary>
        /// insert theo 2 kiểu , có comment ở ProductService
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<ReturnData> Product_Insert(Product_InsertRequestData requestData);


        /// <summary>
        /// lấy dữ liệu theo kiểu EF Core
        /// </summary>
        /// <param name="requestData"></param>
        /// <returns></returns>
        Task<List<Product>> Product_Getlist_EfCore(Product_GetListRequestData requestData);


        /// <summary>
        /// Cập nhật thông tin sản phẩm sử dụng EF Core
        /// </summary>
        Task<ReturnData> Product_Update_EfCore(Product_UpdateRequestData requestData);


        /// <summary>
        /// Xóa sản phẩm sử dụng EF Core
        /// </summary>
        Task<ReturnData> Product_Delete_EfCore(Product_DeleteRequestData requestData);

    }
}
