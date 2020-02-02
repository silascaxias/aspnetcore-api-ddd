using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
{
    public MyContext CreateDbContext(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Api.Application"))
            .AddJsonFile("appsettings.json")
            .Build();
            
        var builder = new DbContextOptionsBuilder<MyContext>();
        builder.UseSqlServer(configuration.GetConnectionString("Default"));
        return new MyContext(builder.Options);
    }
}
}