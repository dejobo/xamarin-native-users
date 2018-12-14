using System;
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using MvvmCross;
using MvvmCross.Platforms.Android;
using AppExercise.Core.Interface;

namespace AppTodo.Droid.Interfaces
{
    public class DialogService : IDialogService
    {
        public void Alert(string message, string title, string okbtnText)
        {
            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            var adb = new AlertDialog.Builder(act);
            adb.SetTitle(title);
            adb.SetMessage(message);
            adb.SetPositiveButton(okbtnText, (sender, args) => { /* some logic */ });
            adb.Create().Show();
        }

        public void CustomAlert(string message, string title, Action YesAction)
        {
            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            var adb = new AlertDialog.Builder(act);
            adb.SetTitle(title);
            adb.SetMessage(message);
            adb.SetPositiveButton("Yes", (sender, args) => { 
                if(YesAction != null){
                    YesAction();
                }
            });
            adb.SetNegativeButton("No", (sender, e) => {});
            adb.Create().Show();
        }

        public void DismissProgress(object progress)
        {
            if(progress is AlertDialog dialog)
            {
                dialog.Dismiss();
            }
        }

        public object ShowProgress()
        {
            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;
            View view = act.LayoutInflater.Inflate(Resource.Layout.ProgressView, null);
            AlertDialog.Builder builder = new AlertDialog.Builder(act);
            builder.SetCancelable(false);
            builder.SetView(view);

            AlertDialog dialog = builder.Create();
            dialog.Show();
            Window window = dialog.Window;
            if (window != null)
            {
                WindowManagerLayoutParams layoutParams = new WindowManagerLayoutParams();
                layoutParams.CopyFrom(dialog.Window.Attributes);
                layoutParams.Width = ViewGroup.LayoutParams.WrapContent;
                layoutParams.Height = ViewGroup.LayoutParams.WrapContent;
                dialog.Window.Attributes = layoutParams;
                Drawable drawable = new ColorDrawable(Android.Graphics.Color.Transparent);
                dialog.Window.SetBackgroundDrawable(drawable);
            }

            return dialog;
        }
    }
}
