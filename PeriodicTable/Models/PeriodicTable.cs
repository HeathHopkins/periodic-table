using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace PeriodicTable
{
    [Register("PeriodicTable")]
    public class PeriodicTable : UIView
    {
        List<Element> Elements;
        List<PeriodicCell> Cells;

        List<PeriodicCellPlaceholder> PlaceholderCells;

        const int CellPadding = 3;

        public PeriodicTable(RectangleF frame, List<Element> elements)
            : base(frame)
        {
            this.Elements = elements.OrderBy(o => o.AtomicNumber).ToList();
            Cells = new List<PeriodicCell>();

            Elements.ForEach(item =>
            {
                var cell = new PeriodicCell(RectangleF.Empty, item);
                Add(cell);
                Cells.Add(cell);
            });

            PlaceholderCells = new List<PeriodicCellPlaceholder>();

            var cellLanthPlaceholder = new PeriodicCellPlaceholder(RectangleF.Empty, new Element() 
            {
                Symbol = "57 - 71",
                Group = 3,
                Period = 6,
                AtomicNumber = 57
            });
            Add(cellLanthPlaceholder);
            PlaceholderCells.Add(cellLanthPlaceholder);

            var cellActPlaceholder = new PeriodicCellPlaceholder(RectangleF.Empty, new Element() 
            {
                Symbol = "89 - 103",
                Group = 3,
                Period = 7,
                AtomicNumber = 89
            });
            Add(cellActPlaceholder);
            PlaceholderCells.Add(cellActPlaceholder);
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

            // layout standard cells
            Cells.Where(o => !o.Element.IsActinoid && !o.Element.IsLanthanoid).ToList().ForEach(cell =>
            {
                var top = cell.Element.Column * CellPadding + ((cell.Element.Column - 1) * cellWidth);
                var left = cell.Element.Row * CellPadding + ((cell.Element.Row - 1) * cellWidth);
                cell.Frame = new RectangleF(top, left, cellWidth, cellWidth);
                cell.SetNeedsLayout();
            });

            // layout Lanthanoids and Actinoids
            Cells.Where(o => o.Element.IsLanthanoid || o.Element.IsActinoid).ToList().ForEach(cell =>
            {
                var offset = (cellWidth + CellPadding) / 2;
                var top = cell.Element.Column * CellPadding + ((cell.Element.Column - 1) * cellWidth) + offset;
                var left = cell.Element.Row * CellPadding + ((cell.Element.Row - 1) * cellWidth) // normal positioning
                    + ((cellWidth + CellPadding) * 2) // shifts it down to outside of the normal table flow
                    + offset; // shifts it down a little more to show that it's not just another row
                cell.Frame = new RectangleF(top, left, cellWidth, cellWidth);
                cell.SetNeedsLayout();
            });

            PlaceholderCells.ForEach(cell =>
            {
                var top = cell.Element.Column * CellPadding + ((cell.Element.Column - 1) * cellWidth);
                var left = cell.Element.Row * CellPadding + ((cell.Element.Row - 1) * cellWidth);
                cell.Frame = new RectangleF(top, left, cellWidth, cellWidth);
                cell.SetNeedsLayout();
            });

//            // layout Actinoid
//            Cells.Where(o => o.Element.IsActinoid).ToList().ForEach(cell =>
//            {
//                var offset = (cellWidth + CellPadding) / 2;
//                var top = cell.Element.Column * CellPadding + ((cell.Element.Column - 1) * cellWidth) + offset;
//                var left = cell.Element.Row * CellPadding + ((cell.Element.Row - 1) * cellWidth) // normal positioning
//                    + ((cellWidth + CellPadding) * 2) // shifts it down to outside of the normal table flow
//                    + offset; // shifts it down a little more to show that it's not just another row
//                cell.Frame = new RectangleF(top, left, cellWidth, cellWidth);
//                cell.SetNeedsLayout();
//            });
        }
    }
}

