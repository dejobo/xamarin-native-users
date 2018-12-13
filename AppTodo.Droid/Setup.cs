using System;
using System.Runtime.Remoting.Contexts;
using Android.Widget;
using AppTodo.Droid.Controls;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platforms.Android.Core;

namespace AppTodo.Droid
{
    public class Setup : MvxAndroidSetup<TodoApp.Core.App>
    {
        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterFactory(
                new MvxCustomBindingFactory<TextView>(
                    "StrikeThought",
                    view => new StrikeStyleTextBinding(view)));
            base.FillTargetFactories(registry);
        }
    }
}
