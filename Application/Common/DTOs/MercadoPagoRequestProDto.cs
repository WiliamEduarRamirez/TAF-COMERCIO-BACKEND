using System;

namespace Application.Common.DTOs
{
    public class MercadoPagoRequestProDto
    {
        public Decimal TransactionAmount { get; set; }
        public string Token { get; set; }
        public string Description { get; set; }
        public int Installments { get; set; }
        public string PaymentMethodId { get; set; }
        public string Email { get; set; }
        public string DocType { get; set; }
        public string DocNumber{ get; set; }
    }
}