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

        /// <inheritdoc/>
        public async Task SaveOrderFromXml(string xmlPath)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(xmlPath, nameof(xmlPath));
            var orderRoot = XmlSerializerHelper.Deserialize<OrderRootXML>(xmlPath);
            if (orderRoot == null) throw new InvalidOperationException($"Can't read the file from {xmlPath}");


            foreach (var order in orderRoot.Orders)
            {
                var purchases = new List<Purchase>();

                foreach (var product in order.Product)
                {
                    var productDb = await _context.Product.FirstOrDefaultAsync(p => p.Name == product.Name);

                    if (productDb != null)
                        purchases.Add(await SavePurchase(productDb, product.Quantity));
                    else
                        throw new InvalidOperationException($"product not found: {product.Name}");

                }

                var user = await _context.User.FirstOrDefaultAsync(u => u.Email == order.User.Email);

                if (user == null) throw new InvalidOperationException($"user not found: {order.User.Email}");
                
                var orderDb = new Order
                {
                    Id = order.Id,
                    Price = order.Sum,
                    User = user,
                    Date = DateOnly.ParseExact(order.Date, "yyyy.MM.dd"),
                    Purchases = purchases
                };

                await _context.Order.AddAsync(orderDb);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Saves the Purchase entity
        /// </summary>
        /// <param name="product">Product model</param>
        /// <param name="count">Count of purchases</param>
        /// <returns></returns>
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