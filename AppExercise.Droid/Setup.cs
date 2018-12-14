using System;
using System.Runtime.Remoting.Contexts;
using Android.Views;
using Android.Widget;
using AppTodo.Droid.Controls;
using AppTodo.Droid.CustomBindings;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platforms.Android.Core;

namespace AppTodo.Droid
{
    public class Setup : MvxAndroidSetup<AppExercise.Core.App>
    {
        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterFactory(
                new MvxCustomBindingFactory<TextView>(
                    "StrikeThought",
                    view => new StrikeStyleTextBinding(view)));
            registry.RegisterFactory(
                new MvxCustomBindingFactory<View>(
                    "Visible",
                    view => new ViewVisibilityByContentBinding(view)));
            base.FillTargetFactories(registry);



        }
    }
}
