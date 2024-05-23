using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public class TodoViewModel : INotifyPropertyChanged
    {
        public ICommand AddTodoCommand { get; private set; }

        public ObservableCollection<TodoItem> TodoItems = new();

        private string? _title;
        private string? _description;
        private bool _isDone;

        public TodoViewModel()
        {
            AddTodoCommand = new RelayCommand(AddTodo);
        }

        public string? Title
        {
            get { return _title; }
            set
            {
                _title = value;
               OnPropertyChanged("Title");
            }
        }

        public string? Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public bool IsDone 
        { 
            get { return _isDone; } 
            set
            {
                _isDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        private void AddTodo(object parameter)
        {
            TodoItem todo = new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = _title ?? throw new NullReferenceException(),
                Description = _description ?? throw new NullReferenceException(),
                IsDone = false
            };

            TodoItems.Add(todo);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private Action<object> execute;

        public RelayCommand(Action<object> executeAction)
        {
            execute = executeAction;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter != null)
            {
                execute(parameter);
            }
        }
    }
}
