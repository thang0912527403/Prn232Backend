using Prn232Project.Models;
namespace Prn232Project.Services
{
    public interface ITokenServices
    {
        string CreateAccessToken(string username);
        RefreshToken CreateRefreshToken(string username);
    }
}
