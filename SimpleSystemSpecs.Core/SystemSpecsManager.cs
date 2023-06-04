using Microsoft.Win32;
using Newtonsoft.Json;
using SimpleSystemSpecs.Core.Data.Models;
using System.Management;
using System.Runtime.InteropServices;

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

                                specs2.TotalVirtualMemorySize = CommonTools.FormatFilesyzeToCorrectMeasurement(long.Parse(managementObject["TotalVirtualMemorySize"].ToString()));
                            }
                            if (managementObject["TotalVisibleMemorySize"] != null)
                            {
                                specs2.TotalVisibleMemorySize = CommonTools.FormatFilesyzeToCorrectMeasurement(long.Parse(managementObject["TotalVisibleMemorySize"].ToString()));//Display operating system version.
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
