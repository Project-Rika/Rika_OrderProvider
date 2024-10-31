using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rika_OrderProvider.Infrastructure.Data.Contexts;
using Rika_OrderProvider.Infrastructure.Data.Repositories;
using Rika_OrderProvider.Infrastructure.Services;
using Rika_OrderProvider.Infrastructure.Services.Interfaces;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices((context, services) =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(context.Configuration.GetConnectionString("RIKA_ORDER_DB")));
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<OrderRepository>();
        services.AddScoped<OrderAddressRepository>();
        services.AddScoped<OrderCustomerRepository>();
    })
    .Build();

host.Run();