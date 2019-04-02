using System;
using System.Collections.Generic;
using Components.HowLargeIsTheResistance.Models;
using HowLargeIsTheResistance.Providers;
using HowLargeIsTheResistance.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HowLargeIsTheResistanceTests.TestCases
{
    [TestClass]
    public class InputValidatorTests
    {
        [TestMethod]
        [DataRow(3)]
        [DataRow(5)]
        public void ValidateArguments_NotExactlyFourArguments_ArgumentOutOfRangeException(int nrArguments)
        {
            #region ARRANGE

            string[] args = new string[nrArguments];

            #endregion

            #region ACT

            #endregion

            #region ASSERT

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => InputValidator.ValidateArguments(args));

            #endregion
        }

        [TestMethod]
        [DataRow(new string[] { "silber", "gold", "schwarz", "blau" })]
        public void ValidateArguments_RingColorsAtWrongPositionsArguments_ArgumentOutOfRangeException(string[] args)
        {
            #region ARRANGE

            ColorCode_DIN_IEC_62_FromJSONProvider provider = new ColorCode_DIN_IEC_62_FromJSONProvider(@"TestFiles\color_codes.json");
            IEnumerable<ColorCode_DIN_IEC_62> colorCodes = provider.LoadColorCodes();

            #endregion

            #region ACT

            #endregion

            #region ASSERT

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => InputValidator.ValidateRingPositions(args, colorCodes));

            #endregion
        }
    }
}
