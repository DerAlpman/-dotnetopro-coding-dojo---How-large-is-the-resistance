using System.Collections.Generic;
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
            -20,
            -10,
            -5,
            -2,
            -1,
            -0.5,
            -0.25,
            -0.1,
            -0.05,
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

        #region Resistor_DIN_IEC_62

        public static bool TryCreate(int baseResistorValue, int multiplier, double tolerance,
            out Resistor_DIN_IEC_62 resistor, out IList<string> errorMessages)
        {
            errorMessages = new List<string>();
            resistor = new Resistor_DIN_IEC_62();

            if (baseResistorValue < 10 || baseResistorValue > 99)
            {
                errorMessages.Add(string.Format("The base resistor value {0} must be between 10 and 99.", baseResistorValue));
            }

            if (multiplier < 1 || multiplier > 9)
            {
                errorMessages.Add(string.Format("The multiplier value {0} must be between 1 and 9.", multiplier));
            }

            if (!ALLOWED_TOLERANCES.Contains(tolerance))
            {
                errorMessages.Add(string.Format("The tolerance value {0} is not allowed.", tolerance));
            }

            resistor._BaseResistorValue = baseResistorValue;
            resistor._Multiplier = multiplier;
            resistor._Tolerance = tolerance;

            return !errorMessages.Any();
        }

        public string ResistorValue()
        {
            return string.Empty;
        }

        #endregion
    }
}
