using System;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using TodoApp.Core.Interface;
using TodoApp.Core.Models;
using TodoApp.Services.Todo;

namespace TodoApp.Core.ViewModels
{
    public class TodoItemDetailViewModel : PageBaseViewModel
    {
        public TodoItemDetailViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            
        }

        private TodoItem mModel;
        public TodoItem Model
        {
            get
            {
                return mModel;
            }
            set
            {
                mModel = value;
                this.RaisePropertyChanged(() => Model);
            }
        }

        public System.Windows.Input.ICommand SaveCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    if (string.IsNullOrEmpty(mModel.Description))
                    {
                        var dialogService = Mvx.Resolve<IDialogService>();
                        dialogService.Alert("Please input description on form", "Todo", "Ok");
                    }
                    else
                    {
                        var service = Mvx.Resolve<ITodoService>();
                        if (mModel.Id > 0)
                        {
                            service.UpdateTodoItemAsync(mModel);
                        }
                        else
                        {
                            service.AddTodoItemAsync(mModel);
                        }
                        _navigationService.Close(this);
                    }

                });
            }
        }

        public bool IsEnableDelete
        {
            get
            {
                return (mModel != null && mModel.Id > 0);
            }
        }

        public System.Windows.Input.ICommand DeleteCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    var dialogService = Mvx.Resolve<IDialogService>();
                    dialogService.CustomAlert("Do you want to delete this?", "Todo", () =>
                    {
                        var service = Mvx.Resolve<ITodoService>();
                        service.RemoveTodoItemAsync(mModel);
                        _navigationService.Close(this);
                    });


                });
            }
        }
    }
}
