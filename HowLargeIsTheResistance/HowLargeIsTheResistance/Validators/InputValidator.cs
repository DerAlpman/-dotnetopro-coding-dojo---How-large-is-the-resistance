using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Components.HowLargeIsTheResistance.Attributes;
using Components.HowLargeIsTheResistance.Models;

namespace HowLargeIsTheResistance.Validators
{
    internal class InputValidator
    {
        /// <summary>
        /// <para></para>
        /// </summary>
        /// <param name="args"></param>
        /// <param name="colorCodes"></param>
        internal static void ValidateArguments(string[] args, IEnumerable<ColorCode_DIN_IEC_62> colorCodes)
        {
            int argsCount = args.Count();
            if (argsCount != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(args), argsCount, "Die Funktion benötigt genau vier Argumente.");
            }

            ValidateRingPositions(args, colorCodes);
        }

        private static void ValidateRingPositions(string[] args, IEnumerable<ColorCode_DIN_IEC_62> colorCodes)
        {
            var propertyInfos = typeof(ColorCode_DIN_IEC_62).GetProperties().Where(p => p.CustomAttributes.Any());

            for (int i = 0; i < args.Count(); i++)
            {
                string colorName = args[i];
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
                    throw new ArgumentOutOfRangeException(String.Format("Der Farbcode {0} ist für den {1}. Ring nicht erlaubt", colorCode.Color, 1));
                }
            }
        }

        private static bool TryGetColorCode(string color, IEnumerable<ColorCode_DIN_IEC_62> colorCodes, out ColorCode_DIN_IEC_62 colorCode)
        {
            colorCode = colorCodes.FirstOrDefault(cc => cc.Color.Equals(color));

            return colorCode != null;
        }
    }
}

