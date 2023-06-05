using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSystemSpecs.Core.Data.Models
{
    public class DiskDrive
    {
        public string DeviceID { get; set; }
        public int Partitions { get; set; }
        public int BytesPerSector { get; set; }
        public string InterfaceType { get; set; }
        public int SectorsPerTrack { get; set; }
        public string Size { get; set; }
        public  int TotalCylinders { get; set; }
        public int TotalHeads { get; set; }
        public string TotalSectors { get; set; }
        public int TotalTracks { get; set; }
        public  int  TracksPerCylinder { get; set; }
        
        public string Caption { get; set; }
        public string FirmwareRevision { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string PNPDeviceID { get; set; }
        public int SCSIBus { get; set; }
        public int SCSIPort { get; set; }
        public int SCSILogicalUnit { get; set; }
        public int SCSITargetId { get; set; }
        public string SerialNumber { get; set; }





    }
}
