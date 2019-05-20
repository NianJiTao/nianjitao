using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public class 查表
    {
        public static HashSet<string> hash数值类型表 = new HashSet<string>
        {
            "byte",
            "int32",
            "int16",
            "int64",
            "single",
            "double",
            "uint16",
            "uint32",
            "uint64",
            "ulong",

            "int",
            "short",
            "float",
            "real",
            "uint",
            "long",
            "ushort",
            "decimal",
            //"char",
        };


        /// <summary>
        /// 返回是否是数值类型
        /// </summary>
        /// <param name="值类型"></param>
        /// <returns></returns>
        public static bool Is数值类型(string 值类型)
        {
            return 查表.hash数值类型表.Contains(值类型.ToLower());
        }


        public static Type GetType标准(string typeName)
        {
            var name = typeName.StartsWith("System.") ? typeName : "System." + typeName;
            try
            {
                return Type.GetType(name);
            }
            catch (Exception)
            {
                return typeof(object);
            }
        }


        public static Type GetType兼容(string typeName)
        {
            var name = typeName.ToLower();
            switch (name)
            {
                case "boolean": return typeof(bool);
                case "byte": return typeof(byte);
                case "char": return typeof(char);
                case "int16": return typeof(short);
                case "int32": return typeof(int);
                case "int64": return typeof(long);
                case "single": return typeof(float);
                case "double": return typeof(double);
                case "uint16": return typeof(ushort);
                case "uint32": return typeof(uint);
                case "uint64": return typeof(ulong);

                case "bool": return typeof(bool);
                case "short": return typeof(short);
                case "ushort": return typeof(ushort);
                case "int": return typeof(int);
                case "uint": return typeof(uint);
                case "float": return typeof(float);
                case "real": return typeof(float);
                case "long": return typeof(long);
                case "ulong": return typeof(ulong);
                case "string": return typeof(string);
                case "datetime": return typeof(DateTime);
                //case "object": return typeof(object);
            }

            return null;
        }


        public static I运行结果<object> Get默认值(string typeName)
        {
            var name = typeName.ToLower();
            var z = false;
            var r = default(object);
            switch (name)
            {
                case "boolean":
                    z = true;
                    r = default(bool);
                    break;
                case "byte":
                    z = true;
                    r = default(byte);
                    break;
                case "char":
                    z = true;
                    r = default(char);
                    break;
                case "int16":
                    z = true;
                    r = default(short);
                    break;
                case "int32":
                    z = true;
                    r = default(int);
                    break;
                case "int64":
                    z = true;
                    r = default(long);
                    break;
                case "single":
                    z = true;
                    r = default(float);
                    break;
                case "double":
                    z = true;
                    r = default(double);
                    break;
                case "uint16":
                    z = true;
                    r = default(ushort);
                    break;
                case "uint32":
                    z = true;
                    r = default(uint);
                    break;
                case "uint64":
                    z = true;
                    r = default(ulong);
                    break;

                case "bool":
                    z = true;
                    r = default(bool);
                    break;
                case "short":
                    z = true;
                    r = default(short);
                    break;
                case "ushort":
                    z = true;
                    r = default(ushort);
                    break;
                case "int":
                    z = true;
                    r = default(int);
                    break;
                case "uint":
                    z = true;
                    r = default(uint);
                    break;
                case "float":
                    z = true;
                    r = default(float);
                    break;
                case "long":
                    z = true;
                    r = default(long);
                    break;
                case "ulong":
                    z = true;
                    r = default(ulong);
                    break;
                case "string":
                    z = true;
                    r = default(string);
                    break;
                case "String":
                    z = true;
                    r = default(string);
                    break;
                case "datetime":
                    z = true;
                    r = DateTime.MinValue;
                    break;
            }

            return new 运行结果<object>(z) {Data = r};
        }


        //static string[] 假值 = new string[]
        //{
        //    "false", "0", "", "unchecked", "关", "假", "-1", "未选中"
        //};
    }
}