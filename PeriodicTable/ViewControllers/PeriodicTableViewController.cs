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

            var label = new UILabel(new RectangleF(0, 600, 100, 20))
            {
                Text = "Heath Hopkins",
                Font = UIFont.SystemFontOfSize(10),// Theme.Font.Semibold(10),
                TextColor = UIColor.Black
            };
            Add(label);
            Console.WriteLine(label.Center);
        }

        public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
        {
            base.DidRotate(fromInterfaceOrientation);
            this.PeriodicTable.SetNeedsLayout();
        }
    }
}

