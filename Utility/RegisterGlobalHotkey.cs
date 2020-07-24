using System;
using System.Runtime.InteropServices;

namespace AudioOutput_Manager.Utility
{
    public class RegisterGlobalHotkey
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey([In] IntPtr hWnd, [In] int id, [In] int fsModifiers, [In] int vk);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey([In] IntPtr hWnd, [In] int id);

        /// <summary>
        /// Registers a GlobalHotKey to windows
        /// </summary>
        /// <param name="Handle"></param>
        /// <param name="fsModifiers"></param>
        /// <param name="vk"></param>
        public void Register(IntPtr Handle, int hotkeyId, int fsModifiers, int vk)
        {
            RegisterHotKey(Handle, hotkeyId, fsModifiers, vk);
        }

        /// <summary>
        /// Unregisters a GlobalHotKey on windows
        /// </summary>
        /// <param name="hWnd"></param>
        public void UnRegister(IntPtr hWnd, int hotkeyId)
        {
            UnregisterHotKey(hWnd, hotkeyId);
        }
    }
}