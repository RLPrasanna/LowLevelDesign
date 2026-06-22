using BookMyShow.DTO;
using BookMyShow.Exceptions;
using BookMyShow.Model;
using BookMyShow.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controller
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public ActionResult<UserRequestDTO> CreateUser([FromBody] UserRequestDTO userRequestDTO)
        {
            UserRequestDTO response=new UserRequestDTO();
            User createdUser=new User();

            try
            {
                createdUser = userService.RegisterUser(userRequestDTO.UserEmail, userRequestDTO.Password);
            }
            catch(InvalidRequestException ex)
            {
                ErrorDTO errorDTO= new ErrorDTO();
                errorDTO.ErrorCode = "Error_Code_101";
                errorDTO.ErrorMessage = "User is already Registered!";
                response.ErrorDTO= errorDTO;
                return BadRequest(response);
            }
            response.UserId = createdUser.Id;
            response.UserEmail = createdUser.Email;
            response.Password = createdUser.Password;
            return Ok(response);
        }
    }
}
