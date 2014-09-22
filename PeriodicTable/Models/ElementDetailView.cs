using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace PeriodicTable
{
    public class ElementDetailView : UIView
    {
        public RectangleF CellFrame { get; set; }
        UIButton btnClose;
        PeriodicTableViewController controller;

        public ElementDetailView(RectangleF frame, PeriodicTableViewController controller)
            : base(frame)
        {
            this.controller = controller;
            btnClose = new UIButton(new RectangleF(0, 0, 300, 44));
            btnClose.SetTitle("Close", UIControlState.Normal);
            btnClose.TouchUpInside += (sender, e) => {
                controller.HideDetails(CellFrame);
            };
            Add(btnClose);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            btnClose.Center = this.Center;
        }
    }
}

