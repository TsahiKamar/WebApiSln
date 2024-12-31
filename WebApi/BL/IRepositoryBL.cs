
using WebApi.Models;

namespace WebApi.BL
{
    public interface IRepositoryBL 
    {
        Task<HttpResponseMessage> GetRepository(string searchParam);
    }
}
