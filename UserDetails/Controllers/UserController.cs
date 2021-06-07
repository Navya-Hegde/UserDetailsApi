using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetails.Model;
using UserDetails.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserDetails.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetUser")]
        public ActionResult<List<User>> GetAllUser()
        {
            var ListUser = _userService.GetAllUser();

            return Ok(ListUser);
        }

        [HttpGet("GetUser")]        
        public ActionResult GetUser([System.Web.Http.FromUri] int id)
        {
            var result = _userService.GetUserById(id);
            if(result==null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteUserById([System.Web.Http.FromUri] string id)
        {
            var result=_userService.DeleteUser(int.Parse(id));
            if (result == false)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddUser([System.Web.Http.FromBody] User user)
        {
            var result=_userService.AddUser(user);
            if(result==false)
            {
                return BadRequest();
            }
            return Created(string.Empty, user);
        }

        [HttpPut]
        public IActionResult UpdateUser([System.Web.Http.FromBody] User user, [System.Web.Http.FromUri] int id)
        {
            var result = _userService.UpdateUser(user, id);
            if (result == false)
            {
                return BadRequest();
            }
            return Created(string.Empty, user);
        }

    }
}