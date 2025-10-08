using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Prn232Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RefreshTokenController : Controller
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllRefreshToken()
        {
            return Ok("Đã lấy token");
        }
        
    }
}
