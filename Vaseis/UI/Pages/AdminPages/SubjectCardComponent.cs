using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Shapes;
using static Vaseis.Styles;

namespace Vaseis
{
    public class SubjectCardComponent : ContentControl
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
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(SubjectCardComponent));

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

           public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(nameof(Description), typeof(string), typeof(SubjectCardComponent));

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

        public TextBlock DescriptionTextBlock { get; private set; }

        /// <summary>
        /// Identifies the <see cref="DataNames"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DataNamesProperty = DependencyProperty.Register(nameof(DataNames), typeof(IEnumerable<string>), typeof(SubjectCardComponent), new PropertyMetadata(OnDataNameChanged));


        private static void OnDataNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as SubjectCardComponent;

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

        public SubjectCardComponent()
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
                Background = White.HexToBrush(),
                Margin = new Thickness(16)
            };

            var titleStackPanel = new StackPanel()
            { 
                Orientation = Orientation.Horizontal
            };
            TitleAndDataStackPanel.Children.Add(titleStackPanel);

            TitleHeader = new TextBlock()
            {
                FontSize = 32,
                FontFamily = Calibri,
                FontWeight = FontWeights.Bold,
                Foreground = DarkBlue.HexToBrush(),
                Margin = new Thickness(24),
                Text = "Title :"
            };
            titleStackPanel.Children.Add(TitleHeader);

            // Creates the title block
            TitleBlock = new TextBlock()
            {
                Margin = new Thickness(24),
                FontSize = 32,
                FontFamily = Calibri,
                FontWeight = FontWeights.Bold,
                Foreground = DarkBlue.HexToBrush(),
            };
            titleStackPanel.Children.Add(TitleBlock);
            //   Binds the title block's text property to the title dependency property
            TitleBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Title))
            {
                Source = this
            });

            var descriptionStackPanel = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            TitleAndDataStackPanel.Children.Add(descriptionStackPanel);

            DescriptionHeader = new TextBlock()
            {
                Margin = new Thickness(24),
                FontSize = 24,
                FontFamily = Calibri,
                FontWeight = FontWeights.Bold,
                Foreground = DarkBlue.HexToBrush(),
                Text = "Description:"
            };
            descriptionStackPanel.Children.Add(DescriptionHeader);

            // Creates the text block for the description
            DescriptionTextBlock = new TextBlock()
            {
                FontSize = 24,
                FontFamily = Calibri,
                Foreground = DarkBlue.HexToBrush(),
                TextWrapping = TextWrapping.Wrap,
            };
            // Binds the title block's text property to the title dependency property
            DescriptionTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Description))
            {
                Source = this
            });

            var DescriptionScrollViewer = new ScrollViewer()
            {
                Margin = new Thickness(24),
                MaxWidth = 1200,
                MaxHeight = 200,
                Content = DescriptionTextBlock
            };
            descriptionStackPanel.Children.Add(DescriptionScrollViewer);

            var SubjectBorder = new Border()
            {
                Margin = new Thickness(32),
                BorderThickness = new Thickness(16),
                BorderBrush = DarkBlue.HexToBrush(),
                CornerRadius = new CornerRadius(16),
                Padding = new Thickness(24),
                Background = White.HexToBrush(),
                Effect = ControlsFactory.CreateShadow()
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
            else if(newValue.ToList().Count() > 0)
            {
                ChildrenHeader = new TextBlock()
                {
                    FontSize = 28,
                    FontFamily = Calibri,
                    FontWeight = FontWeights.SemiBold,
                    Margin = new Thickness(4),
                    Foreground = DarkBlue.HexToBrush(),
                    Text = "More specific subjects:",
                    HorizontalAlignment = HorizontalAlignment.Center,
                };

                var border = new Border()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    BorderBrush = DarkBlue.HexToBrush(),
                    BorderThickness = new Thickness(4),
                    CornerRadius = new CornerRadius(4),
                    Background = Styles.White.HexToBrush(),
                };

                border.Child = ChildrenHeader;
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