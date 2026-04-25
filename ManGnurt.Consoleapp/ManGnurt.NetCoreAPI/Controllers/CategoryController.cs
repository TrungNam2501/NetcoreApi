using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.ExceptionDatabase;
using ManGnurt.DataAccessNetcore.IServices;
using ManGnurt.DataAccessNetcore.RequestData;
using Microsoft.AspNetCore.Mvc;

namespace ManGnurt.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost("GetList")]
        public async Task<IActionResult> Category_GetList(Category_GetlistRequest requestData)
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

        [HttpPost("Insert")]
        public async Task<IActionResult> Category_Insert(Category_InsertRequestData requestData)
        {
            if (requestData == null)
                return BadRequest("Invalid request data.");

            try
            {
                var categoryEntity = new Category
                {
                    CategoryName = requestData.CategoryName,
                };

                var result = await _categoryRepository.Insert(categoryEntity);
                return Ok(new { Success = true, Data = result });
            }
            catch (CategoryException ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Category_Update(Category_UpdateRequestData requestData)
        {
            if (requestData == null || requestData.CategoryID <= 0)
                return BadRequest("Invalid request data.");

            try
            {
                var categoryEntity = new Category
                {
                    CategoryID = requestData.CategoryID,
                    CategoryName = requestData.CategoryName,
                };

                var result = await _categoryRepository.Update(categoryEntity);
                return Ok(new { Success = true, Data = result });
            }
            catch (CategoryException ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Category_Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Category ID.");

            try
            {
                await _categoryRepository.Delete(id);
                return Ok(new { Success = true, Message = "Category deleted successfully." });
            }
            catch (CategoryException ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }
    }
}
