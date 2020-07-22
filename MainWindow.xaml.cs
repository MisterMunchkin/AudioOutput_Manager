using System.Windows;

namespace AudioOutput_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConfigureSettingsForm configureSettingsForm = new ConfigureSettingsForm();
            configureSettingsForm.Show();
            configureSettingsForm.Activate();
        }
    }
}