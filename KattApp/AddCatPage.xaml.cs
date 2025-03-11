namespace KattApp;

public partial class AddCatPage : ContentPage
{
	public AddCatPage()
	{
		InitializeComponent();
	}
    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
        
    }
}