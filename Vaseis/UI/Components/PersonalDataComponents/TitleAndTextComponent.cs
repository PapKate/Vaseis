using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Vaseis
{
    public class TitleAndTextComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// 
        /// </summary>
        protected StackPanel InfoStackPanel { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TextBlock TitleBlock { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected TextBlock TextBlock { get; private set; }

        #endregion

        #region Dependency Properties


        /// <summary>
        /// The title
        /// </summary>
        public string Title
        {
            get { return GetValue(TitleProperty).ToString(); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref=Title"/> dependency property
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(TitleAndTextComponent));

        /// <summary>
        /// The text
        /// </summary>
        public string Text
        {
            get { return GetValue(TextProperty).ToString(); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Text"/> dependency property
        /// </summary>
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(TitleAndTextComponent));

        #endregion

        #region Constructors

        public TitleAndTextComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI() 
        {
            TitleBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 32,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkGray.HexToBrush()
            };

            // Binds the text property of the text block to the Title property
            TitleBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Title))
            {
                Source = this
            });

            TextBlock = new TextBlock()
            {
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 28,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkGray.HexToBrush(),
                Margin = new Thickness(24, 0, 0, 0)
            };

            // Binds the text property of the text block to the Text property
            TextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Text))
            {
                Source = this
            });

            InfoStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            InfoStackPanel.Children.Add(TitleBlock);
            InfoStackPanel.Children.Add(TextBlock);


            Content = InfoStackPanel;
        }

        #endregion

    }
}
