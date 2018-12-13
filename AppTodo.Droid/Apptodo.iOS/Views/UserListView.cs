using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using TodoApp.Core.ViewModels;
using UIKit;

namespace Apptodo.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]     public partial class UserListView : MvxViewController<UserListViewModel>     {         public override void ViewDidLoad()         {             base.ViewDidLoad();
            this.NavigationController.NavigationBarHidden = true;

            var source = new MvxSimpleTableViewSource(tbUsers, nameof(UserItemCell), UserItemCell.Key);
            tbUsers.RowHeight = UITableView.AutomaticDimension;

            var set = this.CreateBindingSet<UserListView, UserListViewModel>();
            set.Bind(source).To(vm => vm.Users);
            set.Apply();

            tbUsers.Source = source;
            tbUsers.ReloadData();         }


        public UserListView() : base(nameof(UserListView), null)
        {
        }



        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

