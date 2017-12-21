using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Core;

namespace NJT.Prism
{
    public class 状态栏Data2 : ViewModelBase3, I标识Data
    {
        public 状态栏Data2(string 数据cs, string 标识cs)
        {
            标识 = 标识cs;
            数据 = 数据cs;
            显示 = true;
        }

        public 状态栏Data2(string 数据cs)
        {
            标识 = "提示";
            数据 = 数据cs;
            显示 = true;
        }


        public 状态栏Data2()
        {
        }

        /// <summary>
        ///     用来区分数据大类别
        /// </summary>
        /// <value>The 标识.</value>
        public string 标识 { get; set; }

        public string 数据
        {
            get { return GetProperty(() => 数据); }
            set { SetProperty(() => 数据, value); }
        }


        public string 标签
        {
            get { return GetProperty(() => 标签); }
            set { SetProperty(() => 标签, value); }
        }

        public string 提示
        {
            get { return GetProperty(() => 提示); }
            set { SetProperty(() => 提示, value); }
        }

        public bool 显示
        {
            get { return GetProperty(() => 显示); }
            set { SetProperty(() => 显示, value); }
        }
    }
}
