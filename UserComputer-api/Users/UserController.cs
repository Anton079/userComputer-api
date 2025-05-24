using Microsoft.AspNetCore.Mvc;
using UserComputer_api.Computers.Dtos;
using UserComputer_api.Computers.Exceptions;
using UserComputer_api.Users.Dtos;
using UserComputer_api.Users.Exceptions;
using UserComputer_api.Users.Service;

namespace UserComputer_api.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IQueryServiceUser _queryService;
        private readonly ICommandServiceUser _commandService;

        public UserController(IQueryServiceUser queryService, ICommandServiceUser commandService)
        {
            _queryService = queryService;
            _commandService = commandService;
        }

        [HttpGet("allUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            GetAllUserDto response = await _queryService.GetAllAsync();

            return Ok(response);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserResponse>> CreateUser([FromBody] UserRequest userRequest)
        {
            try
            {
                UserResponse response = await _commandService.CreateUserAsync(userRequest);
                return Created("", response);
            } catch (UserAlreadyExistException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateUser/{id}")]
        public async Task<ActionResult<UserResponse>> UpdateUser(int id, [FromBody] UserUpdateRequest userUpdate)
        {
            try
            {
                UserResponse response = await _commandService.UpdateUserAsync(id, userUpdate);

                return Accepted("", response);
            } catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<ActionResult<UserResponse>> DeleteUser(int id)
        {
            try
            {
                UserResponse response = await _commandService.DeleteUserAsync(id);
                return Accepted("", response);
            } catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("addComputer/{id}")]
        public async Task<ActionResult<ComputerResponse>> AddComputerAsync([FromBody] ComputerRequest computerRequest)
        {
            try
            {
                var response = await _commandService.AddComputerAsync(computerRequest);
                return Created("", response);
            } catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("updateComputer/{idUser}/{idComputer}")]
        public async Task<ActionResult<ComputerResponse>> UpdateComputerAsync([FromRoute] int Iduser, [FromRoute] int idComputer, [FromBody]ComputerUpdateRequest computerUpdate)
        {
            try
            {
                ComputerResponse response = await _commandService.UpdatecomputerAsync(Iduser, idComputer, computerUpdate);
                return Accepted("", response);
            }catch(ComputerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("deleteComputer/{userId}/{computerId}")]
        public async Task<ActionResult<ComputerResponse>> DeleteComputerAsync([FromRoute]int userId, [FromRoute]int computerId)
        {
            try
            {
                ComputerResponse resp = await _commandService.DeleteComputerAsync(userId, computerId);
                return Accepted("", resp);
            }catch(ComputerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }catch(UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
