using System.Collections.Generic;
using System.IO;
using System.Linq;
using Components.HowLargeIsTheResistance.Models;
using HowLargeIsTheResistance.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HowLargeIsTheResistanceTests
{
    [TestClass]
    public class ColorCode_DIN_IEC_62_FromJSONProviderTests
    {
        [TestMethod]
        public void LoadColorCodes_ProviderGetsNotExistingFileName_FileNotFoundException()
        {
            #region ARRANGE

            ColorCode_DIN_IEC_62_FromJSONProvider provider = new ColorCode_DIN_IEC_62_FromJSONProvider("Schnulli.xml");

            #endregion

            #region ACT

            #endregion

            #region ASSERT

            Assert.ThrowsException<FileNotFoundException>(() => provider.LoadColourCodes());

            #endregion
        }

        [TestMethod]
        public void LoadColorCodes_ProviderGetsExistingFileName_ListOfColorCodesWithElements()
        {
            #region ARRANGE

            ColorCode_DIN_IEC_62_FromJSONProvider provider = new ColorCode_DIN_IEC_62_FromJSONProvider("color_codes.json");

            #endregion

            #region ACT

            IEnumerable<ColorCode_DIN_IEC_62> colorCodes = provider.LoadColourCodes();

            #endregion

            #region ASSERT

            Assert.IsTrue(colorCodes.Any());

            #endregion
        }

        [TestMethod]
        public void LoadColorCodes_ProviderGetsFileWithJSONNotMatchingSchema_ListOfValidationErrorMessagesNotEmpty()
        {
            #region ARRANGE

            ColorCode_DIN_IEC_62_FromJSONProvider provider = new ColorCode_DIN_IEC_62_FromJSONProvider("color_codes_invalid.json");

            #endregion

            #region ACT

            IEnumerable<ColorCode_DIN_IEC_62> colorCodes = provider.LoadColourCodes();

            #endregion

            #region ASSERT

            Assert.IsTrue(provider.ValidationErrorMessages.Any());

            #endregion
        }
    }
}
