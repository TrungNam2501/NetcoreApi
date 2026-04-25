using System;
using System.Collections.Generic;
using System.Text;

namespace ManGnurt.DataAccessNetcore.ExceptionDatabase
{
    public class ProductException : BaseException
    {
        // Truyền mặc định lỗi Product là 400 (BadRequest)
        public ProductException(string message) : base($"[Product Error]: {message}", 400)
        {
        }

        // Bạn có thể tạo các static method để gọi nhanh
        public static void ThrowInvalidPrice() => throw new ProductException("Giá sản phẩm (ProductPrice) không hợp lệ.");
        public static void ThrowNotFound() => throw new ProductException("Sản phẩm không tồn tại.");
    }
}
