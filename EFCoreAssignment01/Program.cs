using EFCoreAssignment01.DbContexts;

namespace EFCoreAssignment01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using ItiDbContext dbContext = new ItiDbContext();
        }
    }
}
