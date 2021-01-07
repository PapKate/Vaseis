using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Shapes;


using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// Creates one part of a user's file
    /// </summary>
    public class TitleAndListComponent : ContentControl
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
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(TitleAndListComponent));

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

        /// <summary>
        /// Identifies the <see cref="DataNames"/> dependency property
        /// </summary>
        public static readonly DependencyProperty DataNamesProperty = DependencyProperty.Register(nameof(DataNames), typeof(IEnumerable<string>), typeof(TitleAndListComponent), new PropertyMetadata(OnDataNameChanged));


        private static void OnDataNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as TitleAndListComponent;

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

        public TitleAndListComponent()
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
            };

            // Creates the title block
            TitleBlock = new TextBlock()
            {
                FontSize = 32,
                FontFamily = Calibri,
                FontWeight = FontWeights.Bold,
                Foreground = DarkGray.HexToBrush(),
                Margin = new Thickness(24, 0, 0, 0)
            };
            // Binds the title block's text property to the title dependency property
            TitleBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Title))
            { 
                Source = this
            });
            TitleAndDataStackPanel.Children.Add(TitleBlock);

            // Creates the data grid
            DataTextGrid = new UniformGrid()
            {
                Columns = 2,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left,
                
            };
            
            // Adds it to the stack panel
            TitleAndDataStackPanel.Children.Add(DataTextGrid);

            // Sets the component's content to the stack panel
            Content = TitleAndDataStackPanel;
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
                            Fill = DarkGray.HexToBrush(),
                            Margin = new Thickness(24),
                            
                        }
                    };
                    // Creates a new text block item ...
                    DataBlock = new TextBlock()
                    {
                        Foreground = DarkGray.HexToBrush(),
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
