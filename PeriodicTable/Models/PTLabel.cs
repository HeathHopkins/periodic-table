﻿using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;

namespace PeriodicTable
{
    [Register("PTLabel")]
    public class PTLabel : UILabel
    {
        public PTLabel()
            : base()
        {
        }

        public override void DrawText(RectangleF rect)
        {
            var insets = new UIEdgeInsets(0, 2, 0, 2);
            base.DrawText(insets.InsetRect(rect));
        }
    }
}

