using Rika_OrderProvider.Infrastructure.Data.Contexts;
using Rika_OrderProvider.Infrastructure.Data.Entities;
namespace Rika_OrderProvider.Infrastructure.Data.Repositories;

public class OrderProductRepository(OrderDbContext dbContext) : BaseRepository<OrderProductEntity>(dbContext)
{

}
