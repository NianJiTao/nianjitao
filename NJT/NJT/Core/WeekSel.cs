using System.Linq;

namespace NJT.Common
{
    public class WeekSel  
    {
        public WeekInfo[] SelList { get; } = new[]
        {
            new WeekInfo(0),
            new WeekInfo(1),
            new WeekInfo(2),
            new WeekInfo(3),
            new WeekInfo(4),
            new WeekInfo(5),
            new WeekInfo(6),
        };

        public void 选择工作日(bool sel)
        {
            foreach (var weekInfo in SelList.Skip(1).Take(5))
            {
                weekInfo.IsChecked = sel;
            }
        }

        public void 选择休息日(bool sel)
        {
            SelList[0].IsChecked
                = SelList[6].IsChecked
                    = sel;
        }

        public void 选择全部(bool sel)
        {
            foreach (var weekInfo in SelList)
            {
                weekInfo.IsChecked = sel;
            }
        }
        public bool[] 取得所选()
        {
            return SelList
                .Select(info => info.IsChecked)
                .ToArray();
        }

        public WeekInfo 星期1
        {
            get { return SelList[1]; }
            set { SelList[1] = value; }
        }

        public WeekInfo 星期2
        {
            get { return SelList[2]; }
            set { SelList[2] = value; }
        }

        public WeekInfo 星期3
        {
            get { return SelList[3]; }
            set { SelList[3] = value; }
        }

        public WeekInfo 星期4
        {
            get { return SelList[4]; }
            set { SelList[4] = value; }
        }

        public WeekInfo 星期5
        {
            get { return SelList[5]; }
            set { SelList[5] = value; }
        }

        public WeekInfo 星期6
        {
            get { return SelList[6]; }
            set { SelList[6] = value; }
        }

        public WeekInfo 星期7
        {
            get { return SelList[0]; }
            set { SelList[0] = value; }
        }
    }
}