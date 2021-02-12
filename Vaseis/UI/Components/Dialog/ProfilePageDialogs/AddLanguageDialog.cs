using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static Vaseis.Styles;

namespace Vaseis
{
    public class AddLanguageDialog : DialogBaseComponent
    {
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

        /// <summary>
        /// 
        /// </summary>
        public TextInputComponent Language { get; private set; }



        /// <summary>
        /// The button that sends the values when user is done
        /// </summary>
        protected Button OkButton { get; private set; }


        #region Constructors

        public AddLanguageDialog(UserDataModel user, Grid pageGrid, ProfilePage profilePage)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));
            ProfilePage = profilePage ?? throw new ArgumentNullException(nameof(profilePage));

            CreateGUI();
        }

        #endregion


        protected async void NewRecOnClick(object sender, RoutedEventArgs e)
        {

            //var updatedRecs = await Services.GetDataStorage.UpdateRecPapers(User, Language.Text);

            //await Services.GetDataStorage.CreateNewLog(User.Username, "Has a new Rec. Paper", $"Referee : {Language.Text}");

            //ProfilePage.RecommendationPapers = updatedRecs;

            CloseDialogOnClick(this, e);
        }


        #region Private Methods
        /// <summary>
        /// Creates and adds the required GUI elements for the change password button
        ///</summary>
        private void CreateGUI()
        {
            //Sets the dialog's title
            DialogTitle.Text = "Add award";

        

   

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
            var AddRecPaper = new StackPanel();

            AddRecPaper.Children.Add(Language);
          //  AddRecPaper.Children.Add(DescriptionInput);


            // Adds a corner radius
            ButtonAssist.SetCornerRadius(OkButton, new CornerRadius(8)); ;
            OkButton.Click += NewRecOnClick;

            AddRecPaper.Children.Add(OkButton);

            InputWrapPanel.Children.Add(AddRecPaper);

            Content = DialogHost;
        }

        #endregion
    }

}