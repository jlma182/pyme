using DomainData.Models;
using Services.Repositories;

namespace Services.Controllers
{
    public class OrderController : IOrderController
    {
        private IOrderRepository Repository { get; set; }
        private IMerchandiseRepository MerchandiseRepository { get; set; }

        public OrderController(IOrderRepository repository, IMerchandiseRepository merchandiseRepository)
        {
            Repository = repository;
            MerchandiseRepository = merchandiseRepository;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return Repository.GetOrders();
        }
        public Order GetOrderById(int id)
        {
            return Repository.GetOrderById(id);
        }

        public void AddOrder(Order order)
        {
            Repository.AddOrder(order);

            MerchandiseRepository.UpdateMerchandiseQuantities(order.Details);

        }
    }
}
