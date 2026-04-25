using ManGnurt.DataAccessNetcore.IServices;
using ManGnurt.DataAccessNetcore.RequestData;
using Microsoft.AspNetCore.Mvc;

namespace ManGnurt.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Obsolete("Use ProductController, AccountController, or CategoryController instead.")]
    public class HomeController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("Product_Getlist")]
        public async Task<IActionResult> Product_Getlist(Product_GetListRequestData requestData)
        {
            try
            {
                var list = await _productRepository.Product_Getlist_EfCore(requestData);
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
                var result = await _productRepository.Product_Insert(requestData);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Product_Update")]
        public async Task<IActionResult> Product_Update(Product_UpdateRequestData requestData)
        {
            try
            {
                var result = await _productRepository.Product_Update_EfCore(requestData);

                if (result.ResponseCode > 0)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("Product_Delete")]
        public async Task<IActionResult> Product_Delete([FromBody] Product_DeleteRequestData requestData)
        {
            try
            {
                var result = await _productRepository.Product_Delete_EfCore(requestData);

                if (result.ResponseCode > 0)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }
    }
}
