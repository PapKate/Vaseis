using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static Vaseis.Styles;

namespace Vaseis
{
    public class NewSubjectDialogComponent : CreateDialogBaseComponent
    {
        #region Public Properties

        /// <summary>
        /// the connected Admin
        /// </summary>
        public UserDataModel User { get; private set; }

        #endregion

        #region Proetcted Properties

        /// <summary>
        /// The new subjects title
        /// </summary>
        protected TextInputComponent SubjectTitleInput { get; private set; }

        /// <summary>
        /// The new subjects Description
        /// </summary>
        protected TextInputComponent DescriptionInput { get; private set; }

        /// <summary>
        /// The picker that the administrator picks the subject(parent), the subject belongs to
        /// </summary>
        protected PickerComponent SubjectParentPicker { get; private set; }


        /// <summary>
        /// The stack panel for the description section
        /// </summary>
        protected StackPanel TextStackPanel { get; private set; }

        /// <summary>
        /// The description text
        /// </summary>
        protected TextBlock TextTitleBlock { get; private set; }

        /// <summary>
        /// The description text box's border
        /// </summary>
        protected Border TextBorder { get; private set; }

        /// <summary>
        /// The description' input text area
        /// </summary>
        protected TextBox ParagraphTextBox { get; private set; }

        #endregion

        #region Dependency Properties

        /// <summary>
        /// This is the new subject's title 
        /// </summary>
        public string SubjectTitle
        {
            get { return (string)GetValue(SubjectTitleProperty); }
            set { SetValue(SubjectTitleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SubjectTitle"/> dependency property
        /// </summary>
        public static readonly DependencyProperty SubjectTitleProperty = DependencyProperty.Register(nameof(SubjectTitle), typeof(string), typeof(NewSubjectDialogComponent));

        /// <summary>
        /// This is the new subject's description 
        /// </summary>
        public string SubjectDescription
        {
            get { return (string)GetValue(SubjectDescriptionProperty); }
            set { SetValue(SubjectDescriptionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="SubjectDescription"/> dependency property
        /// </summary>
        public static readonly DependencyProperty SubjectDescriptionProperty = DependencyProperty.Register(nameof(SubjectDescription), typeof(string), typeof(NewSubjectDialogComponent));

        /// <summary>
        /// All the registered Subjects for the admin to chose wich one is the new one's Parent
        /// </summary>
        public IEnumerable<string> ParentSubjectOptions
        {
            get { return (IEnumerable<string>)GetValue(ParentSubjectOptionsProperty); }
            set { SetValue(ParentSubjectOptionsProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="OptionNames"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ParentSubjectOptionsProperty = DependencyProperty.Register(nameof(ParentSubjectOptions), typeof(IEnumerable<string>), typeof(NewSubjectDialogComponent));

        #endregion

        #region Constructors
        public NewSubjectDialogComponent( UserDataModel user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates a new subject
        /// </summary>
        protected async void CreateNewSubjectOnClick(object sender, RoutedEventArgs e)
        {
            string parent;
            if (string.IsNullOrEmpty(SubjectParentPicker.Text))
                parent = "";
            else
                parent = SubjectParentPicker.Text;

            var newSubject = await Services.GetDataStorage.CreateNewSubject(SubjectTitleInput.Text, ParagraphTextBox.Text, parent);

            await Services.GetDataStorage.CreateNewLog(User.Username, "Added a new Subject-field", $"Subject: {SubjectTitleInput.Text}");

            CloseDialogOnClick(sender, e);
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            DialogTitle.Text = "Create new Subject";

            SubjectTitleInput = new TextInputComponent()
            {
                // With hint text the name
                HintText ="Title",
                Margin = new Thickness(24),
                Width = 240
            };
            InputWrapPanel.Children.Add(SubjectTitleInput);

            SubjectTitleInput.SetBinding(TextInputComponent.TextProperty, new Binding(nameof(SubjectTitle))
            {
                Source = this
            });

            //Takes from the dependencies all the availiable subjects to pick as parent
            SubjectParentPicker = new PickerComponent() 
            { 
                HintText = "Parent",
                CompleteFontSize = 24,
                OptionNames = ParentSubjectOptions
            };
            //binds the pickerComponent to the giver list of all the subjects
            SubjectParentPicker.SetBinding(PickerComponent.OptionNamesProperty, new Binding(nameof(ParentSubjectOptions))
            {
                Source = this
            });

            //Adds all input components to a stackPanel
            InputWrapPanel.Children.Add(SubjectParentPicker);


            // Creates a stack panel for the comments area
            TextStackPanel = new StackPanel()
            {
                Margin = new Thickness(24, 0, 24, 0),
                Orientation = Orientation.Vertical,
                Width = 520
            };

            // Adds to the wrap panel the comments stack panel
            InputStackPanel.Children.Add(TextStackPanel);

            // The title block for comments
            TextTitleBlock = new TextBlock()
            {
                Text = "Description",
                Foreground = DarkGray.HexToBrush(),
                FontSize = 24,
                FontFamily = Calibri,
                FontWeight = FontWeights.Normal,
                Margin = new Thickness(0, 0, 0, 8)
            };

            // Adds the text block to the comments' stack panel...
            TextStackPanel.Children.Add(TextTitleBlock);

            // The border for the comments input area
            TextBorder = new Border()
            {
                BorderBrush = DarkGray.HexToBrush(),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(5)
            };

            // The text input field for comments
            ParagraphTextBox = new TextBox()
            {
                MinLines = 6,
                FontFamily = Calibri,
                FontSize = 20,
                TextWrapping = TextWrapping.Wrap,
                AcceptsReturn = true,
                Padding = new Thickness(4),
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                MinHeight = 200,
                MaxHeight = 300
            };

            // Adds to the border the input field for the comments
            TextBorder.Child = ParagraphTextBox;

            // Adds tot he stack panel the border
            TextStackPanel.Children.Add(TextBorder);

            // Sets the create button's background to dark blue
            CreateButton.Background = DarkBlue.HexToBrush();
            // On click calls method
            CreateButton.Click += CreateNewSubjectOnClick;
        }

        #endregion

    }

}




