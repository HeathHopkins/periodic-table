using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace PeriodicTable
{
    [Register("PeriodicTable")]
    public class PeriodicTable : UIView
    {
        List<Element> Elements;
        List<PeriodicCell> Cells;

        const int CellPadding = 2;

        public PeriodicTable(RectangleF frame, List<Element> elements)
            : base(frame)
        {
            this.Elements = elements;
            Cells = new List<PeriodicCell>();

            Elements.ForEach(item =>
            {
                var cell = new PeriodicCell(RectangleF.Empty, item);
                Add(cell);
                Cells.Add(cell);
            });
        }


        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var columns = 18;
            //var rows = 7;

            var cellWidth = (Frame.Width - ((columns + 1) * CellPadding)) / columns;
            //var cellWidth = Frame.Width / columns;
            Console.WriteLine("FrameWidth {1}, Width {0}", cellWidth, Frame.Width);
            //var cellWidth = 55;

            Cells.ForEach(cell =>
            {
                var top = cell.Element.Column * CellPadding + ((cell.Element.Column - 1) * cellWidth);
                var left = cell.Element.Row * CellPadding + ((cell.Element.Row - 1) * cellWidth);
                cell.Frame = new RectangleF(top, left, cellWidth, cellWidth);
                //cell.SetNeedsDisplay();
                cell.SetNeedsLayout();
            });
        }
    }
}

