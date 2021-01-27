using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using static Vaseis.Styles;

namespace Vaseis
{
    public abstract class CreateDialogBaseComponent : DialogBaseComponent
    {
        #region Protected Properties

        /// <summary>
        /// The create button
        /// </summary>
        protected Button CreateButton { get; private set; }

        #endregion

        #region Dependency Properties

        #region CreateCommand

        /// <summary>
        /// The dialog's cancel command
        /// </summary>
        public ICommand CreateCommand
        {
            get { return (ICommand)GetValue(CreateCommandProperty); }
            set { SetValue(CreateCommandProperty, value); }
        }
        /// <summary>
        /// Identifies the <see cref="CreateCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CreateCommandProperty = DependencyProperty.Register(nameof(CreateCommand), typeof(ICommand), typeof(CreateDialogBaseComponent));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateDialogBaseComponent()
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
            // Creates the create button
            CreateButton = StyleHelpers.CreateDialogButton(DarkPink, "Create");
            CreateButton.Margin = new Thickness(24);
            // Adds it to the dialog's button's stack panel
            DialogButtonsStackPanel.Children.Add(CreateButton);

            // Binds the button;s command property to the create command
            CreateButton.SetBinding(Button.CommandProperty, new Binding(nameof(CreateCommand))
            { 
                Source = this
            });
        }

        #endregion

    }
}
