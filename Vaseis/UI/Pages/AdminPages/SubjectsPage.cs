using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Vaseis
{

    //Τhe subject's page for the admin
    public class SubjectsPage : ContentControl
    {
        #region Public Properties

        #endregion

        #region Proetcted Properties

        /// <summary>
        /// The page's ScrollViewer
        /// </summary>
        protected ScrollViewer scrollViewer { get; private set; }

        /// <summary>
        /// The Page's stackpanel
        /// </summary>
        protected StackPanel subjectsStackPanel { get; private set; }

        /// <summary>
        /// THe page's grid
        /// </summary>
        protected Grid pageGrid { get; private set; }

        /// <summary>
        /// The add subject Button
        /// </summary>
        protected Button AddSubjectButton { get; private set; }

        ///<summary>
        ///Used for all the options for the picker inside the dialog "new Subject"
        ///</summary>
        protected List<string> allTheSubjectTitles { get; private set; }
        #endregion

        #region Dependency Properties

        #endregion

        #region Constructors

        public SubjectsPage()
        {
            CreateGUI();
        }

        #endregion

        #region Protected Methods 

        protected async override void OnInitialized(EventArgs e)
        {

            base.OnInitialized(e);

            var subjects = await Services.GetDataStorage.GetSubjects();
       
            allTheSubjectTitles = new List<string>();

            foreach (var subject in subjects)
            {
                var subjectsChildren = new List<string>();

                foreach (var children in subject.ChildrenSubjects)
                {
                    subjectsChildren.Add(children.Title);

                    allTheSubjectTitles.Add(children.Title);
                }

                var showSubject = new SubjectsComponent()
                {
                    Title = subject.Title,
                    Description = subject.Description,
                    DataNames = subjectsChildren
                };

                subjectsStackPanel.Children.Add(showSubject);

            }
        
        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            pageGrid = new Grid() { };

            scrollViewer = new ScrollViewer();

            subjectsStackPanel = new StackPanel();

            scrollViewer.Content = subjectsStackPanel;

            var AddSubjectButton = new Button()
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                FontSize = 18,
                FontWeight = FontWeights.Normal,
                Content = "Add Subject",
                Margin = new Thickness(0, 24, 24, 12),
                Foreground = Styles.DarkBlue.HexToBrush(),
                Background = Styles.White.HexToBrush(),
            };

            AddSubjectButton.Click += ShowAddSubjectDialogComponentOnClick;

            subjectsStackPanel.Children.Add(AddSubjectButton);

        

            pageGrid.Children.Add(scrollViewer);

            Content = pageGrid;

        }

        /// <summary>
        /// On click shows the create subject dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAddSubjectDialogComponentOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            var newSubject = new NewSubjectDialogComponent()
            {
                ParentSubjectOptions = allTheSubjectTitles
            };
            // Adds it to the page grid

            //gia na mhn kollaei sto ena column to prwto 
            subjectsStackPanel.Children.Add(newSubject);

            // Sets the is open property to true
            newSubject.IsDialogOpen = true;
        }


        #endregion

    }
}