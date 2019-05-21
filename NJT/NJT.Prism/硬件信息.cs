using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using NJT.Core;

namespace NJT.Prism
{
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
                          where cs?["SerialNumber"] != null
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
            var b = GetCpu().FirstOrDefault() ?? string.Empty;
            var r = 注册3.GetMd5(a + "_" + b);
            return Base24Encoding.编码toString(Convert.FromBase64String(r)).Remove(12);
        }

    }
}
