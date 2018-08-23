using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Core;
using NJT.Prism;

namespace NJT.UI
{
    public class 主题助手
    {
        public static void 保存主题()
        {
            ApplicationThemeHelper.SaveApplicationThemeName();
            消息.更新状态栏("保存主题成功");
        }

        public static void 默认主题()
        {
            ApplicationThemeHelper.ApplicationThemeName = "DeepBlue";
            ApplicationThemeHelper.UpdateApplicationThemeName();
            保存主题();
            消息.更新状态栏("调用主题:DeepBlue");
        }
    }
}
