using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public interface I硬件信息
    {
        IList<string> Get网卡();
        IList<string> GetCpu();
        IList<string> Get主板();
        IList<string> Get硬盘();
        string Get特征码();

    }
    public class 硬件信息 : I硬件信息
    {
        public IList<string> Get网卡()
        {
            var mc = new ManagementClass("Win32_NetworkAdapter");
            var moCol = mc.GetInstances();
            return
                moCol.Cast<ManagementObject>()
                    .Where(mo => mo != null && mo["MacAddress"] != null)
                    .Select(mo => mo["MACAddress"].ToString())
                    .Where(mac => !string.IsNullOrEmpty(mac))
                    .ToList();
        }

        public IList<string> GetCpu()
        {
            var mc = new ManagementClass("Win32_Processor");
            var moCol = mc.GetInstances();
            return
                moCol.Cast<ManagementObject>()
                    .Where(mo => mo != null && mo["ProcessorId"] != null)
                    .Select(mo => mo["ProcessorId"].ToString())
                    .Where(mac => !string.IsNullOrEmpty(mac))
                    .ToList();
        }

        public IList<string> Get主板()
        {
            try
            {
                var mc = new ManagementClass("WIN32_BaseBoard");
                var moCol = mc.GetInstances();
                var r = moCol.Cast<ManagementObject>()
                        .Where(mo => mo != null)
                        .Select(mo => mo["SerialNumber"].ToString())
                        .Where(mac => !string.IsNullOrEmpty(mac))
                        .ToList();
                return r;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        public IList<string> Get硬盘()
        {
            try
            {
                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                var mo2 = searcher.Get().OfType<ManagementObject>().ToList();
                var sel = from cs in mo2
                          where  cs?["SerialNumber"] != null
                          select cs["SerialNumber"].ToString().Trim();
                return sel.ToList();

            }
            catch
            {
                return new List<string>();
            }
        }

        public string Get特征码()
        {
            var a = Get主板().FirstOrDefault() ?? string.Empty;
            var b = Get硬盘().FirstOrDefault() ?? string.Empty;
            var r = 注册.GetMd5(a + "_" + b);
            return Base24Encoding.编码toString(Convert.FromBase64String(r)).Remove(12);
        }

        //public string 取网卡1()
        //{
        //    return Get网卡().FirstOrDefault();
        //}

        //public List<string> 取Cpu列表()
        //{
        //    var mc = new ManagementClass("Win32_Processor");
        //    var moCol = mc.GetInstances();
        //    return
        //        moCol.Cast<ManagementObject>()
        //            .Where(mo => mo != null && mo["ProcessorId"] != null)
        //            .Select(mo => mo["ProcessorId"].ToString())
        //            .Where(mac => !string.IsNullOrEmpty(mac))
        //            .ToList();
        //}




        //private string 取主板编号()
        //{
        //    try
        //    {
        //        var mc = new ManagementClass("WIN32_BaseBoard");
        //        var moCol = mc.GetInstances();
        //        var r =
        //            moCol.Cast<ManagementObject>()
        //                .Where(mo => mo != null)
        //                .Select(mo => mo["SerialNumber"].ToString())
        //                .Where(mac => !string.IsNullOrEmpty(mac))
        //                .ToList();
        //        return r.FirstOrDefault();
        //    }
        //    catch (Exception)
        //    {
        //        return string.Empty;
        //    }
        //}


        //public string 取CpuId()
        //{
        //    try
        //    {
        //        return 取Cpu列表().FirstOrDefault();
        //    }
        //    catch (Exception)
        //    {
        //        return string.Empty;
        //    }
        //}

        //public static string 特征码组合()
        //{
        //    var 硬件 = new 硬件信息();
        //    var r = 注册.GetMd5(硬件.取主板编号() + "_" + 硬件.取CpuId());
        //    return Base24Encoding.编码toString(Convert.FromBase64String(r)).Remove(12);
        //}

        //public string 取硬盘Id()
        //{
        //    try
        //    {
        //        var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
        //        var strHardDiskId = string.Empty;
        //        foreach (ManagementObject mo in searcher.Get())
        //        {
        //            strHardDiskId = mo["SerialNumber"].ToString().Trim();
        //            break;
        //        }
        //        return strHardDiskId;
        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }
        //}
    }
}
