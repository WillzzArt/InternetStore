using InternetStoreTestTask.Helpers;
using InternetStoreTestTask.Models.StorageModels;
using InternetStoreTestTask.Models.XMLModels;
using Microsoft.EntityFrameworkCore;

namespace InternetStoreTestTask.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveOrderFromXml(string xmlPath)
        {
            var orders = XmlSerializerHelper.Deserialize<OrderRootXML>(xmlPath);
            if (orders == null) throw new NullReferenceException();

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                foreach (var order in orders.Orders.Where(o => o != null))
                {
                    var user =
                        await _context.User.FirstOrDefaultAsync(u => u.Email == order.User.Email)
                        ?? await SaveUser(order.User);

                    var products = new List<Product>();
                    var purchases = new List<Purchase>();

                    foreach (var product in order.Product)
                    {
                        var productDb =
                            await _context.Product.FirstOrDefaultAsync(p => p.Name == product.Name)
                            ?? await SaveProduct(product);

                        products.Add(productDb);
                        purchases.Add(await SavePurchase(productDb, product.Quantity));

                    }

                    var orderDb = new Order
                    {
                        Id = order.Id,
                        Price = order.Sum,
                        User = user,
                        Products = products,
                        Date = DateOnly.ParseExact(order.Date, "yyyy.MM.dd"),
                        Purchases = purchases
                    };

                    await _context.Order.AddAsync(orderDb);


                }

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        private async Task<User> SaveUser(UserXML user)
        {
            var userDb = new User
            {
                Email = user.Email,
                Fullname = user.FIO
            };

            await _context.User.AddAsync(userDb);

            return userDb;
        }

        private async Task<Product> SaveProduct(ProductXML product)
        {
            var productDb = new Product
            {
                Name = product.Name,
                Price = product.Price,
                Count = 500
            };


            await _context.Product.AddAsync(productDb);

            return productDb;
        }

        private async Task<Purchase> SavePurchase(Product product, int count)
        {
            var purchaseDb = new Purchase
            {
                Product = product,
                Count = count
            };

            await _context.Purchase.AddAsync(purchaseDb);

            return purchaseDb;
        }
    }
}