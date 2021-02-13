using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// The add project dialog for the manager
    /// </summary>
    public class AddProjectDialog : DialogBaseComponent
    {
        #region Public Property

        /// <summary>
        /// 
        /// </summary>
        public ProfilePage ProfilePage { get; private set; }

        /// <summary>
        /// The user
        /// </summary>
        public UserDataModel User { get; }

        /// <summary>
        /// 
        /// </summary>
        public Grid PageGrid { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// 
        /// </summary>
        public TextInputComponent ProjectTitleInpuComponent { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        public TextInputComponent ProjectUrlInpuComponent { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        public TextInputComponent ProjectDescriptionInpuComponent { get; private set; }


        /// <summary>
        /// 
        /// </summary>
        public PickerComponent ProjectMadeForWhoInpuComponent { get; private set; }

        /// <summary>
        /// The button that sends the values when user is done
        /// </summary>
        protected Button OkButton { get; private set; }

        #endregion

        #region Constructors

        public AddProjectDialog(UserDataModel user, Grid pageGrid, ProfilePage profilePage)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));
            ProfilePage = profilePage ?? throw new ArgumentNullException(nameof(profilePage));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        protected async void NewProjectOnClick(object sender, RoutedEventArgs e)
        {


            var updatedProjects = await Services.GetDataStorage.UpdateProjects(User, ProjectTitleInpuComponent.InputTextBox.Text, ProjectUrlInpuComponent.InputTextBox.Text, ProjectDescriptionInpuComponent.InputTextBox.Text, ProjectMadeForWhoInpuComponent.Text);

            await Services.GetDataStorage.CreateNewLog(User.Username, $"A project was added to {User.Username}", $"Project : {ProjectTitleInpuComponent.InputTextBox.Text}");


            ProfilePage.Projects = updatedProjects;

            CloseDialogOnClick(this, e);
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Creates and adds the required GUI elements for the add project Dialog
        ///</summary>
        private void CreateGUI()
        {
            //Sets the dialog's title
            DialogTitle.Text = "New Project Form";

            ProjectTitleInpuComponent = new TextInputComponent()
            {
                HintText = "Project Title",
                Width = 240,
                Margin = new Thickness(24)
            };


            ProjectUrlInpuComponent = new TextInputComponent()
            {
                HintText = "Url",
                Width = 240,
                Margin = new Thickness(24)
            };


            ProjectDescriptionInpuComponent = new TextInputComponent()
            {
                HintText = "Description",
                Width = 240,
                Margin = new Thickness(24)
            };


            ProjectMadeForWhoInpuComponent = new PickerComponent()
            {
                HintText = "Belongs to ?",
                Width = 240,
                CompleteFontSize = 24,
                OptionNames = new List<string> { "Personal", "Company's" }
            };


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


            //i use a stack panel so that the input fields are set in a column
            var AddAwardStackPanel = new StackPanel();

            AddAwardStackPanel.Children.Add(ProjectTitleInpuComponent);
            AddAwardStackPanel.Children.Add(ProjectUrlInpuComponent);
            AddAwardStackPanel.Children.Add(ProjectDescriptionInpuComponent);
            AddAwardStackPanel.Children.Add(ProjectMadeForWhoInpuComponent);

            // Adds a corner radius
            ButtonAssist.SetCornerRadius(OkButton, new CornerRadius(8)); ;
            OkButton.Click += NewProjectOnClick;

            AddAwardStackPanel.Children.Add(OkButton);

            InputWrapPanel.Children.Add(AddAwardStackPanel);

            Content = DialogHost;
        }

        #endregion
    }

}