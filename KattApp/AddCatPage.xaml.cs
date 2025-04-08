namespace KattApp;
using System.Data.SQLite;
using KattApp.Mdoels;

public partial class AddCatPage : ContentPage
{

    int count = 0;

	public AddCatPage()
	{
		InitializeComponent();
	}


    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        var cat = new Cat
 {
     Name = NameEntry.Text,
     Race = RaceEntry.Text,
     Birthday = bDayEntry.Text,
     Food_type = fTypeEntry.Text,
     //Food_amount = int.Parse(fAmountEntry.Text),
     Weight = double.Parse(WeightEntry.Text),
     Comment = CommentEntry.Text
 };

 await App.Database.SaveCatAsync(cat);
 await DisplayAlert("Sparad", "Katten har sparats!", "OK");

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