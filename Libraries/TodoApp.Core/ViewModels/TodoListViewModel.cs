using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using TodoApp.Core.Interface;
using TodoApp.Core.Models;
using TodoApp.Core.ViewModels.ItemViewModels;
using TodoApp.Services.Todo;

namespace TodoApp.Core.ViewModels
{
    public class TodoListViewModel : PageBaseViewModel
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

        public TodoListViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
        }

        private async void OnGetDataAsync()
        {
            //Fake Data
            Todos = null;
            //var dialogService = Mvx.Resolve<IDialogService>();
            var service = Mvx.Resolve<ITodoService>();
            //var dialog = dialogService.ShowProgress();
            var result = await service.GetUserListsAsync();


            Todos = result.Select((User arg) => new TodoListItemModel(arg)
            {
                InfoAction = async (obj) => 
                {
                    var todoDetail = new TodoDetailViewModel(_navigationService)
                    {
                        Model = new User()
                        {
                            Username = obj.Username,
                            Id = obj.Id,
                            Password = obj.Password,
                        },
                    };
                    await _navigationService.Navigate(todoDetail);
                },
                MoreAction = async (obj) => 
                {
                },
            }).ToList();
            //dialogService.DismissProgress(dialog);
        }

        private List<TodoListItemModel> mTodos;
        public List<TodoListItemModel> Todos
        {
            get
            {
                return mTodos;
            }
            set
            {
                mTodos = value;
                this.RaisePropertyChanged(() => Todos);
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
                    await _navigationService.Navigate<TodoDetailViewModel>();
                });
            }
        }




    }
}
