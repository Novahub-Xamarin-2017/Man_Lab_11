using System.Collections.Generic;
using System.Xml.Serialization;

namespace Exercise_5.Models
{
    public class CityList
    {
        [XmlAttribute(AttributeName = "updated")]
        public string UpdatedTime { get; set; }

        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
        
        [XmlElement("city")]
        public List<City> Cities { get; set; }
    }
}