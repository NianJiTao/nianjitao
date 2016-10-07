using NJT.接口;

namespace NJT.Common
{
    public static class 动态学习
    {
        public static void 学习(I智能 对象, string 名称, dynamic 技能)
        {
            if (!对象.技能表.ContainsKey(名称))
            {
                对象.技能表.Add(名称, 技能);
            }
            else
            {
                对象.技能表[名称] = 技能;
            }
        }

        public static dynamic 使用(I智能 对象, string 名称)
        {
            return 对象.技能表.ContainsKey(名称) ? 对象.技能表[名称] : null;
        }
    }
}