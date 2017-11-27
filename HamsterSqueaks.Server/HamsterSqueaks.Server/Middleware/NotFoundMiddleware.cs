using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace HamsterSqueaks.Middleware
{
    /// <summary>
    /// Sets all 404 requests to 200 to make sure Angular does not break. Angular takes care of 404s.
    /// </summary>
    public class NotFoundMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IHostingEnvironment env;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="next"></param>
        /// <param name="env"></param>
        public NotFoundMiddleware(RequestDelegate next, IHostingEnvironment env)
        {
            this.next = next;
            this.env = env;
        }

        /// <summary>
        /// Invokes the middleware logic.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            // Code taken from https://dustinewers.com/angular-cli-with-net-core/
            await next(context);
            if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("api") && !context.Request.Path.Value.StartsWith("account"))
            {
                context.Request.Path = "/Index.html";
                context.Response.StatusCode = 200;
                await next(context);
            }
        }
    }
}
