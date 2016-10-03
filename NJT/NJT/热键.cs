using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NJT
{
    public class 热键
    {
        private 热键管理.HotkeyModeKey _ModeKey;
        private Keys _VirtualKey;
        private string _Name;
        private Int32 _ID;
        //

        public 热键()
        {
        }

        public 热键(string Name)
        {
            _Name = Name;
        }

        public 热键(热键管理.HotkeyModeKey ModeKey, Keys VirtualKey)
        {
            _ModeKey = ModeKey;
            _VirtualKey = VirtualKey;
        }

        public 热键(热键管理.HotkeyModeKey ModeKey, Keys VirtualKey, string Name)
        {
            _ModeKey = ModeKey;
            _VirtualKey = VirtualKey;
            _Name = Name;
        }

        public Keys VirtualKey
        {
            get { return _VirtualKey; }
            set { _VirtualKey = value; }
        }

        public 热键管理.HotkeyModeKey ModeKey
        {
            get { return _ModeKey; }
            set { _ModeKey = value; }
        }

        internal Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Name
        {
            get { return _Name; }
        }
    }


    public class 热键管理
    {
        public event HotkeyPressedEventHandler HotkeyPressed;

        public delegate void HotkeyPressedEventHandler(热键 RecivedHotkey);

        #region API Declares ...

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern Int32 RegisterHotKey(Int32 hWnd, Int32 id, Int32 fsModifiers, Int32 vk);

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern Int32 UnregisterHotKey(Int32 hWnd, Int32 id);

        [DllImport("user32", EntryPoint = "PeekMessageA", CharSet = CharSet.Ansi, SetLastError = true,
            ExactSpelling = true)]
        private static extern Int32 PeekMessage(ref Message lpMsg, Int32 hWnd, Int32 wMsgFilterMin, Int32 wMsgFilterMax,
            Int32 wRemoveMsg);

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern Int32 WaitMessage();

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern Int32 CallWindowProcA(Int32 lpPrevWndFunc, Int32 hwnd, Int32 Msg, Int32 wParam,
            Int32 lParam);

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern Int32 SetWindowLongA(Int32 hwnd, Int32 nIndex, DWindowProc dwNewinteger);

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern Int32 SetWindowLongA(Int32 hwnd, Int32 nIndex, Int32 dwNewinteger);

        #endregion

        #region Declares and Variables ...

        private const Int32 GWL_WNDPROC = -4;
        private const Int32 WL_ALLHOTKEYS = 49151;

        public enum HotkeyModeKey : int
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            Winkey = 8
        }

        private const Int32 PM_REMOVE = 1;

        private const short WM_HOTKEY = 786;

        private Form _Form;
        private List<热键> _HotKeys = new List<热键>();
        private Int32 _WindowProc;
        //

        public delegate Int32 DWindowProc(Int32 hwnd, Int32 uMsg, Int32 wParam, Int32 lParam);

        #endregion

        public 热键管理(Form OwnerForm)
        {
            _Form = OwnerForm;

            var DWP = new DWindowProc(WindowProc);
            _WindowProc = SetWindowLongA(OwnerForm.Handle.ToInt32(), GWL_WNDPROC, DWP);
        }


        [System.Diagnostics.DebuggerStepThrough()]
        private Int32 WindowProc(Int32 hwnd, Int32 uMsg, Int32 wParam, Int32 lParam)
        {
            if (uMsg == WM_HOTKEY)
            {
                foreach (var cls in _HotKeys)
                {
                    if (cls.ID == wParam)
                    {
                        if (HotkeyPressed != null)
                        {
                            HotkeyPressed(cls);
                        }
                        return 0;
                    }
                }

                return 0;
            }
            else
            {
                return CallWindowProcA(_WindowProc, hwnd, uMsg, wParam, lParam);
            }
        }

        public void RegisterHotkey(HotkeyModeKey ModeKey, Keys VirtualKey, string Name)
        {
            Int32 ret;
            var nID = _HotKeys.Count;
            var hotkeyNewShortcut = new 热键(ModeKey, VirtualKey, Name);

            hotkeyNewShortcut.ID = nID;
            _HotKeys.Add(hotkeyNewShortcut);
            ret = RegisterHotKey(_Form.Handle.ToInt32(), nID, (int)ModeKey, (int)VirtualKey);

            Application.DoEvents();
        }

        public void RegisterHotkey(热键 CHoykey)
        {
            this.RegisterHotkey(CHoykey.ModeKey, CHoykey.VirtualKey, CHoykey.Name);
        }

        public void UnregisterAllHotkeys()
        {
            UnregisterHotKey(_Form.Handle.ToInt32(), WL_ALLHOTKEYS);
            SetWindowLongA(_Form.Handle.ToInt32(), GWL_WNDPROC, _WindowProc);
        }

        ~热键管理()
        {
            try
            {
                UnregisterHotKey(_Form.Handle.ToInt32(), WL_ALLHOTKEYS);
                SetWindowLongA(_Form.Handle.ToInt32(), GWL_WNDPROC, _WindowProc);
            } //try
            catch
            {
            }
        }
    }

}
