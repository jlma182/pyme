using DomainData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Controllers
{
    public interface IMerchandiseController
    {
        IEnumerable<Merchandise> GetAllMerchandises();
        Merchandise GetMerchandiseById(int id);
        void AddMerchandise(Merchandise merchandise);
        void UpdateMerchandise(Merchandise merchandise);
        void DeleteMerchandiseById(int id);
    }
}
