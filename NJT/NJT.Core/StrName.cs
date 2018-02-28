using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public static partial class StrName
    {

        public static class 格式化
        {
            public static string 读取配置值 = "未注册{0},使用默认值{1}";
            public static string 启动监测服务失败 = "{0}未启用,{1}服务关闭";
            public static string 启动监测服务成功 = "{0}服务已启动";
            public static string 启动定时服务成功 = "{0}服务启动成功-间隔:{1}";
            public static string 启动定时服务失败 = "{0}服务启动失败";
            public static string 数据刷新完成 = "{0}数据刷新完成";
            public static string 数据刷新错误 = "{0}数据刷新错误";
        }
     
        public static class 其他
        {
            public static string 当前协议 = "当前协议";
            public static string SqlServer1 = "SqlServer1";
            public static string SqlServer2 = "SqlServer2";
            public static string SqlServer3 = "SqlServer3";
            public static string SqlServer4 = "SqlServer4";
            public static string 贵宾授权版本 = "贵宾授权版本";
            public static string 隐藏按钮 = "隐藏按钮";
            public static string 日志记录保留长度 = "日志记录保留长度";
        }



        public static class 状态栏
        {
            public static string 授权 = "授权";
            public static string Opc = "Opc";
            public static string 用户 = "用户";
            public static string 提示 = "提示";

            public static string 心跳 = "心跳";
            public static string 数据库 = "数据库";
            public static string 数据库2 = "数据库2";
            public static string 数据库3 = "数据库3";
            public static string 数据库4 = "数据库4";
            public static string 客户端 = "客户端";
            public static string 服务端 = "服务端";
        }

        /// <summary>
        /// 记录视图的唯一名称,以便查找激活.不能有空格,不能有中文等.
        /// </summary>
        public static class View
        {
            public static string 关于视图 = "InfoView";
            public static string 菜单视图 = "MenuView";
            public static string 日志视图 = "LogView";
            public static string 设置视图 = "SettheView";
            public static string 系统设置视图 = "SystemsetupView";
            public static string 系统注册视图 = "SystemregistryView";
            public static string 状态栏视图 = "StatusbarView";
            public static string 用户管理视图 = "User_management_view";
            public static string 用户编辑视图 = "User_edit_view";
        }



        public static class 导出格式
        {
            public static string Iba = "iba";
            public static string Xlsx = "xlsx";
            public static string Pdf = "pdf";
            public static string Csv = "csv";
        }
    }
}
