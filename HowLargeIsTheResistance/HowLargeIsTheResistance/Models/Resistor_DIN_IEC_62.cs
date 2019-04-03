using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Components.HowLargeIsTheResistance.Attributes;
using Components.HowLargeIsTheResistance.Interfaces;
using Components.HowLargeIsTheResistance.Models;

namespace HowLargeIsTheResistance.Models
{
    /// <summary>
    /// <para>An electronic resistor according to DIN IEC 62.</para>
    /// </summary>
    public class Resistor_DIN_IEC_62 : IElectronicResistor
    {
        #region CONSTS

        private static IReadOnlyList<double> ALLOWED_TOLERANCES = new List<double>()
        {
            0.05,
            0.1,
            0.25,
            0.5,
            1,
            2,
            5,
            10,
            20
        };

        #endregion

        #region FIELDS

        private int _BaseResistorValue;
        private int _Multiplier;
        private double _Tolerance;

        #endregion

        #region CONSTRUCTOR

        private Resistor_DIN_IEC_62(int baseResistorValue, int multiplier, double tolerance)
        {
            this._BaseResistorValue = baseResistorValue;
            this._Multiplier = multiplier;
            this._Tolerance = tolerance;
        }

        #endregion

        #region IElectronicResistor

        /// <summary>
        /// <see cref="IElectronicResistor.ResistorValue()"/>
        /// </summary>
        /// <returns>Resistor value in Ohm plus tolerance in %, e. g. 1300 Ohm ± 0.5 %.</returns>
        public string ResistorValue()
        {
            double resistorValue = _BaseResistorValue * Math.Pow(10, _Multiplier);
            return String.Format(CultureInfo.InvariantCulture, "{0} Ohm ± {1} %", resistorValue, _Tolerance);
        }

        #endregion

        #region Resistor_DIN_IEC_62

        internal static Resistor_DIN_IEC_62 Create(string[] ringColors, IReadOnlyList<ColorCode_DIN_IEC_62> colorCodes)
        {
            ValidateCountColors(ringColors, colorCodes);

            var ringColorCodes = GetColorCodesForRings(ringColors, colorCodes);

            return Resistor_DIN_IEC_62.Create(
                Convert.ToInt32(ringColorCodes[0].DecimalValue + ringColorCodes[1].UnitValue),
                Convert.ToInt32(ringColorCodes[2].Multiplier),
                Convert.ToDouble(ringColorCodes[3].Tolerance));
        }

        private static ColorCode_DIN_IEC_62[] GetColorCodesForRings(string[] ringColors, IReadOnlyList<ColorCode_DIN_IEC_62> colorCodes)
        {
            ColorCode_DIN_IEC_62[] colorCodesForRings = new ColorCode_DIN_IEC_62[ringColors.Count()];

            var propertyInfos = typeof(ColorCode_DIN_IEC_62).GetProperties().Where(p => p.CustomAttributes.Any());

            for (int i = 0; i < ringColors.Count(); i++)
            {
                string colorName = ringColors[i];
                if (!TryGetColorCode(colorName, colorCodes, out ColorCode_DIN_IEC_62 colorCode))
                {
                    throw new ArgumentOutOfRangeException(String.Format("Die Farbe {0} ist nach DIN IEC 62 kein gültiger Wert.", colorName));
                }

                int ringPosition = i + 1;
                var pInfo = propertyInfos.FirstOrDefault(pi => pi.GetCustomAttribute<ResistorRingPositionAttribute>().Position == ringPosition);

                if (pInfo == null)
                {
                    throw new ArgumentNullException(String.Format("Es gibt keine Property mit der Rinposition {0}", ringPosition));
                }

                if (pInfo.GetValue(colorCode).Equals("not_allowed"))
                {
                    throw new ArgumentOutOfRangeException(String.Format("Der Farbcode {0} ist für den {1}. Ring nicht erlaubt", colorCode.Color, ringPosition));
                }

                colorCodesForRings[i] = colorCode;
            }

            return colorCodesForRings;
        }

        internal static Resistor_DIN_IEC_62 Create(int baseResistorValue, int multiplier, double tolerance)
        {
            if (baseResistorValue < 10 || baseResistorValue > 99)
            {
                throw new ArgumentOutOfRangeException(string.Format("The base resistor value {0} must be between 10 and 99.", baseResistorValue));
            }

            if (multiplier < 1 || multiplier > 9)
            {
                throw new ArgumentOutOfRangeException(string.Format("The multiplier value {0} must be between 1 and 9.", multiplier));
            }

            if (!ALLOWED_TOLERANCES.Contains(tolerance))
            {
                throw new ArgumentOutOfRangeException(string.Format("The tolerance value {0} is not allowed.", tolerance));
            }

            return new Resistor_DIN_IEC_62(baseResistorValue, multiplier, tolerance);
        }

        /// <summary>
        /// <para></para>
        /// </summary>
        /// <param name="ringColors"></param>
        /// <param name="colorCodes"></param>
        private static void ValidateCountColors(string[] ringColors, IEnumerable<ColorCode_DIN_IEC_62> colorCodes)
        {
            int ringColorsCount = ringColors.Count();
            if (ringColorsCount != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(ringColors), ringColorsCount, "Der Widerstand benötigt genau vier Farben.");
            }
        }

        private static bool TryGetColorCode(string color, IEnumerable<ColorCode_DIN_IEC_62> colorCodes, out ColorCode_DIN_IEC_62 colorCode)
        {
            colorCode = colorCodes.FirstOrDefault(cc => cc.Color.Equals(color));

            return colorCode != null;
        }

        #endregion

    }
}
