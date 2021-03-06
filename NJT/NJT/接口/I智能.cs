﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace NJT.接口
{
    public interface I泛型<T>
    {
        T 数据 { get; set; }
    }

    public interface I智能模块
    {
        I智能 智能 { get; set; }
    }


    public interface I智能
    {
        dynamic 宿主 { get; set; }
        IDictionary<string, dynamic> 技能表 { get; }

        /// <summary>
        ///     学习:技能名称 和 技能
        ///     技能可以是属性,方法,动态对象.
        /// </summary>
        /// <value>The 学习.</value>
        Action<string, dynamic> 学习 { get; set; }

        /// <summary>
        ///     根据名称查找技能,找不到返回null
        /// </summary>
        /// <value>The 使用.</value>
        Func<string, dynamic> 使用 { get; set; }
    }

    /// <summary>
    ///     Class 智能. 可以扩展类的功能.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class 智能1 : I智能
    {
        public 智能1(dynamic 宿主cs)
        {
            宿主 = 宿主cs;
            技能表 = new ConcurrentDictionary<string, dynamic>();
            学习 = 学习方法;
            使用 = 使用方法;
        }

        public dynamic 动态属性 { get; set; }
        public dynamic 宿主 { get; set; }
        public IDictionary<string, dynamic> 技能表 { get; private set; }
        public Action<string, dynamic> 学习 { get; set; }
        public Func<string, dynamic> 使用 { get; set; }

        public void 学习方法(string 名称, dynamic 技能)
        {
            if (!技能表.ContainsKey(名称))
            {
                技能表.Add(名称, 技能);
            }
            else
            {
                技能表[名称] = 技能;
            }
        }

        public dynamic 使用方法(string 名称)
        {
            return 技能表.ContainsKey(名称) ? 技能表[名称] : null;
        }
    }
}