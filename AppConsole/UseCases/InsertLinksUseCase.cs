using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirst.Context;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace AppConsole.UseCases
{
    public class InsertLinksUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            string result = string.Empty;            

            try
            {
                using (var context = CreateSession())
                {
                    bool wereLinksInjected = await context.StationAssemblyStep.AnyAsync();

                    if (wereLinksInjected)
                    {
                        result = "nothing injected";

                    }
                    else
                    {
                        await InsertPartsAsync(context);
                        await InsertStationAssemblyStepsAsync(context);

                        await context.SaveChangesAsync();
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }

            System.Console.WriteLine(result);

            return result;
        }


        private async Task InsertPartsAsync(AppDbContext context)
        {
            var products = await context.Products.Skip(17).Take(17).ToListAsync();
            var definitions = await context.PartDefinitions.ToListAsync();
            var list = new List<Part>();

            foreach (var product in products)
            {
                foreach (var partDefinition in definitions)
                {
                    list.Add(new Part
                    {
                        PartDefintion = partDefinition,
                        Product = product
                    });
                }
            }

            await context.AddRangeAsync(list);
        }

        private async Task InsertStationAssemblyStepsAsync(AppDbContext context)
        {
            var list = new List<StationAssemblyStep>();

            var stations = await context.Stations.ToListAsync();
            var steps = await context.AssemblySteps.ToListAsync();

            foreach (var station in stations)
            {
                int position = station.PositionAsInt();
                AssemblyStep step;

                switch (position)
                {
                    // Station 1-2: Bohren
                    // Station 3-5: Fügen
                    // Station 6:   Kleben
                    case 1: step = steps.FirstOrDefault(x => x.Name.Equals("Bohren", StringComparison.InvariantCultureIgnoreCase)); break;
                    case 2: goto case 1;
                    case 3: step = steps.FirstOrDefault(x => x.Name.Equals("Fügen", StringComparison.InvariantCultureIgnoreCase)); break;
                    case 4: goto case 3;
                    case 5: goto case 3;
                    case 6: step = steps.FirstOrDefault(x => x.Name.Equals("Kleben", StringComparison.InvariantCultureIgnoreCase)); break;
                    default:
                        step = steps.First();
                        break;
                }

                list.Add(new StationAssemblyStep
                {
                    Station = station,
                    AssemblyStep = step
                });
            }

            await context.AddRangeAsync(list);
        }
    }
}