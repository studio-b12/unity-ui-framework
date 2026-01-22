using System;

namespace Rehawk.UIFramework
{
    /// <summary>
    /// Represents a command that can be executed, offering mechanisms to determine
    /// its executability and to handle its execution. Commonly used for implementing
    /// actions in patterns like MVVM.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// This event is typically used to notify the UI or other subscribers
        /// that the executability of the command has been updated.
        /// </summary>
        event Action CanExecuteChanged;

        /// <summary>
        /// Determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="args">Parameter passed to the method, which can be used to evaluate the command's eligibility for execution.</param>
        /// <returns>Returns true if the command can execute; otherwise, false.</returns>
        bool CanExecute(object args);

        /// <summary>
        /// Executes the command's action using the specified parameter.
        /// </summary>
        /// <param name="args">The parameter to pass to the command during execution.</param>
        void Execute(object args);
    }
}