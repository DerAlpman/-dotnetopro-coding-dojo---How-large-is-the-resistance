using System.Collections.Generic;
using Components.HowLargeIsTheResistance.Models;
using HowLargeIsTheResistance.Models;
using HowLargeIsTheResistance.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HowLargeIsTheResistanceTests.TestCases
{
    [TestClass]
    public class Resistor_DIN_IEC_62Tests
    {
        [TestMethod]
        [DataRow(13, 2, 0.1)]
        public void Create_AllowedValues_NewResistor(int baseValue, int multiplier, double tolerance)
        {
            #region ARRANGE

            #endregion

            #region ACT

            var resistor = Resistor_DIN_IEC_62.Create(baseValue, multiplier, tolerance);

            #endregion

            #region ASSERT

            Assert.IsTrue(resistor != null);

            #endregion
        }

        [TestMethod]
        [DataRow(new string[] { "braun", "rot", "orange", "grün" })]
        public void Create_ColorStringArray_NewResistor(string[] ringColors)
        {
            #region ARRANGE

            ColorCode_DIN_IEC_62_FromJSONProvider colorCodesProvider = new ColorCode_DIN_IEC_62_FromJSONProvider("color_codes.json");
            IReadOnlyList<ColorCode_DIN_IEC_62> colorCodes = colorCodesProvider.LoadColorCodes();

            #endregion

            #region ACT

            var resistor = Resistor_DIN_IEC_62.Create(ringColors, colorCodes);

            #endregion

            #region ASSERT

            Assert.IsTrue(resistor != null);

            #endregion
        }

        [TestMethod]
        [DataRow(13, 2, 0.1, "1300 Ohm ± 0.1 %")]
        [DataRow(43, 5, 20, "4300000 Ohm ± 20 %")]
        public void ResistorValue_ResistorValues_CorrectlyCalculatdResistorValueWithUnits(
            int baseResistorValue, int multiplier, double tolerance, string expectedValue)
        {
            #region ARRANGE

            #endregion

            #region ACT

            var resistor = Resistor_DIN_IEC_62.Create(baseResistorValue, multiplier, tolerance);
            string resistorValue = resistor.ResistorValue();

            #endregion

            #region ASSERT

            Assert.AreEqual<string>(expectedValue, resistorValue);

            #endregion
        }
    }
}
