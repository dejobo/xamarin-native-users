using Android.App;
using Android.Widget;
using Android.OS;
using TodoApp.Core.ViewModels;
using TodoApp.Services.Todo;
using MvvmCross;

namespace AppTodo.Droid
{
    [Activity(Label = "AppTodo", MainLauncher = false, ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

