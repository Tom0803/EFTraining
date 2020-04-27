using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirst.Context;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace AppConsole.UseCases
{
    public class AddProduct2StationUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            string result = string.Empty;

            using (var context = CreateSession())
            {
                var products = await context.Set<Product>().ToListAsync();
                //
                // Access to shadow property
                //
                int? roundId = context.Entry(products.First()).Property<int?>("RoundId").CurrentValue;
                var stations = await context.Stations.Where(x => x.Round.Id == roundId).ToListAsync();

                int productCount = products.Count();

                for (int i = 0; i < productCount; i++)
                {
                    Station station = FindStation(stations, i);
                    products[i].Station = station;
                    products[i].StationId = station.Id;
                }

                context.UpdateRange(products);
                await context.SaveChangesAsync();

                result = string.Join("\n", products);
            }

            Console.WriteLine(result);

            return result;
        }

        private static Station FindStation(List<Station> stations, int i)
        {
            if (i <= 3) return stations[0];
            else if (i <= 6) return stations[1];
            else if (i <= 9) return stations[2];
            else if (i <= 12) return stations[3];
            else if (i <= 15) return stations[4];
            else return stations[5];
        }
    }
}