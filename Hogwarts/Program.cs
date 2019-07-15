using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Hogwarts.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Hogwarts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                HogwartsContext context = services.GetRequiredService<HogwartsContext>();

                if (context.Atractions.Count() == 0)
                {
                    context.Add(new Atractions()
                    {
                        Name = "לונה הוגסמיד",
                        Kind = 1,
                        Address = "טבריה",



                    });
                    context.SaveChanges();
                }

            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

    }
   

}

