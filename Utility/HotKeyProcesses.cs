using System.Windows.Forms;

namespace AudioOutput_Manager.Utility
{
    public class HotKeyProcesses
    {
        /// <summary>
        /// - Checks the current index in default settings if it is still lesser than the cycled list count
        /// - if it is then it will increment the current index and assign it to newIndex
        /// - default settings index is updated
        /// - return the guid of the data by splitting {Id,name} is the format of the string
        /// </summary>
        /// <param name="currentIndex"></param>
        /// <returns></returns>
        public string GetNextCycledAudioId()
        {
            if (Properties.Settings.Default.SelectedCycledIndex < Properties.Settings.Default.CycledList.Count - 1)
            {
                Properties.Settings.Default.SelectedCycledIndex++;
            } 
            else
            {
                Properties.Settings.Default.SelectedCycledIndex = 0;
            }

            var result = Properties.Settings.Default.CycledList[Properties.Settings.Default.SelectedCycledIndex].Split(',');

            return result[0];
        }
    }
}