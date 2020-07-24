﻿using System;
using System.Configuration;

namespace AudioOutput_Manager.Utility
{
    public class RegisterGlobalHotkey
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public void Register(IntPtr Handle, int fsModifiers, int vk)
        {
            int.TryParse(ConfigurationManager.AppSettings.Get("hotkeyId"), out int hotkeyId);

            RegisterHotKey(Handle, hotkeyId, fsModifiers, vk);
        }
    }
}