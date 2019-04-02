using Components.HowLargeIsTheResistance.Attributes;

namespace Components.HowLargeIsTheResistance.Models
{
    /// <summary>
    /// <para> A color code according to DIN IEC 62.</para>
    /// </summary>
    public class ColorCode_DIN_IEC_62
    {
        #region PROPERTIES

        public string Color { get; set; }

        [ResistorRingPositionAttribute(1)]
        public string DecimalValue { get; set; }

        [ResistorRingPositionAttribute(2)]
        public string UnitValue { get; set; }

        [ResistorRingPositionAttribute(3)]
        public string Multiplier { get; set; }

        [ResistorRingPositionAttribute(4)]
        public string Tolerance { get; set; }

        #endregion
    }
}
