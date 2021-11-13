using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryService.Dtos
{
    public class CreateParcelDto
    {
        public decimal Weight { get; set; }

        public string Recipient { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public int? LockerId { get; set; }
    }
}
