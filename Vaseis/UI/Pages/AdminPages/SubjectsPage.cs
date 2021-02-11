using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using static Vaseis.Styles;

namespace Vaseis
{

    //Τhe subject's page for the admin
    public class SubjectsPage : ContentControl
    {
        #region Public Properties

        /// <summary>
        /// The connected Admin
        /// </summary>
        public UserDataModel User { get; private set; }

        #endregion

        #region Proetcted Properties

        /// <summary>
        /// The page's ScrollViewer
        /// </summary>
        protected ScrollViewer scrollViewer { get; private set; }

        /// <summary>
        /// The Page's stackpanel
        /// </summary>
        protected StackPanel SubjectsStackPanel { get; private set; }

        /// <summary>
        /// THe page's grid
        /// </summary>
        protected Grid PageGrid { get; private set; }

        /// <summary>
        /// The add subject Button
        /// </summary>
        protected Button AddSubjectButton { get; private set; }

        ///<summary>
        ///Used for all the options for the picker inside the dialog "new Subject"
        ///</summary>
        protected List<string> AllTheSubjectTitles { get; private set; }
        #endregion

        #region Dependency Properties

        #region New card

        /// <summary>
        /// The new card bool
        /// </summary>
        public bool NewCard
        {
            get { return (bool)GetValue(NewCardProperty); }
            set { SetValue(NewCardProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="NewCard"/> dependency property
        /// </summary>
        public static readonly DependencyProperty NewCardProperty = DependencyProperty.Register(nameof(NewCard), typeof(bool), typeof(SubjectsPage), new PropertyMetadata(OnNewCardChanged));

        /// <summary>
        /// Handles the change of the <see cref="NewCard"/> property
        /// </summary>
        private static void OnNewCardChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as SubjectsPage;

            sender.OnNewCardChangedCore(e);
        }

        #endregion

        #endregion

        #region Constructors

        public SubjectsPage(UserDataModel user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));

            CreateGUI();
        }

        #endregion

        #region Protected Methods 

        protected async override void OnInitialized(EventArgs e)
        {

            base.OnInitialized(e);

            var subjects = await Services.GetDataStorage.GetSubjects();
       
            AllTheSubjectTitles = new List<string>();

            foreach (var subject in subjects)
            {
                AllTheSubjectTitles.Add(subject.Title);

                var subjectsChildren = new List<string>();

                foreach (var children in subject.ChildrenSubjects)
                {
                    subjectsChildren.Add(children.Title);
                }

                var subjectCard = new SubjectCardComponent()
                {
                    Title = subject.Title,
                    Description = subject.Description,
                    DataNames = subjectsChildren
                };

                SubjectsStackPanel.Children.Add(subjectCard);
            }
        
        }


        /// <summary>
        /// Handles the change of the <see cref="NewCard"/> property
        /// </summary>
        /// <param name="e">Event args</param>
        protected virtual void OnNewCardChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region Private Methods

        private void CreateGUI()
        {
            PageGrid = new Grid() { };

            scrollViewer = new ScrollViewer();

            SubjectsStackPanel = new StackPanel();

            scrollViewer.Content = SubjectsStackPanel;

            var AddSubjectButton = StyleHelpers.CreateDataButton(DarkBlue, "Add subject");
            AddSubjectButton.HorizontalAlignment = HorizontalAlignment.Right;

            AddSubjectButton.Click += ShowAddSubjectDialogComponentOnClick;

            SubjectsStackPanel.Children.Add(AddSubjectButton);

        

            PageGrid.Children.Add(scrollViewer);

            Content = PageGrid;

        }

        /// <summary>
        /// On click shows the create subject dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAddSubjectDialogComponentOnClick(object sender, RoutedEventArgs e)
        {
            // Creates a new user dialog
            var newSubject = new NewSubjectDialogComponent(User)
            {
                ParentSubjectOptions = AllTheSubjectTitles,
                CreateCommand = new RelayCommand(() =>
                {
                    NewCard = true;
                })
            };
            // Adds it to the page grid

            //gia na mhn kollaei sto ena column to prwto 
            PageGrid.Children.Add(newSubject);

            // Sets the is open property to true
            newSubject.IsDialogOpen = true;
        }

        /// <summary>
        /// Handles the change of the <see cref="NewCard"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private async void OnNewCardChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (bool)e.NewValue;
            // If the new card is true...
            if (newValue == true)
            {
                // For the new company to be created first
                await Task.Delay(200);
                // Gets all the subjects
                var subjects = await Services.GetDataStorage.GetSubjects();
                // Gets the last created
                var latestSubject = subjects[subjects.Count() - 1];
                // Adds to the subjects titles the title of the latest one
                AllTheSubjectTitles.Add(latestSubject.Title);

                var subjectsChildren = new List<string>();
                if(latestSubject.ChildrenSubjects != null)
                {
                    foreach (var children in latestSubject.ChildrenSubjects)
                    {
                        subjectsChildren.Add(children.Title);
                    }
                }

                // Creates a card component with...
                var subjectCard = new SubjectCardComponent()
                {
                    Title = latestSubject.Title,
                    Description = latestSubject.Description,
                    DataNames = subjectsChildren
                };
                // Adds the card to the stack panel
                SubjectsStackPanel.Children.Add(subjectCard);

            }
        }

        #endregion

    }
}