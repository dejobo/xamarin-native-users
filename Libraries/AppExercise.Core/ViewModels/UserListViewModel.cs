using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using AppExercise.Core.Interface;
using AppExercise.Core.Models;
using AppExercise.Core.ViewModels.ItemViewModels;
using AppExercise.Services.Todo;

namespace AppExercise.Core.ViewModels
{
    public class UserListViewModel : PageBaseViewModel
    {
        private string _title = "NewsReader";
        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(() => Title); }
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public UserListViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
        }

        private async void OnGetDataAsync()
        {
            //Fake Data
            Users = null;
            //var dialogService = Mvx.Resolve<IDialogService>();
            var service = Mvx.IoCProvider.Resolve<ITodoService>();
            //var dialog = dialogService.ShowProgress();
            var result = await service.GetUserListsAsync();


            Users = result.Select((User arg) => new UserItemModel(arg)
            {
                InfoAction =  (obj) => 
                {

                },
                MoreAction =  (obj) => 
                {
                },
            }).ToList();
            //dialogService.DismissProgress(dialog);
        }

        private List<UserItemModel> mUsers;
        public List<UserItemModel> Users
        {
            get
            {
                return mUsers;
            }
            set
            {
                mUsers = value;
                this.RaisePropertyChanged(() => Users);
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
                    await _navigationService.Navigate<CreateUserViewModel>();
                });
            }
        }




    }
}
