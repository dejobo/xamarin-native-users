using System;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Binding.Target;

namespace AppTodo.Droid.CustomBindings
{
    public class ViewVisibilityByContentBinding : MvxAndroidTargetBinding
    {
        public ViewVisibilityByContentBinding(object target) : base(target)
        {
        }

        public override Type TargetType
        {
            get { return typeof(string); }
        }

        protected View View => (View)Target;

        protected override void SetValueImpl(object target, object value)
        {
            if (View != null)
            {
                if(string.IsNullOrEmpty((string) value)){
                    View.Visibility = ViewStates.Gone;
                }
                else{
                    View.Visibility = ViewStates.Visible;
                }
            }
        }
    }
}
