using Microsoft.Win32;
using Newtonsoft.Json;
using SimpleSystemSpecs.Core.Data.Models;
using System.Management;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;

namespace SimpleSystemSpecs.Core
{
    public class SystemSpecsManager
    {
        public SystemSpecs GetSpecs(bool fielsizeformating)
        {
            try
            {


                SystemSpecs specs2 = new SystemSpecs();
                if (fielsizeformating)
                {

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

                        if (processor_name.GetValue("ProcessorNameString") != null)
                        {
                            string cpuinf = processor_name.GetValue("ProcessorNameString").ToString();
                            specs2.ProcessorName = cpuinf;
                        }
                        ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                        foreach (ManagementObject managementObject in mos.Get())
                        {
                            if (managementObject["TotalVirtualMemorySize"] != null)
                            {
                                managementObject["TotalVirtualMemorySize"].ToString();     //Display operating system version.
                                double num = (long.Parse(managementObject["TotalVirtualMemorySize"].ToString()) / 8)/ (1024 ^ 2);
                                specs2.TotalVirtualMemorySize = Convert.ToString(Math.Round(num))+"GB";
                            }
                            if (managementObject["TotalVisibleMemorySize"] != null)
                            {
                                double num = (long.Parse(managementObject["TotalVisibleMemorySize"].ToString()) / 8) / (1024 ^ 2);
                                specs2.TotalVisibleMemorySize = Convert.ToString(num)+"GB"; 
                            }
                            if (managementObject["TotalSwapSpaceSize"] != null)
                            {
                                specs2.TotalSwapSpaceSize = CommonTools.FormatFilesyzeToCorrectMeasurement(long.Parse(managementObject["TotalSwapSpaceSize"].ToString()));//Display operating system version.

                            }

                            if (managementObject["Caption"] != null)
                            {
                                specs2.OperatingSystemName = managementObject["Caption"].ToString();   //Display operating system caption
                            }
                            if (managementObject["OSArchitecture"] != null)
                            {
                                specs2.OSArchitecture = managementObject["OSArchitecture"].ToString();   //Display operating system architecture.
                            }
                            if (managementObject["CSDVersion"] != null)
                            {
                                specs2.OperatingSystemServicePack = managementObject["CSDVersion"].ToString();     //Display operating system version.
                            }
                            if (managementObject["OtherTypeDescription"] != null)
                            {
                                specs2.OperatingSystemType = managementObject["OtherTypeDescription"].ToString();     //Display operating system version.
                            }
                        }
                    }

                }
                else
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

                        if (processor_name.GetValue("ProcessorNameString") != null)
                        {
                            string cpuinf = processor_name.GetValue("ProcessorNameString").ToString();
                            specs2.ProcessorName = cpuinf;
                        }
                        ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
                        foreach (ManagementObject managementObject in mos.Get())
                        {
                            if (managementObject["TotalVirtualMemorySize"] != null)
                            {
                                managementObject["TotalVirtualMemorySize"].ToString();     //Display operating system version.

                                specs2.TotalVirtualMemorySize = managementObject["TotalVirtualMemorySize"].ToString();
                            }
                            if (managementObject["TotalVisibleMemorySize"] != null)
                            {
                                specs2.TotalVisibleMemorySize = managementObject["TotalVisibleMemorySize"].ToString();//Display operating system version.
                            }
                            if (managementObject["TotalSwapSpaceSize"] != null)
                            {
                                specs2.TotalSwapSpaceSize = managementObject["TotalSwapSpaceSize"].ToString();//Display operating system version.

                            }

                            if (managementObject["Caption"] != null)
                            {
                                specs2.OperatingSystemName = managementObject["Caption"].ToString();   //Display operating system caption
                            }
                            if (managementObject["OSArchitecture"] != null)
                            {
                                specs2.OSArchitecture = managementObject["OSArchitecture"].ToString();   //Display operating system architecture.
                            }
                            if (managementObject["CSDVersion"] != null)
                            {
                                specs2.OperatingSystemServicePack = managementObject["CSDVersion"].ToString();     //Display operating system version.
                            }
                            if (managementObject["OtherTypeDescription"] != null)
                            {
                                specs2.OperatingSystemType = managementObject["OtherTypeDescription"].ToString();     //Display operating system version.
                            }
                        }
                        //Win32_MemoryDevice
                        mos = new ManagementObjectSearcher("select * from CIM_PhysicalMemory");
                        specs2.RAM = new List<RAM>();
                        foreach (ManagementObject managementObject in mos.Get())
                        {
                            RAM ram = new RAM();

                            if (managementObject["DeviceLocator"] != null)
                            {
                                // managementObject["DeviceLocator "].ToString();     //Display operating system version.

                                ram.DeviceLocator = managementObject["DeviceLocator"].ToString();
                            }
                            if (managementObject["Speed"] != null)
                            {


                                ram.Speed = int.Parse(managementObject["Speed"].ToString());
                            }
                            if (managementObject["PartNumber"] != null)
                            {


                                ram.PartNumber = managementObject["PartNumber"].ToString();
                            }
                            if (managementObject["Capacity"] != null)
                            {


                                ram.Capacity = managementObject["Capacity"].ToString();
                            }
                            if (managementObject["MaxVoltage"] != null)
                            {


                                ram.MaxVoltage = int.Parse(managementObject["MaxVoltage"].ToString());
                            }
                            if (managementObject["MinVoltage"] != null)
                            {


                                ram.MinVoltage = int.Parse(managementObject["MinVoltage"].ToString());
                            }


                            specs2.RAM.Add(ram);
                        }
                        //Win32_DiskDrive
                        mos = new ManagementObjectSearcher("select * from Win32_DiskDrive");
                        specs2.DiskDrive = new List<DiskDrive>();
                        foreach (ManagementObject managementObject in mos.Get())
                        {
                            DiskDrive diskDrive = new DiskDrive();
                            if (managementObject["SCSIPort"] != null)
                            {
                                // managementObject["DeviceLocator "].ToString();     //Display operating system version.

                                diskDrive.SCSIPort = int.Parse(managementObject["SCSIPort"].ToString());

                            }
                            if (managementObject["SCSIBus"] != null)
                            {
                                diskDrive.SCSIBus = int.Parse(managementObject["SCSIBus"].ToString());
                            }
                            if (managementObject["SerialNumber"] != null)
                            {
                                diskDrive.SerialNumber = managementObject["SerialNumber"].ToString();
                            }
                            if (managementObject["SCSITargetId"] != null)
                            {
                                diskDrive.SCSITargetId = int.Parse(managementObject["SCSITargetId"].ToString());
                            }
                            if (managementObject["TracksPerCylinder"] != null)
                            {
                                diskDrive.TracksPerCylinder = int.Parse(managementObject["TracksPerCylinder"].ToString());
                            }
                            if (managementObject["Partitions"] != null)
                            {
                                diskDrive.Partitions = int.Parse(managementObject["Partitions"].ToString());
                            }
                            if (managementObject["PNPDeviceID"] != null)
                            {
                                diskDrive.PNPDeviceID = managementObject["PNPDeviceID"].ToString();
                            }
                            if (managementObject["BytesPerSector"] != null)
                            {
                                diskDrive.BytesPerSector = int.Parse(managementObject["BytesPerSector"].ToString());
                            }
                          
                            if (managementObject["Caption"] != null)
                            {
                                diskDrive.Caption = managementObject["Caption"].ToString();
                            }
                            if (managementObject["DeviceID"] != null)
                            {
                                diskDrive.DeviceID = managementObject["DeviceID"].ToString();
                            }
                            if (managementObject["FirmwareRevision"] != null)
                            {
                                diskDrive.FirmwareRevision = managementObject["FirmwareRevision"].ToString();
                            }
                            if (managementObject["InterfaceType"] != null)
                            {
                                diskDrive.InterfaceType = managementObject["InterfaceType"].ToString();
                            }
                            if (managementObject["Name"] != null)
                            {
                                diskDrive.Name = managementObject["Name"].ToString();
                            }
                            if (managementObject["Model"] != null)
                            {
                                diskDrive.Model= managementObject["Model"].ToString();
                            }
                            if (managementObject["Size"] != null)
                            {
                                diskDrive.Size = managementObject["Size"].ToString();
                            }
                            if (managementObject["TotalCylinders"] != null)
                            {
                                diskDrive.TotalCylinders = int.Parse(managementObject["TotalCylinders"].ToString());
                            }
                            if (managementObject["TotalHeads"] != null)
                            {
                                diskDrive.TotalHeads = int.Parse(managementObject["TotalHeads"].ToString());
                            }
                            if (managementObject["TotalSectors"] != null)
                            {
                                diskDrive.TotalSectors = managementObject["TotalSectors"].ToString();
                            }
                            //TotalTracks
                            if (managementObject["TotalTracks"] != null)
                            {
                                diskDrive.TotalTracks = int.Parse(managementObject["TotalTracks"].ToString());
                            }
                            //SectorsPerTrack
                            if (managementObject["SectorsPerTrack"] != null)
                            {
                                diskDrive.SectorsPerTrack = int.Parse(managementObject["SectorsPerTrack"].ToString());
                            }
                            //SCSILogicalUnit
                            if (managementObject["SCSILogicalUnit"] != null)
                            {
                                diskDrive.SCSILogicalUnit = int.Parse(managementObject["SCSILogicalUnit"].ToString());
                            }



                            specs2.DiskDrive.Add(diskDrive);
                        }


                    }
                }
                        return specs2;


                    
                
            }







            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);


                return null;
            }
        }
          public void SaveSpecs(string filename)
        {
            try
            {
                if( !File.Exists(filename) )
                {
                    var specs=GetSpecs(false);
                    if (specs != null)
                    {
                        string json = JsonConvert.SerializeObject(specs);
                        File.WriteAllText(filename, json);
                    }
                }
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);


                 
            }
        }
        public SystemSpecs LoadSpecs(string filename)
        {
            try
            {
                SystemSpecs ap=null;
                if (!File.Exists(filename))
                {
                   
                        string json=File.ReadAllText(filename);
                        if(json!= null)
                        {
                          ap=  JsonConvert.DeserializeObject<SystemSpecs>(json);
                        }

                   
                }
                return ap;
            }
            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);
                return null;


            }
        }
    }
       
}
