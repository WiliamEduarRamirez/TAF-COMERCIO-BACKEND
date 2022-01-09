using System.Threading.Tasks;
using Application.Common.DTOs;
using Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            return HandleResult(await Mediator.Send(new Details.Query {Username = username}));
        }

        /*[HttpPut]
        public async Task<IActionResult> UpdateUser(MemberUpdateDto updateDto)
        {
            return HandleResult(await Mediator.Send(new Edit.Command {MemberUpdate = updateDto}));
        }*/
    }
}