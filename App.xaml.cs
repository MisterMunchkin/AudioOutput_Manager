using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace AudioOutput_Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// Code below works on Background application logic please see more: https://www.thomasclaudiushuber.com/2015/08/22/creating-a-background-application-with-wpf/
    /// </summary>
    public partial class App : Application
    {
        private NotifyIcon notifyIcon;
        private bool isExit;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = new MainWindow();
            MainWindow.Closing += MainWindow_Closing;

            notifyIcon = new NotifyIcon();
            notifyIcon.DoubleClick += (s, args) => ShowMainWindow();
            notifyIcon.Icon = AudioOutput_Manager.Properties.Resources.MyIcon;
            notifyIcon.Visible = true;

            CreateContextMenu();
        }

        private void CreateContextMenu()
        {
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.Add("Main Window...").Click += (s, e) => ShowMainWindow();
            notifyIcon.ContextMenuStrip.Items.Add("Exit").Click += (s, e) => ExitApplication();
        }

        private void ExitApplication()
        {
            isExit = true;
            MainWindow.Close();
            notifyIcon.Dispose();
            notifyIcon = null;
        }

        private void ShowMainWindow()
        {
            if (MainWindow.IsVisible)
            {
                if (MainWindow.WindowState == WindowState.Minimized)
                {
                    MainWindow.WindowState = WindowState.Normal;
                }
                MainWindow.Activate();
            }
            else
            {
                MainWindow.Show();
            }
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!isExit)
            {
                e.Cancel = true;
                MainWindow.Hide();
            }
        }
    }
}