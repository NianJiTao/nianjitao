﻿using System;
 

namespace NJT.Prism
{
    /// <summary>
    ///     收到此事件.就打开帮助视图.或者帮助文件
    /// </summary>
    public class Event打开帮助 : EventArgs
    {
    }

    /// <summary>
    ///     收到此事件.就打开关于视图.
    /// </summary>
    public class Event打开关于 : EventArgs
    {
    }

    /// <summary>
    ///     收到此事件.就打开注册视图.
    /// </summary>
    public class Event打开注册 : EventArgs
    {
    }
}