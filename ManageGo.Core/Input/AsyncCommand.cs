using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ManageGo.Core.Input
{
    public sealed class AsyncCommand<T> : AsyncCommand
    {
        public AsyncCommand(Func<object, Task> execute) : base(o => execute((T)o))
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));
        }

        public AsyncCommand(Func<object, Task> execute, Func<T, bool> canExecute) : base(o => execute((T)o), o => canExecute((T)o))
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));
        }
    }

    public class AsyncCommand : ICommand
    {
        readonly Func<object, bool> _canExecute;
        readonly Func<object, Task> _execute;

        Task _task;

        public AsyncCommand(Func<object, Task> execute)
        {
            _execute = execute;
        }

        public AsyncCommand(Func<object, Task> execute, Func<object, bool> canExecute) : this(execute)
        {
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        public AsyncCommand(Func<object, Task> execute, Func<bool> canExecute) : this(o => execute(o), o => canExecute())
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            if (canExecute == null)
                throw new ArgumentNullException("can" + "Execute");
        }

        public bool CanExecute(object parameter)
        {
            return _task == null || _task.IsCompleted;
        }

        public event EventHandler CanExecuteChanged;

        public async void Execute(object parameter)
        {
            _task = _execute(parameter);

            OnCanExecuteChanged();

            await _task;

            OnCanExecuteChanged();
        }

        void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;

            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}
