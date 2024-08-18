using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Markdig;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace OpenAIIttenaryManager
{
    public partial class Form1 : Form
    {

        private readonly HttpClient _httpClient;
        public Form1()
        {
            _httpClient = new HttpClient();
            InitializeComponent();
        }


        private async void reccomendatiopnButton_Click(object sender, EventArgs e)
        {
            string requestDescription = this.descriptionTextBox.Text;
            string requestTitle = this.itineraryNameTextBox.Text;
            this.itineraryNameTextBox.Text = "Loading .. ";
            this.descriptionTextBox.Text = "Loading .. ";
            var request = new RequestModel
            {
                IttenaryName = requestTitle,
                IttenaryDescription = requestDescription
            };
            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7138/api/Input", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var responseModel = JsonConvert.DeserializeObject<ResponseModel>(jsonResponse);
                string htmlText = ConvertMarkdownToRtf(responseModel.Message);
                this.reccomendationTextBox.Rtf = htmlText.Replace("&quot;", "\"");
            }
            else
            {
                this.reccomendationTextBox.Text = "Error calling API.";
            }
        }


        private async void updateButton_Click(object sender, EventArgs e)
        {
            string requestDescription = this.descriptionTextBox.Text;
            string requestTitle = this.itineraryNameTextBox.Text;
            this.itineraryNameTextBox.Text = "Loading .. ";
            this.descriptionTextBox.Text = "Loading .. ";
            var request = new RequestModel
            {
                IttenaryName = requestTitle,
                IttenaryDescription = requestDescription
            };
            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7138/api/Input/api/Input/generate", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                string rawResponse = Markdown.ToPlainText(jsonResponse);
                ResponseModel returnResponse = JsonConvert.DeserializeObject<ResponseModel>(rawResponse);
                rawResponse = returnResponse.Message.Replace("json", "").Replace("\\n","").Replace("\\\"","\"");
                Itinerary responseItenary = JsonConvert.DeserializeObject<Itinerary>(rawResponse);
                this.itineraryNameTextBox.Text = responseItenary.title;
                string outputText =
                    $"Title : {responseItenary.title} "+ Environment.NewLine+
                    $"Cost : {responseItenary.total_cost} "+Environment.NewLine+
                    $"Description : {responseItenary.description} "+Environment.NewLine+
                    $"Start Date : {responseItenary.start_day_of_itnianry} "+Environment.NewLine+
                    $"Total Days : {responseItenary.days.Count} " + Environment.NewLine;
                int dayCount = 0;
                responseItenary.days.ToList().ForEach((day) => {
                    dayCount++;
                    outputText += "Day : " + dayCount + Environment.NewLine;
                    if(day.Transport != null)
                    {
                        outputText += "Transport : " + day.Transport.Name + 
                        ", Cost: " + day.Transport.Cost 
                        + Environment.NewLine;
                    }
                    if(day.Accomodation != null)
                    {
                        outputText += "Accomodation : " + day.Accomodation.Accomodation_Name + ", Cost: " + day.Accomodation.Accomodation_Cost + Environment.NewLine;
                    }
                    day.Activities.ForEach((activity) => {
                        outputText += "Activity : " + activity.Name + ", Description: " + activity.Description + ", Cost: " + activity.Cost + Environment.NewLine;
                    });

                    outputText += Environment.NewLine;


                });

                this.descriptionTextBox.Text = outputText;
                
            }
            else
            {
                this.descriptionTextBox.Text = "Error calling API.";
            }
        }

        private string ConvertMarkdownToRtf(string markdown)
        {
            // Convert Markdown to HTML
            var html = Markdown.ToHtml(markdown);

            // Convert HTML to RTF
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);

            var rtfBuilder = new StringBuilder();
            rtfBuilder.Append(@"{\rtf1\ansi");

            foreach (var node in htmlDoc.DocumentNode.DescendantsAndSelf())
            {
                switch (node.Name)
                {
                    case "p":
                        rtfBuilder.Append(@"\par ");
                        break;
                    case "strong":
                    case "b":
                        rtfBuilder.Append(@"\b ");
                        break;
                    case "#text":
                        rtfBuilder.Append(node.InnerText.Replace("\n", @"\par "));
                        break;
                }

                if (node.Name == "strong" || node.Name == "b")
                {
                    rtfBuilder.Append(@"\b0 ");
                }
            }

            rtfBuilder.Append("}");
            return rtfBuilder.ToString();
        }
    }


    public class RequestModel
    {
        public string IttenaryName { get; set; }
        public string IttenaryDescription { get; set; }
    }

    public class ResponseModel
    {
        public string Message { get; set; }
    }
    public class Itinerary
    {
        public List<Day> days { get; set; }
        public int total_cost { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime start_day_of_itnianry { get; set; }
    }

    public class Day
    {
        public int DayNumber { get; set; }
        public string Description { get; set; }
        public Accommodation Accomodation { get; set; }
        public Transport Transport { get; set; }
        public List<Activity> Activities { get; set; }
    }

    public class Accommodation
    {
        public string Accomodation_Name { get; set; }
        public int Accomodation_Cost { get; set; }
        public string Accomodation_Description { get; set; }
    }

    public class Transport
    {
        public int Cost { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }

    public class Activity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
    }
}
