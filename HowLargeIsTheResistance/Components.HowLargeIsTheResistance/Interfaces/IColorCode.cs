namespace Components.HowLargeIsTheResistance.Models
{
    public interface IColorCode
    {
        string Color { get; }
        string Decimal { get; }
        string Multiplier { get; }
        string Tolerance { get; }
        string UnitPosition { get; }
    }
}