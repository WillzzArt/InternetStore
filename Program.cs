using InternetStoreTestTask.Data;
using InternetStoreTestTask.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


internal class Program
{
    private static async Task Main(string[] args)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();

        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<IConfiguration>(configuration);

        services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseNpgsql(configuration.GetConnectionString("Database")));

        services.AddScoped<IOrderRepository, OrderRepository>();

        var serviceProvider = services.BuildServiceProvider();



        var orderRepository = serviceProvider.GetRequiredService<IOrderRepository>();

        await orderRepository.SaveOrderFromXml("Order.xml");
    }
}
