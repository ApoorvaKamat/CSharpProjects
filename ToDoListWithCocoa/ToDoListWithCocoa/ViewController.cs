using System;

using AppKit;
using Foundation;

namespace ToDoListWithCocoa
{
    /// <summary>
    /// Inherits NSViewController
    /// Controller Class of the Model-View-Controller Architecture
    /// ID generated is T:ToDoListWithCocoa.ViewController
    /// </summary>
    public partial class ViewController : NSViewController
    {
        #region Constructors
        public ViewController(IntPtr handle) : base(handle)
        {
        }
        #endregion

        #region Properties
        #region Overriden Properties
        /// <summary>
        /// This property overrides the base class and returns and updates the NSObject related to this class
        /// ID generated is M:oDoListWithCocoa.ViewController.RepresentedObject
        /// </summary>
        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
            }
        }
        #endregion
        #endregion

        #region Methods
        #region Public Methods
        /// <summary>
        /// Refreshes and Updates the Table data, thus updating the view
        /// ID generated is F:ToDoListWithCocoa.ViewController.ReloadTable
        /// </summary>
        public void ReloadTable()
        {
            ToDoTable.ReloadData();
        }

        #region Menu Handlers
        /// <summary>
        /// Action to select All the rows
        /// ID generated is F:ToDoListWithCocoa.ViewController.SelectAll
        /// </summary>
        /// <param name="sender"></param>
        [Export("selectAll:")]
        public void SelectAll(NSObject sender)
        {
            ToDoTable.SelectAll(this);
        }

        /// <summary>
        /// Action to Deselct All the Rows
        /// ID generated is F:ToDoListWithCocoa.ViewController.DeselectAll
        /// </summary>
        /// <param name="sender"></param>
        [Export("deselectAll:")]
        public void DeselectAll(NSObject sender)
        {
            ToDoTable.DeselectAll(this);
        }
        #endregion
        #endregion

        #region Overriden Methods
        /// <summary>
        /// Overriden Method ViewDidLoad()
        /// Checks if view is Loaded and updates accordingly
        /// Creates an initial Item in the List and Adds it to Data source
        /// ID generated is F:ToDoListWithCocoa.ViewController.ViewDidLoad
        /// </summary>
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var ToDoList = new ToDoTableDataSource();
            ToDoList.ToDoEntities.Add(new ToDoEntities("Enter Item", "Enter Description"));
            ToDoList.Sort("Item", true);

            //Populate the ToDoTable
            ToDoTable.DataSource = ToDoList;
            ToDoTable.Delegate = new ToDoTableDelegate(this, ToDoList);

            // Auto select the first row
            ToDoTable.SelectRow(0, false);


        }
        #endregion

        #endregion
    }
}
