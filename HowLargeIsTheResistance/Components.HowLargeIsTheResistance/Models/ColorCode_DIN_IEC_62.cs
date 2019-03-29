using System.Xml.Serialization;

namespace Components.HowLargeIsTheResistance.Models
{
    /// <summary>
    /// <para> A color code according to DIN IEC 62</para>
    /// </summary>
    [XmlRoot("ColorCode_DIN_IEC_62")]
    public class ColorCode_DIN_IEC_62
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
