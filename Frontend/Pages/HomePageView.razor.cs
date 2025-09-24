using Patient_Portal.Core;

namespace Patient_Portal.Pages
{
    public partial class HomePageView
    {
        protected override async Task OnInitializedAsync()
        {
            await CheckAllowed(LocalStorage);

            if (!IsAllowed)
            {
                await Task.Delay(3000);
                NavigationManager.NavigateTo("/", false, true);
            }
        }
        private void SetActivePage(string page)
        {
            ActivePageService.ActivePage = page;
        }
    }
}
