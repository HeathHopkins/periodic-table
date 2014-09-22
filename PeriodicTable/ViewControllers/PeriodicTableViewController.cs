using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;

namespace PeriodicTable
{
    public class PeriodicTableViewController : UIViewController
    {
        PeriodicTable PeriodicTable;

        ElementDetailView detailsView;

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

            this.PeriodicTable.CellSelected += (Element item, RectangleF cellFrame) =>
            {
                Console.WriteLine("cell selected event in view controller {0}", item.Symbol);
                ShowDetails(item, cellFrame);
                //var transform = CGAffineTransform..MakeScale(scale,scale);
            };

            detailsView = new ElementDetailView(View.Bounds, this)
            {
                AutoresizingMask = View.AutoresizingMask,
                Hidden = true,
                Alpha = 0
            };
            Add(detailsView);
        }

        public void ShowDetails(Element element, RectangleF cellFrame)
        {
            cellFrame.Offset(PeriodicTable.Frame.Location);
            detailsView.CellFrame = cellFrame;
            detailsView.Frame = cellFrame;
            detailsView.BackgroundColor = PeriodicCell.GetBackgroundColor(element.GroupName);
            UIView.Animate(1.2, 0, UIViewAnimationOptions.CurveEaseInOut, 
                () => 
                {
                    detailsView.Hidden = false;
                    detailsView.Alpha = 1;
                    detailsView.Frame = this.View.Bounds;
                },
                () => { detailsView.SetNeedsLayout(); }
            );
        }

        public void HideDetails(RectangleF cellFrame)
        {

            UIView.Animate(1.2, 0, UIViewAnimationOptions.CurveEaseInOut, 
                () => 
            {
                detailsView.Frame = cellFrame;
                detailsView.Alpha = 0;

            },
                () => { detailsView.Hidden = true; }
            );
        }

        public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
        {
            base.DidRotate(fromInterfaceOrientation);
            this.PeriodicTable.SetNeedsLayout();
        }
    }
}

