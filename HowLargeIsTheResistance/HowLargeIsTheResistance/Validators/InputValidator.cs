using System;
using System.Collections.Generic;
using System.Linq;
using Components.HowLargeIsTheResistance.Models;

namespace HowLargeIsTheResistance.Validators
{
    internal class InputValidator
    {
        // Check the ring position and the according value. If "Not allowed" -> collect error messages.
        internal static void ValidateArguments(string[] args)
        {
            int argsCount = args.Count();
            if (argsCount != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(args), argsCount, "Die Funktion benötigt genau vier Argumente.");
            }
        }

        internal static void ValidateRingPositions(string[] args, IEnumerable<ColorCode_DIN_IEC_62> colorCodes)
        {
            ColorCode_DIN_IEC_62 unitPositionCode = colorCodes.First(cc => cc.Color.Equals(args[0]));
            ColorCode_DIN_IEC_62 decimalCode = colorCodes.First(cc => cc.Color.Equals(args[1]));
            ColorCode_DIN_IEC_62 multiplierCode = colorCodes.First(cc => cc.Color.Equals(args[2]));
            ColorCode_DIN_IEC_62 toleranceCode = colorCodes.First(cc => cc.Color.Equals(args[3]));

            for (int i = 0; i < args.Count(); i++)
            {
                ColorCode_DIN_IEC_62 colorCode = colorCodes.First(cc => cc.Color.Equals(i));
            }
            if (unitPositionCode.UnitValue.Equals("not_allowed"))
            {
                throw new ArgumentOutOfRangeException(String.Format("Der Farbcode {0} ist für den {1}. Ring nicht erlaubt", unitPositionCode.Color, 1));
            }

            if (decimalCode.DecimalValue.Equals("not_allowed"))
            {
                throw new ArgumentOutOfRangeException(String.Format("Der Farbcode {0} ist für den {1}. Ring nicht erlaubt", decimalCode.Color, 2));
            }

            if (multiplierCode.Multiplier.Equals("not_allowed"))
            {
                throw new ArgumentOutOfRangeException(String.Format("Der Farbcode {0} ist für den {1}. Ring nicht erlaubt", multiplierCode.Color, 3));
            }

            if (toleranceCode.Tolerance.Equals("not_allowed"))
            {
                throw new ArgumentOutOfRangeException(String.Format("Der Farbcode {0} ist für den {1}. Ring nicht erlaubt", toleranceCode.Color, 4));
            }
        }
    }
}
