using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace Patient_Portal.Core
{
    public partial class McComponentBase : ComponentBase
    {
        protected bool IsAllowed { get; set; }
        protected bool IsAuthCheckDone { get; set; }
        protected bool IsBusy { get; set; }

        protected override void OnInitialized()
        {
            GlobalData.RestoreUserData(LocalStorageSync, out var refresh);
            if(refresh)
                GlobalData.OnRefresh?.Invoke(this, EventArgs.Empty);
                //StateHasChanged();
        }
        public async Task CheckAllowed(ILocalStorageService localStorage)
        {
            if (await AuthenticationChecker.IsAuthenticated(localStorage))
            {
                IsAllowed = true;
            }
            else
            {
                IsAllowed = false;
            }

            IsAuthCheckDone = true;
        }

        public void SetBusy(bool isBusy, bool stateChanged = true)
        {
            IsBusy = isBusy;
            if(stateChanged)
                StateHasChanged();
        }
    }
}
