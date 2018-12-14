using System;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using AppExercise.Core.Localization;
using AppExercise.Services.Todo;

namespace AppExercise.Core.ViewModels
{
    public abstract class PageBaseViewModel : BaseViewModel
    {
        protected readonly IMvxNavigationService _navigationService;

        public PageBaseViewModel(IMvxNavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        private bool mIsBusy = false;
        public bool IsBusy
        {
            get
            {
                return mIsBusy;
            }
            set
            {
                mIsBusy = value;

            }
        }

        public System.Windows.Input.ICommand BackCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    _navigationService.Close(this);
                });
            }
        }
    }
}
