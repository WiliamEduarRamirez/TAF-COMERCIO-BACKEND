using System.Threading.Tasks;
using Application.Common.DTOs;
using Application.MercadoPago.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    public class PaymentsController : BaseApiController

    {
        [HttpPost("mercado-pago")]
        public async Task<IActionResult> Add(MercadoPagoRequestDto mercadoPagoRequest)
        {
            return HandleResult(
                await Mediator.Send(new CreateRequest.Command {MercadoPagoRequest = mercadoPagoRequest}));
        }
    }
}