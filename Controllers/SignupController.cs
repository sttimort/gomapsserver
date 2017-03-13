using Microsoft.AspNetCore.Mvc;

namespace GoMapsCloudAPI.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        [HttpGet("/exists/{user_id}")]
        public JsonResult doesUserExist(long user_id)
        {
            //query data base

            if (/* user exists */ true)
                return Json(new {
                    user_id = user_id,
                    exists = true
                });

            // return Json(new {
            //     user_id = user_id,
            //     exists = true
            // });
        }

        [HttpGet("{user_id}")]
        public string getUserInfo(long user_id)
        {
            return "GET /user/user_id - get user user info";
        }

        [HttpPost]
        public string registerNewUser([FromBody] string user_id)
        {
            return "POST /signup - register new user" + user_id;
        }
    }
}