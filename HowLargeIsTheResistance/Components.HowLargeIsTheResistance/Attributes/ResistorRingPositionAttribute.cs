using System;

namespace Components.HowLargeIsTheResistance.Attributes
{
    internal sealed class ResistorRingPositionAttribute : Attribute
    {
        #region CONSTRUCTOR

        public ResistorRingPositionAttribute(int position)
        {
            Position = position;
        }

        #endregion

        #region PROPERTIES

        public int Position { get; set; }

        #endregion
    }
}
