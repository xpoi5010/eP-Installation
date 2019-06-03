using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePGameFramework.WindowsAPI.user32;
using ePGameFramework.WindowsAPI;

namespace eP_Install_File_Manager
{
    public class Hook
    {
        private llhook baseHook;

        public Hook()
        {
            baseHook = new llhook();
            baseHook.callback_hook_event_kb += BaseHook_callback_hook_event_kb;
        }

        private void BaseHook_callback_hook_event_kb(llhook.LLkeyboardProc keyboardProc)
        {
            KeyPressed[(int)keyboardProc.GetKey()] = keyboardProc.Getkeystatus() == 1;
            KeyEventArgs kea = new KeyEventArgs();
            kea.Key = keyboardProc.GetKey();
            if (KeyPressed[(int)keyboardProc.GetKey()])
                KeyDown?.Invoke(kea);
                   
            else
                KeyUp?.Invoke(kea);
                
        }

        public delegate void KeyeventDele(KeyEventArgs args);

        public event KeyeventDele KeyUp;

        public event KeyeventDele KeyDown;

        public bool[] KeyPressed = new bool[200];

        public void BGProcess(Action action)
        {
            Task task = new Task(action);
            task.Start();
        }
    }

    public class KeyEventArgs
    {
        public key Key;


    }
}
