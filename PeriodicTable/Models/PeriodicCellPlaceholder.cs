using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;

namespace PeriodicTable
{
    public class PeriodicCellPlaceholder : PeriodicCell
    {
        public PeriodicCellPlaceholder(RectangleF frame, Element element)
            : base(frame, element)
        {
            this.lblName.Hidden = true;
            this.lblAtomicNumber.Hidden = true;
            this.lblSymbol.AdjustsFontSizeToFitWidth = true;
            this.lblSymbol.Alpha = 0.6f;
        }
    }
}

