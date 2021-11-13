using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryService.Entities
{
    public class Parcel
    {
        public int Id { get; set; }
        public decimal Weight { get; set; }

        public string Recipient { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public Locker Locker { get; set; }
        public int? LockerId { get; set; }
    }
}
