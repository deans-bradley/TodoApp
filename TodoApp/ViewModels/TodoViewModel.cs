using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public class TodoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand AddTodoCommand { get; private set; }

        public ObservableCollection<TodoItem> TodoItems { get; set; }

        private string _title;
        private string _description;
        private bool _isDone;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
               OnPropertyChanged("Title");
            }
        }

        public string Description
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

        public TodoViewModel()
        {
            TodoItems = new ObservableCollection<TodoItem>();

            AddTodoCommand = new RelayCommand(AddTodo);
        }

        private void AddTodo(object parameter)
        {
            TodoItem todo = new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = _title,
                Description = _description,
                IsDone = false
            };

            TodoItems.Add(todo);

            // Title = "";
        }

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

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
