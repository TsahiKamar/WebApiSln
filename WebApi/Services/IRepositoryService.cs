using Microsoft.AspNetCore.Mvc;

namespace WebApi.Services
{
    public interface IRepositoryService
    {
       Task<IActionResult> GetRepository(string searchParam); // async IEnumerable<RepositoryResponse> 
    }
}
