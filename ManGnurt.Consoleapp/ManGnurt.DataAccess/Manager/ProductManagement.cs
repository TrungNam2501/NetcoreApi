using ManGnurt.DataAccess.Class;
using ManGnurt.DataAccess.Interface;
using ManGnurt.DataAccess.RequestData;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGnurt.DataAccess.Manager
{
    public class ProductManagement : IProductManagement
    {
        public List<Product_GetListResponseData> Product_Getlist(Product_GetListRequestData requestData)
        {
            var list =new List<Product_GetListResponseData>();
            try
            {
                // Bước 1: Mở connection

                var connectionManager = new Connection.SqlConnectionDB_Genneric();
                var connection = connectionManager.DoConnect();

                //Bước 2: Tạo command

                var cmd = new SqlCommand("SP_Product_GetList", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // bước 2.1 : Thêm tham số
                cmd.Parameters.AddWithValue("@ProductID", requestData.ProductID);

                //Bước 3: Thực thi command
                var reader = cmd.ExecuteReader();

                //Bước 4: Đọc dữ liệu
                while (reader.Read())
                {
                    var product = new Product_GetListResponseData();
                    product.ProductID = reader["ProductID"] != DBNull.Value ? (int)reader["ProductID"] : 0;
                    product.ProductName = reader["ProductName"] != DBNull.Value ? (string)reader["ProductName"] : "";
                    product.CategoryName = reader["CategoryName"] != DBNull.Value ? (string)reader["CategoryName"] : ""; ;
                    list.Add(product);
                }

                //Bước 5: Đóng connection
                connection.Close();

                // Bước 6: Trả về dữ liệu
                return list;

            }
            catch(Exception e)
            {
                return list;
            }
 
        }

        public int Product_Insert(Product_InsertRequestData requestData)
        {
            var result = 0;
            try
            {
                // Bước 1: Mở connection

                var connectionManager = new Connection.SqlConnectionDB_Genneric();
                var connection = connectionManager.DoConnect();

                //Bước 2: Tạo command

                var cmd = new SqlCommand("SP_Product_Insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // bước 2.1 : Thêm tham số
                cmd.Parameters.AddWithValue("@ProductName", requestData.ProductName);
                cmd.Parameters.AddWithValue("@ProductImage", requestData.ProductImage);
                cmd.Parameters.AddWithValue("@ProductPrice", requestData.ProductPrice);
                cmd.Parameters.AddWithValue("@CategoryID", requestData.CategoryID);

                //Bước 3: Thực thi command
                var rowOfAffect = cmd.ExecuteNonQuery();

                //Bước 5: Đóng connection
                connection.Close();

                return rowOfAffect;


            }
            catch (Exception e)
            {
                return result;

            }
          
        }
    }
}
