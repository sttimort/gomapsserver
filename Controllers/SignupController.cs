using Microsoft.AspNetCore.Mvc;
using GoMapsCloudAPI.Models;

namespace GoMapsCloudAPI.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepo;

        public UsersController(IUsersRepository usersRepo)
        {
            _usersRepo = usersRepo;
        }

        [HttpGet("/exists/{user_id}")]
        public IActionResult doesUserExist(long user_id)
        {
            if (_usersRepo.Exists(user_id))
                return Ok(new {
                    user_id = user_id,
                    exists = true
                });

            return Ok(new {
                    user_id = user_id,
                    exists = false
                });

            // if (_usersRepo.Exists(user_id))
            //     return Json(new {
            //         user_id = user_id,
            //         exists = true
            //     });

            // return Json(new {
            //     user_id = user_id,
            //     exists = false
            // });
        }

        [HttpGet("{user_id}")]
        public string getUserInfo(long user_id)
        {
            // User user = _usersRepo.

            // return Json(new {
            //     user_id = ;
            return "hello";
        }

        [HttpPost]
        public ActionResult registerNewUser([FromBody] User user)
        {
            try 
            {
                if (user == null)
                    return BadRequest();

                _usersRepo.Create(user);
            }
            catch
            {
                return BadRequest(new {
                    message = "Couldn't register new user"
                });
            }

            return Created($"users/{user.user_id}", user);
        }

        [HttpPost("{id}/photos")]
        public IActionResult uploadPhotos( long user_id)
        {
            return Ok();
        }
    }
}