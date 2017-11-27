using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace HamsterSqueaks.Server
{
    /// <summary>
    /// Main entry point of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point of the app.
        /// </summary>
        /// <param name="args">Arguments provided from Properties -> Debug -> Application Arguments.</param>
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">Arguments provided from Properties -> Debug -> Application Arguments.</param>
        /// <returns>The webhost serving the app.</returns>
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
