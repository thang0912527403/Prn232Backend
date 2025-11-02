using Prn232Project.Models;

namespace Prn232Project.Services
{
    public interface IUserServices
    {
        string GetRoles(string username);
        User? GetUsers(string username);
    }
}
