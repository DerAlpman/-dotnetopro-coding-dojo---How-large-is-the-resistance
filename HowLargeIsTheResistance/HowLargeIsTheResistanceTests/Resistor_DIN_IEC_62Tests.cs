using Components.HowLargeIsTheResistance.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HowLargeIsTheResistanceTests
{
    [TestClass]
    public class Resistor_DIN_IEC_62Tests
    {
        [TestMethod]
        public void TryCreate_AllowedValues_NewCompleteResistor()
        {
            #region ARRANGE

            #endregion

            #region ACT

            var newCompleteResistor = Resistor_DIN_IEC_62.Create(13, 2, -0.1);

            #endregion

            #region ASSERT

            Assert.IsTrue(newCompleteResistor != null);

            #endregion
        }
    }
}
