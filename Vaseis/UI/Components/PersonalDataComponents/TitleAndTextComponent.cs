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

        protected StackPanel InfoStackPanel { get; private set; }

        protected TextBlock TitleBlock { get; private set; }

        protected TextBlock TextBlock { get; private set; }


        #endregion



        #region Dependency Properties


        /// <summary>
        /// The TextAtrr
        /// </summary>

        public string Title
        {
            get { return GetValue(TitleProperty).ToString(); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref=TitleGrade"/> dependency property
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(TitleAndTextComponent));

        /// <summary>
        /// The User's Email
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


        private void CreateGUI() {



            TitleBlock = new TextBlock()
            {
                
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 28,
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
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkGray.HexToBrush()
            };

            // Binds the text property of the text block to the Text property
            TitleBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Text))
            {
                Source = this
            });

            InfoStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(24)
            };

            InfoStackPanel.Children.Add(TitleBlock);
            InfoStackPanel.Children.Add(TextBlock);


            Content = InfoStackPanel;
        }

        #endregion

    }
}
