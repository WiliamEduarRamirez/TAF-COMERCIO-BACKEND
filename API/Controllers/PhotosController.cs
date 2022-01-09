using System;
using System.Threading.Tasks;
using Application.Photos.Commands;
using Application.Photos.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "admin")]
    public class PhotosController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Add.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpGet("products/{id:guid}")]
        public async Task<IActionResult> GetPhotosProduct(Guid id)
        {
            return HandleResult(await Mediator.Send(new List.Query {ProductId = id}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command {PhotoId = id}));
        }

        [HttpPost("{id}/setMain")]
        public async Task<IActionResult> SetMain(string id, SetMain.Command data)
        {
            data.PhotoId = id;
            return HandleResult(await Mediator.Send(data));
        }
    }
}