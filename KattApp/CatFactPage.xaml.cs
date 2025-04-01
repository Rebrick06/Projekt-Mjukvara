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
            [JsonProperty("fact")]
            public string Fact{ get; set; }
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
            string url = "https://catfact.ninja/fact";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage resp = await client.GetAsync(url);

                    if (!resp.IsSuccessStatusCode)
                    {
                        return "API Not Available";
                    }

                    string jsonString = await resp.Content.ReadAsStringAsync();
                    CatFact fact = JsonConvert.DeserializeObject<CatFact>(jsonString);

                    return fact?.Fact ?? "No fact available";
                }
            }
            catch (Exception ex)
            {
                return "API Not Available";
            }
            return "Error";
        }
    }
}