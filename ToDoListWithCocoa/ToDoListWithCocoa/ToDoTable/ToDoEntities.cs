using System;

namespace ToDoListWithCocoa
{
    /// <summary>
    /// Creates an Object Named ToDoEntities.
    /// ID String generated is T:ToDOListWithCocoa.ToDoEntities.
    /// </summary>
    public class ToDoEntities
    {
        #region Properties
        public string Item { get; set; } = "";
        public string Description { get; set; } = "";
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor to create the object for ToDoEntities
        /// </summary>
        /// <param name="item">Sets the value of the Item for the To Do List</param>
        /// <param name="description">Sets the value of the Description for the To Do List</param>
        public ToDoEntities(string item, string description)
        {
            this.Item = item;
            this.Description = description;
        }
        #endregion

    }
}
