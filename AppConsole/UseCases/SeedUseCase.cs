using System;
using System.Threading.Tasks;
using CodeFirst.Models;
using CodeFirst.Context;
using System.Collections.Generic;

namespace AppConsole.UseCases
{
    public class SeedUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            try
            {
                using (var context = base.CreateSession())
                {
                    DateTime start = DateTime.Now;
                    var round = await AddRoundAsync(context, start);
                    await AddStationsAsync(context, round);
                    await AddProductsAsync(context, round, start);
                    await AddAssemblyStepsAsync(context);
                    await AddPartDefinitionsAsync(context);

                    await context.SaveChangesAsync();
                    Console.WriteLine($"Roud.Id AFTER: [{round.Id}]");
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return "";
        }

        private Task AddPartDefinitionsAsync(AppDbContext context)
        {
            var items = new List<PartDefinition>()
            {
                new PartDefinition{ Name="0815", Cost=200},
                new PartDefinition{ Name="0816", Cost=300},
                new PartDefinition{ Name="0817", Cost=150}
            };

            return context.AddRangeAsync(items);
        }


        private Task AddAssemblyStepsAsync(AppDbContext context)
        {
            var items = new List<AssemblyStep>()
            {
                new AssemblyStep{ Name="Bohren", Cost=2},
                new AssemblyStep{ Name="Fügen", Cost=1},
                new AssemblyStep{ Name="Kleben", Cost=2}
            };

            return context.AddRangeAsync(items);
        }

        private Task AddProductsAsync(AppDbContext context, Round round, DateTime start)
        {
            var products = new List<Product>();
            var random = new Random();

            for (int i = 0; i < 50; i++)
            {
                int add = random.Next(0, 50);
                products.Add(new Product { Start = start.AddMinutes(add), Round = round });
            }

            return context.Products.AddRangeAsync(products);
        }

        private Task AddStationsAsync(AppDbContext context, Round round)
        {
            var stations = new List<Station>();

            for (int i = 1; i < 7; i++)
            {
                string name = $"Station_{i}";
                stations.Add(new Station { Position = name, Round = round });
            }

            return context.AddRangeAsync(stations);
        }

        private async Task<Round> AddRoundAsync(AppDbContext context, DateTime start)
        {
            var round = new Round { Start = start };
            Console.WriteLine($"Roud.Id BEFORE: [{round.Id}]");
            await context.Rounds.AddAsync(round);

            return round;
        }
    }
}