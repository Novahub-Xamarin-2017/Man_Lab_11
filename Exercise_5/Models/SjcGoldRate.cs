using System.Xml.Serialization;

namespace Exercise_5.Models
{
    [XmlRoot("root")]
    public class SjcGoldRate
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("ratelist")]
        public CityList CityList { get; set; }
    }
}