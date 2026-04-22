namespace ManGnurt.NetCoreAPI.MiddleWare
{
    public class MyMiddleware
    {
        private  readonly RequestDelegate _next;
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public  Task Invoke(HttpContext httpContext)
        {
         
            httpContext.Response.Headers.Add("X-My-Custom-Header", "This is a custom header added by MyMiddleware");
            httpContext.Response.Headers.Add("X-Request-Received-Time", DateTime.UtcNow.ToString("o"));
            return _next(httpContext);
            
        }
    }
}
