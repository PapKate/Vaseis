using MaterialDesignThemes.Wpf;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using static Vaseis.Styles;


namespace Vaseis
{
    public class EmployeeJobRequestsDataGridRowComponent : BaseJobPositionsDataGridRowComponent
    {
        /// <summary>
        /// The page's grid
        /// </summary>
        public Grid PageGrid { get; }

        #region Protected Properties

        /// <summary>
        /// The request evaluation button
        /// </summary>
        protected Button RemoveRequestButton { get; private set; }

        #endregion

        #region RemoveRow

        /// <summary>
        /// The open dialog command
        /// </summary>
        public ICommand RemoveRowCommand
        {
            get { return (ICommand)GetValue(RemoveRowProperty); }
            set { SetValue(RemoveRowProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="RemoveRowCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty RemoveRowProperty = DependencyProperty.Register(nameof(RemoveRowCommand), typeof(ICommand), typeof(EmployeeJobRequestsDataGridRowComponent));

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeJobRequestsDataGridRowComponent(Grid pageGrid) : base(pageGrid)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));

            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            // Creates the edit button
            RemoveRequestButton = ControlsFactory.CreateControlButton(PackIconKind.Minus, Red);
            RemoveRequestButton.ToolTip = new ToolTipComponent() { Text = "Remove evaluation request"};
            RemoveRequestButton.SetBinding(Button.CommandProperty, new Binding(nameof(RemoveRowCommand))
            { 
                Source = this
            });

            // Add it to the grid
            RowDataGrid.Children.Add(RemoveRequestButton);
            // On the ninth column
            Grid.SetColumn(RemoveRequestButton, 9);
            Grid.SetColumnSpan(RemoveRequestButton, 2);
        }

        #endregion

    }
}
