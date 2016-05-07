using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Common
{
    public class 逆波兰计算
    {
        /// <summary>  
        /// 算术逆波兰表达式计算.  
        /// </summary>  
        /// <param name="s"></param>  
        /// <returns></returns>  
        public static string 逆波兰表达式计算(string s)
        {
            var 二目运算符 = "^*/+-";
            var S = 逆波兰表达式转换(s);
            var tmp = "";
            //Stack<char> sk = new Stack<char>();
            var sk = new System.Collections.Stack();
            var c = ' ';
            var Operand = new System.Text.StringBuilder();
            double x, y;
            for (var i = 0; i < S.Length; i++)
            {
                c = S[i];
                if (char.IsDigit(c) || c == '.')
                {
                    //数据值收集.  
                    Operand.Append(c);
                }
                else if (c == ' ' && Operand.Length > 0)
                {
                    #region 运算数转换

                    try
                    {
                        tmp = Operand.ToString();
                        if (tmp.StartsWith("-"))
                        {
                            sk.Push(-((double)Convert.ToDouble(tmp.Substring(1, tmp.Length - 1))));
                        }
                        else
                        {
                            sk.Push(Convert.ToDouble(tmp));
                        }
                    }
                    catch
                    {
                        return "发现异常数据值.";
                    }
                    Operand = new System.Text.StringBuilder();

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
                        sk.Push(0);
                        break;
                    }
                    if (sk.Count > 0)
                        x = (double)sk.Pop();
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
                            sk.Push(System.Math.Pow(x, y));
                            break;
                    }

                    #endregion
                }
                else if (c == '!') //单目取反.)  
                {
                    sk.Push(-((double)sk.Pop()));
                }
            }
            if (sk.Count > 1)
                return "运算没有完成.";
            if (sk.Count == 0)
                return "结果丢失..";
            return sk.Pop().ToString();
        }

        /// <summary>  
        /// Reverse Polish Notation  
        /// 算术逆波兰表达式.生成.  
        /// </summary>  
        /// <param name="s"></param>  
        /// <returns></returns>   
        private static string 逆波兰表达式转换(string s)
        {
            var 运算符 = "()!^%.*/+-";
            StringBuilder sb;

            var sk = new Stack<char>();
            //System.Collections.Stack sk = new System.Collections.Stack();
            var re = new System.Text.StringBuilder();
            var c = ' ';
            var op = "!^%.*/+-";
            foreach (var item in s)
            {
                if (char.IsDigit(item) || 运算符.Contains(item))
                {
                    re.Append(item);
                }
            }

            sb = new System.Text.StringBuilder(re.ToString());

            #region 对负号进行预转义处理.

            for (var i = 0; i < sb.Length - 1; i++)
                if (sb[i] == '-' && (i == 0 || (sb[i - 1] == '(' || Power(sb[i - 1]) > 0)))
                    sb[i] = '!'; //字符转义.  

            #endregion

            #region 将中缀表达式变为后缀表达式.

            re = new System.Text.StringBuilder();
            for (var i = 0; i < sb.Length; i++)
            {
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
                        else
                        {
                            if (Power(c) < Power(sb[i])) //如果优先级比上次的高,则压栈.  
                            {
                                sk.Push(c);
                                break;
                            }
                            else
                            {
                                re.Append(' ');
                                re.Append(c);
                            }
                            //如果不是左括号,那么将操作符加入后缀式中.  
                        }
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
                        c = (char)sk.Pop(); //pop Operator  
                        if (c != '(')
                        {
                            re.Append(' ');
                            re.Append(c);
                            re.Append(' ');
                        }
                        else
                            break;
                    }
                }
                else
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
        /// 优先级别测试函数.  
        /// </summary>  
        /// <param name="opr"></param>  
        /// <returns></returns>  
        /// 
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
        /// 规范化逆波兰表达式.  
        /// </summary>  
        /// <param name="s"></param>  
        /// <returns></returns>  
        private static string FormatSpace(string s)
        {
            var ret = new System.Text.StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                if (!(s.Length > i + 1 && s[i] == ' ' && s[i + 1] == ' '))
                    ret.Append(s[i]);
                else
                    ret.Append(s[i]);
            }
            return ret.ToString(); //.Replace('!','-');  
        }
    }
}
