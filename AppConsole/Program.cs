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
        }

        static void Main(string[] args)
        {
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
        }
        private static Dictionary<string, UseCase> _map = new Dictionary<string, UseCase>();
    }
}
