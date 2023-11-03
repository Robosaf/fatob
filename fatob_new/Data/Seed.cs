using fatob_new.Models;

namespace fatob_new.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDataContext>();

                context.Database.EnsureCreated();

                if (!context.Travels.Any())
                {
                    context.AddRange(
                        new List<Travel>()
                        {
                            new Travel()
                            {
                                StartCity = "Warsaw",
                                EndCity = "Gdansk",
                                Bus = new Bus()
                                {
                                    RegisterNumber = "WA4453WW",
                                    Color = Enums.ColorEnum.Green
                                },
                                StartOfTravel = new DateTime(2023, 10, 11, 14, 30, 0),
                                EndOfTravel = new DateTime(2023, 10, 11, 19, 30, 0),
                                Cost = 120
                            },
                            new Travel()
                            {
                                StartCity = "Warsaw",
                                EndCity = "Krakow",
                                Bus = new Bus()
                                {
                                    RegisterNumber = "KR4563WW",
                                    Color = Enums.ColorEnum.Red
                                },
                                StartOfTravel = new DateTime(2023, 10, 11, 11, 30, 0),
                                EndOfTravel = new DateTime(2023, 10, 11, 16, 0, 0),
                                Cost = 80
                            },
                            new Travel()
                            {
                                StartCity = "Gdansk",
                                EndCity = "Warsaw",
                                Bus = new Bus()
                                {
                                    RegisterNumber = "WA4003WW",
                                    Color = Enums.ColorEnum.Green
                                },
                                StartOfTravel = new DateTime(2023, 10, 11, 10, 30, 0),
                                EndOfTravel = new DateTime(2023, 10, 11, 14, 30, 0),
                                Cost = 90
                            },
                        });
                    context.SaveChanges();
                }
                    
            }
        }


    }
}
