using System.Threading.Tasks;
using CodeFirst.Context;

namespace AppConsole.UseCases
{
    public abstract class UseCase
    {
        public abstract Task<string> ExecuteAsync();

        protected AppDbContext CreateSession() => new AppDbContext();
    }
}