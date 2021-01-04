using MaterialDesignThemes.Wpf;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Vaseis
{
    /// <summary>
    /// The button that points to an employee's profile
    /// </summary>
    public class UserButtonComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The stack panel containing a user's name and username
        /// </summary>
        protected StackPanel UserData { get; private set; }

        /// <summary>
        /// The user's username
        /// </summary>
        protected TextBlock UserUsernameText { get; private set; }

        /// <summary>
        /// The user's full name
        /// </summary>
        protected TextBlock UserFullNameText { get; private set; }

        /// <summary>
        /// The button representing a user
        /// </summary>
        protected Button UserButton { get; private set; }

        #endregion

        #region Dependency Properties

        #region Username

        /// <summary>
        /// The user's username
        /// </summary>
        public string Username
        {
            get { return GetValue(UsernameProperty).ToString(); }
            set { SetValue(UsernameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Username"/> dependency property
        /// </summary>
        public static readonly DependencyProperty UsernameProperty = DependencyProperty.Register(nameof(Username), typeof(string), typeof(UserButtonComponent));

        #endregion

        #region Full Name

        /// <summary>
        /// The user's full name
        /// </summary>
        public string FullName
        {
            get { return GetValue(FullNameProperty).ToString(); }
            set { SetValue(FullNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="FullName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty FullNameProperty = DependencyProperty.Register(nameof(FullName), typeof(string), typeof(UserButtonComponent));

        #endregion

        #region Background Color

        /// <summary>
        /// The path of the image
        /// </summary>
        public string BackgroundColor
        {
            get { return GetValue(BackgroundColorProperty).ToString(); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="ImagePath"/> dependency property
        /// </summary>
        public static readonly DependencyProperty BackgroundColorProperty = DependencyProperty.Register(nameof(BackgroundColor), typeof(string), typeof(UserButtonComponent), new PropertyMetadata(OnBackgroundChanged));

        /// <summary>
        /// Handles the change of the <see cref="ImagePath"/> property
        /// </summary>
        private static void OnBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as UserButtonComponent;

            //sender.OnBackgroundChangedCore(e);
        }

        #endregion

        #endregion


        #region Constructors

        public UserButtonComponent()
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
            UserData = new StackPanel()
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };

            UserUsernameText = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextWrapping = TextWrapping.Wrap,
                FontSize = 32,
                FontWeight = FontWeights.Bold,
            };

            // Binds the text property of the text block to the Username property
            UserUsernameText.SetBinding(TextBlock.TextProperty, new Binding(nameof(Username))
            {
                Source = this
            });

            UserFullNameText = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
            };

            // Binds the text property of the text block to the FullName property
            UserFullNameText.SetBinding(TextBlock.TextProperty, new Binding(nameof(FullName))
            {
                Source = this
            });

            UserData.Children.Add(UserFullNameText);

            UserData.Children.Add(this.UserUsernameText);

            UserButton = new Button()
            {
                Style = MaterialDesignStyles.RaisedButton,
                Height = double.NaN,
                Margin = new Thickness(24),
                Padding = new Thickness(8),
                BorderThickness = new Thickness(0),
                Content = UserData
            };

            UserButton.SetBinding(Button.BackgroundProperty, new Binding(nameof(Background))
            {
                Source = this
            });

            ButtonAssist.SetCornerRadius(UserButton, new CornerRadius(8));

            Content = UserButton;
        }

        #endregion

    }
}
