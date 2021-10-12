using System;
using AppKit;
using Foundation;
using System.Collections.Generic;

namespace ToDoListWithCocoa
{
    /// <summary>
    /// Inherits NStableViewDataSource
    /// Handles the Data for the To Do List
    /// </summary>
    public class ToDoTableDataSource : NSTableViewDataSource
    {
        #region Constructor
        public ToDoTableDataSource()
        {
        }
        #endregion

        #region Public Variables
        /// <summary>
        /// Data Source Holder for the To Do List
        /// </summary>
        public List<ToDoEntities> ToDoEntities = new List<ToDoEntities>();
        #endregion

        /**
         *  This is region is coded as per Microsoft Docs
         */
        #region Methods
        #region Public Methods
        /// <summary>
        /// This methods implements Sorting of rows in Ascending order,
        /// when user selects the sort key of the corresponding column.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="ascending"></param>
        public void Sort(string key, bool ascending)
        {
            //Take Action Based on Key
            switch (key)
            {
                case "Item":
                    if (ascending)
                    {
                        ToDoEntities.Sort((x, y) => x.Item.CompareTo(y.Item));
                    }
                    else
                    {
                        ToDoEntities.Sort((x, y) => -1 * x.Item.CompareTo(y.Item));
                    }
                    break;
                case "Description":
                    if (ascending)
                    {
                        ToDoEntities.Sort((x, y) => x.Description.CompareTo(y.Description));
                    }
                    else
                    {
                        ToDoEntities.Sort((x, y) => -1 * x.Description.CompareTo(y.Description));
                    }
                    break;

            }
        }
        #endregion
        
        #region Overriden Methods

        /// <summary>
        /// Returns the Number of Rows in the To Do List
        /// </summary>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public override nint GetRowCount(NSTableView tableView)
        {
            return ToDoEntities.Count;
        }

        /// <summary>
        /// Sorts the Data based on User Selection
        /// </summary>
        /// <param name="tableView"></param>
        /// <param name="oldDescriptors"></param>
        public override void SortDescriptorsChanged(NSTableView tableView, NSSortDescriptor[] oldDescriptors)
        {
            // Sort the data
            if (oldDescriptors.Length > 0)
            {
                // Update sort
                Sort(oldDescriptors[0].Key, oldDescriptors[0].Ascending);
            }
            else
            {
                // Grab current descriptors and update sort
                NSSortDescriptor[] tbSort = tableView.SortDescriptors;
                Sort(tbSort[0].Key, tbSort[0].Ascending);
            }

            // Refresh table
            tableView.ReloadData();
        }
        #endregion
        #endregion
    }
}
