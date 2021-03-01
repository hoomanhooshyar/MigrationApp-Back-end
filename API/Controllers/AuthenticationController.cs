
using Core.Entities;
using Core.Interfaces;
using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _repository;
        
        public AuthenticationController(IUserRepository repository){
            _repository = repository;

        }
        [HttpPost("login")]
        public async Task<ActionResult<Result>> Login(Login login){
            var user = await _repository.Login(login.Username,login.Password);
            Result result = new Result();
            if(user == null)
            {
                result.Status = -1;
                result.Message = "نام کاربری یا کلمه عبور اشتباه است";
                return NotFound(result);
            }
            else
            {
                result.Status = user.RoleId;
                result.Message = user.Token;
                return Ok(result);
            }
            
        }

        [HttpPost("signup")]
        public async Task<ActionResult<Result>> Signup(Signup user)
        {
            var result = await _repository.Signup(user);
            return Ok(result);
        }

        [HttpPost("get_user_data")]
        public async Task<ActionResult<UserDTO>> GetUserData()
        {
            StringValues headerValue;
            Request.Headers.TryGetValue("HTTP_TOKEN", out headerValue);
            var headerValueResult = headerValue.FirstOrDefault();
            if(headerValueResult == null || headerValueResult == "")
            {
                var user = new UserDTO();
                user.Id = -1;
                user.Name = "fail";
                return user;
            }
            else
            {
                var result = await _repository.GetUserData(headerValueResult);
                return result;
            }
        }
    }
}