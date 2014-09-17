using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace PeriodicTable
{
    public class PeriodicTableViewController : UIViewController
    {
        PeriodicTable PeriodicTable;

        public PeriodicTableViewController()
            : base()
        {
            Title = "Periodic Table";
        }

        public override void LoadView()
        {
            this.View = new UIView(UIScreen.MainScreen.ApplicationFrame)
            {
                BackgroundColor = Theme.BackgroundColor,
                AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
            };

            this.PeriodicTable = new PeriodicTable(new RectangleF(0, 44, View.Frame.Width, View.Frame.Height), Element.All);
            this.PeriodicTable.AutoresizingMask = View.AutoresizingMask;
            Add(this.PeriodicTable);
        }

        public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
        {
            base.DidRotate(fromInterfaceOrientation);
            this.PeriodicTable.SetNeedsLayout();
        }
    }
}

