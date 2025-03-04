namespace KattApp;

public partial class MyCatPage : ContentPage
{
    public MyCatPage()
    {
        InitializeComponent();
    }
    private async void OnNavigateButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCatPage());
    }

    public class Cat()
    {
        public string _name { get; set; }
        public string _race { get; set; }
        public int _bday { get; set; }
        public int _weight { get; set; }
        public string _coment { get; set; }

        /*public Cat(string name, string race, int bday, int weight, string coment)
        {
            _name = name;
            _race = race;
            _bday = bday;
            _weight = weight;
            _coment = coment;
        }*/
    }
}