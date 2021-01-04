using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
namespace Vaseis
{
    public static class MaterialDesignStyles
    {
        /// <summary>
        /// The material design raised button
        /// By default gets the mid hue (DArk Pink) as the background color
        /// </summary>
        public static Style RaisedButton = Application.Current.Resources["MaterialDesignRaisedButton"] as Style;

        /// <summary>
        /// 
        /// </summary>
        public static Style LightRaisedButton = Application.Current.Resources["MaterialDesignRaisedLightButton"] as Style;

        /// <summary>
        /// 
        /// </summary>
        public static Style DarkRaisedButton = Application.Current.Resources["MaterialDesignRaisedDarkButton"] as Style;

        public static Style AccentRaisedButton = Application.Current.Resources["MaterialDesignRaisedAccentButton"] as Style;


        public static Style NameTextBox = Application.Current.Resources["MaterialDesignNameTextBox"] as Style;

   

        /// <summary>
        /// 
        /// </summary>
        public static Style TextBoxStyle = Application.Current.Resources["MaterialDesignOutlinedTextBox"] as Style;


        /// <summary>
        /// The material design flat button
        /// By default gets the mid hue (DArk Pink) as the background color
        /// </summary>
        public static Style FlatButton = Application.Current.Resources["MaterialDesignFlatButton"] as Style;
    }
}
