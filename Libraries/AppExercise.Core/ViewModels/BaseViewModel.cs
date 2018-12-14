using System;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using AppExercise.Services.Todo;

namespace AppExercise.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        private static AppResources mResources;
        public AppResources Resources
        {
            get
            {
                mResources = mResources ?? new AppResources();
                return mResources;
            }
        }

        public class AppResources : Localization.AppResources
        {
            public string this[string key]
            {
                get
                {
                    return ResourceManager.GetString(key, Culture);
                }
            }
        }
    }

}
