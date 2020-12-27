using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using MaterialDesignThemes.Wpf;

using System.Linq;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Vaseis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateGUI();

            //Grid
            //StackPanel
            //UniformGrid
            //WrapPanel
            //Canvas
        }

        public void CreateGUI()
        {
            var border = new Border()
            {
                BorderBrush = Brushes.BlanchedAlmond,
                CornerRadius = new CornerRadius(50),
                Background = Brushes.White,
                Margin = new Thickness(100)
                
            };

            //var grid = new Grid() 
            //{
            //};

            var stackPanel = new StackPanel();

            //grid.ColumnDefinitions.Add(new ColumnDefinition()
            //{
            //    Width = new GridLength(2, GridUnitType.Star)
            //});
            //grid.ColumnDefinitions.Add(new ColumnDefinition());

            // border.Child = grid;

            var button1 = new Button
            {
                Style = MaterialDesignStyles.RaisedButton,
                Content = "Test",
                Background = Brushes.Blue,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                FontSize = 12,
                Width = 400
        };

            border.Child = button1;

            //button1.Style = MaterialDesignStyles.RaisedButton;

            stackPanel.Children.Add(border);

            //Grid.SetColumnSpan(button1, 2);

            var button2 = new Button()
            {
                Content = "Test 2",
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 400
            };


            //Grid.SetColumn(button2, 1);

            stackPanel.Children.Add(button2);

            Content = stackPanel;
        }
    }
}
