using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Components.HowLargeIsTheResistance.Interfaces;
using Components.HowLargeIsTheResistance.Models;

namespace HowLargeIsTheResistance.Providers
{
    /// <summary>
    /// <para>A class to provide color codes according to DIN IEC 62 from an XML file.</para>
    /// </summary>
    internal class ColorCode_DIN_IEC_62_FromXMLProvider : IColorCode_DIN_IEC_62_Provider
    {
        #region FIELDS

        private readonly string _FileName;
        private readonly XmlReaderSettings _XmlReaderSettings;

        #endregion

        #region CONSTRUCTOR

        public ColorCode_DIN_IEC_62_FromXMLProvider(string fileName)
        {
            this._FileName = fileName;

            _XmlReaderSettings = new XmlReaderSettings();
            _XmlReaderSettings.ValidationType = ValidationType.Schema;
            _XmlReaderSettings.Schemas.Add(@"http://www.dotnetpro.de/HowLargeIsTheResistance", @"Schemas\color_codes.xsd");
            _XmlReaderSettings.IgnoreComments = true;
            _XmlReaderSettings.IgnoreProcessingInstructions = true;
            _XmlReaderSettings.IgnoreWhitespace = true;
        }

        #endregion

        #region ColorCode_DIN_IEC_62_Provider

        /// <summary>
        /// <see cref="ColorCode_DIN_IEC_62_FromXMLProvider"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ColorCode_DIN_IEC_62> LoadColourCodes()
        {
            if (!File.Exists(_FileName))
            {
                yield break;
            }

            XmlReader reader = XmlReader.Create(_FileName);//, _XmlReaderSettings);

            foreach (var colorCode in DeserializeXml(reader))
            {
                yield return colorCode;
            }
        }

        private List<ColorCode_DIN_IEC_62> DeserializeXml(XmlReader reader)
        {
            List<ColorCode_DIN_IEC_62> colorCodes = new List<ColorCode_DIN_IEC_62>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ColorCode_DIN_IEC_62>));//, @"http://www.dotnetpro.de/HowLargeIsTheResistance");

            //if (serializer.CanDeserialize(reader))
            //{
            foreach (var item in (List<ColorCode_DIN_IEC_62>)serializer.Deserialize(reader))
            {
                colorCodes.Add(item);
            }
            //}

            return colorCodes;
        }

        #endregion
    }
}
