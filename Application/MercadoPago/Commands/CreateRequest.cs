using System.Threading;
using System.Threading.Tasks;
using Application.Common.DTOs;
using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;

namespace Application.MercadoPago.Commands
{
    public class CreateRequest
    {
        public class Command : IRequest<Result<MercadoPagoRequestResult>>
        {
            public MercadoPagoRequestDto MercadoPagoRequest { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<MercadoPagoRequestResult>>
        {
            private readonly IMercadoPagoAccessor _mercadoPagoAccessor;

            public Handler(IMercadoPagoAccessor mercadoPagoAccessor)
            {
                _mercadoPagoAccessor = mercadoPagoAccessor;
            }   

            public async Task<Result<MercadoPagoRequestResult>> Handle(Command request,
                CancellationToken cancellationToken)
            {
                var response = await _mercadoPagoAccessor.CreateRequestCheckoutApi(request.MercadoPagoRequest);
                return Result<MercadoPagoRequestResult>.Success(response);
            }
        }
    }
}