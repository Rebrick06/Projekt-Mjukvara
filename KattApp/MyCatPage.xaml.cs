namespace KattApp;

public partial class MyCatPage : ContentPage
{
    public MyCatPage()
    {
        InitializeComponent();
    }
    private async void OnNavigateButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCatPage());
    }
}