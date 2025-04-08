using Microsoft.Maui.Controls.Shapes;
using System.Linq.Expressions;
using KattApp.Mdoels;

namespace KattApp;

public partial class MyCatPage : ContentPage
{
    public MyCatPage()
    {
        InitializeComponent();
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        PrintCatData();
    }
    private async void OnNavigateButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCatPage());
    }

    private async void PrintCatData()
    {
        var cats = await App.Database.GetCatsAsync();
        catsCollectionView.ItemsSource = cats;
    }
}