using System;

namespace Doge.WebApp.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public DateTime RequiredShippedTime { get; set; }
        public string ShipTo { get; set; }
    }
}