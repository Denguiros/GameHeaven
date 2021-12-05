using System.Collections.Generic;

namespace GameHeaven.Dtos.PaymentDto
{
    public class CreatePaymentDto
    {
        public string PayerId { get; set; }
        public int Amount { get; set; }
        public List<int> GamesIds { get; set; }
    }
}
