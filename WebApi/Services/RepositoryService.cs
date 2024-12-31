using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApi.Models;

namespace WebApi.Services
{
    public class RepositoryService: ControllerBase,IRepositoryService //ControllerBase,
    {
        private readonly ApiSettings _apiSettings;
        private readonly string repositoriesSearchUrl;


        private readonly ControllerBase _ControllerBase;

        public RepositoryService(IOptions<ApiSettings> apiSettings)
        {
            _apiSettings = apiSettings.Value;
            repositoriesSearchUrl = _apiSettings.RepositoriesSearchUrl;

            //_ControllerBase = controllerBase;
        }

        public async Task<IActionResult> GetRepository(string searchParam) // async IEnumerable<RepositoryResponse> 
        {
            var httpClient = new HttpClient();
            //var _uri = repositoriesSearchUrl + searchParam;

            //var uri = new Uri(_uri); //new Uri("https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&page=2&api_key=DEMO_KEY");

            //var result = new DataModel();

            //var response = await httpClinet.GetStringAsync(uri);
            //var result = JsonSerializer.Deserialize<IEnumerable<RepositoryResponse>>(response);


            //SAMPLE

            var url = repositoriesSearchUrl + searchParam;
            try
            { 
            // Sending a GET request to the external API
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error calling external api service");
            }

            // Reading the response content as a string
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON response into a C# object (e.g., ExternalData)
            var data = JsonConvert.DeserializeObject<RepositoryResponse>(jsonResponse);

            // Return the data
            return Ok(data);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }


        }

    }
}
