using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    IConfigurationRoot config = JsonConfigurationExtensions.AddJsonFile((IConfigurationBuilder)new ConfigurationBuilder(), "appsettings.json", false).Build();
                    string hostString = (string)ConfigurationBinder.GetValue<string>(config, "HOST");
                    if (!string.IsNullOrEmpty(hostString))
                    {
                        HostingAbstractionsWebHostBuilderExtensions.UseUrls(webBuilder, new string[1] { hostString });
                    }
                    WebHostBuilderExtensions.UseStartup<Startup>(webBuilder);
                });
    }
}
