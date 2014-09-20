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

        const int CellMargin = 2;

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


            var baseWidth = Frame.Width;
            var columns = 18;
            //var rows = 7;


            var tableWidth = baseWidth - CellMargin;  // seed an offset
            while (tableWidth % columns != 0)
                tableWidth = tableWidth - 2;
            Console.WriteLine("Calculated table width: {0}", tableWidth);

            var tableWidthMargin = (baseWidth - tableWidth) / 2;
            Console.WriteLine("Left and right table margin is {0}", tableWidthMargin);

            // THIS VALUE NEEDS TO BE EVEN TO PREVENT BLURRY TEXT
            var cellWidth = (tableWidth / columns) - 2;
            Console.WriteLine("Cell width w/o margin: {0}", cellWidth);

            // layout standard cells
            Cells.Where(o => !o.Element.IsActinoid && !o.Element.IsLanthanoid).ToList().ForEach(cell =>
            {
                var marginOffset = cell.Element.Column == 1 ? CellMargin / 2 : CellMargin;
                var x = cell.Element.Column * marginOffset + ((cell.Element.Column - 1) * cellWidth) + tableWidthMargin;
                var y = cell.Element.Row * CellMargin + ((cell.Element.Row - 1) * cellWidth);
                cell.Frame = new RectangleF(x, y, cellWidth, cellWidth);
                cell.SetNeedsLayout();
            });

            // layout Lanthanoids and Actinoids
            Cells.Where(o => o.Element.IsLanthanoid || o.Element.IsActinoid).ToList().ForEach(cell =>
            {
                var offset = (cellWidth + CellMargin) / 2;
                var x = cell.Element.Column * CellMargin + ((cell.Element.Column - 1) * cellWidth) + offset;
                var y = cell.Element.Row * CellMargin + ((cell.Element.Row - 1) * cellWidth) // normal positioning
                    + ((cellWidth + CellMargin) * 2) // shifts it down to outside of the normal table flow
                    + offset; // shifts it down a little more to show that it's not just another row
                cell.Frame = new RectangleF(x, y, cellWidth, cellWidth).ToEvenValues();
                cell.SetNeedsLayout();
            });

            PlaceholderCells.ForEach(cell =>
            {
                //var top = cell.Element.Column * CellPadding + ((cell.Element.Column - 1) * cellWidth);
                //var left = cell.Element.Row * CellPadding + ((cell.Element.Row - 1) * cellWidth);
                //cell.Frame = new RectangleF(top, left, cellWidth, cellWidth);
                //cell.SetNeedsLayout();
            });
        }
    }
}

