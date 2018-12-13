using System;
using System.Linq;
using System.Windows.Input;
using MvvmCross.Commands;
using TodoApp.Core.Models;

namespace TodoApp.Core.ViewModels.ItemViewModels
{
    public class TodoListItemModel : ItemBaseViewModel<TodoList>
    {
        public TodoListItemModel(TodoList mModel) : base(mModel)
        {
            
        }

        public string ActiveText
        {
            get
            {
                if(Model.Active)
                {
                    return "Active";
                }
                else
                {
                    return "Unactive";
                }
            }
        }

        public string DoneText
        {
            get
            {
                if(Model != null)
                {
                    if (Model.TodoItems != null && Model.TodoItems.Count > 0)
                    {
                        var item_not_complete = Model.TodoItems.Where((TodoItem arg) => arg.Completed == false).Count();
                        if (item_not_complete == 0)
                        {
                            return "(Done)";
                        }
                    }
                }
                return string.Empty;
            }
        }

        public string NameListWithState
        {
            get
            {
                return $"{Model.Name} {DoneText}";
            }
        }

        public override void OnEditModel()
        {
            this.RaisePropertyChanged(() => ActiveText);
            this.RaisePropertyChanged(() => NameListWithState);
        }

        public Action<TodoList> InfoAction { get; set; } = null;

        public ICommand InfoCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    if(InfoAction != null)
                    {
                        InfoAction(this.Model);
                    }
                });
            }
        }

        //DetailCommand
    }
}
