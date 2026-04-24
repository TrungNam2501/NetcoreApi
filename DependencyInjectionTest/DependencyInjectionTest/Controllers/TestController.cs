using DependencyInjectionTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITransientService _transient1;
        private readonly ITransientService _transient2;
        private readonly IScopedService _scoped1;
        private readonly IScopedService _scoped2;
        private readonly ISingletonService _singleton1;
        private readonly ISingletonService _singleton2;

        // Constructor: Đã sửa IScapedService thành IScopedService
        public TestController(
            ITransientService transient1, ITransientService transient2,
            IScopedService scoped1, IScopedService scoped2, // Đảm bảo interface này khớp với file Services của bạn
            ISingletonService singleton1, ISingletonService singleton2)
        {
            _transient1 = transient1;
            _transient2 = transient2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                // Transient: Mỗi lần gọi là một ID mới
                Transient = new { Service1 = _transient1.GetOperationID(), Service2 = _transient2.GetOperationID() },

                // Scoped: Giống nhau trong cùng 1 request, đổi khi F5
                Scoped = new { Service1 = _scoped1.GetOperationID(), Service2 = _scoped2.GetOperationID() },

                // Singleton: Giống nhau mãi mãi cho đến khi restart app
                Singleton = new { Service1 = _singleton1.GetOperationID(), Service2 = _singleton2.GetOperationID() }
            });
        }
    }
}