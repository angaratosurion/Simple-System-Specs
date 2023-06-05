using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSystemSpecs.Core.Data.Models
{
    public class RAM
    {

        public string DeviceLocator { get; set; }
        public int MinVoltage { get; set; }
        public int MaxVoltage { get; set; }
        public string PartNumber { get; set; }
        public int Speed { get; set; }
        public string Capacity { get; set; }


    }
}
