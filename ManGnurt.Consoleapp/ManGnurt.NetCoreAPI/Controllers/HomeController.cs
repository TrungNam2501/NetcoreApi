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
                var list = await _productServices.Product_Getlist(requestData);
                return Ok(list);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        } 
    }
}
