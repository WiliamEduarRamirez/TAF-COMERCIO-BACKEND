using System.Threading.Tasks;
using Application.Common.DTOs;
using Application.Common.Interfaces;
using Application.MercadoPago;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Microsoft.Extensions.Options;

namespace Infrastructure.MercadoPago
{
    public class MercadoPagoAccessor : IMercadoPagoAccessor
    {
        public MercadoPagoAccessor(IOptions<MercadoPagoSettings> config)
        {
            MercadoPagoConfig.AccessToken = config.Value.AccessToken;
        }

        public async Task<MercadoPagoRequestResult> CreateRequestCheckoutApi(MercadoPagoRequestDto mercadoPagoRequest)
        {
            var paymentRequest = new PaymentCreateRequest()
            {
                TransactionAmount = mercadoPagoRequest.TransactionAmount,
                Token = mercadoPagoRequest.Token,
                Description = mercadoPagoRequest.Description,
                Installments = mercadoPagoRequest.Installments,
                PaymentMethodId = mercadoPagoRequest.PaymentMethodId,
                Payer = new PaymentPayerRequest
                {
                    Email = mercadoPagoRequest.Email,
                    Identification = new IdentificationRequest()
                    {
                        Type = mercadoPagoRequest.DocType,
                        Number = mercadoPagoRequest.DocNumber,
                    },
                },
            };
            var client = new PaymentClient();
            var payment = await client.CreateAsync(paymentRequest);
            return new MercadoPagoRequestResult {Status = payment.Status};
        }

        /*public async Task<MercadoPagoRequestResult> CreateRequestCheckoutPro()
        
        {
        }*/
    }
}