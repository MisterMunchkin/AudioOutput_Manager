using AudioOutput_Manager.Enum;
using AudioOutput_Manager.Utility;
using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

namespace AudioOutput_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CoreAudioProcesses coreAudioProcesses;
        private RegisterGlobalHotkey registerGlobalHotkey;
        private HwndSource hwndSource;
        private readonly HotKeyProcesses hotKeyProcesses;

        public MainWindow()
        {
            InitializeComponent();
            this.coreAudioProcesses = new CoreAudioProcesses();
            this.registerGlobalHotkey = new RegisterGlobalHotkey();
            this.hotKeyProcesses = new HotKeyProcesses();

            coreAudioProcesses.ActivateDefaultSettings();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var helper = new WindowInteropHelper(this);
            hwndSource = HwndSource.FromHwnd(helper.Handle);
            hwndSource.AddHook(HwndHook);

            registerGlobalHotkey.Register(helper.Handle, ConfigManager.CycledHotKeyId, (int)KeyModifier.Control, Keys.PageDown.GetHashCode());
        }

        protected override void OnClosed(EventArgs e)
        {
            hwndSource.RemoveHook(HwndHook);
            hwndSource = null;

            var helper = new WindowInteropHelper(this);
            registerGlobalHotkey.UnRegister(helper.Handle, ConfigManager.CycledHotKeyId);

            base.OnClosed(e);
        }

        /// <summary>
        /// The hook that will check if our registered global hotkeys have been triggered
        /// if it is then it will call OnGlobalHotKeyPressed
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="handled"></param>
        /// <returns></returns>
        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            const int WM_HOTKEYID = 0;

            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case WM_HOTKEYID:
                            OnGlobalHotKeyPressed(wParam, lParam);
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }

        /// <summary>
        /// Is called when the GlobalHotKey is pressed
        /// </summary>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        private void OnGlobalHotKeyPressed(IntPtr wParam, IntPtr lParam)
        {
            Keys key = (Keys)(((int)lParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
            KeyModifier modifier = (KeyModifier)((int)lParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
            int id = wParam.ToInt32();

            if (Properties.Settings.Default.CycledList.Count > 0)
            {
                var nextAudioCycleId = hotKeyProcesses.GetNextCycledAudioId();

                var device = coreAudioProcesses.GetCoreAudioDevice(nextAudioCycleId);

                coreAudioProcesses.SetDefaultDevice(device);
            }
        }

        /// <summary>
        /// Resets the Default settings in the application and Unregisters the global hotkey
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetDefaultSettings_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reset();

            var helper = new WindowInteropHelper(this);
            registerGlobalHotkey.UnRegister(helper.Handle, ConfigManager.CycledHotKeyId);
        }

        /// <summary>
        /// Brings up the form where you can configure the cycled audio outputs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigureSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            ConfigureSettingsForm configureSettingsForm = new ConfigureSettingsForm();
            configureSettingsForm.Activate();
            configureSettingsForm.Show();
        }
    }
}