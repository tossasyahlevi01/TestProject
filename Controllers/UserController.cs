using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TestProject.DTO;
using TestProject.Models;
using TestProject.Service;

namespace TestProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser _UserService { get; set; }
        public UserController(IUser UserService)
        {
            _UserService = UserService;
        }


        [AllowAnonymous]
        [HttpPost("Logon")]
        public async Task<ActionResult<GeneralResponses>> Logon([FromBody] UserLogonDTO Entity)
        {
            try
            {
                var GetData = await _UserService.Logon(Entity);
                if (GetData.Error == true)
                {
                    return BadRequest(GetData.GetUser);
                }
                else
                {
                    return Ok(GetData.GetUser);
                }

            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(Return);
            }
        }

        [HttpGet("GetListUser")]
        public async Task<ActionResult<GeneralResponses>> GetListUser()
        {
            try
            {
                var GetData = await _UserService.listUser();
                if (GetData.Error == true)
                {
                    return BadRequest(GetData.GetUser);
                }
                else
                {
                    return Ok(GetData.GetUser);
                }

            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(Return);
            }
        }


        [HttpGet("GetDetailUser/{userid}")]
        public async Task<ActionResult<GeneralResponses>> GetDetailUser(string UserId)
        {
            try
            {
                var GetData = await _UserService.GetDetailUser(UserId);
                if (GetData.Error == true)
                {
                    return BadRequest(GetData.GetUser);
                }
                else
                {
                    return Ok(GetData.GetUser);
                }

            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(Return);
            }
        }


        [HttpPost("InsertUser")]
        public async Task<ActionResult<GeneralResponses>> InsertUser([FromBody] UserDTO Entity)
        {
            try
            {
                var GetData = await _UserService.InsertUser(Entity);
                if (GetData.Error == true)
                {
                    return BadRequest(GetData.GetUser);
                }
                else
                {
                    return Ok(GetData.GetUser);
                }

            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(Return);
            }
        }

        [HttpPost("UpdateUser")]
        public async Task<ActionResult<GeneralResponses>> UpdateUser([FromBody] UserDTO Entity)
        {
            try
            {
                var GetData = await _UserService.UpdateUser(Entity);
                if (GetData.Error == true)
                {
                    return BadRequest(GetData.GetUser);
                }
                else
                {
                    return Ok(GetData.GetUser);
                }

            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(Return);
            }
        }

        [HttpGet("DeleteUser/{userid}")]
        public async Task<ActionResult<GeneralResponses>> DeleteUser(string userid)
        {
            try
            {
                var GetData = await _UserService.DeleteUser(userid);
                if (GetData.Error == true)
                {
                    return BadRequest(GetData.GetUser);
                }
                else
                {
                    return Ok(GetData.GetUser);
                }

            }
            catch (Exception ex)
            {
                var Return = new GeneralResponses()
                {
                    Message = ex.Message,
                    IsError = true
                };
                return BadRequest(Return);
            }
        }

    }
}
