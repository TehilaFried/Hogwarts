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
                        Name = "בלונה הוגסמיד, כל אחד יכול למצוא את המתקנים שילהיבו אותו. באתר מגוון אטרקציות לילדים,נוער ולכל אוהבי האקסטרים",
                        Kind = 1,
                        Address = "https://i.ytimg.com/vi/3-81zUqPqE4/maxresdefault.jpg",
                        Age = 9,
                        DurationTime = 10,
                        TicketPrice = 90,
                        //Title
                    });
                    context.SaveChanges();
                }

                if (context.Atractions.Count() == 1)
                {
                    context.Add(new Atractions()
                    {
                        Name = "פונדק שלושת המטאטאים",
                        Kind = 1,
                        Address = "https://via-arkadia.co.il/wp-content/uploads/2016/01/NITHAN_THAI_007-839x391.jpg",
                        Age = 3,
                        DurationTime = 30,
                        TicketPrice = 80,
                        //Title
                    });
                    context.SaveChanges();
                }

                if (context.Atractions.Count() == 2)
                {
                    context.Add(new Atractions()
                    {
                        Name = "הגלידריה של פלוריאן פורטסקיו",
                        Kind = 1,
                        Address = "http://www.welovebrighton.com/wp-content/uploads/2014/07/gelato1.jpg",
                        Age = 0,
                        DurationTime = 0,
                        TicketPrice = 30,
                        //Title
                    });
                    context.SaveChanges();
                }

                if (context.Atractions.Count() == 3)
                {
                    context.Add(new Atractions()
                    {
                        Name = "חורשת ווילס ",
                        Kind = 1,
                        Address = "https://www.izikbi.com/files/catalog/item/thumbsrc/c5000/B0066748-B0066750-Pano-e%20copy.jpg",
                        Age = 0,
                        DurationTime = 0,
                        TicketPrice = 15,
                        //Title
                    });
                    context.SaveChanges();
                }

                if (context.Atractions.Count() == 4)
                {
                    context.Add(new Atractions()
                    {
                        Name = "האזור האסור- ספריה קסומה ",
                        Kind = 1,
                        Address = "https://cdn-image.travelandleisure.com/sites/default/files/styles/1600x1000/public/1476719873/Strahov-Monastery-LIBRARY1016.jpg?itok=njrX149R",
                        Age = 18,
                        DurationTime = 0,
                        TicketPrice = 60,
                        //Title
                    });
                    context.SaveChanges();
                }

                if (context.Atractions.Count() == 5)
                {
                    context.Add(new Atractions()
                    {
                        Name = "חנות ההוקוס מוקוס של האחים וויזלי ",
                        Kind = 1,
                        Address = "https://img.buzzfeed.com/buzzfeed-static/static/2014-06/21/9/enhanced/webdr09/original-grid-image-20405-1403358828-6.jpg?crop=990:655;0,2&downsize=400:*&output-format=auto&output-quality=auto",
                        Age = 0,
                        DurationTime = 0,
                        TicketPrice = 10,
                        //Title
                    });
                    context.SaveChanges();
                }

                if (context.Atractions.Count() == 6)
                {
                    context.Add(new Atractions()
                    {
                        Name = "האגם הגדול- צלילה חופשית ",
                        Kind = 1,
                        Address = "https://images.pottermore.com/bxd3o8b291gf/6iG89kbQNa8gCOckq2ocQa/cfa3133476d2d4f444752b293683c56b/HarryPotter_PM_B4C26M1_HarryInGreatLakeMerpeopleSecondTask_Moment.jpg?w=1200",
                        Age = 0,
                        DurationTime = 0,
                        TicketPrice = 10,
                        //Title
                    });
                    context.SaveChanges();
                }
            }





            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

    }
   

}

