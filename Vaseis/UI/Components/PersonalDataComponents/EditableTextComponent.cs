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
    public  class EditableTextComponent : TitleAndTextComponent

    {
        #region Protected Properties

        /// <summary>
        /// The Box that receives the Email (not the email's title, the email email :P )
        /// </summary>
        protected TextInputComponent InputText { get; private set; }

        #endregion

        #region Dependency Property



        #endregion

        #region Constructors

        public EditableTextComponent() 
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
            InputText = new TextInputComponent()
            {

            };

            TextGrid.Children.Add(InputText);

        }

        #endregion

    }
}
