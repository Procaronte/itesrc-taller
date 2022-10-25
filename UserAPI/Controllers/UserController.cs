using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.Requests;
using Services.Implementations;
using Services.Interfaces;
using System.Net;
using UserAPI.Responses;

namespace UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                if(users == null || users.Count == 0)
                {
                    return Ok(new StandardResponse<string>(HttpStatusCode.NotFound, null, "No users found"));
                }
                return Ok(new StandardResponse<List<User>>(HttpStatusCode.OK, users));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                if (user == null)
                {
                    return Ok(new StandardResponse<string>(HttpStatusCode.NotFound, null, "No users found"));
                }
                return Ok(new StandardResponse<User>(HttpStatusCode.OK, user));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(CreateOrUpdateUserRequest request)
        {
            try
            {
                var response = await _userService.AddUser(request);
                if (response == null)
                {
                    return Ok(new StandardResponse<User>(HttpStatusCode.BadRequest, null, "Something went wrong"));
                }
                return Ok(new StandardResponse<User>(HttpStatusCode.OK, response, "User added succesfully"));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
