
using MaterialDesignThemes.Wpf;

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// A message dialog
    /// </summary>
    public class MessageDialogComponent : DialogBaseComponent
    {
        #region Protected Properties

        /// <summary>
        /// The message's block
        /// </summary>
        protected TextBlock MessageBlock { get; private set; }

        // The ok button
        protected Button OkButton { get; private set; }

        /// <summary>
        /// The job request's data grid row
        /// </summary>
        protected EmployeeJobRequestsDataGridRowComponent JobPositionRequestDataGridRow { get; private set; }

        #endregion

        #region Dependency Properties

        #region Color

        /// <summary>
        /// The Error Message (empty or username)
        /// </summary>
        public Brush BrushColor
        {
            get { return (Brush)GetValue(HexColorProperty); }
            set { SetValue(HexColorProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="BrushColor"/> dependency property
        /// </summary>
        public static readonly DependencyProperty HexColorProperty = DependencyProperty.Register(nameof(BrushColor), typeof(Brush), typeof(MessageDialogComponent));

        #endregion

        #region Title

        /// <summary>
        /// The Error Message (empty or username)
        /// </summary>
        public string Title
        {
            get { return GetValue(TitleProperty).ToString(); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Title"/> dependency property
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(nameof(Title), typeof(string), typeof(MessageDialogComponent));

        #endregion

        #region Message

        /// <summary>
        /// The Error Message (empty or username)
        /// </summary>
        public string Message
        {
            get { return GetValue(MessageProperty).ToString(); }
            set { SetValue(MessageProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Message"/> dependency property
        /// </summary>
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(nameof(Message), typeof(string), typeof(MessageDialogComponent));

        #endregion

        #region OkCommand

        /// <summary>
        /// The edit command
        /// </summary>
        public ICommand OkCommand
        {
            get { return (ICommand)GetValue(OkCommandProperty); }
            set { SetValue(OkCommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="OkCommand"/> dependency property
        /// </summary>
        public static readonly DependencyProperty OkCommandProperty = DependencyProperty.Register(nameof(OkCommand), typeof(ICommand), typeof(MessageDialogComponent));

        #endregion

        #endregion

        #region Constructors

        public MessageDialogComponent()
        {
            CreateGUI();
        }

        public MessageDialogComponent(EmployeeJobRequestsDataGridRowComponent jobPositionRequestDataGridRow)
        {
            JobPositionRequestDataGridRow = jobPositionRequestDataGridRow ?? throw new ArgumentNullException(nameof(jobPositionRequestDataGridRow));

            CreateGUI();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Binds the dialog's title
            DialogTitle.SetBinding(TextBlock.TextProperty, new Binding(nameof(Title))
            {
                Source = this
            });

            // Binds the dialog's foreground color
            DialogTitle.SetBinding(TextBlock.ForegroundProperty, new Binding(nameof(BrushColor))
            {
                Source = this
            });

            // Creates a message text block
            MessageBlock = new TextBlock()
            {
                TextAlignment = TextAlignment.Center,
                FontSize = 24,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
                Margin = new Thickness(24),
                Foreground = DarkGray.HexToBrush(),
                TextWrapping = TextWrapping.Wrap,
            };

            // Binds the text property of the message block to the message property
            MessageBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Message))
            {
                Source = this
            });
            // Adds it to the wrap panel
            InputWrapPanel.Children.Add(MessageBlock);

            // Creates an OK button
            OkButton = new Button()
            {
                Background = DarkBlue.HexToBrush(),
                Height = 40,
                Width = 164,
                Content = new TextBlock()
                {
                    Foreground = White.HexToBrush(),
                    FontSize = 24,
                    FontWeight = FontWeights.Normal,
                    FontFamily = Calibri,
                    Text = "OK"
                },
                Padding = new Thickness(0),
                BorderThickness = new Thickness(0),
            };
            // Binds its command
            OkButton.SetBinding(Button.CommandProperty, new Binding(nameof(OkCommand))
            { 
                Source = this
            });

            // Adds a corner radius
            ButtonAssist.SetCornerRadius(OkButton, new CornerRadius(8)); ;
            OkButton.Click += CloseDialogOnClick;
            // And background property
            OkButton.SetBinding(Button.BackgroundProperty, new Binding(nameof(BrushColor))
            {
                Source = this
            });
            // Adds it to the button's stack panel
            DialogButtonsStackPanel.Children.Add(OkButton);

            // Sets the component's content as the dialog host
            Content = DialogHost;
        }

        #endregion
    }
}
