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
    /// The add certificate dialog for the manager
    /// </summary>
    public class AddCertificateDialog : DialogBaseComponent
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
        public TextInputComponent CertificateTitleInpuComponent { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public TextInputComponent CertificateDescriptionInpuComponent { get; private set; }


        /// <summary>
        /// The button that sends the values when user is done
        /// </summary>
        protected Button OkButton { get; private set; }


        #endregion

        #region Constructors

        public AddCertificateDialog(UserDataModel user, Grid pageGrid, ProfilePage profilePage)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));
            ProfilePage = profilePage ?? throw new ArgumentNullException(nameof(profilePage));

            CreateGUI();
        }

        #endregion

        #region Protected Methods

        protected async void NewCertificateOnClick(object sender, RoutedEventArgs e)
        {

            var updatedCertificates = await Services.GetDataStorage.UpdateCertificates(User, CertificateTitleInpuComponent.Text,CertificateDescriptionInpuComponent.Text);

            await Services.GetDataStorage.CreateNewLog(User.Username, "Got a Project", $"Project : {CertificateTitleInpuComponent.Text}");

            ProfilePage.Certificates = updatedCertificates;

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
            DialogTitle.Text = "Add project";

            CertificateTitleInpuComponent = new TextInputComponent()
            {
                HintText = "Certificate Title"
            };

            CertificateDescriptionInpuComponent = new TextInputComponent()
            {
                HintText = "Description"
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
            var AddCertificateStackPanel = new StackPanel();

            AddCertificateStackPanel.Children.Add(CertificateTitleInpuComponent);
            AddCertificateStackPanel.Children.Add(CertificateDescriptionInpuComponent);

            // Adds a corner radius
            ButtonAssist.SetCornerRadius(OkButton, new CornerRadius(8)); ;
            OkButton.Click += NewCertificateOnClick;

            AddCertificateStackPanel.Children.Add(OkButton);

            InputWrapPanel.Children.Add(AddCertificateStackPanel);

            Content = DialogHost;
        }

        #endregion
    }

}