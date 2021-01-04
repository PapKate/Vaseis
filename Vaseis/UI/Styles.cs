using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Vaseis
{
    /// <summary>
    /// Contains all the hexadecimal values for colors, universal font sizes, margins and paddings
    /// </summary>
    public static class Styles
    {
        /// <summary>
        /// White color 
        /// </summary>
        public const string White = "FFFFFF";

        /// <summary>
        /// A bit darker white color = ghost white
        /// </summary>
        public const string GhostWhite = "F4F4F9";

        /// <summary>
        /// A dark blue color = purssian blue
        /// </summary>
        public const string DarkBlue = "002E54";

        /// <summary>
        /// A dark green color = hookers green
        /// </summary>
        public const string HookersGreen = "397367";

        /// <summary>
        /// A dark shade of pink color = big dip oruby
        /// </summary>
        public const string DarkPink = "9F1747";

        /// <summary>
        /// A dark gray color = jet (font color) 
        /// </summary>
        public const string DarkGray = "333333";

        /// <summary>
        /// A fiery red color = red pigment
        /// </summary>
        public const string Red = "F11422";

        /// <summary>
        /// Green color = Caribbean green
        /// </summary>
        public const string Green = "35CE8D";

        /// <summary>
        /// A light blue color = Aero
        /// </summary>
        public const string LightBlue = "8EB8E5";

        /// <summary>
        /// Yellow color = Mustard
        /// </summary>
        public const string Yellow = "F5D547";

        /// <summary>
        /// A blue green color = Metallic seaweed
        /// </summary>
        public const string GreenBlue = "028090";

        /// <summary>
        /// A light green blue color = Green sheen
        /// </summary>
        public const string LightGreenBlue = "70C1B3";

        /// <summary>
        /// Light orange color = Mandarin
        /// </summary>
        public const string Orange = "EF8354";

        /// <summary>
        /// The default margin
        /// </summary>
        public static Thickness DeaultMargin = new Thickness(24);

        /// <summary>
        /// Calibri font family
        /// </summary>
        public static FontFamily Calibri = new FontFamily("Calibri");
    }
}
