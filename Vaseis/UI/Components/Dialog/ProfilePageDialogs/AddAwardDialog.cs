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
    /// The add award dialog for the manager
    /// </summary>
    public class AddAwardDialog : DialogBaseComponent
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
        public TextInputComponent AwardTitleInpuComponent { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public DatePicker DateAcquiredPicker { get; private set; }

        /// <summary>
        /// The button that sends the values when user is done
        /// </summary>
        protected Button OkButton { get; private set; }


        #endregion

        #region Constructors

        public AddAwardDialog(UserDataModel user, Grid pageGrid, ProfilePage profilePage)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));
            ProfilePage = profilePage ?? throw new ArgumentNullException(nameof(profilePage));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        protected async void NewAwardOnClick(object sender, RoutedEventArgs e)
        {

            var updatedAwards =  await Services.GetDataStorage.UpdateAwards(User, DateAcquiredPicker.SelectedDate, AwardTitleInpuComponent.InputTextBox.Text);

            await Services.GetDataStorage.CreateNewLog(User.Username, "Added a new Subject", $"Subject : {AwardTitleInpuComponent.InputTextBox.Text}");

            ProfilePage.Awards = updatedAwards;

            CloseDialogOnClick(this, e);
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Creates and adds the required GUI elements for the change password button
        ///</summary>
        private void CreateGUI()
        {
            //Sets the dialog's title
            DialogTitle.Text = "New Award Form";

            AwardTitleInpuComponent = new TextInputComponent()
            {
                HintText = "Award Title",
                Width = 240,
                Margin = new Thickness(24)
            };

            DateAcquiredPicker = ControlsFactory.CreateDatePicker("Date acquired");

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

            AddAwardStackPanel.Children.Add(AwardTitleInpuComponent);
            AddAwardStackPanel.Children.Add(DateAcquiredPicker);

            // Adds a corner radius
            ButtonAssist.SetCornerRadius(OkButton, new CornerRadius(8)); ;
            OkButton.Click += NewAwardOnClick;

            AddAwardStackPanel.Children.Add(OkButton);

            InputWrapPanel.Children.Add(AddAwardStackPanel);

            Content = DialogHost;
        }

        #endregion
    }

}