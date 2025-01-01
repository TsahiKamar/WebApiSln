using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.BL
{
    public class RepositoryBL: IRepositoryBL
    {
        private readonly IJwtService _jwtService;
        private readonly IRepositoryService _repositoryService;

        public RepositoryBL(IJwtService jwtService,IRepositoryService repositoryService)
        {
            _jwtService = jwtService;
            _repositoryService = repositoryService;
        }

        #region Public Methods

        public async Task<IActionResult> GetRepositories(string searchParam) 
        {
            IActionResult response = await _repositoryService.GetRepositories(searchParam);
            return response;
        }

        #endregion

        #region Private Methods

        //// Method to convert IActionResult to HttpResponseMessage
        //private HttpResponseMessage ConvertToHttpResponseMessage(IActionResult actionResult)
        //{
        //    // To simulate how we'd normally process IActionResult into HttpResponseMessage
        //    if (actionResult is ObjectResult objectResult)
        //    {
        //        // Create a new HttpResponseMessage based on the ObjectResult
        //        var httpResponseMessage = new HttpResponseMessage((HttpStatusCode)objectResult.StatusCode)
        //        {
        //            Content = new StringContent(JsonConvert.SerializeObject(objectResult.Value))

        //        };

        //        // Optionally, you can add headers here if needed
        //        httpResponseMessage.Headers.Add("Custom-Header", "HeaderValue");

        //        return httpResponseMessage;
        //    }

        //    // Handle other types of IActionResult (NotFound, BadRequest, etc.)
        //    if (actionResult is NotFoundResult)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.NotFound);
        //    }
        //    else if (actionResult is BadRequestResult)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.BadRequest);
        //    }
        //    else if (actionResult is OkResult)
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }

        //    // Handle other cases or throw exception if needed
        //    throw new NotImplementedException("Unsupported IActionResult type");
        //}
        #endregion
    }
}
