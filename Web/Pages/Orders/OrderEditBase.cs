using DomainData.Models;
using Microsoft.AspNetCore.Components;
using Services.Controllers;

namespace Web.Pages.Orders
{
    public class OrderEditBase : ComponentBase
    {
        [Inject]
        public IMerchandiseController MerchandiseController { get; set; }

        [Inject]
        public IOrderController OrderController { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected List<Merchandise> Merchandises { get; set; }

        protected Order Order { get; set; }

        public string Filter { get; set; }


        protected override void OnInitialized()
        {
            Merchandises = MerchandiseController.GetAllMerchandises().ToList();
            Order = new Order();
            base.OnInitialized();
        }

        public bool IsVisible(Merchandise merchandise)
        {
            Console.WriteLine("enter");

            if (string.IsNullOrEmpty(Filter))
                return true;

            if (merchandise.Name.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                return true;

            if (merchandise.Id.ToString().StartsWith(Filter))
                return true;

            return false;
        }

        protected void HandleValidSubmit()
        {
            OrderController.AddOrder(Order);

            NavigateToOverview();
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/");
        }

        protected void AddProduct (Merchandise merchandise)
        {
            if (Order.Details.Count(o => o.MerchandiseId == merchandise.Id) >= 1)
                return;
            Order.Details.Add(new OrderDetail { MerchandiseId = merchandise.Id, Merchandise= merchandise, Quantity = 1 , Price = merchandise.Price});
        }

        protected void  IncrementQuantity(OrderDetail detail)
        {
            foreach (var selectedItem in Order.Details.Where(d => d.MerchandiseId == detail.MerchandiseId))
            {
                selectedItem.Quantity++;
            }
        }

        protected void DecrementQuantity(OrderDetail detail)
        {
            foreach (var selectedItem in Order.Details.Where(d => d.MerchandiseId == detail.MerchandiseId))
            {
                selectedItem.Quantity--;
            }
            var item = Order.Details.Where(d => d.MerchandiseId == detail.MerchandiseId && d.Quantity == 0).FirstOrDefault();
            Order.Details.Remove(item);


        }

    }
}
