using System.Xml.Serialization;
using Components.HowLargeIsTheResistance.Models;

namespace HowLargeIsTheResistance.Models
{
    internal class ColorCode : IColorCode
    {
        #region PROPERTIES

        [XmlAttribute]
        public string Color { get; set; }

        [XmlAttribute]
        public string Decimal { get; set; }

        [XmlAttribute]
        public string UnitPosition { get; set; }

        [XmlAttribute]
        public string Multiplier { get; set; }

        [XmlAttribute]
        public string Tolerance { get; set; }

        #endregion
    }
}
