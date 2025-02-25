namespace KattApp;

public partial class AddCatPage : ContentPage
{
	public AddCatPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await MainThread.InvokeOnMainThreadAsync(async () => { await LoadRecipes(); });
    }

    private async Task LoadRecipes()
    {

        //no code yet
    }
}