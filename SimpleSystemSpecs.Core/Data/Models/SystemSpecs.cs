using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSystemSpecs.Core.Data.Models
{
    public  class SystemSpecs
    {
        [DisplayName("Processor Name")]
        public string ProcessorName { get; set; }
        [DisplayName("Total Virtual Memory Size")]
        public string TotalVirtualMemorySize { get; set; }
        [DisplayName("Total Visible Memory Size")]
        public string TotalVisibleMemorySize { get; set; }
        [DisplayName("Total Swap Space Size")]
        public string TotalSwapSpaceSize { get; set; }
        [DisplayName("Operating System")]
        public string OperatingSystemName { get; set; }
        [DisplayName("OSArchitecture")]
        public string OSArchitecture { get; set; }
        [DisplayName("Operating System Service Pack")]
        public string OperatingSystemServicePack { get; set; }
        [DisplayName("Operating System Type")]
        public  string OperatingSystemType  { get; set; }
        public List<RAM> RAM { get; set; }
        public List<DiskDrive> DiskDrive { get; set; }

    }
}
