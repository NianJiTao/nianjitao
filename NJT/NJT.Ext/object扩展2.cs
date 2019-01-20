using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NJT.Core;

namespace NJT.Ext
{
    public static partial class 扩展
    {
        /// <summary>
        /// 根据参数引用,返回提取是否成功,和参数值
        /// 支持多级参数,用.分割;如:忠旺退火炉卷信息.[0].铝卷号
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="参数引用"></param>
        /// <returns></returns>
        public static I运行结果<object> Get参数值(this object obj, string 参数引用)
        {
            if (obj == null)
                return new 运行结果<object>(false, "参数为空") {Data = null};

            if (string.IsNullOrEmpty(参数引用))
                return new 运行结果<object>(true) {Data = obj};

            var 子级参数 = 参数引用.To分割(".");
            var 待提取 = obj;
            I运行结果<object> r = new 运行结果<object>(true) {Data = obj};
            foreach (var s in 子级参数)
            {
                r = Get参数值2(待提取, s);
                待提取 = r.Data;
            }

            return r;
        }

        private static I运行结果<object> Get参数值2(object obj, string 参数引用)
        {
            //匹配 [0] 或者[]
            var is索引 = Regex.Match(参数引用, "\\[\\d*\\]");
            if (!is索引.Success)
            {
                var propertiesList = obj.GetPropertiesList();
                var propertyInfo = propertiesList.FirstOrDefault(x => x.Name == 参数引用);
                if (propertyInfo == null)
                {
                    return new 运行结果<object>(false, "未找到参数") {Data = obj};
                }

                var r = RunFunc.TryRun(() => propertyInfo.GetValue(obj));
                if (!r.IsTrue) r.Data = obj;

                return r;
            }

            var index = 参数引用.GetNumber();

            if (obj is IEnumerable<object> coll2)
            {
                var r = coll2.Count() > index
                    ? new 运行结果<object>(true) {Data = coll2.Skip(index).FirstOrDefault()}
                    : new 运行结果<object>(false, $"{index}索引太大") {Data = coll2};

                return r;
            }

            return new 运行结果<object>(false, $"{参数引用}不是集合") {Data = obj};
        }
    }
}