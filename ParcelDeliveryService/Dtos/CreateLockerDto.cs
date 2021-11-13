using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelDeliveryService.Dtos
{
    public class CreateLockerDto
    {
        public string Code { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
    }
}
