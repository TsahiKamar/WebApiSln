using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Web.Http;
using WebApi.BL;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class RepositoryController : ControllerBase
    {

        private readonly IRepositoryBL _repositoryBL;

        private readonly ILogger<RepositoryController> _logger;
        private readonly IUserService _userService;

        private readonly IValidator<AuthenticateRequest> _authenticateRequestValidator;


        public RepositoryController(IRepositoryBL repositoryBL,ILogger<RepositoryController> logger, IUserService userService, IValidator<AuthenticateRequest> authenticateRequestValidator)
        {
            _userService = userService;
            _repositoryBL = repositoryBL;
            _logger = logger;
            _authenticateRequestValidator = authenticateRequestValidator;

        }
        //INIT JWT TOKEN AFTER VERIFY USERNAME & PASSWORD 
        [Microsoft.AspNetCore.Mvc.HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest request)
        {
            AuthenticateResponse response = null;
            try
            {

                
                var validationResult = _authenticateRequestValidator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                response = _userService.Authenticate(request);

                if (response == null)
                    return BadRequest(new { message = "Username or Password is incorrect" });//return 400
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Ok(response);
        }

        [Authorize]
        //[Microsoft.AspNetCore.Mvc.HttpGet("{searchParam}")]
        [Microsoft.AspNetCore.Mvc.HttpGet("GetRepositories")]
        public async Task<IActionResult> GetRepositories([FromUri] string searchParam)
        {

            IActionResult response;
            try
            {

                  response = await _repositoryBL.GetRepositories(searchParam);

                if ( ((IStatusCodeActionResult)response).StatusCode != 200)
                {
                   var statusCode = ((IStatusCodeActionResult)response).StatusCode ?? -1;
                   _logger.LogError($"Error invoke GetRepository service ! statusCode: {statusCode}", searchParam);
                   return StatusCode(statusCode, "Error invoke GetRepository service");
                }
            }
            catch (Exception ex)
            {
                    _logger.LogError(ex.Message, searchParam);
                    return StatusCode(500, $"Internal server error: {ex.Message}");
            }
      
            return Ok(response);

        }
    }
}
