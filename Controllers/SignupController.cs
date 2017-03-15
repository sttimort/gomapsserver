using Microsoft.AspNetCore.Mvc;
using GoMapsCloudAPI.Models;
using GoMapsCloudAPI.Interfaces;

namespace GoMapsCloudAPI.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private IUsersRepository _usersRepository;

        public UsersController(IUsersRepository usersRepository)
        {
            // _usersRepository = usersRepository;
        }

        [HttpGet("/exists/{user_id}")]
        public JsonResult Exists(long user_id)
        {
            if (/*_usersRepository.Exists(user_id)*/ true)
                return Json(new {
                    user_id = user_id,
                    exists = true
                });

            // return Json(new {
            //     user_id = user_id,
            //     exists = false
            // });
        }

        [HttpGet("{user_id}")]
        public string GetUserInfo(long user_id)
        {
            return "GET /user/user_id - get user user info";
        }

        [HttpPost]
        public string RegisterNewUser([FromBody] string user_id)
        {
            return "POST /signup - register new user" + user_id;
        }
    }
}