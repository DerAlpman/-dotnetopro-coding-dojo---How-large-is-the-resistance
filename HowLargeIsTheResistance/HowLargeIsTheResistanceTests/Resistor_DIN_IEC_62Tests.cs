using System.Collections.Generic;
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

            bool newCompleteResistor = Resistor_DIN_IEC_62.TryCreate(13, 2, -0.1,
                out Resistor_DIN_IEC_62 resistor, out IList<string> errorMessages);

            #endregion

            #region ASSERT

            Assert.IsTrue(newCompleteResistor);

            #endregion
        }
    }
}
