using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainData.Models
{
    public class Merchandise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Detail { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string? Picture { get; set; }

        public void UpdateWith(Merchandise merchandise)
        {
            this.Name = merchandise.Name;
            this.Detail = merchandise.Detail;
            this.Quantity= merchandise.Quantity;
            this.Price= merchandise.Price;
            this.Picture = merchandise.Picture;
        }
    }
}
