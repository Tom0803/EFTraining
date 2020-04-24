using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirst.Context;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace AppConsole.UseCases
{
    public class ReadStationsUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            string result = string.Empty;

            try
            {
                using (var context = CreateSession())
                {
                    var list = await context.Stations.ToListAsync();
                    result = string.Join("\n", list);
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