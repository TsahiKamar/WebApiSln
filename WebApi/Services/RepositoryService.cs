using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
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


        //ORIG CODE TR 
        public async Task<IActionResult> GetRepository(string searchParam)
        {
            var httpClient = new HttpClient();

            //var response = await httpClinet.GetStringAsync(uri);
            //var result = JsonSerializer.Deserialize<IEnumerable<RepositoryResponse>>(response);

            var url = repositoriesSearchUrl + searchParam;
            var jsonResponse = string.Empty;
            try
            {
                //FOR HTTPS USE VIA HTTP
                //Set User-Agent header (GitHub API requires it)
                httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClient");

                // Sending a GET request to the external API
                var response = await httpClient.GetAsync(url);

                //FOR HTTPS USE VIA HTTP - Ensure a successful response (status code 200)
                response.EnsureSuccessStatusCode();

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode, "Error calling external api service");
                }

                // Reading the response content as a string
                jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into a C# object (e.g., ExternalData)
                //var data = JsonConvert.DeserializeObject<RepositoryResponse>(jsonResponse);

                //my
                //var myDeserializedClass = JsonConvert.DeserializeObject<RepositoryResponse>(jsonResponse);


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            return Ok(jsonResponse);//jsonResponse

        }


        //TEST TEST ONLY
        //       public async Task<HttpResponseMessage> GetRepository(string searchParam)
        //       {
        //           var httpClient = new HttpClient();

        //           //var response = await httpClinet.GetStringAsync(uri);
        //           //var result = JsonSerializer.Deserialize<IEnumerable<RepositoryResponse>>(response);

        //           var url = repositoriesSearchUrl + searchParam;
        //           var jsonResponse = string.Empty;
        //           HttpResponseMessage httpResponseMessage= new HttpResponseMessage();//TEMP ONLY
        //           try
        //           {
        //               //FOR HTTPS USE VIA HTTP
        //               //Set User-Agent header (GitHub API requires it)
        //               httpClient.DefaultRequestHeaders.Add("User-Agent", "HttpClient");

        //               // Sending a GET request to the external API
        //               var response = await httpClient.GetAsync(url);

        //               //FOR HTTPS USE VIA HTTP - Ensure a successful response (status code 200)
        //               response.EnsureSuccessStatusCode();

        //               if (!response.IsSuccessStatusCode)
        //               {
        //                   //return StatusCode((int)response.StatusCode, "Error calling external api service");
        //               }

        //               // Reading the response content as a string
        //               jsonResponse = await response.Content.ReadAsStringAsync();

        //               // Deserialize the JSON response into a C# object (e.g., ExternalData)
        //               var data = JsonConvert.DeserializeObject<RepositoryResponse>(jsonResponse);

        //               //my
        //               //var myDeserializedClass = JsonConvert.DeserializeObject<RepositoryResponse>(jsonResponse);

        //httpResponseMessage = ConvertToHttpResponseMessage(Ok(jsonResponse));//ORIG jsonResponse


        //           }
        //           catch (Exception ex)
        //           {
        //               //return StatusCode(500, $"Internal server error: {ex.Message}");
        //           }
        //           //return Ok(jsonResponse);//jsonResponse
        //           return httpResponseMessage;



        //       }


        public HttpResponseMessage ConvertToHttpResponseMessage(IActionResult actionResult)
        {
            // To simulate how we'd normally process IActionResult into HttpResponseMessage
            if (actionResult is ObjectResult objectResult)
            {
                // Create a new HttpResponseMessage based on the ObjectResult
                var httpResponseMessage = new HttpResponseMessage((HttpStatusCode)objectResult.StatusCode)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(objectResult.Value))

                };

                // Optionally, you can add headers here if needed
                httpResponseMessage.Headers.Add("Custom-Header", "HeaderValue");

                return httpResponseMessage;
            }

            // Handle other types of IActionResult (NotFound, BadRequest, etc.)
            if (actionResult is NotFoundResult)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            else if (actionResult is BadRequestResult)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else if (actionResult is OkResult)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }

            // Handle other cases or throw exception if needed
            throw new NotImplementedException("Unsupported IActionResult type");
        }


    }
}
