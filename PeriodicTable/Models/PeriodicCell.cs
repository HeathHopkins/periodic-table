using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;

namespace PeriodicTable
{
    [Register("PeriodicCell")]
    public class PeriodicCell : UIButton
    {
        protected PTLabel lblAtomicNumber, lblSymbol, lblName;

        protected const int PaddingWidth = 4;

        public Element Element { get; private set; }

        public PeriodicCell(RectangleF frame, Element element)
            : base(frame)
        {
            this.Element = element;
            this.BackgroundColor = CellBackgroundColor;

            lblAtomicNumber = new PTLabel()
            {
                Text = this.Element.AtomicNumber.ToString(),
                TextColor = UIColor.White,
                BackgroundColor = UIColor.Clear
            };

            lblSymbol = new PTLabel()
            {
                Text = this.Element.Symbol,
                TextColor = UIColor.White,
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = this.BackgroundColor
            };

            lblName = new PTLabel()
            {
                Text = this.Element.Name,
                TextColor = UIColor.White,
                TextAlignment = UITextAlignment.Center,
                AdjustsFontSizeToFitWidth = true,
                BackgroundColor = UIColor.Clear
                //BackgroundColor = UIColor.Red
            };

//            lblWeight = new PTLabel()
//            {
//                Text = this.Element.AtomicWeight,
//                AdjustsFontSizeToFitWidth = true
//            };

            Add(lblSymbol);
            Add(lblAtomicNumber);
            Add(lblName);
//            Add(lblWeight);

            this.TouchDragEnter += (object sender, EventArgs e) => {
                HighlightCell();
            };

            this.TouchDown += (object sender, EventArgs e) => {
                HighlightCell();
            };
            this.TouchDragExit += (object sender, EventArgs e) => {
                UnhighlightCell();
            };
            this.TouchUpInside += (object sender, EventArgs e) => {
                UnhighlightCell();
            };
        }

        public void HighlightCell()
        {
            lblSymbol.BackgroundColor = BackgroundColor.Lighten(2);
        }

        public void UnhighlightCell()
        {
            lblSymbol.BackgroundColor = BackgroundColor;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            lblSymbol.Frame = new RectangleF(0, 0, Frame.Width, Frame.Height);

            var symbolFontSize = Math.Floor(Frame.Height / 2.3);
            symbolFontSize = symbolFontSize % 2 == 0 ? symbolFontSize : symbolFontSize - 1;
            lblSymbol.Font = Theme.Font.Black((float)symbolFontSize);

            var textFontSize = Math.Floor(Frame.Height / 5);
            textFontSize = textFontSize % 2 == 0 ? textFontSize : textFontSize - 1;
            var font = Theme.Font.Semibold((float)textFontSize);

            var heightLblName = Math.Floor(Frame.Height / 3);
            heightLblName = heightLblName % 2 == 0 ? heightLblName : heightLblName - 1;
            var yLblName = Frame.Height - heightLblName;
            lblName.Frame = new RectangleF(0, (float)yLblName, Frame.Width, (float)heightLblName);
            lblName.Font = font;

            lblAtomicNumber.Frame = new RectangleF(0, 2, Frame.Width, (float)textFontSize);
            lblAtomicNumber.Font = font;


        }

        public UIColor CellBackgroundColor
        {
            get
            {
                return PeriodicCell.GetBackgroundColor(Element.GroupName);
            }
        }

        public static UIColor GetBackgroundColor(string groupName)
        {
            switch (groupName)
            {
                case "Metalloids":
                    return FlatUI.Color.Amethyst;
                case "Other Nonmetals":
                    return FlatUI.Color.Emerald;
                case "Halogens":
                    return FlatUI.Color.Alizarin;
                case "Noble Gases":
                    return FlatUI.Color.BelizeHole;
                case "Alkali Metals":
                    return FlatUI.Color.Orange;
                case "Alkaline Earth Metals":
                    return FlatUI.Color.SunFlower;
                case "Lanthanoids":
                    return FlatUI.Color.Pumpkin;
                case "Actinoids":
                    return FlatUI.Color.Pomegranate;
                case "Transition Metals":
                    return FlatUI.Color.PeterRiver;
                case "Post-transition Metals":
                    return FlatUI.Color.GreenSea;
                default:
                    return UIColor.Black;
            }
        }
    }
}

