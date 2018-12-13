using System;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using TodoApp.Core.Interface;
using TodoApp.Core.Models;
using TodoApp.Services.Todo;

namespace TodoApp.Core.ViewModels
{
    public class TodoDetailViewModel : PageBaseViewModel
    {
        public override Task Initialize()
        {
            return base.Initialize();
        }

        public System.Windows.Input.ICommand SaveCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    if(string.IsNullOrEmpty(mModel.Name))
                    {
                        var dialogService = Mvx.Resolve<IDialogService>();
                        dialogService.Alert("Please input name on form", "Todo", "Ok");
                    }
                    else
                    {
                        var service = Mvx.Resolve<ITodoService>();
                        if(mModel.Id > 0)
                        {
                            service.UpdateTodoListAsync(mModel);
                        }
                        else
                        {
                            service.AddTodoListAsync(mModel);
                        }
                        _navigationService.Close(this);
                    }

                });
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
                            service.RemoveTodoListAsync(mModel);
                            _navigationService.Close(this);
                      });
                   
                   
                });
            }
        }

       
        private TodoList mModel = null;

        public TodoDetailViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            if(mModel == null)
            {
                mModel = new TodoList();
            }
        }

        public TodoList Model
        {
            get
            {
                return mModel;
            }
            set
            {
                mModel = value;
                this.RaisePropertyChanged(nameof(Model));
            }
        }

        public bool IsEnableDelete
        {
            get
            {
                return (mModel != null && mModel.Id > 0);
            }
        }
    }
}
