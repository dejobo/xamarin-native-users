using System;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Plugin;
using MvvmCross.ViewModels;
using TodoApp.Core.ViewModels;
using TodoApp.Services.Todo;

namespace TodoApp.Core
{
    public class App : MvxApplication  
    {  
        public override void Initialize()  
        {  
            CreatableTypes()  
                .EndingWith("Service")  
                .AsInterfaces()  
                .RegisterAsLazySingleton();

            RegisterAppStart<TodoListViewModel>();
        }
    }  
}
