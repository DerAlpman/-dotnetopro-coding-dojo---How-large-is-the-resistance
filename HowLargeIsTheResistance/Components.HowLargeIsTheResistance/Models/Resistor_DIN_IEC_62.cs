using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Components.HowLargeIsTheResistance.Models
{
    /// <summary>
    /// <para>An electronic resistor according to DIN IEC 62.</para>
    /// </summary>
    public class Resistor_DIN_IEC_62
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

        #region Resistor_DIN_IEC_62

        public static Resistor_DIN_IEC_62 Create(int baseResistorValue, int multiplier, double tolerance)
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

        public string ResistorValue()
        {
            double resistorValue = _BaseResistorValue * Math.Pow(10, _Multiplier);
            return String.Format(CultureInfo.InvariantCulture, "{0} Ohm ± {1} %", resistorValue, _Tolerance);
        }

        #endregion
    }
}
