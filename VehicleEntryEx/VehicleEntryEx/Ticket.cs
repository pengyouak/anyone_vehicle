using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace VehicleEntryEx
{
    public class Ticket
    {
        public Ticket() { }

        public string CreateTime { get; set; }
        public string BatchId { get; set; }
        public string ShopId { get; set; }
        public string Owner { get; set; }
        public string TrafficId { get; set; }
        public string ParentClass { get; set; }
        public string SubClass { get; set; }
        public string Detailed { get; set; }
        public string Brand { get; set; }
        public string Origin { get; set; }
        public string WholeWeight { get; set; }
        public string GrossWeight { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public string QuantityP { get; set; }
        public string UnitP { get; set; }
        public string Deposit { get; set; }
        public string Fees { get; set; }
        public string Charges { get; set; }
    }
}
