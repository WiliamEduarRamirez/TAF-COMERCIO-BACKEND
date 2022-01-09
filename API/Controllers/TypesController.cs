using System;
using System.Threading.Tasks;
using Application.Types.Commands;
using Application.Types.DTOs;
using Application.Types.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "admin")]
    public class TypesController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetTypes([FromQuery] TypeParams @params)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query {Params = @params}));
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(TypeCreateDto type)
        {
            return HandleResult(await Mediator.Send(new Create.Command {TypeCreate = type}));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutActivity(Guid id, TypeCreateDto typeUpdate)
        {
            typeUpdate.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command {TypeUpdate = typeUpdate}));
        }
    }
}