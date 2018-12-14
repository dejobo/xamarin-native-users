using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using AppExercise.Core.Interface;
using AppExercise.Core.Models;
using AppExercise.Services.Todo;

namespace AppExercise.Core.ViewModels
{
    public class CreateUserViewModel : PageBaseViewModel
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
                    if(string.IsNullOrEmpty(mModel.Username)){
                        var dialogService = Mvx.IoCProvider.Resolve<IDialogService>();
                        dialogService.Alert("Please input username", Resources["excercise"], "Ok");
                    }
                    else{
                        ValidatePassword = ValidatePasswordText(mModel.Password);
                        if (string.IsNullOrEmpty(mValidatePassword))
                        {
                            var service = Mvx.IoCProvider.Resolve<ITodoService>();
                            service.AddUserToListAsync(mModel);
                            _navigationService.Close(this);
                        }
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
                    var dialogService = Mvx.IoCProvider.Resolve<IDialogService>();
                    dialogService.CustomAlert("Do you want to delete this?", "Todo", () =>
                      {
                            var service = Mvx.IoCProvider.Resolve<ITodoService>();
                            service.RemoveUserFromListAsync(mModel);
                            _navigationService.Close(this);
                      });
                   
                   
                });
            }
        }

       
        private User mModel = null;

        public CreateUserViewModel(IMvxNavigationService navigationService) : base(navigationService)
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

        private string mValidatePassword = "";
        public string ValidatePassword
        {
            get
            {
                return mValidatePassword;
            }
            set
            {
                mValidatePassword = value;
                this.RaisePropertyChanged(nameof(ValidatePassword));
                this.RaisePropertyChanged(nameof(IsHiddenValidate));
            }
        }

        public bool IsHiddenValidate
        {
            get
            {
                return  string.IsNullOrEmpty(mValidatePassword);
            }
        }

        private string ValidatePasswordText(string text)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasChar = new Regex(@"[a-z]+");
            var hasCharUper = new Regex(@"[A-Z]+");
            var has5To12Length = new Regex(@".{5,12}");
            var hasSpecialChar = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            if(text == null){
                text = "";
            }
            string result = "";
            if(!hasNumber.IsMatch(text)){
                result = "Password must to have at least one number";
            }
            if (!hasChar.IsMatch(text) && !hasCharUper.IsMatch(text))
            {
                result = appendStringToShow(result, "Password must to have at least one character");
            }
            if (!has5To12Length.IsMatch(text))
            {
                result = appendStringToShow(result, "Password must be between 5 and 12 characters in length");
            }
            if (hasSpecialChar.IsMatch(text))
            {
                result = appendStringToShow(result, "Password must not content any special characters");
            }
            return result;
        }

        private string appendStringToShow(string textOriginal, string textAppend)
        {
            if(string.IsNullOrEmpty(textOriginal)){
                return textAppend;
            }
            else{
                return textOriginal + "\n" + textAppend;
            }
        }
    }


}
