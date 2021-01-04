using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Vaseis
{
    public class LoginPPage : ContentControl
    {
        #region Protected Properties 

        protected LoginComponentsContainer LoginContainer { get; private set; }

        #endregion


        #region Constructors

        public LoginPPage()
        {
            CreateGUI();
        }

        #endregion

        #region Private Methods 
        private void CreateGUI() 
        {

            var loginGrid = new Grid()
            {
               ColumnDefinitions = 
                {
                new ColumnDefinition(),
                new ColumnDefinition(),
                new ColumnDefinition()
                }
            };
           

            var firstLoginColumn = new StackPanel() {
                Background = Styles.DarkBlue.HexToBrush()
            };

            var secondLoginColumn = new LoginComponentsContainer() { };

            var thirdLoginColumn = new StackPanel()
            {
                Background = Styles.DarkBlue.HexToBrush()
            };

            loginGrid.Children.Add(firstLoginColumn);
            loginGrid.Children.Add(secondLoginColumn);
            loginGrid.Children.Add(thirdLoginColumn);

            Content = loginGrid;
        }



        #endregion



    }
}

