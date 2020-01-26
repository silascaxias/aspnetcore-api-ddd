using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            // Using to create Migrations
            var connectionString = "Server=localhost;Port=3306;Database=APIDatabase;Uid=root;Pwd=root";
            var optionBuilder = new DbContextOptionsBuilder<MyContext> ();
            optionBuilder.UseMySql (connectionString);
            return new MyContext (optionBuilder.Options);
        }
    }
}