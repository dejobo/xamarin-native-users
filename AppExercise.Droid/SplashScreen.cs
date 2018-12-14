
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppTodo.Droid.Interfaces;
using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using AppExercise.Core.Interface;
using AppExercise.Services.Todo;

namespace AppTodo.Droid
{
    [Activity(
        Label = "App Exercise"
        , Theme = "@style/Theme.Splash"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity<Setup, AppExercise.Core.App>
    {
        public SplashScreen() : base(Resource.Layout.SplashScreen)
        {
            
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Mvx.IoCProvider.RegisterSingleton<ITodoService>(() => new TodoService());
            Mvx.IoCProvider.RegisterSingleton<IDialogService>(() => new DialogService());
        }

    }
}
