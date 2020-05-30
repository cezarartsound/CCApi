using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using pt.portugal.eid;

namespace CCApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PTEID_ReaderSet.initSDK();

            CreateHostBuilder(args).Build().Run();

            PTEID_ReaderSet.releaseSDK();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseWindowsService();
    }
}
