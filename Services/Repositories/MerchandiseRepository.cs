using DomainData.Models;

namespace Services.Repositories
{
    public class MerchandiseRepository : IMerchandiseRepository
    {
        private readonly AppDbContext _appDbContext;

        public MerchandiseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Merchandise> GetAllMerchandises()
        {
            return _appDbContext.Merchandises;
        }

        public Merchandise GetMerchandiseById(int id)
        {
            return _appDbContext.Merchandises.FirstOrDefault(a => a.Id == id);

        }

        public Merchandise AddMerchandise(Merchandise merchandise)
        {
            var merchandiseAdded = _appDbContext.Merchandises.Add(merchandise);

            _appDbContext.SaveChanges();
            return merchandiseAdded.Entity;
        }

        public Merchandise UpdateMerchandise(Merchandise merchandise)
        {
            var merchandiseToUpdate = _appDbContext.Merchandises.FirstOrDefault(a => a.Id == merchandise.Id);

            if (merchandiseToUpdate != null)
            {
                merchandiseToUpdate.UpdateWith(merchandise);
            }

            _appDbContext.SaveChanges();

            return merchandiseToUpdate;
        }

        public void UpdateMerchandiseQuantities(ICollection<OrderDetail> orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                foreach (var merchadiseToUpdate in _appDbContext.Merchandises.Where(m => m.Id== orderDetail.MerchandiseId)) {
                    merchadiseToUpdate.Quantity -= orderDetail.Quantity;
                }
            }
            _appDbContext.SaveChanges();
        }


        public void DeleteMerchandiseById(int id)
        {
            var merchandiseToDelete = _appDbContext.Merchandises.FirstOrDefault(a => a.Id == id);

            if (merchandiseToDelete == null) return;

            _appDbContext.Merchandises.Remove(merchandiseToDelete);
            _appDbContext.SaveChanges();

        }

    }
}
