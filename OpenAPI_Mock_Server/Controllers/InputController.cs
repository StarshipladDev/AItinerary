using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Hosting;

namespace OpenAPI_Mock_Server.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class InputController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string openAiApiKey = "";
        private readonly IWebHostEnvironment _hostingEnvironment;

        public InputController(HttpClient httpClient, IWebHostEnvironment hostingEnvironment)
        {
            _httpClient = httpClient;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestModel request)
        {
            var apiUrl = "https://api.openai.com/v1/chat/completions"; // Adjust the endpoint if necessary

            ChatGPTRequestModel requestBody = new ChatGPTRequestModel();
            requestBody.model = "gpt-4o-mini";
            requestBody.messages = [
                new ChatGPTRequestMessage(){ role = "system", 
                    content = 
                    "You are an assistant that" +
                    " will be provided a tourist iteniary name and description. " +
                    "You will provide reccomendations as to how to make the description more appealing, " +
                    "as well as how to improve the name such as spelling msitakes or a lack of clarity. " +
                    "The format you shold provide responses in is a bullet pointed list of changes you would reccomend" +
                    "or clarity that is required in the content. Each itinary must have descriptions of transport between" +
                    "locations, names of accomodation to stay at, at least 1 activity each day, and transport for each person" +
                    "to and from the destination. The group count must be mentioned. "
                },
                new ChatGPTRequestMessage(){ role = "user",
                    content =
                    $"Iteniary Title : {request.IttenaryName}." +
                    $"Iteniary Description : {request.IttenaryDescription}"
                }
           ];

            var jsonRequestBody = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {openAiApiKey}");
            var response = await _httpClient.PostAsync(apiUrl, content);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<OpenAiResponse>(responseBody);

            return Ok(new ResponseModel() { Message = result.Choices[0].message.content });
        }

        [HttpPost]
        [Route("api/[controller]/generate")]
        public async Task<IActionResult> Generate([FromBody] RequestModel request)
        {

            string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Assets/accomodation.json");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            string jsonContent = await System.IO.File.ReadAllTextAsync(filePath);
            Suppliers suppliers = JsonConvert.DeserializeObject<Suppliers>(jsonContent);

            var apiUrl = "https://api.openai.com/v1/chat/completions"; // Adjust the endpoint if necessary

            ChatGPTRequestModel requestBody = new ChatGPTRequestModel();
            requestBody.model = "gpt-4o";
            requestBody.messages = [
                new ChatGPTRequestMessage(){ role = "system",
                    content =$"You are an assistant that will only reply with JSON, no preamble etc.\r\n" +
                    $"You will be provided an itinerary title, description, " +
                    $"as well as a selection of JSON itinerary options in a JSON format." +
                    $"\r\nYou will modify the description and title to be more appealing, " +
                    $"and use the provided JSON information to give a cost, as well as itinerary " +
                    $"for the specified amount of people.\r\n  " +
                    $"The format for each service available will be an array of json objects with a name, " +
                    $"description, available dates in a YYYY-mm-DD format. " +
                    $"You will also be given the clients prefrances in the description of the itinerary." +
                    $"\r\nTransport is required to and from each activity, " +
                    $"and at the start of a day that accomodation changes.\r\n\r\n" +
                    $"The JSON format of your reply should be:\r\n\r\n\"days\":" +
                    $"[{{Day_Number : int, Description : \"Overview Of Day\", " +
                    $"Accomodation:{{" +
                    $"Accomodation_Name : \" Name of the accommodation\", " +
                    $"Accomodation_Cost: int," +
                    $"Accomodation_Description:\" description of the accom \"}}," +
                    $"Transport:{{key for transport cost, description and name}}, " +
                    $"Activities:[{{Each activity object should have a name, description and cost}}]], " +
                    $"\"total cost\": int, \"title\":\"title of itinary\", " +
                    $"\"description\":\"description of itinary\", " +
                    $"\"start_day_of_itnianry\": \"YYYY-mm-DD value\""+
                    @"}" + $". If an ammount of days are specified, the resposne must only account for that many days" +
                    $", no more, no less. If no service is available for required days, put an empty value in the relevant field"
                },
                new ChatGPTRequestMessage(){ role = "user",
                    content =
                    $"Iteniary Title : {request.IttenaryName}." +
                    $"Iteniary Description : {request.IttenaryDescription}"+
                    "Your supplier content is : "
                    +jsonContent
                }
           ];

            var jsonRequestBody = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {openAiApiKey}");
            var response = await _httpClient.PostAsync(apiUrl, content);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<OpenAiResponse>(responseBody);

            return Ok(new ResponseModel() { Message = result.Choices[0].message.content });
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

    public class ChatGPTRequestModel
    {
        public string? model { get; set; }
        public ChatGPTRequestMessage[]? messages { get; set; }
    }
    public class ChatGPTRequestMessage
    {
        public string? role { get; set; }
        public string? content { get; set; }
    }
    public class OpenAiResponse
    {
        public Choice[] Choices { get; set; }

        public class Choice
        {
            public OpenAiResponseMessage message { get; set; }
        }
        public class OpenAiResponseMessage
        {
            public string role;
            public string content;

        }
    }

    public class Supplier
    {
        public string Name { get; set; }
        public List<string> DatesAvailable { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public int Cost;
    }

    public class Suppliers
    {
        public List<Supplier> suppliers { get; set; }
    }

   

}
