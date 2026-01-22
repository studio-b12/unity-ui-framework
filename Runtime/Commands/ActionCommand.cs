using System;

namespace Rehawk.UIFramework
{
    public delegate void CommandActionDelegate(object args);

    /// <summary>
    /// Provides a concrete implementation of the <see cref="ICommand"/> interface
    /// designed to encapsulate a delegate to be executed as a command.
    /// This class allows dynamic enabling and disabling of the command's executability
    /// and facilitates the handling of parameterized actions.
    /// </summary>
    public class ActionCommand : ICommand
    {
        private readonly CommandActionDelegate commandAction;
        private bool isExecutable;

        /// <summary>
        /// Gets or sets a value indicating whether the command is currently executable.
        /// Updates to this property raise the <see cref="CanExecuteChanged"/> event, allowing for dynamic enable/disable behavior of the command.
        /// </summary>
        /// <value>
        /// A boolean value where true indicates the command is executable, and false indicates it is not.
        /// </value>
        public bool IsExecutable
        {
            get => isExecutable;
            set
            {
                if (value == isExecutable) 
                    return;
                
                isExecutable = value;
                CanExecuteChanged?.Invoke();
            } 
        }

        public event Action CanExecuteChanged;
        
        public ActionCommand(CommandActionDelegate commandAction, bool isExecutable = true)
        {
            this.commandAction = commandAction;
            this.isExecutable = isExecutable;
        }

        public bool CanExecute(object args)
        {
            return IsExecutable;
        }

        public void Execute(object args)
        {
            commandAction.Invoke(args);
        }
    }
}