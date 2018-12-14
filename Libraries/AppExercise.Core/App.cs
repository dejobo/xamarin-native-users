using System;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Plugin;
using MvvmCross.ViewModels;
using AppExercise.Core.ViewModels;
using AppExercise.Services.Todo;

namespace AppExercise.Core
{
    public class App : MvxApplication  
    {  
        public override void Initialize()  
        {  
            CreatableTypes()  
                .EndingWith("Service")  
                .AsInterfaces()  
                .RegisterAsLazySingleton();

            RegisterAppStart<UserListViewModel>();
        }
    }  
}
