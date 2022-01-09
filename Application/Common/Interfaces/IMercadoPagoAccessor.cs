using System.Threading.Tasks;
using Application.Common.DTOs;
using Application.MercadoPago;

namespace Application.Common.Interfaces
{
    public interface IMercadoPagoAccessor
    {
        Task<MercadoPagoRequestResult> CreateRequestCheckoutApi(MercadoPagoRequestDto mercadoPagoRequest);
        /*Task<MercadoPagoRequestResult> CreateRequestCheckoutPro(MercadoPagoRequestDto mercadoPagoRequest);*/
    }
}