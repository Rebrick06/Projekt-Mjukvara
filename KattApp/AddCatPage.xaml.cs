namespace KattApp;
using System.Data.SQLite;

public partial class AddCatPage : ContentPage
{
    
	public AddCatPage()
	{
		InitializeComponent();
	}


    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        string Name = NameEntry.Text;
        string Race = RaceEntry.Text;
        string birthDay = bDayEntry.Text;
        string foodType = fTypeEntry.Text;
        int foodAmount = int.TryParse(fAmountEntry.Text, out int Fa) ? Fa : 0;
        double weight = double.TryParse(WeightEntry.Text, out double W) ? W : 0.0;
        string comment = CommentEntry.Text;
        if(App._db.AddCat(new App.Cat(Name, Race, birthDay, foodType, foodAmount, weight, comment)))
        {
            await DisplayAlert("SUCCESS", Name + " has been successfully added\n"+Name+ " " + Race+ " " +birthDay+ " " + foodType + " " + foodAmount + " " + weight + " " + comment, "OK");
        }
        else
        {
            await DisplayAlert("UH OH!", "Something went wrong\n " + Name + " " + Race + " " + birthDay + " " + foodType + " " + foodAmount + " " + weight + " " + comment, "OK");
        }

        await Navigation.PopAsync();
    }
    
}