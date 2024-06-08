using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonorFlow.Core.ValueObjects
{
    public record LocationInfo(string Cep, string Address, string District, string City, string State)
    {
    }
}
