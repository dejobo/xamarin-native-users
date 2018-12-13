
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace AppTodo.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "", Theme = "@style/AppTheme")]
    public class TodoListItemView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TodoListItemView);
            // Create your application here
        }
    }
}
