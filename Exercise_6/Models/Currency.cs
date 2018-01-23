using System.Xml.Serialization;

namespace Exercise_6.Models
{
    public class Currency
    {
        [XmlAttribute(AttributeName = "CurrencyName")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "CurrencyCode")]
        public string Code { get; set; }

        [XmlAttribute(AttributeName = "Buy")]
        public string Buy { get; set; }

        [XmlAttribute(AttributeName = "Transfer")]
        public string Transfer { get; set; }

        [XmlAttribute(AttributeName = "Sell")]
        public string Sell { get; set; }

        public override string ToString() => $"{Name}\n{Code}\n{Buy}\n{Sell}";
    }
}