using System;
using System.Collections.Generic;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using TodoApp.Core.Interface;
using TodoApp.Core.Models;
using TodoApp.Services.Todo;

namespace TodoApp.Core.ViewModels
{
    public class TodoListItemViewModel : PageBaseViewModel
    {
        public TodoListItemViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
        }

        private async void OnGetDataAsync()
        {
            //Fake Data
            TodoItems = null;
            //var dialogService = Mvx.Resolve<IDialogService>();
            var service = Mvx.Resolve<ITodoService>();
            //var dialog = dialogService.ShowProgress();
            Todo = await service.GetFakeTodoListByIdAsync(mTodo.Id);
             


           // dialogService.DismissProgress(dialog);
        }

        private TodoList mTodo;
        public TodoList Todo
        {
            get
            {
                return mTodo;
            }
            set
            {
                mTodo = value;
                TodoItems = mTodo.TodoItems;
                this.RaisePropertyChanged(() => Todo);
            }
        }

        private List<TodoItem> mTodoItems;
        public List<TodoItem> TodoItems
        {
            get
            {
                return mTodoItems;
            }
            set
            {
                mTodoItems = value;
                this.RaisePropertyChanged(() => TodoItems);
            }
        }

        public override void Start()
        {
            base.Start();
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            OnGetDataAsync();
        }

        public System.Windows.Input.ICommand ItemSelectedCommand
        {
            get
            {
                return new MvxCommand<TodoItem>(DoSelectItemAsync);
            }
        }

        public override void Prepare()
        {
            base.Prepare();

        }



        public System.Windows.Input.ICommand CreateNewCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    var todoDetailViewModel = new TodoItemDetailViewModel(_navigationService)
                    {
                        Model = new TodoItem()
                        {
                            TodoListId = Todo.Id,
                        },
                    };
                    await _navigationService.Navigate(todoDetailViewModel);
                });
            }
        }

        private async void DoSelectItemAsync(TodoItem item)
        {
            var todoDetailViewModel = new TodoItemDetailViewModel(_navigationService)
            {
                Model = new TodoItem()
                {
                    Description = item.Description,
                    Id = item.Id,
                    Completed = item.Completed,
                    TodoListId = item.TodoListId,
                },
            };
            await _navigationService.Navigate(todoDetailViewModel);
        }
    }
}
