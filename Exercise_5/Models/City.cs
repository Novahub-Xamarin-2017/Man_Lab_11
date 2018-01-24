using System.Collections.Generic;
using System.Xml.Serialization;

namespace Exercise_5.Models
{
    class City
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("item")]
        public List<Currency> Currencies { get; set; }
    }
}