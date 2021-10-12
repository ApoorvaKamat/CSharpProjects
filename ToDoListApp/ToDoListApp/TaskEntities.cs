using System;
namespace ToDoListApp
{
    /// <summary>
    /// Creates an Object Named TaskEntities.
    /// ID String generated is T:ToDoListApp.TaskEntities
    /// </summary>
    public class TaskEntities
    {
        #region Public Variables
        public TaskItems taskItems = new TaskItems();
        #endregion

        #region Constructors
        public TaskEntities()
        {
        }
        /// <summary>
        /// Constructor to Initialise with Task Entities Title and Description only
        /// ID generated is M:ToDoListApp.TaskEntities.#ctor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="discription"></param>
        public TaskEntities(string title, string discription)
        {
            taskItems.Title = title;
            taskItems.Description = discription;
        }

        /// <summary>
        /// /// Constructor to Initialise with Task Entities Title, Description , time and day
        /// ID generated is M:ToDoListApp.TaskEntities.#ctor
        /// </summary>
        /// <param name="title"></param>
        /// <param name="discription"></param>
        /// <param name="time"></param>
        /// <param name="day"></param>
        public TaskEntities(string title, string discription, DateTime time, string day)
        {
            taskItems.Title = title;
            taskItems.Description = discription;
            taskItems.Time = time;
            taskItems.Day = day;
        }
        #endregion
    }
}
