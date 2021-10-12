using System;
using System.Collections.Generic;
using System.Linq;


namespace ToDoListApp
{
    /// <summary>
    /// Inherits List
    /// Defines Specific List functions such as Add, Delete, Edit, etc.
    /// ID generated is T:ToDoListApp.TaskList
    /// </summary>
    public class TaskList : List<TaskEntities>
    {
        #region Private Variables
        private List<TaskEntities> Tasks = new List<TaskEntities>();
        private List<TaskEntities> CompletedTasks = new List<TaskEntities>();
        #endregion

        #region Constructor
        public TaskList()
        {
        }
        #endregion
        #region Methods
        #region Private Methods
        private void AddItem(string title, string description)
        {
            Tasks.Add(new TaskEntities(title, description));
            
        }
        private void AddItem(string title, string description,DateTime time, string day)
        {
            Tasks.Add(new TaskEntities(title, description, time, day));

        }
        private void DisplayList(List<TaskEntities> tasks)
        {
            Console.WriteLine();
            Console.WriteLine("Title \t | Descrition");
            Console.WriteLine("------------------------");
            foreach (var t in tasks)
            {
                Console.WriteLine("{0} \t {1}", t.taskItems.Title, t.taskItems.Description);
            }

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Creates New Task Item
        /// </summary>
        public void NewTaskItem()
        {
            
            Console.WriteLine("\n Enter New Task Title: ");
            var title = Console.ReadLine().Trim().ToString();

            Console.WriteLine("\n Enter New Task Description: ");
            var description = Console.ReadLine().Trim().ToString();

            Console.WriteLine($"\n Do you want me to add {title} - {description} to your list?");
            Console.WriteLine("\n Press Y to confirm, N to reject");
            var userConfirmation = Console.ReadKey().Key.ToString();

            if (userConfirmation.Equals("Y", StringComparison.OrdinalIgnoreCase)){

                this.AddItem(title, description);
            }

        }
        /// <summary>
        /// Displays the To Do List
        /// </summary>
        public void DisplayTaskList()
        {
            this.DisplayList(Tasks);

        }
        /// <summary>
        /// Delets the selected item from the To Do List
        /// </summary>
        public void DeleteTaskItem()
        {
            Console.WriteLine("\n Enter the name of the item you want to delete");
            var removeItem = Console.ReadLine().Trim().ToString();
            Tasks.RemoveAll(x => x.taskItems.Title == removeItem);
           
        }
        /// <summary>
        /// Edits the selected item from the To Do List
        /// </summary>
        public void EditListItem()
        {
            Console.WriteLine("\n Enter the name of the item you want to Edit");
            var editItemTitle = Console.ReadLine().Trim().ToString();
            Console.WriteLine("\n Enter the Updated Descrition ");
            var editItemDescription = Console.ReadLine().Trim().ToString();
            Tasks.Where(x => x.taskItems.Title == editItemTitle).ToList().ForEach(x => x.taskItems.Description = editItemDescription);

        }
        /// <summary>
        /// Moves the selected Item to completed Task list and Displays both the Lists
        /// </summary>
        public void MarkCompletedItems()
        {
            Console.WriteLine("\n Enter the name of the item you want to Complete");
            var completedItem = Console.ReadLine().Trim().ToString();
            var completedListItem = Tasks.Where(x => x.taskItems.Title == completedItem).ToList();
            Tasks.RemoveAll(x => x.taskItems.Title == completedItem);
            CompletedTasks = completedListItem;

            //Display The Completed task List
            Console.WriteLine("\n COMPLETED LIST");
            this.DisplayList(CompletedTasks);

            //Display the Task List
            Console.WriteLine("\n ToDo LIST");
            this.DisplayList(Tasks);
        }
        #endregion

        #endregion
    }
}
