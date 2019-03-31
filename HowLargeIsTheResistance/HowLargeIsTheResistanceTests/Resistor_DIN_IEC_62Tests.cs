using Components.HowLargeIsTheResistance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HowLargeIsTheResistanceTests
{
    [TestClass]
    public class Resistor_DIN_IEC_62Tests
    {
        [TestMethod]
        public void TryCreate_AllowedValues_NewResistor()
        {
            #region ARRANGE

            #endregion

            #region ACT

            var resistor = Resistor_DIN_IEC_62.Create(13, 2, 0.1);

            #endregion

            #region ASSERT

            Assert.IsTrue(resistor != null);

            #endregion
        }

        [TestMethod]
        [DataRow(13, 2, 0.1, "1300 Ohm ± 0.1 %")]
        public void ResistorValue_ResistorValues_CorrectlyCalculatdResistorValueWithUnits(
            int baseResistorValue, int multiplier, double tolerance, string expectedValue)
        {
            #region ARRANGE

            #endregion

            #region ACT

            var resistor = Resistor_DIN_IEC_62.Create(13, 2, 0.1);
            string resistorValue = resistor.ResistorValue();

            #endregion

            #region ASSERT

            Assert.AreEqual<string>(expectedValue, resistorValue);

            #endregion
        }
    }
}
