using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static Vaseis.Styles;

namespace Vaseis
{
    //THIS Component is just fore the profile page -> personal data column where, the user can Edit his email
    //just like bio component switches between editBox to textBox and backwwords by clicking on the edit button
    //A new component was used instead of the bioComponent because it had fixed size & backgournd colour and the was no reason
    //for them to be added as dependencies 
    public  class EditableTextComponent : TitleAndTextComponent

    {
        #region Protected Properties

        /// <summary>
        /// The Box that receives the Email (not the email's title, the email email :P )
        /// </summary>
        protected TextInputComponent InputTextBox { get; private set; }

        #endregion

        #region Dependency Property

        #region InputText

        /// <summary>
        /// The is editable bool
        /// </summary>
        public string InputText
        {
            get { return (string)GetValue(InputTextProperty); }
            set { SetValue(InputTextProperty, value); }
        }
        /// <summary>
        /// Identifies the <see cref="InputText"/> dependency property
        /// </summary>
        public static readonly DependencyProperty InputTextProperty = DependencyProperty.Register(nameof(InputText), typeof(string), typeof(EditableTextComponent));
        #endregion

        #region IsEditable

        /// <summary>
        /// The is editable bool
        /// </summary>
        public bool IsEditable
        {
            get { return (bool)GetValue(IsEdidableProperty); }
            set { SetValue(IsEdidableProperty, value); }
        }
        /// <summary>
        /// Identifies the <see cref="IsEditable"/> dependency property
        /// </summary>
        public static readonly DependencyProperty IsEdidableProperty = DependencyProperty.Register(nameof(IsEditable), typeof(bool), typeof(EditableTextComponent), new PropertyMetadata(EditText));


        /// <summary>
        /// Handles the change of the <see cref="IsEditable"/> property
        /// </summary>
        private static void EditText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as EditableTextComponent;

            sender.EditTextCore(e);
        }

        #endregion

        #region SaveEdit

        /// <summary>
        /// The is save edits bool
        /// </summary>
        public bool SaveEdit
        {
            get { return (bool)GetValue(SaveEditProperty); }
            set { SetValue(SaveEditProperty, value); }
        }
        /// <summary>
        /// Identifies the <see cref="SaveEdit"/> dependency property
        /// </summary>
        public static readonly DependencyProperty SaveEditProperty = DependencyProperty.Register(nameof(SaveEdit), typeof(bool), typeof(EditableTextComponent), new PropertyMetadata(AfterEditText));

        /// <summary>
        /// Handles the change of the <see cref="SaveEdit"/> property
        /// </summary>
        private static void AfterEditText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as EditableTextComponent;

            sender.AfterEditTextCore(e);
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EditableTextComponent() 
        {
            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Handles the change of the <see cref="IsEditable"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void EditText(DependencyPropertyChangedEventArgs e)
        {

        }

        /// <summary>
        /// Handles the change of the <see cref="SaveEdit"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void AfterEditText(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region Private Methods 

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            InputTextBox = new TextInputComponent()
            {

            };
            InputTextBox.Visibility = Visibility.Collapsed;
            TextGrid.Children.Add(InputTextBox);

        }

        /// <summary>
        /// Handles the change of the <see cref="EditCommand"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void EditTextCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (bool)e.NewValue;
            // If the edit is true...
            if (newValue == true)
            {
                // Collapse the block
                TextBlock.Visibility = Visibility.Collapsed;
                // Show the box
                InputTextBox.Visibility = Visibility.Visible;
                // The box's text gets the block's text
                InputTextBox.Text = TextBlock.Text;
            }
            // If the edit is false...
            if (newValue == false)
            {
                // Collapse the box
                TextBlock.Visibility = Visibility.Visible;
                // Show the block
                InputTextBox.Visibility = Visibility.Collapsed;
            }
            // Calls the virtual method
            EditText(e);
        }

        /// <summary>
        /// Handles the change of the <see cref="EditCommand"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void AfterEditTextCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (bool)e.NewValue;
            // If save is true...
            if (newValue == true)
            {
                // Sets the text from the box to the block
                TextBlock.Text = InputTextBox.Text;
                InputText = InputTextBox.Text;
            }
            // Calls the virtual method
            AfterEditText(e);
        }

        #endregion

    }
}
