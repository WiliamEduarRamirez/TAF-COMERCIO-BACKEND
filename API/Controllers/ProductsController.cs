using System;
using System.Threading.Tasks;
using Application.Products.Commands;
using Application.Products.DTOs;
using Application.Products.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductsController : BaseApiController
    {
        /*/api/Products*/
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query {Params = param}));
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            /*null, */
            var response = await Mediator.Send(new Details.Query {Id = id});
            /*null, error, success, value*/
            return HandleResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductCreatedDto product)
        {
            return HandleResult(await Mediator.Send(new Create.Command {ProductCreated = product}));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> PutActivity(Guid id, ProductCreatedDto product)
        {
            product.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command {ProductUpdated = product}));
        }

        [HttpPut("{id:guid}/changeStatus")]
        public async Task<IActionResult> PutActivityEstate(Guid id, ProductPatchDto productPatch)
        {
            return HandleResult(await Mediator.Send(new ChangeStatus.Command {Id = id, ProductPatch = productPatch}));
        }
    }
}