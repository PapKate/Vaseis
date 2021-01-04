using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Vaseis
{
    public class ProfileInfo : ContentControl { 

    #region Protected Properties

       /// <summary>
       /// The FirstName TextBlock
       /// </summary>
       protected TextBlock FirstNameText { get; private set; }

        /// <summary>
        /// The User's FirstName TextBlock
        /// </summary>
        protected TextBlock UsersFirstNameText { get; private set; }

        /// <summary>
        /// The Lastname TextBlock
        /// </summary>
        protected TextBlock LastNameText { get; private set; }

        /// <summary>
        /// The User's Lastname TextBlock
        /// </summary>
        protected TextBlock UsersLastNameText { get; private set; }

        /// <summary>
        /// The CompanyTitle
        /// </summary>
        protected TextBlock CompanyTitle{ get; private set; }

        /// <summary>
        /// The User's CompanyTitle
        /// </summary>
        protected TextBlock UsersCompanyTitle { get; private set; }

        /// <summary>
        /// The Email TextBlock
        /// </summary>
        protected TextBlock EmailText { get; private set; }

        /// <summary>
        /// The User's Email TextBlock
        /// </summary>
        protected TextBlock UsersEmailText { get; private set; }

       


    #endregion

        #region Dependency Poperties

        /// <summary>
        /// The User's FirstName
        /// </summary>
        public string FirstName
        {
            get { return GetValue(FirstNameProperty).ToString(); }
            set { SetValue(FirstNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="FirstName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty FirstNameProperty = DependencyProperty.Register(nameof(FirstName), typeof(string), typeof(ProfileInfo));

        /// <summary>
        /// The User's LastName
        /// </summary>
        public string LastName
        {
            get { return GetValue(LastNameProperty).ToString(); }
            set { SetValue(LastNameProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="LastName"/> dependency property
        /// </summary>
        public static readonly DependencyProperty LastNameProperty = DependencyProperty.Register(nameof(LastName), typeof(string), typeof(ProfileInfo));

        /// <summary>
        /// The Company Title
        /// </summary>
        public string Company
        {
            get { return GetValue(CompanyProperty).ToString(); }
            set { SetValue(CompanyProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="CompanyGrade"/> dependency property
        /// </summary>
        public static readonly DependencyProperty CompanyProperty = DependencyProperty.Register(nameof(Company), typeof(string), typeof(ProfileInfo));

        /// <summary>
        /// The User's Email
        /// </summary>
        public string Email
        {
            get { return GetValue(EmailProperty).ToString(); }
            set { SetValue(EmailProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Email"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EmailProperty = DependencyProperty.Register(nameof(Email), typeof(string), typeof(ProfileInfo));

        #endregion

        #region Constructor
        public ProfileInfo() {
          CreateGUI();
        }

        #endregion

        #region Private Methods 

        private void CreateGUI() {

            FirstNameText = new TextBlock()
            {
                Text = "First Name",
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 26,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkBlue.HexToBrush()
            };

            UsersFirstNameText = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkBlue.HexToBrush()
            };

            // Binds the text property of the text block to the FistName property
            UsersFirstNameText.SetBinding(TextBlock.TextProperty, new Binding(nameof(FirstName))
            {
                Source = this
            });

            LastNameText = new TextBlock()
            {
                Text = "Last Name",
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 26,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkBlue.HexToBrush()
            };


            UsersLastNameText = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 24,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkBlue.HexToBrush()
            };

            // Binds the text property of the text block to the LastName property
            UsersLastNameText.SetBinding(TextBlock.TextProperty, new Binding(nameof(LastName))
            {
                Source = this
            });


            CompanyTitle = new TextBlock()
            {
                Text = "Company",
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 26,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkBlue.HexToBrush()
            };

            UsersCompanyTitle = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkBlue.HexToBrush()
            };

            // Binds the text property of the text block to the Company property
            UsersCompanyTitle.SetBinding(TextBlock.TextProperty, new Binding(nameof(Company))
            {
                Source = this
            });

            EmailText = new TextBlock()
            {
                Text = "Email",
                HorizontalAlignment = HorizontalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 26,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkBlue.HexToBrush()
            };

           UsersEmailText = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 24,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkBlue.HexToBrush()
            };

            // Binds the text property of the text block to the email property
            UsersEmailText.SetBinding(TextBlock.TextProperty, new Binding(nameof(Email))
            {
                Source = this
            });

            //personal dT column will be created with the prfil pcture as one! 

        }



        #endregion


    }
}
