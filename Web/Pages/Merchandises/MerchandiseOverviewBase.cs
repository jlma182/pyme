using DomainData.Models;
using Microsoft.AspNetCore.Components;
using Services.Controllers;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;

namespace Web.Pages.Merchandises
{
    public class MerchandiseOverviewBase: ComponentBase
    {
        [Inject]
        public IMerchandiseController MerchandiseController { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<Merchandise> Merchandises { get; set; }

        public string Filter { get; set; }


        protected override void OnInitialized()
        {
            Merchandises = MerchandiseController.GetAllMerchandises().ToList();
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

        protected void NavigateToEdit()
        {
            NavigationManager.NavigateTo("/merchandise/edit");
        }


    }
}
