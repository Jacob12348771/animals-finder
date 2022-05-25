using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService monkeyService;
    
    // Observable collection raises the change notification.
    public ObservableCollection<Monkey> Monkeys { get; } = new ObservableCollection<Monkey>();
    public MonkeysViewModel(MonkeyService monkeyService)
    {
        Title = "Monkey Finder";
        this.monkeyService = monkeyService;
    }
    [ICommand]
    async Task GoToDetailsAsync(Monkey monkey)
    {
        if (monkey is null)
            return;

        // Key value pair for monkey.
        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
            new Dictionary<string, object>
            {
                {"Monkey", monkey}
            });
    }
    
    [ICommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy)
        {
            return;
        }
        try
        {
            IsBusy = true;
            
            // Allowing monkeys to be obtained asynchronously.
            var monkeys = await monkeyService.GetMonkeys();
            
            if (Monkeys.Count != 0)
            {
                Monkeys.Clear();
            }
            
            foreach (var monkey in monkeys)
            {
                Monkeys.Add(monkey);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error", "Unable to load monkeys.", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
