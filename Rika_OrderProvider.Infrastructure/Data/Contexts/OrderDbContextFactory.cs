using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Rika_OrderProvider.Infrastructure.Data.Contexts;

public class OrderDbContextFactory : IDesignTimeDbContextFactory<OrderDbContext>
{
    public OrderDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();
        optionsBuilder.UseSqlServer("Server=tcp:rika-eh.database.windows.net,1433;Initial Catalog=rika-orderdb;Persist Security Info=False;User ID=rikaeh;Password=Bytmig123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        return new OrderDbContext(optionsBuilder.Options);
    }
}
