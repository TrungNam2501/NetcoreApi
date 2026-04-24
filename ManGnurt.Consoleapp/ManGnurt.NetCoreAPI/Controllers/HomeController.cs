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
        private readonly IProductServices _productServices;
        public HomeController(IProductServices productServices)
        {
            this._productServices = productServices;
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
    }
}
