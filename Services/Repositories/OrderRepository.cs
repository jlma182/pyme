using DomainData.Models;

namespace Services.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Order> GetOrders()
        {
            return _appDbContext.Orders;
        }

        public Order GetOrderById(int id)
        {
            return _appDbContext.Orders.FirstOrDefault(order => order.Id == id);
        }
        public Order AddOrder(Order order)
        {
            var orderAdded = _appDbContext.Orders.Add(order);

            _appDbContext.SaveChanges();
            return orderAdded.Entity;
        }
    }
}
