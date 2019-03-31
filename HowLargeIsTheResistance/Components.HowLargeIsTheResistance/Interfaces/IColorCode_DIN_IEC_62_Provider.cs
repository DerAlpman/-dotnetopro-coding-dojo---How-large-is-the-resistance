using System.Collections.Generic;
using Components.HowLargeIsTheResistance.Models;

namespace Components.HowLargeIsTheResistance.Interfaces
{
    /// <summary>
    /// <para>An interface for providing color codes according to DIN IEC 62.</para>
    /// </summary>
    public interface IColorCode_DIN_IEC_62_Provider
    {
        /// <summary>
        /// <para>Load color codes.</para>
        /// </summary>
        /// <returns>Collection of color codes</returns>
        IEnumerable<ColorCode_DIN_IEC_62> LoadColourCodes();
    }
}
