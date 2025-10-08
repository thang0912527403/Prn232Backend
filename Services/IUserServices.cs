using Prn232Project.Models;

namespace Prn232Project.Services
{
    public interface IUserServices
    {
        Roles GetRoles(string username);
        Users GetUsers(string username);
    }
}
