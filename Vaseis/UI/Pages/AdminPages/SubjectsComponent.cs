using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Shapes;
using static Vaseis.Styles;

namespace Vaseis
{
    public class SubjectsComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The stack panel containing the title and a list of data
        /// </summary>
        protected StackPanel TitleAndDataStackPanel { get; private set; }

        /// <summary>
        /// The title text
        /// </summary>
        protected TextBlock TitleBlock { get; private set; }

        /// <summary>
        /// The title header
        /// </summary>
        protected TextBlock TitleHeader { get; private set; }

        /// <summary>
        /// The description header
        /// </summary>
        protected TextBlock DescriptionHeader { get; private set; }

        /// <summary>
        /// The children header
        /// </summary>
        protected TextBlock ChildrenHeader { get; private set; }

        /// <summary>
        /// A grid containing the data list
        /// </summary>
        protected UniformGrid DataTextGrid { get; private set; }

        /// <summary>
        /// A data
        /// </summary>
        protected TextBlock DataBlock { get; private set; }

        /// <summary>
        /// The dot in front of a data text
        /// </summary>
        protected BulletDecorator DataDot { get; private set; }

        #endregion

        #region Dependency Properties

        #region Title

        /// <summary>
        /// The title
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(SubjectsComponent));

        #endregion


        #region Description

        /// <summary>
        /// The title
        /// </summary>
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

           public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(nameof(Description), typeof(string), typeof(SubjectsComponent));

        #endregion

        #region List of data

        /// <summary>
        /// The required options for content box items' content
        /// </summary>
        public IEnumerable<string> DataNames
        {
            get { return (IEnumerable<string>)GetValue(DataNamesProperty); }
            set { SetValue(DataNamesProperty, value); }
        }

        public TextBlock DescriptionTitleBlock { get; private set; }

        /// <summary>
        /// Identifies the <see cref="DataNames"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DataNamesProperty = DependencyProperty.Register(nameof(DataNames), typeof(IEnumerable<string>), typeof(SubjectsComponent), new PropertyMetadata(OnDataNameChanged));


        private static void OnDataNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as SubjectsComponent;

            sender.OnDataNameChangedCore(e);
        }

        #endregion

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the change of the <see cref="OptionNames"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnDataNameChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region Constructors

        public SubjectsComponent()
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

            // Creates the stack panel
            TitleAndDataStackPanel = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(32),
                Background = White.HexToBrush(),
            };

            TitleHeader = new TextBlock()
            {
                FontSize = 32,
                FontFamily = Calibri,
                FontWeight = FontWeights.Bold,
                Foreground = DarkBlue.HexToBrush(),
                Margin = new Thickness(24, 24, 0, 0),
                Text = "Title :         "
            };

            // Creates the title block
            TitleBlock = new TextBlock()
            {
                FontSize = 32,
                FontFamily = Calibri,
                FontWeight = FontWeights.Bold,
                Foreground = DarkBlue.HexToBrush(),
                Margin = new Thickness(24, 24, 0, 0),
            };
            //   Binds the title block's text property to the title dependency property
            TitleBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Title))
            {
                Source = this
            });     

            DescriptionHeader = new TextBlock()
            {
                FontSize = 32,
                FontFamily = Calibri,
                FontWeight = FontWeights.Bold,
                Foreground = DarkBlue.HexToBrush(),
                Margin = new Thickness(24, 24, 0, 0),
                Text = "Description :  "
            };

            // Creates the title block
            DescriptionTitleBlock = new TextBlock()
            {
                FontSize = 32,
                FontFamily = Calibri,
                FontWeight = FontWeights.Bold,
                Foreground = DarkBlue.HexToBrush(),
                Margin = new Thickness(24, 24, 0, 0),
                MaxWidth = 1000
            };
            // Binds the title block's text property to the title dependency property
            DescriptionTitleBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Description))
            {
                Source = this
            });

         
            ChildrenHeader = new TextBlock()
            {
                FontSize = 32,
                FontFamily = Calibri,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(8),
                Foreground = DarkBlue.HexToBrush(),
                Text = "More Specific subjects :",
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            var border = new Border()
            {
                HorizontalAlignment = HorizontalAlignment.Center,             
                Margin = new Thickness(0, 24, 24, 12),
                BorderBrush = DarkBlue.HexToBrush(),
                BorderThickness = new Thickness(4),
                CornerRadius = new CornerRadius(4),
                Background = Styles.White.HexToBrush(),
            };
       

            border.Child = ChildrenHeader;

            #region Grid

            var grid = new Grid()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
            };

            grid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            grid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(1, GridUnitType.Auto)
            });

            grid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

            grid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

            grid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

            grid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(1, GridUnitType.Auto)
            });

            Grid.SetRow(TitleHeader, 0);
            Grid.SetColumn(TitleHeader, 0);

            Grid.SetRow(TitleBlock, 0);
            Grid.SetColumn(TitleBlock, 1);

            Grid.SetRow(DescriptionHeader, 1);
            Grid.SetColumn(DescriptionTitleBlock, 0);
            Grid.SetRowSpan(DescriptionTitleBlock, 3);

            Grid.SetRow(DescriptionTitleBlock, 1);
            Grid.SetColumn(DescriptionTitleBlock, 1);

            grid.Children.Add(TitleHeader);
            grid.Children.Add(TitleBlock);
            grid.Children.Add(DescriptionHeader);
            grid.Children.Add(DescriptionTitleBlock);

            #endregion

            TitleAndDataStackPanel.Children.Add(grid);
            TitleAndDataStackPanel.Children.Add(border);

            // Creates the data grid
            DataTextGrid = new UniformGrid()
            {
                Columns = 5,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            // Adds it to the stack panel
            TitleAndDataStackPanel.Children.Add(DataTextGrid);



            var SubjectBorder = new Border()
            {
                //Style = MaterialDesignStyles.RaisedButton,
                Height = double.NaN,
                Margin = new Thickness(24),
                Padding = new Thickness(8),
                Background = DarkBlue.HexToBrush(),
                BorderThickness = new Thickness(0),
                CornerRadius = new CornerRadius(8)
            };

            SubjectBorder.Child = TitleAndDataStackPanel;

            // Sets the component's content to the stack panel
            Content = SubjectBorder;
        }


        /// <summary>
        /// Handles the change of the <see cref="DataNames"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnDataNameChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (IEnumerable<string>)e.NewValue;
            // If the new value is null...
            if (newValue == null)
            {
                // Creates a combo box item
                DataBlock = new TextBlock()
                {
                    Foreground = DarkGray.HexToBrush(),
                    FontFamily = Calibri,
                    FontSize = 20,
                    // with text "empty"
                    Text = "Empty",
                    Margin = new Thickness(24)

                };

                // Adds it to the title and data stack panel
                TitleAndDataStackPanel.Children.Add(DataBlock);
            }
            // Else...
            else
            {
                // For each string in the list...
                foreach (var dataText in DataNames)
                {
                    // Creates a bullet decorator
                    var DataDot = new BulletDecorator()
                    {
                        Bullet = new Ellipse()
                        {
                            Height = 10,
                            Width = 10,
                            Fill = DarkBlue.HexToBrush(),
                            Margin = new Thickness(24),

                        }
                    };
                    // Creates a new text block item ...
                    DataBlock = new TextBlock()
                    {
                        Foreground = DarkBlue.HexToBrush(),
                        FontFamily = Calibri,
                        FontSize = 24,
                        TextWrapping = TextWrapping.Wrap,
                        // with text the one string
                        Text = dataText,
                        Margin = new Thickness(32, 24, 24, 24)
                    };
                    // Sets the text block as the dot's child
                    DataDot.Child = DataBlock;

                    // Adds the text block with the dot to the grid
                    DataTextGrid.Children.Add(DataDot);
                }
            }

            // Further handle the change
            OnDataNameChanged(e);
        }

        #endregion


    }
}