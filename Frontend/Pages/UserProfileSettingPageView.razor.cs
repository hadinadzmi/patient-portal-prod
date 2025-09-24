namespace Patient_Portal.Pages
{
    public partial class UserProfileSettingPageView
    {
        private void HandleLogout()
        {
            // Clear local storage/session (if using Blazored.LocalStorage or similar)
            // Example: await LocalStorage.ClearAsync(); // If you inject ILocalStorageService

            // Redirect to login page
            Navigation.NavigateTo("/login", forceLoad: true);
        }
    }
}
