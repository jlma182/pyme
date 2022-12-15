using DomainData.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting.Server;
using Services.Controllers;
using System.Diagnostics;

namespace Web.Pages.Merchandises
{
    public class MerchandiseEditBase : ComponentBase
    {

        [Inject]
        public IMerchandiseController MerchandiseController { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Merchandise Merchandise { get; set; } = new Merchandise();

        public IBrowserFile FormFile { get; set; }

        public string PictureDataUrl { get; set; }

        protected override void OnInitialized()
        {
            Merchandise = new Merchandise();
            base.OnInitialized();
        }

        protected async Task HandleValidSubmit()
        {

            Merchandise.Picture = SetImageName();
            MerchandiseController.AddMerchandise(Merchandise);

            await UploadFile(FormFile);

            NavigateToOverview();
        }

        protected string SetImageName()
        {
            var contentType = FormFile.ContentType.Split('/'); // kind of type / extension file
            var fileType = contentType[1];
            return $"{Guid.NewGuid()}.{fileType}";
        }


        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/merchandises");
        }

        protected void OnInputFileChanged (InputFileChangeEventArgs inputFileChangeEvent)
        {
            //var file = inputFileChangeEvent.File;
            //var buffer = new byte[file.Size];

            //await file.OpenReadStream().ReadAsync(buffer);

            //PictureDataUrl = $"data:image/png;base64,{Convert.ToBase64String(buffer)}";
            FormFile = inputFileChangeEvent.File;

        }

        public async Task<bool> UploadFile(IBrowserFile uFile)
        {
            if (uFile is not null && uFile.Size > 0)
            {
                var fileName = Merchandise.Picture;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\appImages", fileName);
                using var fileStream = new FileStream(filePath, FileMode.Create);

                await uFile.OpenReadStream().CopyToAsync(fileStream);
                return true;
            }
            return false;
        }
    }
}
