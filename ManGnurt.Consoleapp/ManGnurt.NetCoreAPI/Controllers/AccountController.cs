using ManGnurt.DataAccessNetcore.DataObject;
using ManGnurt.DataAccessNetcore.ExceptionDatabase;
using ManGnurt.DataAccessNetcore.IServices;
using ManGnurt.DataAccessNetcore.RequestData;
using Microsoft.AspNetCore.Mvc;

namespace ManGnurt.NetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("GetList")]
        public async Task<IActionResult> Account_GetList(Account_GetListRequestData requestData)
        {
            try
            {
                var list = await _accountRepository.GetList(requestData);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Account_Insert(Account_InsertRequestData requestData)
        {
            if (requestData == null)
                return BadRequest("Invalid request data.");

            try
            {
                var accountEntity = new Account
                {
                    UserName = requestData.UserName,
                    Password = requestData.Password,
                    Address = requestData.Address,
                };

                var result = await _accountRepository.Insert(accountEntity);
                return Ok(new { Success = true, Data = result });
            }
            catch (AccountException ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Account_Update(Account_UpdateRequestData requestData)
        {
            if (requestData == null || requestData.AccountID <= 0)
                return BadRequest("Invalid request data.");

            try
            {
                var accountEntity = new Account
                {
                    AccountID = requestData.AccountID,
                    UserName = requestData.UserName,
                    Password = requestData.Password,
                    Address = requestData.Address,
                };

                var result = await _accountRepository.Update(accountEntity);
                return Ok(new { Success = true, Data = result });
            }
            catch (AccountException ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = ex.Message });
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Account_Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Account ID.");

            try
            {
                await _accountRepository.Delete(id);
                return Ok(new { Success = true, Message = "Account deleted successfully." });
            }
            catch (AccountException ex)
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
