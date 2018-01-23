using System.Collections.Generic;
using System.Xml.Serialization;

namespace Exercise_6.Models
{
    [XmlRoot("ExrateList")]
    public class CurrencyList
    {
        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [XmlElement("Exrate")]
        public List<Currency> Currencies { get; set; }

        [XmlElement("Source")]
        public string Source { get; set; }
    }
}