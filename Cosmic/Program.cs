using System.Threading.Tasks;

namespace Cosmic
{
    class Program
    {
        static Task<int> Main(string[] args)
        {
            return new Runtime().ExecuteAsync(args);
        }
    }
}
