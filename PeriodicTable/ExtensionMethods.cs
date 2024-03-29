﻿using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Drawing;

namespace PeriodicTable
{
    public static class ExtensionMethods
    {
        public static UIColor ToUIColor(this string hexString)
        {
            hexString = hexString.Replace("#", "");

            if (hexString.Length == 3)
                hexString = hexString + hexString;

            if (hexString.Length != 6)
                throw new Exception("Invalid hex string");

            int red = Int32.Parse(hexString.Substring(0,2), System.Globalization.NumberStyles.AllowHexSpecifier);
            int green = Int32.Parse(hexString.Substring(2,2), System.Globalization.NumberStyles.AllowHexSpecifier);
            int blue = Int32.Parse(hexString.Substring(4,2), System.Globalization.NumberStyles.AllowHexSpecifier);

            return UIColor.FromRGB(red, green, blue);
        }

        public static SizeF StringSize(this UILabel label)
        {
            return new NSString(label.Text).StringSize(label.Font);
        }

        /// <summary>
        /// Returns a lighter color
        /// </summary>
        /// <param name="steps">The number of steps to lighten.</param>
        public static UIColor Lighten(this UIColor color, int steps)
        {
            int modifier = 16 * steps;

            float rF, gF, bF, aF;
            color.GetRGBA(out rF, out gF, out bF, out aF);

            int r, g, b, a;
            r = (int)Math.Ceiling(rF * 255);
            g = (int)Math.Ceiling(gF * 255);
            b = (int)Math.Ceiling(bF * 255);
            a = (int)Math.Ceiling(aF * 255);

            r += modifier;
            g += modifier;
            b += modifier;
            // leave 'a' alone?

            r = r > 255 ? 255 : r;
            g = g > 255 ? 255 : g;
            b = b > 255 ? 255 : b;

            return UIColor.FromRGBA(r, g, b, a);
        }

        /// <summary>
        /// Returns a darker color
        /// </summary>
        /// <param name="steps">The number of steps to darken.</param>
        public static UIColor Darken(this UIColor color, int steps)
        {
            int modifier = 16 * steps;

            float rF, gF, bF, aF;

            color.GetRGBA(out rF, out gF, out bF, out aF);

            int r, g, b, a;
            r = (int)Math.Ceiling(rF * 255);
            g = (int)Math.Ceiling(gF * 255);
            b = (int)Math.Ceiling(bF * 255);
            a = (int)Math.Ceiling(aF * 255);

            r -= modifier;
            g -= modifier;
            b -= modifier;
            // leave 'a' alone?

            r = r < 0 ? 0 : r;
            g = g < 0 ? 0 : g;
            b = b < 0 ? 0 : b;

            return UIColor.FromRGBA(r, g, b, a);
        }

        public static RectangleF ToEvenValues(this RectangleF frame)
        {
            var x = (int)frame.X;
            var height = (int)frame.Height;
            if (height % 2 != 0) // if not odd, reduce by 1
                height--;

            var y = (int)frame.Y;
            var width = (int)frame.Width;
            if (width % 2 != 0) // if not odd, reduce by 1
                width--;

            return new RectangleF((float)x, (float)y, (float)width, (float)height);
        }
    }
}
