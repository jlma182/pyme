using DomainData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public interface IMerchandiseRepository
    {
        IEnumerable<Merchandise> GetAllMerchandises();
        Merchandise GetMerchandiseById(int id);
        Merchandise AddMerchandise(Merchandise merchandise);
        Merchandise UpdateMerchandise(Merchandise merchandise);
        void UpdateMerchandiseQuantities(ICollection<OrderDetail> orderDetails);
        void DeleteMerchandiseById(int id);
    }
}
