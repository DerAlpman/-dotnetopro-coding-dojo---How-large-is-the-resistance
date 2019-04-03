using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Components.HowLargeIsTheResistance.Models;
using HowLargeIsTheResistance.Models;
using HowLargeIsTheResistance.Providers;

namespace HowLargeIsTheResistance
{
    class Program
    {
        static void Main(string[] ringColors)
        {
            try
            {
                ColorCode_DIN_IEC_62_FromJSONProvider colorCodesProvider = new ColorCode_DIN_IEC_62_FromJSONProvider("color_codes.json");
                IReadOnlyList<ColorCode_DIN_IEC_62> colorCodes = colorCodesProvider.LoadColorCodes();

                if (colorCodesProvider.ValidationErrorMessages.Any())
                {
                    ((List<string>)colorCodesProvider.ValidationErrorMessages).ForEach(vem => Console.WriteLine(vem));
                    return;
                }

                Resistor_DIN_IEC_62 resistor = Resistor_DIN_IEC_62.Create(ringColors, colorCodes);

                Console.WriteLine(resistor.ResistorValue());
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(String.Format(e.Message, e.FileName));
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
