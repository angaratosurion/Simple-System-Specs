using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSystemSpecs.Data.Models
{
    public  class SystemSpecs
    {
        public string ProcessorName { get; set; }
        public string TotalVirtualMemorySize { get; set; }
        public string TotalVisibleMemorySize { get; set; }
        public string TotalSwapSpaceSize { get; set; }
        public string OperatingSystemName { get; set; }
        public string OSArchitecture { get; set; }
        public string OperatingSystemServicePack { get; set; }
        public  string OperatingSystemType  { get; set; }
    }
}
