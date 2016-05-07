using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NJT.Common;
using NJT.Events;
using NJT.接口;

namespace NJT.ViewModels
{
    public class 状态栏视图ViewModel : Vm基类<dynamic>
    {
        private readonly IDictionary<string, 状态栏Data1> 属性列表;

        public 状态栏视图ViewModel()
        {
            属性列表 = new ConcurrentDictionary<string, 状态栏Data1>();
            新闻部 = 小冰.宣传部;

            事件订阅();

            初始化();
        }

        public 状态栏Data1 提示 { get; set; }
        public 状态栏Data1 授权 { get; set; }

        private void 初始化()
        {
            提示 = new 状态栏Data1("提示", "初始化");
            属性列表.Add("提示", 提示);

            授权 = new 状态栏Data1("授权", "初始化");
            属性列表.Add("授权", 授权);
        }

        private void 事件订阅()
        {
            新闻部.GetEvent<状态栏更新Event>().Subscribe(状态更新Action, true);
        }

        private void 状态更新Action(I状态栏Data obj)
        {
            if (属性列表.ContainsKey(obj.标识))
            {
                属性列表[obj.标识].数据 = obj.数据;
            }
        }
    }
}
