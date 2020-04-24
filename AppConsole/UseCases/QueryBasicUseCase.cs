using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppConsole.UseCases
{
    public class QueryBasicUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            string result = string.Empty;

            try
            {
                using (var context = CreateSession())
                {
                    // var first = await context.Products.Include(p => p.Round)
                    //                                     .ThenInclude(r => r.Stations)
                    //                                     .Include("Round.Products")
                    //                                     .FirstOrDefaultAsync();
                    // Console.WriteLine(first.ToString());
                    // result = first.ToString();

                    var rounds = await context.Rounds.Include(r => r.Products)
                                                    .Include(r => r.Stations)
                                                    .AsNoTracking()
                                                    .ToListAsync();

                    var product = rounds.SelectMany(r => r.Products).First();
                    result = product.ToString();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            
            System.Console.WriteLine(result);

            return result;
        }
    }
}