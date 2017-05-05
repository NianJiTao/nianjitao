using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    /// <summary>
    /// 检测事件发生的频率是否过高.
    /// </summary>
    public static class 超频检测
    {
        private static readonly Dictionary<string, DateTime> 历史 = new Dictionary<string, DateTime>();


        /// <summary>
        /// 发生频率过高.返回true
        /// </summary>
        /// <param name="事件名"></param>
        /// <param name="最短间隔"></param>
        /// <returns></returns>
        public static bool Is超频(string 事件名, TimeSpan 最短间隔)
        {
            if (历史.ContainsKey(事件名))
            {
                if (DateTime.Now - 历史[事件名] > 最短间隔)
                {
                    历史[事件名] = DateTime.Now;
                    return false;
                }
                return true;
            }
            历史.Add(事件名, DateTime.Now);
            return false;
        }
    }
}
