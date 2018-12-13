using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using TodoApp.Core.Models;
using TodoApp.Core.ViewModels.ItemViewModels;
using UIKit;

namespace Apptodo.iOS.Views
{
    public partial class UserItemCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("UserItemCell");
        public static readonly UINib Nib;

        static UserItemCell()
        {
            Nib = UINib.FromName("UserItemCell", NSBundle.MainBundle);
        }

        protected UserItemCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<UserItemCell, UserItemModel>();
                set.Bind(lbUserName).To(u => u.Model.Username);
                set.Apply();
            });
        }
    }
}
