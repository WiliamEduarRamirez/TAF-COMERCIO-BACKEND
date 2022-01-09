using System;
using System.Threading.Tasks;
using Application.Categories.Commands;
using Application.Categories.DTOs;
using Application.Categories.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoriesController : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] CategoryParams @params)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query {Params = @params}));
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(CategoryCreatedDto category)
        {
            return HandleResult(await Mediator.Send(new Create.Command {CategoryCreated = category}));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutActivity(Guid id, CategoryCreatedDto categoryUpdated)
        {
            categoryUpdated.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command {CategoryUpdated = categoryUpdated}));
        }
    }
}