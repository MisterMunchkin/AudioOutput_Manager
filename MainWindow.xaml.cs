using AudioSwitcher.AudioApi.CoreAudio;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace AudioOutput_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CoreAudioController audioController;
        private List<CoreAudioDevice> audioDeviceList = new List<CoreAudioDevice>();
        private CoreAudioDevice selectedDevice;

        public MainWindow()
        {
            audioController = new CoreAudioController();

            InitializeComponent();
            InitializeAudioOutput_List();
        }

        public void InitializeAudioOutput_List()
        {
            AudioOutput_List.MouseDoubleClick += new MouseButtonEventHandler(AudioOutput_List_DoubleClick);
            GetAudioPlaybackDevices();
        }

        /// <summary>
        /// Gets all playback devices currently registered
        /// </summary>
        public void GetAudioPlaybackDevices()
        {
            audioDeviceList = audioController.GetPlaybackDevices().ToList();

            AudioOutput_List.Items.Clear();
            foreach(var audioDevice in audioDeviceList)
            {
                AudioOutput_List.Items.Add(audioDevice.FullName);
            }
        }

        /// <summary>
        /// This method will set the audio playback device to the device
        /// selected by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AudioOutput_List_DoubleClick(object sender, MouseEventArgs e)
        {
            var selectedItem = audioDeviceList.Where(a => a.FullName.Equals(AudioOutput_List.SelectedItem.ToString())).FirstOrDefault();

            var result = audioController.SetDefaultDevice(selectedItem);
        }

        private void AudioOutput_List_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedDevice = audioDeviceList.Where(a => a.FullName.Equals(AudioOutput_List.SelectedItem.ToString())).FirstOrDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CycledAudioDevices_List.Items.Add(selectedDevice.FullName);
        }
    }
}