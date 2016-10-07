using System;
using Prism.Mvvm;

namespace NJT.Common
{
    public class WeekInfo : BindableBase
    {
        private bool _isChecked;

        public WeekInfo(int number)
        {
            this.Number = Math.Abs(number) % 7;
            英文 = DayOfWeek.Monday;
            中文 = 英文.ToWeek中文();
        }

        public int Number { get; private set; }

        public string 中文 { get; set; }

        public DayOfWeek 英文 { get; private set; }

        public bool IsChecked
        {
            get { return _isChecked; }
            set { SetProperty(ref _isChecked, value); }
        }
    }


}