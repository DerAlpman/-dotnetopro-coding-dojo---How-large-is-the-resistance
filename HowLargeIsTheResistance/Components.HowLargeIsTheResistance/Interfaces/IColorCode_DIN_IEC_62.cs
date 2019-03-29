namespace Components.HowLargeIsTheResistance.Models
{
    /// <summary>
    /// <para>An interface to a color code according to DIN IEC 62.</para>
    /// </summary>
    public interface IColorCode_DIN_IEC_62
    {
        string Color { get; }
        string Decimal { get; }
        string Multiplier { get; }
        string Tolerance { get; }
        string UnitPosition { get; }
    }
}