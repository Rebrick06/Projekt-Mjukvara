using KattApp.Services;

namespace KattApp;
using System.Data.SQLite;
using KattApp.Mdoels;


public partial class AddCatPage : ContentPage
{

    UpploadImage uploadImage {  get; set; }

    int count = 0;

	public AddCatPage()
	{
		InitializeComponent();
        uploadImage = new UpploadImage();
	}



    /// <summary>
    /// knapp för att lägga till mer mat 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnAddFood(object sender, EventArgs e)
    {
        count++;
        AmountFood.Text = $"{count.ToString()}    g";
    }

    /// <summary>
    /// knapp för att tabort mat
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnRemoveFood(object sender, EventArgs e)
    {
        count--;
        if (count <= 0) { count = 0; }//kan inte bli mindre än noll
        AmountFood.Text = $"{count.ToString()}    g";
    }

    /// <summary>
    /// lägger till en blid ifrån kamrarullen
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public async void UploadImage_Clicked(object sender, EventArgs e)
    {
        var img = await uploadImage.OpenMediaPickerAsync();

        var imagefile = await uploadImage.Upload(img);

        Image_Upload.Source = ImageSource.FromStream(()=>
           uploadImage.ByteArrayToStream(uploadImage.StringToByteBase64(imagefile.byteBase46)
            ));
    }
    
    
    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        var cat = new Cat
 {
     Name = NameEntry.Text,
     Race = RaceEntry.Text,
     Birthday = bDayEntry.Text,
     Food_type = fTypeEntry.Text,
     //Food_amount = count,
     Weight = double.Parse(WeightEntry.Text),
     Comment = CommentEntry.Text
 };

 await App.Database.SaveCatAsync(cat);
 await DisplayAlert("Sparad", "Katten har sparats!", "OK");

 await Navigation.PopAsync();
    }

}