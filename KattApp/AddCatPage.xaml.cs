using KattApp.Services;

namespace KattApp;


public partial class AddCatPage : ContentPage
{
    UpploadImage uploadImage {  get; set; }

    int count = 0;

	public AddCatPage()
	{
		InitializeComponent();
        uploadImage = new UpploadImage();
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

        //går tilbacka till my cats
        await Navigation.PopAsync();
    }
}