using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.ExceptionDatabase;
using ManGnurt.DataAccessNetcore.IServices;
using ManGnurt.DataAccessNetcore.RequestData;
using Microsoft.AspNetCore.Mvc;

namespace ManGnurt.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductGenericRepository _productGenericRepository;

        public ProductController(
            IProductRepository productRepository,
            IProductGenericRepository productGenericRepository)
        {
            _productRepository = productRepository;
            _productGenericRepository = productGenericRepository;
        }

        #region Product Repository (EF Core)

        [HttpPost("GetList")]
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

        [HttpPost("Insert")]
        public async Task<IActionResult> Product_Insert(Product_InsertRequestData requestData)
        {
            if (requestData == null)
                return BadRequest("Invalid request data.");

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

        [HttpPut("Update")]
        public async Task<IActionResult> Product_Update(Product_UpdateRequestData requestData)
        {
            if (requestData == null || requestData.ProductID <= 0)
                return BadRequest("Invalid request data.");

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

        [HttpDelete("Delete")]
        public async Task<IActionResult> Product_Delete([FromBody] Product_DeleteRequestData requestData)
        {
            if (requestData == null || requestData.ProductID <= 0)
                return BadRequest("Invalid request data.");

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

        #endregion

        #region Product Generic Repository

        [HttpPost("GenericRepository/GetList")]
        public async Task<IActionResult> Product_GetListGenericRepository(Product_GetListRequestData requestData)
        {
            try
            {
                var list = await _productGenericRepository.GetList(requestData);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("GenericRepository/Insert")]
        public async Task<IActionResult> Product_InsertGenericRepository(Product_InsertRequestData requestData)
        {
            if (requestData == null)
                return BadRequest("Invalid request data.");

            try
            {
                var productEntity = new Product
                {
                    ProductName = requestData.ProductName,
                    ProductPrice = requestData.ProductPrice,
                    ProductImage = requestData.ProductImage,
                    CategoryID = requestData.CategoryID
                };

                var result = await _productGenericRepository.Insert(productEntity);
                return Ok(new { Success = true, Data = result });
            }
            catch (ProductException ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }

        [HttpPut("GenericRepository/Update")]
        public async Task<IActionResult> Product_UpdateGenericRepository(Product_UpdateRequestData requestData)
        {
            if (requestData == null || requestData.ProductID <= 0)
                return BadRequest("Invalid request data.");

            try
            {
                var productEntity = new Product
                {
                    ProductID = requestData.ProductID,
                    ProductName = requestData.ProductName,
                    ProductPrice = requestData.ProductPrice,
                    ProductImage = requestData.ProductImage,
                    CategoryID = requestData.CategoryID
                };

                var result = await _productGenericRepository.Update(productEntity);
                return Ok(new { Success = true, Data = result });
            }
            catch (ProductException ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("GenericRepository/Delete/{id}")]
        public async Task<IActionResult> Product_DeleteGenericRepository(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Product ID.");

            try
            {
                await _productGenericRepository.Delete(id);
                return Ok(new { Success = true, Message = "Product deleted successfully." });
            }
            catch (ProductException ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }

        #endregion
    }
}
