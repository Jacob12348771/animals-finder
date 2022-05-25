namespace MonkeyFinder.ViewModel;

public partial class BaseViewModel : ObservableObject
{
    public BaseViewModel()
    {
    }
    [ObservableProperty]
    [AlsoNotifyChangeFor(nameof(isNotBusy))]
    bool isBusy;

    [ObservableProperty]
    string title;

    public bool isNotBusy => isBusy;

}
