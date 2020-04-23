using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppConsole.UseCases
{
    public class QueryBasicUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            try
            {
                using (var context = CreateSession())
                {
                    var first = await context.Products.FirstAsync();
                    Console.WriteLine(first.ToString());
                    return first.ToString();
                }
            }
            catch (System.Exception)
            {
                throw;
            }

            return "";
        }
    }
}