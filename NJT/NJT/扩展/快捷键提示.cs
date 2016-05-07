using System.Windows.Input;

namespace NJT.扩展
{
    public static partial class 扩展方法
    {
        public static string To提示(this KeyBinding cs)
        {
            var r = "";
            switch (cs.Modifiers)
            {
                case ModifierKeys.None:
                    break;
                case ModifierKeys.Alt:
                    r = "Alt+";
                    break;
                case ModifierKeys.Control:
                    r = "Ctrl+";
                    break;
                case ModifierKeys.Shift:
                    r = "Shift+";
                    break;
                case ModifierKeys.Windows:
                    r = "Win+";
                    break;
                default:
                    break;
            }
            var key = cs.Key == Key.None ? string.Empty : cs.Key.ToString();

            return r + key;
        }
    }
}
