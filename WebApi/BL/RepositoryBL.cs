using Microsoft.AspNetCore.Mvc;
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

    }
}
