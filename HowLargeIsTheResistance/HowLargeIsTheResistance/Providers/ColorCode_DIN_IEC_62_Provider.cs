using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Components.HowLargeIsTheResistance.Interfaces;
using Components.HowLargeIsTheResistance.Models;

namespace HowLargeIsTheResistance.Providers
{
    /// <summary>
    /// <para>A class to provide color codes according to DIN IEC 62.</para>
    /// </summary>
    internal class ColorCode_DIN_IEC_62_Provider : IColorCode_DIN_IEC_62_Provider
    {
        #region FIELDS

        private readonly string _FileName;
        private readonly XmlReaderSettings _XmlReaderSettings;

        #endregion

        #region CONSTRUCTOR

        public ColorCode_DIN_IEC_62_Provider(string fileName)
        {
            this._FileName = fileName;

            _XmlReaderSettings = new XmlReaderSettings();
            _XmlReaderSettings.ValidationType = ValidationType.Schema;
            _XmlReaderSettings.Schemas.Add(@"HowLargeIsTheResistance", @"Schemas\color_codes.xsd");
        }

        #endregion

        #region ColorCode_DIN_IEC_62_Provider

        /// <summary>
        /// <see cref="ColorCode_DIN_IEC_62_Provider"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ColorCode_DIN_IEC_62> LoadColourCodes()
        {
            if (!File.Exists(_FileName))
            {
                yield break;
            }

            XmlReader reader = CreateXmlReader();

            foreach (var colorCode in DeserializeXml(reader))
            {
                yield return colorCode;
            }
        }

        private XmlReader CreateXmlReader()
        {
            return XmlReader.Create(_FileName, _XmlReaderSettings);
        }

        private List<ColorCode_DIN_IEC_62> DeserializeXml(XmlReader reader)
        {
            List<ColorCode_DIN_IEC_62> colorCodes = new List<ColorCode_DIN_IEC_62>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ColorCode_DIN_IEC_62>));

            return colorCodes;
        }

        #endregion
    }
}
