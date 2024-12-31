using Microsoft.AspNetCore.Mvc;

namespace WebApi.Services
{
    public interface IRepositoryService
    {
        Task<IActionResult> GetRepository(string searchParam); 
        //TEST TEST
        //Task<HttpResponseMessage> GetRepository(string searchParam);

    }
}
