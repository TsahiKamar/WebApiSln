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
        private readonly IUserService _userService;

        //Id = 1, FirstName = "Test", LastName = "User",

        public RepositoryBL(IJwtService jwtService,IRepositoryService repositoryService, IUserService userService)
        {
            _jwtService = jwtService;
            _repositoryService = repositoryService;
            _userService = userService;
            //_logger = logger;
        }

        #region Public Methods
        //moved to userService
        //public AuthenticateResponse Authenticate(AuthenticateRequest model)
        //{
        //    var user = _userService.GetAll().SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

        //    // return null if user not found
        //    if (user == null) return null;

        //    // authentication successful so generate jwt token
        //    var token = this._jwtService.generateJwtToken(user);

        //    return new AuthenticateResponse(user, token);
        //}

        public User? GetById(int id)
        {
            return _userService.GetAll().FirstOrDefault(x => x.Id == id);
        }
        //public User GetByUserName(string userName)
        //{
        //    return _users.FirstOrDefault(x => x.Username == userName);
        //}



        public async Task<HttpResponseMessage> GetRepository(string searchParam) //HttpResponseMessage // IActionResult // IEnumerable<RepositoryResponse>
        {
            //     public IHttpActionResult SomeAction()
            //{
            //HttpResponseMessage responseMsg =
            //    new
            //    HttpResponseMessage(HttpStatusCode.RedirectMethod);


            //IHttpActionResult response = this.ResponseMessage(responseMsg);
            //return response;
            //}

            IActionResult actionResult =  await _repositoryService.GetRepository(searchParam);


            // Convert the IActionResult to HttpResponseMessage
            var httpResponseMessage = ConvertToHttpResponseMessage(actionResult);

            return httpResponseMessage;


        }
        #endregion

        #region Private Methods

        // Method to convert IActionResult to HttpResponseMessage
        private HttpResponseMessage ConvertToHttpResponseMessage(IActionResult actionResult) //ORIG async Task<HttpResponseMessage>
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
        #endregion
    }
}
