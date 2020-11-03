using System.Threading.Tasks;
using ProcessSIM.Domain.Auth;

namespace ProcessSIM.ServiceLayer.Services
{
    public interface ITokenProvider
    {
        Task<AuthToken> Create(ApplicationUser user);
    }
}