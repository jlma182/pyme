using DomainData.Models;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Controllers
{
    public class MerchandiseController : IMerchandiseController
    {
        public IMerchandiseRepository  Repository { get; set; }

        public MerchandiseController(IMerchandiseRepository repository)
        {
            Repository = repository;
        }

        public IEnumerable<Merchandise> GetAllMerchandises()
        {
            return Repository.GetAllMerchandises();
        }

        public Merchandise GetMerchandiseById(int id)
        {
            return Repository.GetMerchandiseById(id);
        }

        public void AddMerchandise(Merchandise merchandise)
        {
            Repository.AddMerchandise(merchandise);
        }

        public void UpdateMerchandise(Merchandise merchandise)
        {
            Repository.UpdateMerchandise(merchandise);
        }

        public void DeleteMerchandiseById(int id)
        {
            Repository.DeleteMerchandiseById(id);
        }

    }
}
