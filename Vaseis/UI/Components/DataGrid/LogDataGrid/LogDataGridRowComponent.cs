using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static Vaseis.Styles;

namespace Vaseis
{
    class LogDataGridRowComponent : ContentControl
    {
        #region Public Properties

        #endregion

        #region Protected Properties

        /// <summary>
        /// The row's border
        /// </summary>
        protected Border RowBorder { get; private set; }

        /// <summary>
        /// The grid inside the row
        /// </summary>
        protected Grid RowGrid { get; private set; }
         
        /// <summary>
        /// The username TextBlock
        /// </summary>
        private TextBlock UsernameTextBlock { get;  set; }

        /// <summary>
        /// The action TextBlock
        /// </summary>
        private TextBlock ActionTextBlock { get; set; }

        /// <summary>
        /// The details TextBlock
        /// </summary>
        private TextBlock DetailsTextBlock { get; set; }

        /// <summary>
        /// When the action happened TextBlock
        /// </summary>
        private TextBlock DateTimeTextBlock { get; set; }

        #endregion

        #region Dependency Properties

        /// <summary>
        /// The user's username
        /// </summary>
        public string Username
        {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Username"/> dependency property
        /// </summary>
        public static readonly DependencyProperty UsernameProperty = DependencyProperty.Register(nameof(Username), typeof(string), typeof(LogDataGridRowComponent));

        /// <summary>
        /// The user's action
        /// </summary>
        public string Action
        {
            get { return (string)GetValue(ActionProperty); }
            set { SetValue(ActionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Action"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ActionProperty = DependencyProperty.Register(nameof(Action), typeof(string), typeof(LogDataGridRowComponent));


        /// <summary>
        /// The action Details
        /// </summary>
        public string Details
        {
            get { return (string)GetValue(DetailsProperty); }
            set { SetValue(DetailsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Details"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DetailsProperty = DependencyProperty.Register(nameof(Details), typeof(string), typeof(LogDataGridRowComponent));

        /// <summary>
        /// When tghe action happened
        /// </summary>
        public string DateTime
        {
            get { return (string)GetValue(DateTimeProperty); }
            set { SetValue(DateTimeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DateTime"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DateTimeProperty = DependencyProperty.Register(nameof(DateTime), typeof(string), typeof(LogDataGridRowComponent));


        #endregion

        #region Constructors

        public LogDataGridRowComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the row's border
            RowBorder = new Border()
            {
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = DarkPink.HexToBrush(),
                Background = GhostWhite.HexToBrush(),
                Padding = new Thickness(12),
            };

            #region About the grid

            RowGrid = new Grid();

            RowGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(400, GridUnitType.Pixel)
            });
            RowGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(400, GridUnitType.Pixel)
            });

            RowGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(400, GridUnitType.Pixel)
            });

            RowGrid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(400, GridUnitType.Pixel)
            });

            #endregion

            UsernameTextBlock = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Foreground = DarkBlue.HexToBrush(),
                Width = 400
            };
            // Binds the text property of the text block to the Text property
            UsernameTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Username))
            {
                Source = this
            });

            RowGrid.Children.Add(UsernameTextBlock);
            Grid.SetColumn(UsernameTextBlock,0);

            ActionTextBlock = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 24,
                FontWeight = FontWeights.SemiBold,
                Foreground = DarkBlue.HexToBrush(),
                Width = 400
            };
            // Binds the text property of the text block to the Text property
            ActionTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Action))
            {
                Source = this
            });

            RowGrid.Children.Add(ActionTextBlock);
            Grid.SetColumn(ActionTextBlock, 1);

            DetailsTextBlock = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Foreground = DarkBlue.HexToBrush(),
                Width = 400
            };
            // Binds the text property of the text block to the Text property
            DetailsTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Details))
            {
                Source = this
            });

            RowGrid.Children.Add(DetailsTextBlock);
            Grid.SetColumn(DetailsTextBlock, 2);

            DateTimeTextBlock = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Foreground = DarkBlue.HexToBrush(),
                Width = 400
            };
            // Binds the text property of the text block to the Text property
            DateTimeTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(DateTime))
            {
                Source = this
            });

            RowGrid.Children.Add(DateTimeTextBlock);
            Grid.SetColumn(DateTimeTextBlock, 3);

            RowBorder.Child = RowGrid;

            Content = RowBorder;
            #endregion

        }

    }
}