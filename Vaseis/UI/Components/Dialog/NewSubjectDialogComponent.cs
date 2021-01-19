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
    public class NewSubjectDialogComponent : DialogBaseComponent
    {
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
        protected PickerComponent BelongsToSubjectPicker { get; private set; }

        /// <summary>
        /// The button that sends the values when Admin is done
        /// </summary>
        protected Button OkButton { get; private set; }

        /// <summary>
        /// The StackPanel that holds all the elements and get put in the InputWrapPanel
        /// </summary>
        protected StackPanel CreateSubjectStackPanel { get; private set; }


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
        public NewSubjectDialogComponent()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            CreateSubjectStackPanel = new StackPanel();

            DialogTitle.Text = "Create new Subject";

            SubjectTitleInput = new TextInputComponent()
            {
                // With hint text the name
                HintText ="New subject's title",
                Margin = new Thickness(24),
                Width = 240
            };
            CreateSubjectStackPanel.Children.Add(SubjectTitleInput);

            DescriptionInput = new TextInputComponent()
            {
                // With hint text the name
                HintText = "Subject's Description",
                Margin = new Thickness(24),
                Width = 240
            };
            CreateSubjectStackPanel.Children.Add(DescriptionInput);

            //Takes from the dependencies all the availiable subjects to pick as parent
            BelongsToSubjectPicker = new PickerComponent() 
            { 
                HintText = "Subject's parent Subject",
                FontSize = 24,
                OptionNames = ParentSubjectOptions
            };
            //binds the pickerComponent to the giver list of all the subjects
            BelongsToSubjectPicker.SetBinding(PickerComponent.OptionNamesProperty, new Binding(nameof(ParentSubjectOptions))
            {
                Source = this
            });

            //Adds all input components to a stackPanel
            CreateSubjectStackPanel.Children.Add(BelongsToSubjectPicker);

            //Adds the stackPanel to the InputWrapPanel
            //This was done to prevent the inputs from not being vertically aligned instead of two in each row
            InputWrapPanel.Children.Add(CreateSubjectStackPanel);

            //the ok Button

            OkButton = new Button()
            {
                Background = DarkBlue.HexToBrush(),
                Height = 40,
                Width = 164,
                Margin = new Thickness(28),
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

            // Adds a corner radius
            ButtonAssist.SetCornerRadius(OkButton, new CornerRadius(8)); ;
            OkButton.Click += CloseDialogOnClick;

            //Adds the button the the dialog panel
            DialogButtonsStackPanel.Children.Add(OkButton);

            Content = DialogHost;

        }

        #endregion

    }

}




