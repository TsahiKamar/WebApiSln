using Microsoft.AspNetCore.Mvc;

namespace WebApi.Services
{
    public interface IRepositoryService
    {
        Task<IActionResult> GetRepositories(string searchParam); 
    }
}
