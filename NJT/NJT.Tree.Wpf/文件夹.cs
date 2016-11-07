using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace NJT.Tree.Wpf
{
    public class 文件夹 : I树枝<文件夹, string>, INotifyPropertyChanged
    {
        private Guid _身份证 = Guid.NewGuid();
        private string _数据;
        private 文件夹 _选择项;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string 名称 { get; set; }


        public Guid 身份证
        {
            get { return _身份证; }
            set { _身份证 = value; }
        }


        public bool Is选中 { get; set; }
        public bool Is展开 { get; set; }

        public bool 可展开 => 子.Count > 0;

        public int 深度 { get; set; }


        public 文件夹 选择项
        {
            get { return _选择项; }
            set
            {
                if (_选择项 != value)
                {
                    _选择项 = value;
                    OnPropertyChanged(nameof(选择项));
                }
            }
        }


        public 文件夹 父 { get; set; }


        public string 数据
        {
            get { return _数据; }
            set
            {
                if (_数据 != value)
                {
                    _数据 = value;
                    OnPropertyChanged(nameof(数据));
                }
            }
        }


        public object Tag { get; set; }


        public void 刷新()
        {
            子.Clear();
            if (!string.IsNullOrEmpty(数据) && Directory.Exists(数据))
            {
                var dirs = Directory.GetDirectories(数据).Skip(1);
                var find = (from dir in dirs
                            let d = new DirectoryInfo(dir)
                            where (d.Attributes & FileAttributes.System) == 0
                            //&& (d.Attributes & FileAttributes.Hidden) == 0
                            select new 文件夹
                            {
                                数据 = dir,
                                深度 = this.深度 + 1,
                                父 = this,
                                名称 = d.Name
                            });

                foreach (var item in find)
                {
                    子.Add(item);
                }
            }


            OnPropertyChanged(nameof(可展开));
        }


        public ObservableCollection<文件夹> 子 { get; } = new ObservableCollection<文件夹>();


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}