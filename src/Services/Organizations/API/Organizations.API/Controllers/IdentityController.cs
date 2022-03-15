using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Organizations.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from x in User.Claims select new { x.Type, x.Value });
        }

        [HttpGet]
        [Route("GetDoctor")]
        [Authorize("ClientIdPolicy")]
        public IActionResult GetDoctor()
        {
            return new JsonResult(from x in User.Claims select new { x.Type, x.Value });
        }
    }
}
