namespace DomainData.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MerchandiseId { get; set; }
        public Merchandise Merchandise { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
