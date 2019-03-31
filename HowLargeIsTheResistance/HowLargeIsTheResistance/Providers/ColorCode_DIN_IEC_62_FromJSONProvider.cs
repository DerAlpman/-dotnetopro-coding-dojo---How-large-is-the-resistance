using System;
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

        #endregion

        #region CONSTRUCTOR

        public ColorCode_DIN_IEC_62_FromJSONProvider(string fileName)
        {
            this._FileName = fileName;
        }

        #endregion

        #region IColorCode_DIN_IEC_62_Provider

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

            if (TryGetJSONSchema(out JSchema schema))
            {
                foreach (var item in DeserializeJSONWithSchema(schema))
                {
                    yield return item;
                }
            }

            yield break;
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

                IList<string> messages = new List<string>();
                validatingReader.ValidationEventHandler += (o, a) => throw new Exception(a.Message);

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
