﻿using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;

namespace PeriodicTable
{
    [Register("PeriodicCell")]
    public class PeriodicCell : UIButton// UIView
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

            //var heightLblName = ((Frame.Height - lblSymbol.Font.LineHeight - lblSymbol.Font.Descender) / 2);
            var heightLblName = Math.Floor(Frame.Height / 3);
            heightLblName = heightLblName % 2 == 0 ? heightLblName : heightLblName - 1;
            //var yLblName = heightLblName + lblSymbol.Font.LineHeight + lblSymbol.Font.Descender;
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

//        public override void Draw(System.Drawing.RectangleF rect)
//        {
//            base.Draw(rect);
//
//            //// General Declarations
//            var context = UIGraphics.GetCurrentContext();
//
//            //// Color Declarations
//            var color = UIColor.FromRGBA(1.000f, 1.000f, 1.000f, 1.000f);
//
//            //// Shadow Declarations
//            var shadow = UIColor.Black.ColorWithAlpha(0.2f).CGColor;
//            var shadowOffset = new SizeF(1.1f, 1.1f);
//            var shadowBlurRadius = 0.0f;
//
//            //// Rectangle Drawing
//            var rectanglePath = UIBezierPath.FromRect(new RectangleF(63.0f, 31.0f, 54.0f, 54.0f));
//            color.SetStroke();
//            rectanglePath.LineWidth = 1.0f;
//            rectanglePath.Stroke();
//
//
//            //// Symbol Drawing
//            RectangleF textRect = new RectangleF(63.0f, 45.0f, 59.0f, 22.0f);
//            {
//                var textContent = "He";
//                color.SetFill();
//                var textInset = RectangleF.Inflate(textRect, -4.0f, 0.0f);
//                var textFont = UIFont.FromName("HelveticaNeue-Light", 22.0f);
//                textInset.Offset(0.0f, (textInset.Height - new NSString(textContent).StringSize(textFont, textInset.Size).Height) / 2.0f);
//                new NSString(textContent).DrawString(textInset, textFont, UILineBreakMode.WordWrap, UITextAlignment.Left);
//            }
//
//
//            //// AtomicNumber Drawing
//            RectangleF atomicNumberRect = new RectangleF(63.0f, 31.0f, 50.0f, 14.0f);
//            {
//                var textContent = "2";
//                context.SaveState();
//                context.SetShadowWithColor(shadowOffset, shadowBlurRadius, shadow);
//                color.SetFill();
//                var atomicNumberInset = RectangleF.Inflate(atomicNumberRect, -4.0f, 0.0f);
//                var atomicNumberFont = UIFont.FromName("HelveticaNeue-Light", UIFont.SmallSystemFontSize);
//                atomicNumberInset.Offset(0.0f, (atomicNumberInset.Height - new NSString(textContent).StringSize(atomicNumberFont, atomicNumberInset.Size).Height) / 2.0f);
//                new NSString(textContent).DrawString(atomicNumberInset, atomicNumberFont, UILineBreakMode.WordWrap, UITextAlignment.Left);
//                context.RestoreState();
//
//            }
//
//
//            //// Weight Drawing
//            RectangleF weightRect = new RectangleF(63.0f, 73.0f, 54.0f, 12.0f);
//            {
//                var textContent = "4.0026";
//                context.SaveState();
//                context.SetShadowWithColor(shadowOffset, shadowBlurRadius, shadow);
//                color.SetFill();
//                var weightInset = RectangleF.Inflate(weightRect, -4.0f, 0.0f);
//                var weightFont = UIFont.FromName("HelveticaNeue-Light", UIFont.SmallSystemFontSize);
//                weightInset.Offset(0.0f, (weightInset.Height - new NSString(textContent).StringSize(weightFont, weightInset.Size).Height) / 2.0f);
//                new NSString(textContent).DrawString(weightInset, weightFont, UILineBreakMode.WordWrap, UITextAlignment.Left);
//                context.RestoreState();
//
//            }
//
//
//            //// Name Drawing
//            RectangleF nameRect = new RectangleF(67.0f, 61.0f, 50.0f, 12.0f);
//            {
//                var textContent = "Helium";
//                context.SaveState();
//                context.SetShadowWithColor(shadowOffset, shadowBlurRadius, shadow);
//                color.SetFill();
//                var nameFont = UIFont.FromName("HelveticaNeue-Light", UIFont.SmallSystemFontSize);
//                nameRect.Offset(0.0f, (nameRect.Height - new NSString(textContent).StringSize(nameFont, nameRect.Size).Height) / 2.0f);
//                new NSString(textContent).DrawString(nameRect, nameFont, UILineBreakMode.WordWrap, UITextAlignment.Left);
//                context.RestoreState();
//
//            }
//
//        }


    }
}

