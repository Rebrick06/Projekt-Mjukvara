namespace KattApp;

public partial class AddCatPage : ContentPage
{
    int count = 0;
	public AddCatPage()
	{
		InitializeComponent();
	}
    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        //går tilbacka till my cats
        await Navigation.PopAsync();
    }

    private void OnAddFood(object sender, EventArgs e)
    {
        count++;
        if (count <= 0) { count = 0; }
        AmountFood.Text = $"{count.ToString()}    g";
    }

    private void OnRemoveFood(object sender, EventArgs e)
    {
        count--;
        if (count <= 0) { count = 0; }
        AmountFood.Text = $"{count.ToString()}    g";
    }
}