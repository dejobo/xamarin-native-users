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
                    if(string.IsNullOrEmpty(mModel.Username))
                    {
                        var dialogService = Mvx.Resolve<IDialogService>();
                        dialogService.Alert("Please input name on form", "Exercise", "Ok");
                    }
                    else
                    {
                        var service = Mvx.Resolve<ITodoService>();
                        service.AddUserToListAsync(mModel);
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
                            service.RemoveUserFromListAsync(mModel);
                            _navigationService.Close(this);
                      });
                   
                   
                });
            }
        }

       
        private User mModel = null;

        public TodoDetailViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            if(mModel == null)
            {
                mModel = new User();
            }
        }

        public User Model
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
