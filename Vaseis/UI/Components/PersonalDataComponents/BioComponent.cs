using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Vaseis
{
    public class BioComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The Bio Header Text
        /// </summary>
        public TextBlock BioTextBlock{ get;  set; }


        /// <summary>
        /// The Bio 
        /// </summary>
        public Expander BioExpander { get; set; }

        #endregion

        #region Dependency Properties

        /// <summary>
        /// The User's Bio
        /// </summary>
        public string Bio
        {
            get { return GetValue(BioProperty).ToString(); }
            set { SetValue(BioProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="FirstName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty BioProperty = DependencyProperty.Register(nameof(Bio), typeof(string), typeof(BioComponent));

        #endregion

        #region Constructors 

        public BioComponent() 
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            BioTextBlock = new TextBlock()
            {
                Text = "Bio",
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 28,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkBlue.HexToBrush()
            };

            BioExpander = new Expander()
            { 
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkBlue.HexToBrush(),
                Background = Styles.White.HexToBrush(),
            };

            // Binds the text property of the expander to the Bio property
            BioExpander.SetBinding(TextBlock.TextProperty, new Binding(nameof(Bio))
            {
                Source = this
            });


            var bioStackPanel = new StackPanel()
            {
                Background = Styles.White.HexToBrush()
            };

            bioStackPanel.Children.Add(BioTextBlock);
            bioStackPanel.Children.Add(BioExpander);

            Content = bioStackPanel;

        }

        #endregion
    }
}
