using System;
using TodoApp.Core.Interface;

namespace Apptodo.iOS.Interfaces
{
    public class DialogService : IDialogService
    {
        public void Alert(string message, string title, string okbtnText)
        {

        }

        public void CustomAlert(string message, string title, Action YesAction)
        {

        }

        public void DismissProgress(object progress)
        {

        }

        public object ShowProgress()
        {
            return null;
        }
    }
}
