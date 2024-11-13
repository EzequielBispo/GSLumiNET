using GSLumiNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSLumiNET.Domain.DTOs
{
    public class RegistroDTO
    {
        public DateTime Data { get; set; }
        public double IExterna { get; set; }
        public double IInterna { get; set; }
        public double ILampada { get; set; }
    }
}
