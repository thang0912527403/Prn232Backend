using Prn232Project.Data;
using Prn232Project.Models;
namespace Prn232Project.Services
{
    public class UserServiceVer1:IUserServices
    {
        private readonly ApplicationDbContext _context;
        public UserServiceVer1(ApplicationDbContext context)
        {
            _context = context;
        }
        public Roles GetRoles(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            var userRole = _context.UserRoles.FirstOrDefault(ur => ur.UserId == user.Id);
            var role = _context.Roles.FirstOrDefault(r => r.Id == userRole.RoleId);
            return role;
        }
        public Users GetUsers(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            return user;
        }
    }
}
