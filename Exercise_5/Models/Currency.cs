using System.Xml.Serialization;

namespace Exercise_5.Models
{
    public class Currency
    {
        [XmlAttribute(AttributeName = "buy")]
        public string Buy { get; set; }

        [XmlAttribute(AttributeName = "sell")]
        public string Sell { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        public override string ToString() => $"Type: {Type}\nBuy: {Buy}\t\t\tSell: {Sell}";
    }
}