using System;
using System.Linq;
using System.Collections.Generic;
using AppConsole.UseCases;

namespace AppConsole
{
    class Program
    {
        static Program()
        {
            _map.Add("seed", new SeedUseCase());
            _map.Add("query", new QueryBasicUseCase());
            _map.Add("seed-links", new InsertLinksUseCase());
            _map.Add("read-stations", new ReadStationsUseCase());
            _map.Add("migrate", new MigrateUseCase());
            _map.Add("product2station", new AddProduct2StationUseCase());
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("--------------------------------------------");
            var key = string.Empty;

            if (args != null && args.Count() > 0)
                key = args.Last();

            try
            {
                if (_map.TryGetValue(key, out UseCase useCase))
                {
                    useCase.ExecuteAsync().Wait();
                }
                else
                {
                    System.Console.WriteLine($"Key {key} not found");
                    var keys = string.Join(", ", _map.Keys);
                    System.Console.WriteLine($"Try one of the following keys: {Environment.NewLine}{keys}");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.WriteLine($"Ran with key {key}");
            System.Console.WriteLine("--------------------------------------------");
        }
        private static Dictionary<string, UseCase> _map = new Dictionary<string, UseCase>();
    }
}
