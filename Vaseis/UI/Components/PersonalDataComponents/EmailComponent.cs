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
    public  class EmailComponent : ContentControl
    {
        #region Protected Properties

        /// <summary>
        /// The Email Boxs' title 
        /// </summary>
        protected TextBlock EmailTitleBlock { get; private set; }

        /// <summary>
        /// The whole email grid  
        /// </summary>
        protected Grid EmailTextGrid { get; private set; }

        /// <summary>
        ///The user's previous email Text
        /// </summary>
        public TextBlock EmailTextBlock { get; private set; }

        /// <summary>
        /// The Box that receives the Emal (not the email's title, the email email :P )
        /// </summary>
        public TextBox EmailTextBox { get; private set; }

        /// <summary>
        /// The stack panel that contains the emailGrid
        /// </summary>
        protected StackPanel EmailStackPanel { get; private set; }

        #endregion

        #region Dependency Properties

        /// <summary>
        /// The User's Email
        /// </summary>
        public string Email
        {
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Email"/> dependency property
        /// </summary>
        public static readonly DependencyProperty EmailProperty = DependencyProperty.Register(nameof(Email), typeof(string), typeof(EmailComponent));

        #endregion

        #region Constructors

        public EmailComponent() 
        {
            CreateGUI();
        }

        #endregion


        #region Private Methods 

        private void CreateGUI()
        {
            //the title of the block that shows this is the email section in the PersonalDataColumn
            EmailTitleBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                TextTrimming = TextTrimming.CharacterEllipsis,
                FontSize = 32,
                FontWeight = FontWeights.Bold,
                Foreground = Styles.DarkGray.HexToBrush(),
                Text = "Email"
            };

            // Creates the user's email grid
            EmailTextGrid = new Grid();

            // Creates the user's email text block
            EmailTextBlock = new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 20,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkGray.HexToBrush(),
             
            };

            // Binds the text property of the UsersEmailBlock to the Email property
            EmailTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Email))
            {
                Source = this
            });

            //The editable user's email section
            EmailTextBox = new TextBox() {
                HorizontalAlignment = HorizontalAlignment.Left,
                FontSize = 20,
                FontWeight = FontWeights.Normal,
                Foreground = Styles.DarkGray.HexToBrush(),
                TextWrapping = TextWrapping.Wrap,
          
                Visibility = Visibility.Collapsed,
                Background = GhostWhite.HexToBrush()
            };

            EmailTextGrid.Children.Add(EmailTextBlock);
            EmailTextGrid.Children.Add(EmailTextBox);

            EmailStackPanel = new StackPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Left,         
            };

            EmailStackPanel.Children.Add(EmailTitleBlock);

            EmailStackPanel.Children.Add(EmailTextGrid);

          
            Content = EmailStackPanel;
        }

        #endregion

    }
}
