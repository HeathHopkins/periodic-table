using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace PeriodicTable
{
    public static class Theme
    {
        public static void Apply()
        {

        }
        static Lazy<UIColor> backgroundColor = new Lazy<UIColor>(() => FlatUI.Color.PeterRiver);
        public static UIColor BackgroundColor { get { return backgroundColor.Value; } }

        //static Lazy<UIColor> linenPattern = new Lazy<UIColor>(() => UIColor.FromPatternImage(UIImage.FromFile("")));
        //public static UIColor LinenPattern { get { return linenPattern.Value; } }

        const string FontName = @"HelveticaNeue-Medium";
        const string BoldFontName = @"HelveticaNeue-Bold";

        public static UIFont FontOfSize(float size)
        {
            return UIFont.FromName(FontName, size);
        }

        public static UIFont BoldFontOfSize(float size)
        {
            return UIFont.FromName(BoldFontName, size);
        }
    }
}


