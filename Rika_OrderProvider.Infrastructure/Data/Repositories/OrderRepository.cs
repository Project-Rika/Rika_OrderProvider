using Rika_OrderProvider.Infrastructure.Data.Contexts;
using Rika_OrderProvider.Infrastructure.Data.Entities;
namespace Rika_OrderProvider.Infrastructure.Data.Repositories;

public class OrderRepository(OrderDbContext dbContext) : BaseRepository<OrderEntity>(dbContext)
{

}
