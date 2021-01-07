using System;
using System.Windows.Input;

namespace Vaseis
{
    public class RelayCommand : ICommand
    {
        #region Public Properties

        /// <summary>
        /// The action to execute
        /// </summary>
        public Action Action { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="action">The action to execute</param>
        public RelayCommand(Action action)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter"> Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter) => Action();

        #endregion

        #region Public Events

        /// <summary>
        /// Represents the method that will handle an event that has no event data.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object that contains no event data.</param>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion
    }
}
