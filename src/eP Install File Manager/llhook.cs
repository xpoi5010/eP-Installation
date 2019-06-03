using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
namespace ePGameFramework.WindowsAPI.user32
{
    public class llhook
    {
        public llhook()
        {
            kb_delegate = new callback_(callback_process_kb);
            m_delegate = new callback_(callback_process_m);
            kb_h = SetWindowsHookExW(kb_ll_id, kb_delegate, IntPtr.Zero, 0);
            m_h = SetWindowsHookExW(m_ll_id, m_delegate, IntPtr.Zero, 0);
            if (kb_h == IntPtr.Zero || m_h == IntPtr.Zero)
                throw new System.Exception($"call: Function:SetWindowsHookExW returns NULL,Error code:0x{Convert.ToString(GetLastError(), 16)}");
        }

        ~llhook()
        {
            UnhookWindowsHookEx(kb_h);
            UnhookWindowsHookEx(m_h);
        }

        private const string DllName = "user32.dll";

        private const int kb_ll_id = 13;

        private const int m_ll_id = 14;

        private static Delegate kb_delegate;

        private static Delegate m_delegate;

        private static IntPtr kb_h;

        private static IntPtr m_h;
        [DllImport(DllName, SetLastError = true)]
        private extern static IntPtr SetWindowsHookExW(int idHook, Delegate lpfn, IntPtr hmode, uint dwThreadId);

        [DllImport(DllName, SetLastError = true)]
        private extern static IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport(DllName, SetLastError = true)]
        private extern static bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("Kernel32.dll")]
        private extern static uint GetLastError();

        public class hook_callback
        {
            public int code;

            public IntPtr wParam;

            public IntPtr lParam;
        }

        private delegate void callback_(int nCode, IntPtr wParam, IntPtr lParam);

        public delegate void kb_hook_event(LLkeyboardProc keyboardProc);

        public delegate void m_hook_event(LLMouseProc keyboardProc);

        private void callback_process_kb(int nCode, IntPtr wParam, IntPtr lParam)
        {
           callback_hook_event_kb?.Invoke(LLkeyboardProc.ConvertFromArgs(nCode, wParam, lParam));
            CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private void callback_process_m(int nCode, IntPtr wParam, IntPtr lParam)
        {
           callback_hook_event_m?.Invoke(LLMouseProc.ConvertFromArgs(nCode, wParam, lParam));
            CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        public event kb_hook_event callback_hook_event_kb;

        public event m_hook_event callback_hook_event_m;

        public class LLkeyboardProc : hook_callback
        {
            private KBDLLHOOKSTRUCT KBDLLHOOKSTRUCT;

            private bool init = false;

            public unsafe key GetKey()
            {
                if (!init)
                    init_KBDLLHOOSTRU();
                return (key)KBDLLHOOKSTRUCT.vkCode;
            }
            
            public unsafe void init_KBDLLHOOSTRU()
            {
                void* pointer = this.lParam.ToPointer();
                KBDLLHOOKSTRUCT* p = (KBDLLHOOKSTRUCT*)pointer;
                KBDLLHOOKSTRUCT = *p;
                init = true;
            }

            public int Getkeystatus()
            {
                return this.wParam.ToInt32() == 0x0100 || this.wParam.ToInt32() == 0x0104 ? 1 : 0;
            }

            public static LLkeyboardProc ConvertFromArgs(int nCode, IntPtr wParam, IntPtr lParam)
            {
                return new LLkeyboardProc { code = nCode, wParam = wParam, lParam = lParam };
            }
        }

        public class LLMouseProc : hook_callback
        {
            MOUSEHOOKSTRUCT MOUSEHOOKSTRUCT;

            private bool init = false;
            public enum MouseEvent
            {
                WM_LBUTTONDOWN = 0x0201,
                WM_LBUTTONUP = 0x0202,
                WM_MOUSEMOVE = 0x0200,
                WM_MOUSEWHEEL = 0x020A,
                WM_MOUSEHWHEEL = 0x020E,
                WM_RBUTTONDOWN = 0x0204,
                WM_RBUTTONUP = 0x0205
            }
            
            public unsafe void init_MOUSHOOKSTRU()
            {
                void* tagMOUSE = this.lParam.ToPointer();
                MOUSEHOOKSTRUCT* p =(MOUSEHOOKSTRUCT*)tagMOUSE;
                MOUSEHOOKSTRUCT = *p;
                init = true;
            }

            public Point GetPoint()
            {
                if (!init)
                    init_MOUSHOOKSTRU();
                return new Point((int)MOUSEHOOKSTRUCT.x, (int)MOUSEHOOKSTRUCT.y);
            }

            public MouseEvent GetEvent()
            {
                if (!init)
                    init_MOUSHOOKSTRU();
                return (MouseEvent)this.wParam;
            }

            public static LLMouseProc ConvertFromArgs(int nCode, IntPtr wParam, IntPtr lParam)
            {
                return new LLMouseProc { code = nCode, wParam = wParam, lParam = lParam };
            }

        }

        private hook_callback ConvertFromArgs(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return new hook_callback { code = nCode, wParam = wParam, lParam = lParam };
        }

        private struct KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scancode;
            public uint flags;
            public uint time;
            public uint dwExtraInfo;
        }

        public struct MOUSEHOOKSTRUCT
        {
            public long x;
            public long y;
            public uint hwnd;
            public uint wHitTestCode;
            public uint dwExtraInfo;
        }
    }
}
