using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParcelDeliveryService.Entities
{
    public class Locker
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }

        [JsonIgnore]
        public List<Parcel> Parcels { get; set; }
    }
}
