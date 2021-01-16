﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using static Vaseis.Styles;

namespace Vaseis
{
    /// <summary>
    /// A row for the employee's data grid
    /// </summary>
    public class EmployeeMyEvaluationsDataGridRowComponent : DataGridRowComponent
    {
        #region Public Properties

        /// <summary>
        /// The page's grid
        /// </summary>
        public Grid PageGrid { get; }

        /// <summary>
        /// The evaluation of an employee
        /// </summary>
        public EvaluationDataModel Evaluation { get; }

        #endregion

        #region Protected Properties

        /// <summary>
        /// More details text
        /// </summary>
        protected TextBlock ResultTextBlock { get; private set; }

        /// <summary>
        /// The row's border
        /// </summary>
        protected Border RowBorder { get; private set; }

        #endregion

        #region Dependency Properties

        #region Result

        /// <summary>
        /// The result text
        /// </summary>
        public string Result
        {
            get { return (string)GetValue(ResultTextProperty); }
            set { SetValue(ResultTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Result"/> dependency property
        /// </summary>
        public static readonly DependencyProperty ResultTextProperty = DependencyProperty.Register(nameof(Result), typeof(string), typeof(EmployeeMyEvaluationsDataGridRowComponent), new PropertyMetadata(OnTextChanged));

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as EmployeeMyEvaluationsDataGridRowComponent;

            sender.OnTextChangedCore(e);
        }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EmployeeMyEvaluationsDataGridRowComponent(Grid pageGrid, EvaluationDataModel evaluation)
        {
            PageGrid = pageGrid ?? throw new ArgumentNullException(nameof(pageGrid));
            Evaluation = evaluation ?? throw new ArgumentNullException(nameof(evaluation));

            CreateGUI();

            Update();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Updates the UI based on the values of the <see cref="Evaluation"/>
        /// </summary>
        public void Update()
        {
            EmployeeName = Evaluation.UsersJobFilesPair.Employee.Username;
            EvaluatorName = Evaluation.UsersJobFilesPair.Evaluator.Username;
            EvaluationGrade = "7";
            InterviewGrade = GetGrade(Evaluation.InterviewGrade).ToString("F", CultureInfo.InvariantCulture);
            ReportGrade = GetGrade(Evaluation.ReportGrade).ToString("F", CultureInfo.InvariantCulture);
            FilesGrade = GetGrade(Evaluation.FilesGrade).ToString("F", CultureInfo.InvariantCulture);
            JobName = Evaluation.JobPositionRequest.JobPosition.Job.JobTitle;
            DepartmentName = Evaluation.JobPositionRequest.JobPosition.Job.Department.DepartmentName.ToString();
            Result = CreateResult(7);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Turn the grade from 1000 to 10 max
        /// </summary>
        /// <param name="grade"></param>
        /// <returns></returns>
        protected double GetGrade(int? grade)
        {
            // If not null return the new value else 0
            var parsedGrade = grade * 0.01 ?? default(int);
            // returns the grade scaled to 10
            return parsedGrade;
        }

        /// <summary>
        /// Calculates the final evaluation grade
        /// </summary>
        /// <param name="filesGrade">The files grade</param>
        /// <param name="interviewGrade">The interview's grade</param>
        /// <param name="reportGrade">The report's grade</param>
        /// <returns></returns>
        protected int CreateEvaluationGrade(int filesGrade, int interviewGrade, int reportGrade)
        {
            var evaluationGrade = 7;

            // Returns the evaluation's grade
            return evaluationGrade;
        }

        /// <summary>
        /// Creates the result 
        /// </summary>
        /// <param name="evaluationGrade">The final evaluation's grade</param>
        /// <returns></returns>
        protected string CreateResult(int evaluationGrade)
        {
            // By default the result is empty
            var result = "-";
            // If the evaluation's grade is grater than 5...
            if (evaluationGrade > 5)
                // Result set to pass
                result = "Pass";
            // If evaluation grade smaller or equal to 5...
            if (evaluationGrade <= 5)
                // Result set to fail
                result = "Fail";
            // Returns the result
            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates and adds the required GUI elements
        /// </summary>
        private void CreateGUI()
        {
            // Creates the row's border
            RowBorder = new Border()
            {
                BorderThickness = new Thickness(0, 0, 0, 1),
                BorderBrush = DarkPink.HexToBrush(),
                Background = GhostWhite.HexToBrush(),
                Padding = new Thickness(12),
                
            };
            // Sets the row's child as the data grid's row
            RowBorder.Child = RowDataGrid;

            // Creates the result text block
            ResultTextBlock = new TextBlock()
            {
                FontFamily = Calibri,
                FontSize = 28,
                FontWeight = FontWeights.SemiBold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            // Adds it to the data grid
            RowDataGrid.Children.Add(ResultTextBlock);
            // On its eighth row
            Grid.SetColumn(ResultTextBlock, 8);

            // Binds the result text to the result text block
            ResultTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Result))
            {
                Source = this
            });

            // Sets the component's content as the row's border
            Content = RowBorder;
        }

        /// <summary>
        /// Handles the change of the <see cref="Result"/> property internally
        /// </summary>
        /// <param name="e">Event args</param>
        private void OnTextChangedCore(DependencyPropertyChangedEventArgs e)
        {
            // Get the new value
            var newValue = (string)e.NewValue;
            // If the new value is null...
            if (newValue == null)
            {
                ResultTextBlock.Text = "-";
            }
            // Else...
            else
            {
                // Sets the result's text as the new value
                ResultTextBlock.Text = newValue;
                
                // If the new value is Fail...
                if (newValue == "Fail")
                    // Sets the result's foreground to red
                    ResultTextBlock.Foreground = Red.HexToBrush();
                
                // If the new value is Pass...
                if (newValue == "Pass")
                { 
                    // Sets the result's foreground to green
                    ResultTextBlock.Foreground = Green.HexToBrush();
                    // Creates a tick button
                    var acquireButton = ControlsFactory.CreateCheckButton();
                    // Creates a tool tip for it
                    acquireButton.ToolTip = new ToolTipComponent() { Text = "Acquire job position" };
                    // Adds it to the row's grid
                    RowDataGrid.Children.Add(acquireButton);
                    // On the ninth column
                    Grid.SetColumn(acquireButton, 9);
                    // Binds the button's command to the ICommmad
                    acquireButton.SetBinding(Button.CommandProperty, new Binding(nameof(ShowDialogCommand))
                    { 
                        Source = this
                    });
                }
            }
        }

        #endregion

    }
}
