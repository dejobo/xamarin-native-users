using Apptodo.iOS.Interfaces;
using Foundation;
using MvvmCross;
using MvvmCross.Platforms.Ios.Core;
using TodoApp.Core.Interface;
using TodoApp.Services.Todo;
using UIKit;

namespace Apptodo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<Setup, TodoApp.Core.App>
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var result = base.FinishedLaunching(application, launchOptions);

            return result;
        }

    }

    public class Setup : MvxIosSetup<TodoApp.Core.App> {


        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            Mvx.IoCProvider.RegisterSingleton<ITodoService>(new TodoService());
            Mvx.IoCProvider.RegisterSingleton<IDialogService>(new DialogService());
        }
    }
}

