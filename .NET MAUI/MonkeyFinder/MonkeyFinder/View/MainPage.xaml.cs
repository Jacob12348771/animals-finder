namespace MonkeyFinder.View;

public partial class MainPage : ContentPage
{
	public MainPage(MonkeysViewModel viewModel)
	{
		InitializeComponent();
        
        // View model used for the page.
		BindingContext = viewModel;
	}
}

