using System.Collections.Generic;
using Components.HowLargeIsTheResistance.Models;
using HowLargeIsTheResistance.Providers;

namespace HowLargeIsTheResistance
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorCode_DIN_IEC_62_FromJSONProvider colorCodesProvider = new ColorCode_DIN_IEC_62_FromJSONProvider("color_codes.json");
            IReadOnlyList<ColorCode_DIN_IEC_62> colorCodes = colorCodesProvider.LoadColorCodes();
        }
    }
}
