using AudioOutput_Manager.Utility;
using System.Windows;

namespace AudioOutput_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CoreAudioProcesses coreAudioProcesses;

        public MainWindow()
        {
            InitializeComponent();
            this.coreAudioProcesses = new CoreAudioProcesses();
            coreAudioProcesses.ActivateDefaultSettings();
        }

        private void ResetDefaultSettings_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reset();
        }

        private void ConfigureSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            coreAudioProcesses.ActivateDefaultSettings();

            ConfigureSettingsForm configureSettingsForm = new ConfigureSettingsForm();
            configureSettingsForm.Activate();
            configureSettingsForm.Show();
        }
    }
}