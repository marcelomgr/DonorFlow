using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorFlow.Core.Dtos
{
    public class LocationInfoDTO
    {
        public string Cep { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
