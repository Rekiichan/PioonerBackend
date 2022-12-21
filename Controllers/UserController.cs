using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pioneer_Backend.Model;
using Pioneer_Backend.Service;

namespace Pioneer_Backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            return _service.GetUsers();
        }
        [HttpGet("{id:length(24)}")]
        public ActionResult<User> GetUser(string id)
        {
            var user = _service.GetUser(id);
            return Json(user);
        }
        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _service.Create(user);
            return Json(user);
        }


        #region for new client
        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public ActionResult Login([FromBody] User user)
        {
            var token = _service.Authenticate(user.Email, user.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { token, user });
        }

        #endregion
    }
}
