using InternetStoreTestTask.Data;
using InternetStoreTestTask.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


internal class Program
{
    private static async Task Main(string[] args)
    {
        var serviceProvider = ConfigureServices();

        var orderRepository = serviceProvider.GetRequiredService<IOrderRepository>();

        await orderRepository.SaveOrderFromXml("Order.xml");
    }

    /// <summary>
    /// Configures services
    /// </summary>
    /// <returns>service provider</returns>
    private static IServiceProvider ConfigureServices()
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        IServiceCollection services = new ServiceCollection();

        services.AddSingleton<IConfiguration>(configuration);

        services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseNpgsql(configuration.GetConnectionString("Database")));

        services.AddScoped<IOrderRepository, OrderRepository>();

        return services.BuildServiceProvider();
    }
}
