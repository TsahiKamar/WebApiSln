using Microsoft.AspNetCore.Mvc;
using WebApi.BL;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepositoryController : ControllerBase
    {

        private readonly RepositoryBL _repositoryBL;

        private readonly ILogger<RepositoryController> _logger;
      

        public RepositoryController(RepositoryBL repositoryBL,ILogger<RepositoryController> logger)
        {
            _repositoryBL = repositoryBL;
            _logger = logger;

        }



        //SAMPLE http://localhost:5000/api/externaldata/1 int
        //SAMPLE http://localhost:5000/api/externaldata/JohnDoe, string 
        //[HttpGet(Name = "GetRepository")]
        //[HttpGet("{searchParam}")]
        [HttpGet("{searchParam}", Name = "GetRepository")]
        public async Task<IActionResult> GetRepository(string searchParam) //IENURABLE ?  IEnumerable<RepositoryResponse>
        //public async Task<IActionResult> GetRepository([FromQuery] string searchParam) //IENURABLE ?  IEnumerable<RepositoryResponse>
        {

            HttpResponseMessage response;

                try
                {
                //        // URL of the external JSON service
                //        var url = "https://api.example.com/data";

                //        // Sending a GET request to the external API
                //        var response = await _httpClient.GetAsync(url);

                  response = await _repositoryBL.GetRepository(searchParam);

                  if (!response.IsSuccessStatusCode)
                  {
                     return StatusCode((int)response.StatusCode, "Error calling external service");
                  }

            //        // Reading the response content as a string
            //        var jsonResponse = await response.Content.ReadAsStringAsync();

            //        // Deserialize the JSON response into a C# object (e.g., ExternalData)
            //        var data = JsonConvert.DeserializeObject<ExternalData>(jsonResponse);

                    // Return the data
                    //return Ok(data);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, searchParam);//?
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
                
                return Ok(response);

        }
    }
}


//[HttpGet]
//public async Task<IActionResult> GetExternalData()
//{
//    try
//    {
//        // URL of the external JSON service
//        var url = "https://api.example.com/data";

//        // Sending a GET request to the external API
//        var response = await _httpClient.GetAsync(url);

//        if (!response.IsSuccessStatusCode)
//        {
//            return StatusCode((int)response.StatusCode, "Error calling external service");
//        }

//        // Reading the response content as a string
//        var jsonResponse = await response.Content.ReadAsStringAsync();

//        // Deserialize the JSON response into a C# object (e.g., ExternalData)
//        var data = JsonConvert.DeserializeObject<ExternalData>(jsonResponse);

//        // Return the data
//        return Ok(data);
//    }
//    catch (Exception ex)
//    {
//        return StatusCode(500, $"Internal server error: {ex.Message}");
//    }
//}
//    }
//}