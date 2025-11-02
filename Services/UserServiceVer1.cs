using Prn232Project.Data;
using Prn232Project.Models;
namespace Prn232Project.Services
{
    public class UserServiceVer1:IUserServices
    {
        private readonly CloneEbayDbContext _context;
        public UserServiceVer1(CloneEbayDbContext context)
        {
            _context = context;
        }
        public string GetRoles(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null|| user.Role == null)
            {
                return string.Empty;
            }
            return user.Role;
        }
        public User? GetUsers(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            return user;
        }
    }
}
