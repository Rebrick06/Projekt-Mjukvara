namespace KattApp;

public partial class AddCatPage : ContentPage
{
	public AddCatPage()
	{
		InitializeComponent();
	}
    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        //går tillbacka till MyCatPage
        await Navigation.PushAsync(new MyCatPage());
    }
}