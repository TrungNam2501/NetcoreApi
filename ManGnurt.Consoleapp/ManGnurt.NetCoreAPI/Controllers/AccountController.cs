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
    }
}
