using System.Windows.Forms;

namespace AudioOutput_Manager.Utility
{
    public static class Utility
    {
        /// <summary>
        /// List view item have subitems array (0) = Name, (1) = string Id 
        /// in the CycledList properties the format is <id,name>
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string GenerateCycledListDefaultPropertyString(ListViewItem item)
        {
            return item.SubItems[1].Text + "," + item.SubItems[0].Text;
        }
    }
}