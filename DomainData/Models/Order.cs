using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainData.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();
        public Invoice Invoice { get; set; } = new();

    }
}
