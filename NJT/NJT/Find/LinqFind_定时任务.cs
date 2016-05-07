using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.接口;

namespace NJT.Find
{
    public static partial class LinqFind
    {
        /// <summary>
        /// 找到已经超过执行时间的任务,
        /// </summary>
        /// <param name="任务表"></param>
        /// <returns>list</returns>
        public static List<I定时任务> 查找需要执行的任务(IList<I定时任务> 任务表)
        {
            var find = from cs in 任务表
                       where cs.Is启用
                             && !cs.Is已执行
                             && cs.启动时间 <= DateTime.Now
                       select cs;
            return find.ToList();
        }

        /// <summary>
        /// 找到下一条要执行的任务
        /// </summary>
        /// <param name="任务表"></param>
        /// <returns>I定时任务</returns>
        public static I定时任务 查找即将执行的任务(IList<I定时任务> 任务表)
        {
            var find = from cs in 任务表
                       where cs.Is启用
                        && !cs.Is已执行
                             && cs.启动时间 >= DateTime.Now
                       orderby cs.启动时间
                       select cs;
            return find.FirstOrDefault();

        }
        /// <summary>
        /// 找到已经执行过的任务.list
        /// </summary>
        /// <param name="任务表"></param>
        /// <returns>List</returns>
        public static List<I定时任务> 查找已经执行的任务(IList<I定时任务> 任务表)
        {
            var find = from cs in 任务表
                       where cs.Is已执行
                       select cs;
            return find.ToList();
        }
        /// <summary>
        /// 找到进入倒计时的任务.
        /// </summary>
        /// <param name="任务表"></param>
        /// <param name="倒计时间隔"></param>
        /// <returns>List</returns>
        public static List<I定时任务> 查找进入倒计时的任务(IList<I定时任务> 任务表, TimeSpan 倒计时间隔)
        {
            var find = from cs in 任务表
                       where cs.Is启用
                             && !cs.Is倒计时
                             && cs.启动时间 >= DateTime.Now
                             && cs.启动时间 - DateTime.Now <= 倒计时间隔
                       select cs;
            return find.ToList();

        }

    }
}
