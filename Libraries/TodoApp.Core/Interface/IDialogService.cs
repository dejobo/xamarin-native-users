using System;
namespace TodoApp.Core.Interface
{
    public interface IDialogService
    {
        void Alert(string message, string title, string okbtnText);
        object ShowProgress();
        void DismissProgress(object progress);
        void CustomAlert(string message, string title, Action YesAction);
    }
}
