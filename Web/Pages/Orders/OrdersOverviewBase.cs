using Microsoft.AspNetCore.Components;
using Services.Controllers;
using DomainData.Models;

namespace Web.Pages.Orders
{
    public class OrdersOverviewBase: ComponentBase
    {
        [Inject]
        private IOrderController Controller { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }


        public List<Order> Orders { get; set; }
        public string Filter { get; set; }

        public bool IsVisible(Order order)
        {
            Console.WriteLine("enter");

            if (string.IsNullOrEmpty(Filter))
                return true;

            if (order.Invoice.Name.Contains(Filter, StringComparison.OrdinalIgnoreCase))
                return true;

            if (order.Invoice.Nit.ToString().StartsWith(Filter))
                return true;

            return false;
        }
        protected override void OnInitialized()
        {
            Orders = Controller.GetAllOrders().ToList();
            base.OnInitialized();
        }

        protected void NavigateToEdit()
        {
            NavigationManager.NavigateTo("/orders/edit");
        }
    }
}
