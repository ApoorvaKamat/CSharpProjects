using System;
namespace ToDoListApp
{
    /// <summary>
    /// Sets and retuns Properties used for Task Items
    /// ID generated is T:ToDoListApp.TaskItems
    /// </summary>
    public class TaskItems
    {
        #region Public Properties
        public string Title { get; set; }
        public  string Description { get; set; }
        public  DateTime Time { get; set; }
        public  string Day { get; set; }
        #endregion
    }
}
