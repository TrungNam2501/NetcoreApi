using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.ExceptionDatabase;
using ManGnurt.DataAccessNetcore.IServices;
using ManGnurt.DataAccessNetcore.RequestData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManGnurt.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IProductRepository _productServices;
        private readonly IproductGenericRepository _productGenecricServices;
        private readonly IAccountRepository _accountRepository;
        private readonly ICategoryRepository _categoryRepository;


        public HomeController(IProductRepository productServices, IproductGenericRepository productGenecricServices, IAccountRepository _accountRepository, ICategoryRepository categoryRepository)
        {
            this._productServices = productServices;
            this._productGenecricServices = productGenecricServices;
            this._accountRepository = _accountRepository;
            this._categoryRepository = categoryRepository;
        }
        [HttpPost("Product_Getlist")]
        public async Task<IActionResult> Product_Getlist(Product_GetListRequestData requestData)
        {
            try
            {
                var list = await _productServices.Product_Getlist_EfCore(requestData);
                return Ok(list);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost("Product_Insert")]
        public async Task<IActionResult> Product_Insert(Product_InsertRequestData requestData)
        {
            try
            {
                var list = await _productServices.Product_Insert(requestData);
                return Ok(list);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut("Product_Update")]
        public async Task<IActionResult> Product_Update(Product_UpdateRequestData requestData)
        {
            // Gọi service xử lý logic EF Core bạn vừa viết
            var result = await _productServices.Product_Update_EfCore(requestData);

            if (result.ResponseCode > 0)
                return Ok(result);

            return BadRequest(result);
        }

        // --- API XÓA SẢN PHẨM ---
        [HttpDelete("Product_Delete")]
        public async Task<IActionResult> Product_Delete([FromBody] Product_DeleteRequestData requestData)
        {
            // Lưu ý: Với Delete dùng [FromBody] nếu bạn truyền Object trong Body
            var result = await _productServices.Product_Delete_EfCore(requestData);

            if (result.ResponseCode > 0)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost("Product_GetlistGenericRepository")]
        public async Task<IActionResult> Product_GetlistGenericRepository(Product_GetListRequestData requestData)
        {
            try
            {
                //var list = await _productServices.Product_Getlist_EfCore(requestData);
                var list = await _productGenecricServices.GetList(requestData);
                return Ok(list);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPost("Product_InsertGenericRepository")]
        public async Task<IActionResult> Product_InsertGenericRepository(Product_InsertRequestData requestData)
        {
            // Kiểm tra dữ liệu đầu vào cơ bản
            if (requestData == null) return BadRequest("Dữ liệu không hợp lệ.");

            try
            {
                // BƯỚC QUAN TRỌNG: Chuyển đổi từ RequestData sang Entity Product
                // Điều này giải quyết lỗi "cannot convert from RequestData to Product"
                var productEntity = new Product
                {
                    ProductName = requestData.ProductName,
                    ProductPrice = requestData.ProductPrice,
                    ProductImage = requestData.ProductImage,
                    CategoryID = requestData.CategoryID
                };

                // Gọi hàm Insert đã override. Lúc này logic bắt lỗi ProductName, ProductPrice... 
                // trong ProductGenericRepository sẽ được thực thi.
                var result = await _productGenecricServices.Insert(productEntity);

                return Ok(new { Success = true, Data = result });
            }
            catch (ProductException ex)
            {
                // Bắt lỗi riêng của Product mà bạn đã throw ở lớp Repository
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                // Bắt các lỗi hệ thống khác
                return StatusCode(500, new { Success = false, Message = "Lỗi hệ thống: " + ex.Message });
            }
        }

        [HttpPost("Account_InsertGenericRepository")]
        public async Task<IActionResult> Account_InsertGenericRepository(Account_InsertRequestData requestData)
        {
            // Kiểm tra dữ liệu đầu vào cơ bản
            if (requestData == null) return BadRequest("Dữ liệu không hợp lệ.");

            try
            {
                // BƯỚC QUAN TRỌNG: Chuyển đổi từ RequestData sang Entity Product
                // Điều này giải quyết lỗi "cannot convert from RequestData to Product"
                var productEntity = new Account
                {
                    UserName = requestData.UserName,
                    Password = requestData.Password,
                    Address = requestData.Address,
                   
                };

                // Gọi hàm Insert đã override. Lúc này logic bắt lỗi ProductName, ProductPrice... 
                // trong ProductGenericRepository sẽ được thực thi.
                var result = await _accountRepository.Insert(productEntity);

                return Ok(new { Success = true, Data = result });
            }
            catch (ProductException ex)
            {
                // Bắt lỗi riêng của Product mà bạn đã throw ở lớp Repository
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                // Bắt các lỗi hệ thống khác
                return StatusCode(500, new { Success = false, Message = "Lỗi hệ thống: " + ex.Message });
            }
        }

        [HttpPost("CategoryGenericRepository_Getlist")]
        public async Task<IActionResult> CategoryGenericRepository_Getlist(Category_GetlistRequest requestData)
        {
            try
            {
                var list = await _categoryRepository.GetList(requestData);
                return Ok(list);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }


    }
}
