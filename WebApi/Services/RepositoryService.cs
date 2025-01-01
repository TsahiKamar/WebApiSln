using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApi.Models;

namespace WebApi.Services
{
    public class RepositoryService: ControllerBase,IRepositoryService 
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

        public async Task<IActionResult> GetRepositories(string searchParam)
        {
            var httpClient = new HttpClient();

            var url = repositoriesSearchUrl + searchParam;
            var jsonResponse = string.Empty;
            var data = new object();

            //USE FOR DEV ENV ONLY  - FOR HTTPS USE VIA HTTP
            httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClient");

            //Sending a GET request to the external API
            var response = await httpClient.GetAsync(url);

            //USE FOR DEV ENV ONLY - FOR HTTPS USE VIA HTTP - Ensure a successful response (status code 200)
            response.EnsureSuccessStatusCode();

            // Reading the response content as a string
            jsonResponse = await response.Content.ReadAsStringAsync();

            //Deserialize the JSON response into a C# object
            data = JsonConvert.DeserializeObject<RepositoryResponse>(jsonResponse);
                
            return Ok(data);
        }

    }
}
