using System;
using System.Collections.Generic;

namespace DTOs
{
    [Serializable]
    public class Order
    {
        public int OrderId { get; set; }

        public Customer Customer { get; set; }

        public string Comments { get; set; }

        public List<SalesItem> OrderLines { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public DateTime ConfirmationDate { get; set; }

        public double TotalPrice { get; set; }

        public PersonAuth ResponsibleSeller { get; set; }
    }
}
