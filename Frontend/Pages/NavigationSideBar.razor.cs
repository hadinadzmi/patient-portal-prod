using Patient_Portal.Core;

namespace Patient_Portal.Pages
{
    public partial class NavigationSideBar
    {
        private void SetActivePage(string page)
        {
            ActivePageService.ActivePage = page;
        }
        protected override async Task OnInitializedAsync()
        {
            //if (TestGlobals.FakeLogin)
            //{
            //    IsAllowed = true;
            //    return;
            //}

            await CheckAllowed(LocalStorage);

            if (!IsAllowed)
            {
                await Task.Delay(3000);
                NavigationManager.NavigateTo("/", false, true);
            }
        }
        protected override void OnInitialized()
        {
            ActivePageService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            ActivePageService.OnChange -= StateHasChanged;
        }
    }
}
