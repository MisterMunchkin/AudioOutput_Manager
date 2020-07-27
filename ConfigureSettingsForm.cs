using AudioOutput_Manager.Utility;
using System;
using System.Windows.Forms;

namespace AudioOutput_Manager
{
    public partial class ConfigureSettingsForm : Form
    {
        private readonly CoreAudioProcesses coreAudioProcesses;

        public ConfigureSettingsForm()
        {
            InitializeComponent();

            this.coreAudioProcesses = new CoreAudioProcesses();

            AudioOutput_ListView_Load();
            CycledAudioOutput_ListView_Load();
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

            foreach (var savedItemString in savedCycledAudio)
            {
                var savedItem = savedItemString.Split(',');

                ListViewItem item = new ListViewItem(savedItem[1]);

                item.SubItems.Add(savedItem[0]);

                CycledAudioOutput_ListView.Items.Add(item);
            }
        }

        private void AudioOutput_ListView_DoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var selectedItem = coreAudioProcesses.GetCoreAudioDevice(AudioOutput_ListView.SelectedItems[0].SubItems[1].Text);

            coreAudioProcesses.SetDefaultDevice(selectedItem);
        }

        private void GetAudioPlaybackDevices()
        {
            foreach (var audioDevice in coreAudioProcesses.coreAudioDeviceList)
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

        private void AudioOutput_ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void SaveChanges_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

            MessageBox.Show("Changes Saved!");
        }

        private void DeleteSelected_Click(object sender, EventArgs e)
        {
            var selectedItem = CycledAudioOutput_ListView.SelectedItems[0];
            string selectedStringItem = Utility.Utility.GenerateCycledListDefaultPropertyString(selectedItem);

            CycledAudioOutput_ListView.Items.Remove(selectedItem);
            Properties.Settings.Default.CycledList.Remove(selectedStringItem);
        }
    }
}