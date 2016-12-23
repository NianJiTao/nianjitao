using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public class 定长队列<T> : Queue<T>
    {
        private int _长度 = 10;

        public 定长队列(int 长度)
        {
            this.长度 = 长度;
        }

        public int 长度
        {
            get { return _长度; }
            set
            {
                if (value > 0)
                {
                    _长度 = value;
                }
            }
        }

        public void Add(T value)
        {
            Enqueue(value);
            while (Count > 长度)
            {
                Dequeue();
            }
        }
    }


    /// <summary>
    ///     Class 哈希.有限长度
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class 定长哈希<T> : HashSet<T>
    {
        private int _长度 = 10;

        public 定长哈希(int 长度)
        {
            this.长度 = 长度;
        }

        public int 长度
        {
            get { return _长度; }
            set
            {
                if (value > 0)
                {
                    _长度 = value;
                }
            }
        }

        public new void Add(T value)
        {
            base.Add(value);
            if (Count > 长度)
            {
                Clear();
            }
        }
    }


    public class 定长字典<T, T2> : Dictionary<T, T2>
    {
        private int _长度 = 20;

        public 定长字典(int 长度)
        {
            this.长度 = 长度;
        }

        public int 长度
        {
            get { return _长度; }
            set
            {
                if (value > 0)
                {
                    _长度 = value;
                }
            }
        }

        public new void Add(T value, T2 t2)
        {
            if (Count > 长度)
            {
                Clear();
            }
            base.Add(value, t2);
        }
    }
}
