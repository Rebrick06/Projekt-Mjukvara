using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Newtonsoft.Json; // Lägg till Newtonsoft.Json via NuGet
using System.Collections.Generic;
using System.Globalization;

namespace KattApp
{
    public partial class CatFactPage : ContentPage
    {
        public class ContentHandler
        {
            CatFact catFact;
        }

        public class CatFact
        {
            [JsonProperty("text")]
            public string Text { get; set; }
        }
        public CatFactPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            CatFactLabel.Text = await GetCatFact();
        }

        private async Task<string> GetCatFact()
        {
            string url = "https://cat-fact.herokuapp.com/facts";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resp = await client.GetAsync(url);

                string jsonString = await resp.Content.ReadAsStringAsync();

                List<CatFact> facts = JsonConvert.DeserializeObject<List<CatFact>>(jsonString);

                if (facts.Count > 0)
                {
                    DateTime today = DateTime.Today;
                    int day = today.DayOfYear;

                    return facts[day % facts.Count].Text;
                }
            }
            return "ERROR";
        }
    }
}