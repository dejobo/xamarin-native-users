using System;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Commands;
using AppExercise.Core.Models;

namespace AppExercise.Core.ViewModels.ItemViewModels
{
    public class UserItemModel : ItemBaseViewModel<User>
    {
        public UserItemModel(User mModel) : base(mModel)
        {
            
        }

        public Action<User> InfoAction { get; set; } = null;

        public ICommand InfoCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    if(InfoAction != null)
                    {
                        InfoAction(this.Model);
                    }
                });
            }
        }

        //DetailCommand
    }
}
