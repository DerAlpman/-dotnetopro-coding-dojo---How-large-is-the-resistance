﻿using System.Linq;
using HowLargeIsTheResistance.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HowLargeIsTheResistanceTests
{
    [TestClass]
    public class ColorCode_DIN_IEC_62_ProviderTests
    {
        [TestMethod]
        public void LoadColorCodes_ProviderGetsNotExistingFileName_EmptyListOfColorCodes()
        {
            #region ARRANGE

            ColorCode_DIN_IEC_62_Provider provider = new ColorCode_DIN_IEC_62_Provider("Schnulli.xml");

            #endregion

            #region ACT

            var colorCodes = provider.LoadColourCodes();

            #endregion

            #region ASSERT

            Assert.IsTrue(!colorCodes.Any());

            #endregion
        }

        [TestMethod]
        public void LoadColorCodes_ProviderGetsExistingFileName_ListOfColorCodesWithElements()
        {
            #region ARRANGE

            ColorCode_DIN_IEC_62_Provider provider = new ColorCode_DIN_IEC_62_Provider("color_codes.xml");

            #endregion

            #region ACT

            var colorCodes = provider.LoadColourCodes();

            #endregion

            #region ASSERT

            Assert.IsTrue(colorCodes.Any());

            #endregion
        }
    }
}
