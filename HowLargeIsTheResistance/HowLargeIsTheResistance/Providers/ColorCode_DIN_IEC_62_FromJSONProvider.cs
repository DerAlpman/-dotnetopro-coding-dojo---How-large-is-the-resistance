using System.Collections.Generic;
using System.IO;
using Components.HowLargeIsTheResistance.Interfaces;
using Components.HowLargeIsTheResistance.Models;

namespace HowLargeIsTheResistance.Providers
{
    /// <summary>
    /// <para>A class to provide color codes according to DIN IEC 62 from a JSON file.</para>
    /// </summary>
    internal class ColorCode_DIN_IEC_62_FromJSONProvider : IColorCode_DIN_IEC_62_Provider
    {
        #region FIELDS

        private readonly string _FileName;

        #endregion

        #region CONSTRUCTOR

        public ColorCode_DIN_IEC_62_FromJSONProvider(string fileName)
        {
            this._FileName = fileName;
        }

        #endregion

        #region ColorCode_DIN_IEC_62_FromJSONProvider

        /// <summary>
        /// <see cref="IColorCode_DIN_IEC_62_Provider.LoadColourCodes()"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ColorCode_DIN_IEC_62> LoadColourCodes()
        {
            if (!File.Exists(_FileName))
            {
                yield break;
            }

            yield break;
        }

        #endregion
    }
}
