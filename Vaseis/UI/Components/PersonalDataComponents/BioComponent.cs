using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Vaseis
{
    public class BioComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The Bio Header Text
        /// </summary>
        protected TextBlock BioTitle { get; private set; }

        /// <summary>
        /// The Bio 
        /// </summary>
        protected TextBlock BioTextBlock { get; private set; }

        /// <summary>
        /// The stack panel containing bio text and the title
        /// </summary>
        protected StackPanel BioStackPanel { get; private set; }

        /// <summary>
        /// The bio's border
        /// </summary>
        protected Border BioBorder { get; private set; }
        #endregion

        #region Dependency Properties

        /// <summary>
        /// The User's Bio
        /// </summary>
        public string BioText
        {
            get { return GetValue(BioProperty).ToString(); }
            set { SetValue(BioProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="BioText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty BioProperty = DependencyProperty.Register(nameof(BioText), typeof(string), typeof(BioComponent));

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
            BioTitle = new TextBlock()
            {
                Text = "Bio",
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 32,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkGray.HexToBrush(),
                Margin = new Thickness(0, 0, 0, 12)
            };

            BioTextBlock = new TextBlock()
            { 
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkGray.HexToBrush(),
                Background = Styles.White.HexToBrush(),
                TextWrapping = TextWrapping.Wrap,
                
            };

            // Binds the text property of the expander to the Bio property
            BioTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(BioText))
            {
                Source = this
            });

            var BioScrollViwer = new ScrollViewer()
            {
                VerticalAlignment = VerticalAlignment.Top,
                Content = BioTextBlock,
                VerticalScrollBarVisibility = ScrollBarVisibility.Visible,
                CanContentScroll = true,
                MaxHeight = 200
            };

            BioStackPanel = new StackPanel()
            {
                Background = Styles.White.HexToBrush(),
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(24),
            };
            // Adds the title to the stack panel
            BioStackPanel.Children.Add(BioTitle);
            // Adds the scroll viewer to the stack panel
            BioStackPanel.Children.Add(BioScrollViwer);

            // Bio's border
            BioBorder = new Border()
            {
                // Adds corner radius
                CornerRadius = new CornerRadius(8),
                // No thickness
                BorderThickness = new Thickness(0), 
                // Adds a shadow
                Effect = ControlsFactory.CreateShadow(),
                Background = Styles.White.HexToBrush(),
                Width = 1000,
                Margin = new Thickness(24),
            };

            BioBorder.Child = BioStackPanel;

            Content = BioBorder;

        }

        #endregion
    }
}
