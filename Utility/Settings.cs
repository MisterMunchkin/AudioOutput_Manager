using System.IO;
using System.Xml.Serialization;

namespace AudioOutput_Manager.Utility
{
    public class Settings
    {
        public string selectedCycledIndex { get; set; }
        public AudioControllerViewModel cycledList { get; set; }

        public void Save(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(Settings));
                xmls.Serialize(sw, this);
            }
        }

        public Settings Read(string filename)
        {
            using (StreamReader sw = new StreamReader(filename))
            {
                XmlSerializer xmls = new XmlSerializer(typeof(Settings));
                return xmls.Deserialize(sw) as Settings;
            }
        }
    }
}