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
        static Lazy<UIColor> backgroundColor = new Lazy<UIColor>(() => FlatUI.Color.Clouds);
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

        public static class Font
        {
            public static UIFont Black(float size)
            {
                return UIFont.FromName("Lato-Black", size);
            }

            public static UIFont Bold(float size)
            {
                return UIFont.FromName("Lato-Bold", size);
            }

            public static UIFont Medium(float size)
            {
                return UIFont.FromName("Lato-Medium", size);
            }

            public static UIFont Regular(float size)
            {
                return UIFont.FromName("Lato-Regular", size);
            }

            public static UIFont Semibold(float size)
            {
                return UIFont.FromName("Lato-Semibold", size);
            }
        }
    }
}


