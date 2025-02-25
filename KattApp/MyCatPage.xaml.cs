namespace KattApp;

public partial class MyCatPage : ContentPage
{
    public MyCatPage()
    {
        InitializeComponent();
    }
    async void OnButtonClicked(object sender, EventArgs args)
    {
        await Navigation.PushAsync(new AddCatPage());
    }

}