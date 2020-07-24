using System.Windows.Forms;

namespace AudioOutput_Manager.Utility
{
    public class HotKeyProcesses
    {
        public ListViewItem GetNextCycledIndex(int currentIndex, ListView list)
        {
            int newIndex = 0;
            if (currentIndex < list.Items.Count - 1)
            {
                newIndex = currentIndex + 1;
            }

            Properties.Settings.Default.SelectedCycledIndex = newIndex;

            ListViewItem result = list.Items[newIndex];
            return result;
        }
    }
}