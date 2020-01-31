using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            // Using to create Migrations
            var connectionString = "Server=.\\SQLEXPRESS2020;Database=APIDatabase;Uid=sa;Pwd=root";
            var optionBuilder = new DbContextOptionsBuilder<MyContext> ();
            optionBuilder.UseSqlServer (connectionString);
            return new MyContext (optionBuilder.Options);
        }
    }
}