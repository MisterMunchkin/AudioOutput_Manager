using AudioOutput_Manager.Enum;
using AudioOutput_Manager.Utility;
using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AudioOutput_Manager
{
    public partial class ConfigureSettingsForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private RegisterGlobalHotkey RegisterGlobalHotkey;
        private readonly CoreAudioController audioController;
        private List<CoreAudioDevice> audioDeviceList = new List<CoreAudioDevice>();

        public ConfigureSettingsForm()
        {
            InitializeComponent();

            this.RegisterGlobalHotkey = new RegisterGlobalHotkey();
            audioController = new CoreAudioController();

            AudioOutput_ListView_Load();
            CycledAudioOutput_ListView_Load();

            RegisterGlobalHotkey.Register(this.Handle, (int)KeyModifier.Control, Keys.PageDown.GetHashCode());
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0312)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();

                MessageBox.Show("Hot key pressed!");
            }
        }

        private void AudioOutput_ListView_Load()
        {
            AudioOutput_ListView.Clear();
            AudioOutput_ListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(AudioOutput_ListView_DoubleClick);
            GetAudioPlaybackDevices();
        }

        private void CycledAudioOutput_ListView_Load()
        {
            CycledAudioOutput_ListView.Clear();
            var savedCycledAudio = Properties.Settings.Default.CycledList;

            if (savedCycledAudio != null)
            {
                foreach (var savedItemString in savedCycledAudio)
                {
                    var savedItem = savedItemString.Split(',');

                    ListViewItem item = new ListViewItem(savedItem[1]);

                    item.SubItems.Add(savedItem[0]);

                    CycledAudioOutput_ListView.Items.Add(item);
                }
            } 
            else
            {
                Properties.Settings.Default.CycledList = new List<string>();
            }
        }

        private void AudioOutput_ListView_DoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var selectedItem = audioDeviceList.Where(a => a.FullName.Equals(AudioOutput_ListView.SelectedItems.ToString())).FirstOrDefault();

            audioController.SetDefaultDevice(selectedItem);
        }

        private void GetAudioPlaybackDevices()
        {
            audioDeviceList = audioController.GetPlaybackDevices().ToList();

            foreach (var audioDevice in audioDeviceList)
            {
                ListViewItem item = new ListViewItem(audioDevice.FullName);

                item.SubItems.Add(audioDevice.Id.ToString());

                AudioOutput_ListView.Items.Add(item);
            }
        }

        private void AddToCycleButton_Click(object sender, EventArgs e)
        {
            AudioControllerViewModel audioData = new AudioControllerViewModel()
            {
                Id = AudioOutput_ListView.SelectedItems[0].SubItems[1].Text,
                Name = AudioOutput_ListView.SelectedItems[0].SubItems[0].Text
            };

            ListViewItem item = new ListViewItem(audioData.Name);

            item.SubItems.Add(audioData.Id);

            CycledAudioOutput_ListView.Items.Add(item);

            Properties.Settings.Default.CycledList.Add(audioData.Id + ',' + audioData.Name);
        }

        private void AudioOutput_ListView_SelectedIndexChanged(object sender, EventArgs e){}

        private void SaveChanges_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}