public class ActivePageService
{
    public event Action OnChange;
    private string _activePage = "Home";

    public string ActivePage
    {
        get => _activePage;
        set
        {
            if (_activePage != value)
            {
                _activePage = value;
                NotifyStateChanged();
            }
        }
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
