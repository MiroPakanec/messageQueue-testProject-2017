using System;
using System.Collections.Generic;

namespace DTOs
{
    [Serializable]
    public class SalesItem
    {
        public int SalesId { get; set; }

        public string Description { get; set; }

        public double TotalLinePrice { get; set; }

        public double Quantity { get; set; }

        public Item Product { get; set; }

        public DateTime ReservationDate { get; set; }
    }
}