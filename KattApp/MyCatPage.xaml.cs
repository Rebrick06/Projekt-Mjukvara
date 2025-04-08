using Microsoft.Maui.Controls.Shapes;
using System.Linq.Expressions;

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

    private void PrintCatData()
    {
        List<App.Cat> cats = App._db.getData();
        foreach (App.Cat cat in cats)
        {
            Border catFrame = new Border
            {
                Stroke = Colors.Gray,
                StrokeShape = new RoundRectangle { CornerRadius = 10 },
                StrokeThickness = 2,
                Padding = 10,
                Margin = new Thickness(0, 5),
                BackgroundColor = Colors.LightGray
            };

            StackLayout stack = new StackLayout();

            stack.Children.Add(new Label { Text = $"Namn: {cat._name}", FontSize = 18, FontAttributes = FontAttributes.Bold });
            stack.Children.Add(new Label { Text = $"Ras: {cat._race}" });
            stack.Children.Add(new Label { Text = $"Födelsedag: {cat._bday}" });
            stack.Children.Add(new Label { Text = $"Mattyp: {cat._food_type}" });
            stack.Children.Add(new Label { Text = $"Matmängd: {cat._food_amount} g" });
            stack.Children.Add(new Label { Text = $"Vikt: {cat._weight} kg" });
            stack.Children.Add(new Label { Text = $"Kommentar: {cat._comment}" });

            catFrame.Content = stack;
            CatContainer.Children.Add(catFrame);
        }
        
    }
}