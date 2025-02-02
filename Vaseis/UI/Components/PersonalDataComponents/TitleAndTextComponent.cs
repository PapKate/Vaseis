﻿using System;
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
        /// The stack panel for title and text
        /// </summary>
        protected StackPanel InfoStackPanel { get; private set; }

        /// <summary>
        /// The title's text block
        /// </summary>
        protected TextBlock TitleBlock { get; private set; }

        /// <summary>
        /// The text's grid
        /// </summary>
        protected Grid TextGrid { get; private set; }

        /// <summary>
        /// The text's text block
        /// </summary>
        protected TextBlock TextBlock { get; private set; }

        #endregion

        #region Dependency Properties


        /// <summary>
        /// The title
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
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
            get { return (string)GetValue(TextProperty); }
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
                FontSize = 28,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkGray.HexToBrush(),
                Width = 280
            };

            // Binds the text property of the text block to the Title property
            TitleBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Title))
            {
                Source = this
            });

            TextGrid = new Grid()
            {

            };

            TextBlock = new TextBlock()
            {
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkGray.HexToBrush(),
            };

            // Binds the text property of the text block to the Text property
            TextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Text))
            {
                Source = this
            });
            TextGrid.Children.Add(TextBlock);

            InfoStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            InfoStackPanel.Children.Add(TitleBlock);
            InfoStackPanel.Children.Add(TextGrid);


            Content = InfoStackPanel;
        }

        #endregion

    }
}
