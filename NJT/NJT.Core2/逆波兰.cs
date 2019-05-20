using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NJT.Core
{
    public class 逆波兰
    {
        /// <summary>
        ///     算术逆波兰表达式计算.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static 运行结果<double> 计算(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return new 运行结果<double>(false){Data = 0d};
            }
            var 二目运算符 = "^*/+-";
            var S = 逆波兰表达式转换(s);
            var tmp = "";
            var sk = new Stack();
            var c = ' ';
            var operand = new StringBuilder();
            double x, y;
            for (var i = 0; i < S.Length; i++)
            {
                c = S[i];
                if (char.IsDigit(c) || c == '.')
                {
                    //数据值收集.  
                    operand.Append(c);
                }
                else if (c == ' ' && operand.Length > 0)
                {
                    #region 运算数转换

                    try
                    {
                        tmp = operand.ToString();
                        if (tmp.StartsWith("-"))
                            sk.Push(-Convert.ToDouble(tmp.Substring(1, tmp.Length - 1)));
                        else
                            sk.Push(Convert.ToDouble(tmp));
                    }
                    catch
                    {
                        return new 运行结果<double>(false, "发现异常数据值.");
                    }
                    operand = new StringBuilder();

                    #endregion
                }
                else if (二目运算符.Contains(c))
                {
                    #region 双目运算

                    if (sk.Count > 0) /**************************/
                    {
                        y = (double)sk.Pop();
                    }
                    else
                    {
                        sk.Push(0d);
                        break;
                    }
                    if (sk.Count > 0)
                    {
                        x = (double)sk.Pop();
                    }
                    else
                    {
                        sk.Push(y);
                        break;
                    }
                    switch (c)
                    {
                        case '+':
                            sk.Push(x + y);
                            break;
                        case '-':
                            sk.Push(x - y);
                            break;
                        case '*':
                            sk.Push(x * y);
                            break;
                        case '/':
                            sk.Push(x / y);
                            break;
                        case '%':
                            sk.Push(x % y);
                            break;
                        case '^':
                            sk.Push(Math.Pow(x, y));
                            break;
                    }

                    #endregion
                }
                else if (c == '!') //单目取反.)  
                {
                    if (sk.Count > 0)
                        sk.Push(-(double)sk.Pop());
                }
            }
            if (sk.Count > 1)
                return new 运行结果<double>(false, "运算没有完成.");
            if (sk.Count == 0)
                return new 运行结果<double>(false, "结果丢失.");
            var r = sk.Pop();
            //return new 运行结果<double>(true) { Data = Convert.ToDouble(r) };

            if (r is double d)
            {
                return new 运行结果<double>(true) { Data = d };
            }
            else
            {
                return new 运行结果<double>(false, "结果不是数值") { Data = Convert.ToDouble(r) };
            }
        }

        /// <summary>
        ///     Reverse Polish Notation
        ///     算术逆波兰表达式.生成.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string 逆波兰表达式转换(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            var 运算符 = "()!^%.*/+-";
            StringBuilder sb;

            var sk = new Stack<char>();
            var re = new StringBuilder();
            var c = ' ';
            var op = "!^%.*/+-";
            foreach (var item in s)
                if (char.IsDigit(item) || 运算符.Contains(item))
                    re.Append(item);

            sb = new StringBuilder(re.ToString());

            #region 对负号进行预转义处理.

            for (var i = 0; i < sb.Length - 1; i++)
                if (sb[i] == '-' && (i == 0 || sb[i - 1] == '(' || Power(sb[i - 1]) > 0))
                    sb[i] = '!'; //字符转义.  

            #endregion

            #region 将中缀表达式变为后缀表达式.

            re = new StringBuilder();
            for (var i = 0; i < sb.Length; i++)
                if (char.IsDigit(sb[i]) || sb[i] == '.') //如果是数值.  
                {
                    re.Append(sb[i]); //加入后缀式  
                }
                else if (op.Contains(sb[i])) //.  
                {
                    #region 运算符处理

                    while (sk.Count > 0) //栈不为空时  
                    {
                        c = sk.Pop(); //将栈中的操作符弹出.  
                        if (c == '(') //如果发现左括号.停.  
                        {
                            sk.Push(c); //将弹出的左括号压回.因为还有右括号要和它匹配.  
                            break; //中断.  
                        }
                        if (Power(c) < Power(sb[i])) //如果优先级比上次的高,则压栈.  
                        {
                            sk.Push(c);
                            break;
                        }
                        re.Append(' ');
                        re.Append(c);
                        //如果不是左括号,那么将操作符加入后缀式中.  
                    }
                    sk.Push(sb[i]); //把新操作符入栈.  
                    re.Append(' ');

                    #endregion
                }
                else if (sb[i] == '(') //基本优先级提升  
                {
                    sk.Push('(');
                    re.Append(' ');
                }
                else if (sb[i] == ')') //基本优先级下调  
                {
                    while (sk.Count > 0) //栈不为空时  
                    {
                        c = sk.Pop(); //pop Operator  
                        if (c != '(')
                        {
                            re.Append(' ');
                            re.Append(c);
                            re.Append(' ');
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    re.Append(sb[i]);
                }
            while (sk.Count > 0)
            {
                re.Append(' ');
                re.Append(sk.Pop());
            }

            #endregion

            re.Append(' ');
            return FormatSpace(re.ToString());
        }

        /// <summary>
        ///     优先级别测试函数.
        /// </summary>
        /// <param name="opr"></param>
        /// <returns></returns>
        private static int Power(char opr)
        {
            switch (opr)
            {
                case '+':
                    return 1;
                case '-':
                    return 1;
                case '*':
                    return 2;
                case '/':
                    return 2;
                case '%':
                    return 3;
                case '^':
                    return 3;
                case '!':
                    return 4;
                default:
                    return 0;
            }
        }

        /// <summary>
        ///     规范化逆波兰表达式.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string FormatSpace(string s)
        {
            var ret = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
                if (!(s.Length > i + 1 && s[i] == ' ' && s[i + 1] == ' '))
                    ret.Append(s[i]);
                else
                    ret.Append(s[i]);
            return ret.ToString(); //.Replace('!','-');  
        }
    }
}