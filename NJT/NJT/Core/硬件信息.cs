//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Management;
//using System.Text;
//using System.Threading.Tasks;

//namespace NJT.Common
//{

//    public class 硬件信息
//    {
//        public List<string> 网卡列表()
//        {
//            var mc = new ManagementClass("Win32_NetworkAdapter");
//            var moCol = mc.GetInstances();
//            return
//                moCol.Cast<ManagementObject>()
//                    .Where(mo => mo != null && mo["MacAddress"] != null)
//                    .Select(mo => mo["MACAddress"].ToString())
//                    .Where(mac => !string.IsNullOrEmpty(mac))
//                    .ToList();
//        }

//        public string 取网卡1()
//        {
//            return 网卡列表().FirstOrDefault();
//        }

//        public List<string> 取Cpu列表()
//        {
//            var mc = new ManagementClass("Win32_Processor");
//            var moCol = mc.GetInstances();
//            return
//                moCol.Cast<ManagementObject>()
//                    .Where(mo => mo != null && mo["ProcessorId"] != null)
//                    .Select(mo => mo["ProcessorId"].ToString())
//                    .Where(mac => !string.IsNullOrEmpty(mac))
//                    .ToList();
//        }

//        public List<string> 取所有列表()
//        {
//            var r = new List<string>();
//            r.Add("主板:");
//            r.Add(取主板编号());
//            r.Add("硬盘:");
//            r.Add(取硬盘Id());
//            r.Add("CPU:");
//            r.Add(取CpuId());
//            r.Add("主机名:");
//            r.Add(Environment.MachineName);
//            r.Add("网卡:");
//            r.Add(取网卡1());
//            return r;
//        }


//        private string 取主板编号()
//        {
//            try
//            {
//                var mc = new ManagementClass("WIN32_BaseBoard");
//                var moCol = mc.GetInstances();
//                var r =
//                    moCol.Cast<ManagementObject>()
//                        .Where(mo => mo != null)
//                        .Select(mo => mo["SerialNumber"].ToString())
//                        .Where(mac => !string.IsNullOrEmpty(mac))
//                        .ToList();
//                return r.FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                return string.Empty;
//            }
//        }


//        public string 取CpuId()
//        {
//            try
//            {
//                return 取Cpu列表().FirstOrDefault();
//            }
//            catch (Exception)
//            {
//                return string.Empty;
//            }
//        }

//        public static string 特征码组合()
//        {
//            var 硬件 = new 硬件信息();
//            var r = 注册.计算Md5(硬件.取主板编号() + "_" + 硬件.取CpuId());
//            return Base24Encoding.编码toString(Convert.FromBase64String(r)).Remove(12);
//        }

//        public string 取硬盘Id()
//        {
//            try
//            {
//                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
//                var strHardDiskId = string.Empty;
//                foreach (ManagementObject mo in searcher.Get())
//                {
//                    strHardDiskId = mo["SerialNumber"].ToString().Trim();
//                    break;
//                }
//                return strHardDiskId;
//            }
//            catch
//            {
//                return string.Empty;
//            }
//        }
//    }
//    //public class 硬件信息
//    //{
//    //    public List<string> 网卡列表()
//    //    {
//    //        var mc = new ManagementClass("Win32_NetworkAdapter");
//    //        var moCol = mc.GetInstances();
//    //        return
//    //            moCol.Cast<ManagementObject>()
//    //                .Where(mo => mo != null && mo["MacAddress"] != null)
//    //                .Select(mo => mo["MACAddress"].ToString())
//    //                .Where(mac => !string.IsNullOrEmpty(mac))
//    //                .ToList();
//    //    }

//    //    public string 取网卡1()
//    //    {
//    //        return 网卡列表().FirstOrDefault();
//    //    }

//    //    public List<string> 取Cpu列表()
//    //    {
//    //        var mc = new ManagementClass("Win32_Processor");
//    //        var moCol = mc.GetInstances();
//    //        return
//    //            moCol.Cast<ManagementObject>()
//    //                .Where(mo => mo != null && mo["ProcessorId"] != null)
//    //                .Select(mo => mo["ProcessorId"].ToString())
//    //                .Where(mac => !string.IsNullOrEmpty(mac))
//    //                .ToList();
//    //    }

//    //    public List<string> 取所有列表()
//    //    {
//    //        var r = new List<string>();
//    //        r.Add("主板:");
//    //        r.Add(取主板编号());
//    //        r.Add("硬盘:");
//    //        r.Add(取硬盘Id());
//    //        r.Add("CPU:");
//    //        r.Add(取CpuId());
//    //        r.Add("主机名:");
//    //        r.Add(Environment.MachineName);
//    //        r.Add("网卡:");
//    //        r.Add(取网卡1());
//    //        return r;
//    //    }


//    //    private String 取主板编号()
//    //    {
//    //        try
//    //        {
//    //            var mc = new ManagementClass("WIN32_BaseBoard");
//    //            var moCol = mc.GetInstances();
//    //            var r =
//    //                moCol.Cast<ManagementObject>()
//    //                    .Where(mo => mo != null)
//    //                    .Select(mo => mo["SerialNumber"].ToString())
//    //                    .Where(mac => !string.IsNullOrEmpty(mac))
//    //                    .ToList();
//    //            return r.FirstOrDefault();
//    //        }
//    //        catch (Exception)
//    //        {
//    //            return string.Empty;
//    //        }
//    //    }


//    //    public String 取CpuId()
//    //    {
//    //        try
//    //        {
//    //            return 取Cpu列表().FirstOrDefault();
//    //        }
//    //        catch (Exception)
//    //        {
//    //            return string.Empty;
//    //        }
//    //    }

//    //    public static String 特征码组合()
//    //    {
//    //        var 硬件 = new 硬件信息();
//    //        var r = 注册.计算Md5(硬件.取主板编号() + "_" + 硬件.取CpuId());
//    //        return  Base24Encoding.GetString(Convert.FromBase64String(r)).Remove(12);
//    //    }

//    //    public String 取硬盘Id()
//    //    {
//    //        try
//    //        {
//    //            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
//    //            var strHardDiskId = string.Empty;
//    //            foreach (ManagementObject mo in searcher.Get())
//    //            {
//    //                strHardDiskId = mo["SerialNumber"].ToString().Trim();
//    //                break;
//    //            }
//    //            return strHardDiskId;
//    //        }
//    //        catch
//    //        {
//    //            return string.Empty;
//    //        }
//    //    }
//    //}
//}
