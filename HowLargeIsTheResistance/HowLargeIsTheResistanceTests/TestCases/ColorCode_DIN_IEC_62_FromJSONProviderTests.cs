using System.Collections.Generic;
using System.IO;
using System.Linq;
using Components.HowLargeIsTheResistance.Models;
using HowLargeIsTheResistance.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HowLargeIsTheResistanceTests.TestCases
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

            Assert.ThrowsException<FileNotFoundException>(() => provider.LoadColorCodes());

            #endregion
        }

        [TestMethod]
        public void LoadColorCodes_ProviderGetsExistingFileName_ListOfColorCodesWithElements()
        {
            #region ARRANGE

            ColorCode_DIN_IEC_62_FromJSONProvider provider = new ColorCode_DIN_IEC_62_FromJSONProvider(@"TestFiles\Color_codes.json");

            #endregion

            #region ACT

            IEnumerable<ColorCode_DIN_IEC_62> ColorCodes = provider.LoadColorCodes();

            #endregion

            #region ASSERT

            Assert.IsTrue(ColorCodes.Any());

            #endregion
        }

        [TestMethod]
        public void LoadColorCodes_ProviderGetsFileWithJSONNotMatchingSchema_ListOfValidationErrorMessagesNotEmpty()
        {
            #region ARRANGE

            ColorCode_DIN_IEC_62_FromJSONProvider provider = new ColorCode_DIN_IEC_62_FromJSONProvider(@"TestFiles\Color_codes_invalid.json");

            #endregion

            #region ACT

            var ColorCodes = provider.LoadColorCodes();

            #endregion

            #region ASSERT

            Assert.IsTrue(provider.ValidationErrorMessages.Any());

            #endregion
        }
    }
}
