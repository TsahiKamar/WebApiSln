
using Microsoft.AspNetCore.Mvc;

namespace WebApi.BL
{
    public interface IRepositoryBL 
    {
        Task<IActionResult> GetRepositories(string searchParam);
    }
}
