using System;
using Android.Graphics;
using Android.Widget;
using MvvmCross.Binding;
using MvvmCross.Platforms.Android.Binding.Target;

namespace AppTodo.Droid.Controls
{
    public class StrikeStyleTextBinding : MvxAndroidTargetBinding
    {
        public StrikeStyleTextBinding(object target) : base(target)
        {
        }

        public const string BindingName = "StrikeStyle"; 

        private bool _currentValue;

        public override Type TargetType
        {
            get { return typeof(bool); }
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWay; }
        }

        protected override void SetValueImpl(object target, object value)
        {
            var boolValue = (bool)value;
            var anotherView = (TextView)target;

            if (anotherView == null)
            {
                // this can happen - we are using WeakReferences in the base class
                return;
            }

            if (_currentValue == boolValue)
                return;

            _currentValue = boolValue;
            if(_currentValue == true)
            {
                anotherView.PaintFlags |= PaintFlags.StrikeThruText;
            }
            else
            {
                anotherView.PaintFlags &= ~PaintFlags.StrikeThruText;
            }
        }
    }
}
