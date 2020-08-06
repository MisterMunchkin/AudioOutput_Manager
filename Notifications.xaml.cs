using System;
using System.Windows;
using System.Windows.Threading;

namespace AudioOutput_Manager
{
    /// <summary>
    /// Interaction logic for Notifications.xaml
    /// </summary>
    public partial class Notifications : Window
    {
        public Notifications(string message)
        {
            //subscribing custom method to Windows Loaded event
            Loaded += Notifications_Loaded;
            InitializeComponent();

            NotificationMessage_TextBlock.Text = message;
        }

        void Notifications_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                var workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
                var corner = transform.Transform(new Point(workingArea.Right, workingArea.Bottom));

                this.Left = corner.X - this.ActualWidth;
                this.Top = corner.Y - this.ActualHeight;
            }));
        }
        
        public void Activator()
        {
            this.Activate();
            this.Show();
            this.Topmost = true;
        }
    }
}