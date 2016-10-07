using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NJT.Common
{
    public static class 角度计算
    {
        /// <summary>
        /// 反正切 计算顺时针角度为正. 距12点正的角度. 
        /// 使用反正切函数计算角度. 当前角度的对边 比 临边. 反正切计算后为弧度. 再转换为角度.
        /// ↑: 0 , ↖:-45, ↗:45, →: 90
        /// </summary>
        /// <param name="源Point">The 源 point.</param>
        /// <param name="目标Point">The 目标 point.</param>
        /// <returns>System.Int32.</returns>
        public static double 时钟角度(Point 源Point, Point 目标Point)
        {
            double 角度2 = 0;
            try
            {
                角度2 = Math.Atan((目标Point.X - 源Point.X) / (源Point.Y - 目标Point.Y)) * 180 / Math.PI;
            }
            catch (Exception)
            {
                角度2 = 0;
            }
            return 角度2;
        }
    }
}
