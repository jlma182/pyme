using DomainData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Controllers
{
    public interface IOrderController
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddOrder(Order order);
    }
}
