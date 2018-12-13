using System;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace TodoApp.Core.ViewModels.ItemViewModels
{
    public abstract class ItemBaseViewModel<T> : BaseViewModel
    {
        private T mModel;
        public T Model
        {
            get
            {
                return mModel;
            }
            set
            {
                mModel = value;
                this.RaisePropertyChanged(() => Model);
                OnEditModel();
            }
        }
        
        public ItemBaseViewModel(T _Model)
        {
            Model = _Model;
        }

        public Action<T> MoreAction { get; set; } = null;

        public ICommand MoreCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    if (MoreAction != null)
                    {
                        MoreAction(this.Model);
                    }
                });
            }
        }

        public virtual void OnEditModel()
        {
            
        }
    }
}
