using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Exercise_5.Models
{
    public class City
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("item")]
        public List<Currency> Currencies { get; set; }
    }
}