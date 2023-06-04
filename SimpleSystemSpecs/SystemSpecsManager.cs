using Microsoft.Win32;
using SimpleSystemSpecs;
using SimpleSystemSpecs.Data.Models;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SlimeWeb.Core.Tools
{
    public class SystemSpecsManager
    {
        public SystemSpecs GetSpecs()
        {
            try
            {


                SystemSpecs specs2 = new SystemSpecs();

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
                            specs2.TotalVirtualMemorySize = managementObject["TotalVirtualMemorySize"].ToString();     //Display operating system version.
                        }
                        if (managementObject["TotalVisibleMemorySize"] != null)
                        {
                            specs2.TotalVisibleMemorySize = managementObject["TotalVisibleMemorySize"].ToString();     //Display operating system version.
                        }
                        if (managementObject["TotalSwapSpaceSize"] != null)
                        {
                            specs2.TotalSwapSpaceSize = managementObject["TotalSwapSpaceSize"].ToString();     //Display operating system version.
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
                return specs2;

            }







            catch (Exception ex)
            {
                CommonTools.ErrorReporting(ex);


                return null;
            }
        }
    }
       
}
