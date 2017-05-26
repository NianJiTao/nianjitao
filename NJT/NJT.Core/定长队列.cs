using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJT.Core
{
    public interface I定长列表<in T>
    {
        int 长度 { get; set; }
        void 添加(T value);
    }

    public class 定长队列<T> : Queue<T>, I定长列表<T>
    {
        private int _长度 = 10;

        public 定长队列(int 长度)
        {
            this.长度 = 长度;
        }

        public int 长度
        {
            get => _长度;
            set
            {
                if (value > 0)
                {
                    _长度 = value;
                }
            }
        }

        public void 添加(T value)
        {
            base.Enqueue(value);
            while (Count > 长度)
            {
                Dequeue();
            }
        }

        public void Add(T value)
        {
            添加(value);
        }
    }


    public class 定长列表<T> : List<T>, I定长列表<T>
    {
        private int _长度 = 10;

        public 定长列表(int 长度)
        {
            this.长度 = 长度;
        }

        public int 长度
        {
            get => _长度;
            set
            {
                if (value > 0)
                {
                    _长度 = value;
                }
            }
        }

        public void 添加(T value)
        {
            base.Add(value);
            while (Count > 长度)
            {
                base.RemoveAt(0);
            }
        }

        public new void Add(T value)
        {
            添加(value);
        }
    }

    /// <summary>
    ///     Class 哈希.有限长度
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class 定长哈希<T> : HashSet<T>, I定长列表<T>
    {
        private int _长度 = 10;

        public 定长哈希(int 长度)
        {
            this.长度 = 长度;
        }

        public int 长度
        {
            get => _长度;
            set
            {
                if (value > 0)
                {
                    _长度 = value;
                }
            }
        }

        public void 添加(T value)
        {
            if (Count >= 长度)
            {
                this.Take(Count - 长度 + 1).ToList().ForEach(x => base.Remove(x));
            }
            base.Add(value);
            //while (Count > 长度)
            //{
            //    if (this.FirstOrDefault() != null)
            //    {
            //        Remove(this.FirstOrDefault());
            //    }
            //}
        }

        public new void Add(T value)
        {
            添加(value);
        }
    }


    public class 定长字典<TKey, TValue> : Dictionary<TKey, TValue>
    {
        private int _长度 = 20;

        public 定长字典(int 长度)
        {
            this.长度 = 长度;
        }

        public int 长度
        {
            get => _长度;
            set
            {
                if (value > 0)
                {
                    _长度 = value;
                }
            }
        }


        public new void Add(TKey key, TValue value)
        {
            if (Count >= 长度)
            {
                this.Take(Count - 长度 + 1).ToList().ForEach(x => base.Remove(x.Key));
            }
            base.Add(key, value);
        }
    }
}