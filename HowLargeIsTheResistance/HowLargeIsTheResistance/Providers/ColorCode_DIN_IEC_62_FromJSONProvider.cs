using System.Collections.Generic;
using System.IO;
using Components.HowLargeIsTheResistance.Interfaces;
using Components.HowLargeIsTheResistance.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace HowLargeIsTheResistance.Providers
{
    /// <summary>
    /// <para>A class to provide color codes according to DIN IEC 62 from a JSON file.</para>
    /// </summary>
    internal class ColorCode_DIN_IEC_62_FromJSONProvider : IColorCode_DIN_IEC_62_Provider
    {
        #region CONSTS

        private const string SCHEMA_FILE_NAME = @"Schemas/color_codes_schema.json";

        #endregion

        #region FIELDS

        private readonly string _FileName;
        private readonly IList<string> _ValidationErrorMessages = new List<string>();

        #endregion

        #region PROPERTIES

        public IList<string> ValidationErrorMessages => _ValidationErrorMessages;

        #endregion

        #region CONSTRUCTOR

        public ColorCode_DIN_IEC_62_FromJSONProvider(string fileName)
        {
            this._FileName = fileName;
        }

        #endregion

        #region IColorCode_DIN_IEC_62_Provider

        /// <summary>
        /// <see cref="IColorCode_DIN_IEC_62_Provider.LoadColorCodes()"/>
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<ColorCode_DIN_IEC_62> LoadColorCodes()
        {
            IList<ColorCode_DIN_IEC_62> colorCodes = new List<ColorCode_DIN_IEC_62>();

            if (!File.Exists(_FileName))
            {
                throw new FileNotFoundException(_FileName);
            }

            if (TryGetJSONSchema(out JSchema schema))
            {
                foreach (var item in DeserializeJSONWithSchema(schema))
                {
                    colorCodes.Add(item);
                }
            }

            return ((IReadOnlyList<ColorCode_DIN_IEC_62>)colorCodes);
        }

        #endregion

        #region ColorCode_DIN_IEC_62_FromJSONProvider

        private IEnumerable<ColorCode_DIN_IEC_62> DeserializeJSONWithSchema(JSchema schema)
        {
            IList<ColorCode_DIN_IEC_62> colorCodes = new List<ColorCode_DIN_IEC_62>();

            using (StreamReader file = File.OpenText(_FileName))
            using (JsonTextReader reader = new JsonTextReader(file))
            using (JSchemaValidatingReader validatingReader = new JSchemaValidatingReader(reader))
            {
                validatingReader.Schema = schema;

                validatingReader.ValidationEventHandler += (o, a) => _ValidationErrorMessages.Add(a.Message);

                JsonSerializer serializer = new JsonSerializer();
                colorCodes = serializer.Deserialize<List<ColorCode_DIN_IEC_62>>(validatingReader);
            }

            return colorCodes;
        }

        private static bool TryGetJSONSchema(out JSchema schema)
        {
            using (StreamReader file = File.OpenText(SCHEMA_FILE_NAME))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                schema = JSchema.Load(reader);
            }

            return schema != null;
        }

        #endregion
    }
}
