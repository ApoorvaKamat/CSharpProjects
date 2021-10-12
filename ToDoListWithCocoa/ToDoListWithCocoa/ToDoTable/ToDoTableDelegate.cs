using System;
using AppKit;
using CoreGraphics;


namespace ToDoListWithCocoa
{
	/// <summary>
	/// Inherits NSTableViewDataDelegate
	/// Manipulates the View of the To Do Table Coulumns
	/// ID Generated is T:ToDoListWithCocoa.ToDoTableDelegate
	/// </summary>
	public class ToDoTableDelegate: NSTableViewDelegate
    {
		#region Private Variables
		private ToDoTableDataSource DataSource;
		private ViewController Controller;
		#endregion

		#region Constructors
		/// <summary>
		/// Initialises the ToDoTableDelegate
		/// ID generated is M:ToDoListWithCocoa.ToDoTableDelegate.#ctor
		/// </summary>
		/// <param name="controller"></param>
		/// <param name="datasource"></param>
		public ToDoTableDelegate(ViewController controller, ToDoTableDataSource datasource)
		{
			this.Controller = controller;
			this.DataSource = datasource;
		}
		#endregion


		#region Methods

		#region Private Methods
		/// <summary>
		/// Sets the Value of the Text fields in the Table (Item and Decription)
		/// ID generated is F:oDoListWithCocoa.ToDoTableDelegate.ConfigureTextField
		/// </summary>
		/// <param name="view">Each cell is pased as a view</param>
		/// <param name="row">ID of the Row whose text fields are to be set</param>
		private void ConfigureTextField(NSTableCellView view, nint row)
		{
			// Add to view
			view.TextField.AutoresizingMask = NSViewResizingMask.WidthSizable;
			view.AddSubview(view.TextField);

			// Configure
			view.TextField.BackgroundColor = NSColor.Clear;
			view.TextField.Bordered = false;
			view.TextField.Selectable = false;
			view.TextField.Editable = true;

			// Wireup events
			view.TextField.EditingEnded += (sender, e) => {

				// Take action based on type
				switch (view.Identifier)
				{
					case "To Do Item":
						DataSource.ToDoEntities[(int)view.TextField.Tag].Item = view.TextField.StringValue;
						break;
					case "Description":
						DataSource.ToDoEntities[(int)view.TextField.Tag].Description = view.TextField.StringValue;
						break;
				}
			};

			// Tag view
			view.TextField.Tag = row;
		}
		#endregion

		#region Overriden Methods

		/// <summary>
		/// This method allows user to select a Row for editing
		/// ID generated is F:oDoListWithCocoa.ToDoTableDelegate.ShouldSelectRow
		/// </summary>
		/// <param name="tableView"></param>
		/// <param name="row"></param>
		/// <returns></returns>
		public override bool ShouldSelectRow(NSTableView tableView, nint row)
        {
			return true;
        }

		/// <summary>
		/// This methods selects the row that contains the string typed by the user
		/// ID generated is F:oDoListWithCocoa.ToDoTableDelegate.GetNextTypeSelectMatch
		/// </summary>
		/// <param name="tableView"></param>
		/// <param name="startRow"></param>
		/// <param name="endRow"></param>
		/// <param name="searchString"></param>
		/// <returns></returns>
		public override nint GetNextTypeSelectMatch(NSTableView tableView, nint startRow, nint endRow, string searchString)
        {
			nint row = 0;
			foreach (var entity in DataSource.ToDoEntities)
			{
				if (entity.Item.Contains(searchString)) return row;

				// Increment row counter
				++row;
			}

			// If not found select the first row
			return 0;
		}

		/// <summary>
		/// This methods allows the user to reorder the Coulums
		/// ID generated is F:oDoListWithCocoa.ToDoTableDelegate.ShouldReorder
		/// </summary>
		/// <param name="tableView"></param>
		/// <param name="columnIndex"></param>
		/// <param name="newColumnIndex"></param>
		/// <returns></returns>
		public override bool ShouldReorder(NSTableView tableView, nint columnIndex, nint newColumnIndex)
        {
			return true;
        }

		/// <summary>
		/// This methods allows user to Edit the Item and Description of a selected Row
		/// ID generated is F:oDoListWithCocoa.ToDoTableDelegate.GetViewForItem
		/// </summary>
		/// <param name="tableView"></param>
		/// <param name="tableColumn"></param>
		/// <param name="row"></param>
		/// <returns></returns>

		public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
			// This pattern allows you reuse existing views when they are no-longer in use.
			// If the returned view is null, you instance up a new view
			// If a non-null view is returned, you modify it enough to reflect the new dataSTextField
			NSTableCellView view = (NSTableCellView)tableView.MakeView(tableColumn.Title, this);
			if (view == null)
			{
				view = new NSTableCellView();

				// Configure the view
				view.Identifier = tableColumn.Title;

				// Take action based on title
				switch (tableColumn.Title)
				{
					case "To Do Item":
						//view.ImageView = new NSImageView(new CGRect(0, 0, 16, 16));
						//view.AddSubview(view.ImageView);
						view.TextField = new NSTextField(new CGRect(20, 0, 400, 16));
						ConfigureTextField(view, row);
						break;
					case "Description":
						view.TextField = new NSTextField(new CGRect(0, 0, 400, 16));
						ConfigureTextField(view, row);
						break;
					case "Delete Item":
						// Create new button
						var button = new NSButton(new CGRect(0, 0, 81, 16));
						button.SetButtonType(NSButtonType.MomentaryPushIn);
						button.Title = "Delete";
						button.Tag = row;

						// Wireup events
						button.Activated += (sender, e) => {
							// Get button and product
							var btn = sender as NSButton;
							var entity = DataSource.ToDoEntities[(int)btn.Tag];

							// Configure alert
							var alert = new NSAlert()
							{
								AlertStyle = NSAlertStyle.Informational,
								InformativeText = $"Are you sure you want to delete {entity.Item}? This operation cannot be undone.",
								MessageText = $"Delete {entity.Item}?",
							};
							alert.AddButton("Cancel");
							alert.AddButton("Delete");
							alert.BeginSheetForResponse(Controller.View.Window, (result) => {
								// Should we delete the requested row?
								if (result == 1001)
								{
									// Remove the given row from the dataset
									DataSource.ToDoEntities.RemoveAt((int)btn.Tag);

									// Keep A dataset incase the deleted set was the last set
									if(DataSource.ToDoEntities.Count == 0)
                                    {
										DataSource.ToDoEntities.Add(new ToDoEntities("Enter Item", "Enter Description"));
                                    }
									Context.IsAnyRowDeleted = true;
									Controller.ReloadTable();
								}
							});
						};

						// Add to view
						view.AddSubview(button);
						break;
					case "Add Item":
						var rowCount = DataSource.ToDoEntities.Count;

						//Create new button for last row only
						var addButton = new NSButton(new CGRect(0, 0, 81, 16));
						addButton.SetButtonType(NSButtonType.MomentaryPushIn);
						addButton.Title = "Add";
						if (row == rowCount - 1)
						{
							view.AddSubview(addButton);
						}

						//Wire up events
						addButton.Activated += (sender, e) =>
						{
							//Get button and product
							var addbtn = sender as NSButton;

							//Add new row
							DataSource.ToDoEntities.Add(new ToDoEntities("Enter Item", "Enter Description"));

							Controller.ReloadTable();
						};

						break;

				}

			}

			// Setup view based on the column selected
			switch (tableColumn.Title)
			{
				case "To Do Item":
					view.TextField.StringValue = DataSource.ToDoEntities[(int)row].Item;
					view.TextField.Tag = row;
					break;
				case "Description":
					view.TextField.StringValue = DataSource.ToDoEntities[(int)row].Description;
					view.TextField.Tag = row;
					break;
				case "Delete Item":
					foreach (NSView subview in view.Subviews)
					{
						var btn = subview as NSButton;
						if (btn != null)
						{
							btn.Tag = row;
						}
					}
					break;
				case "Add Item":
					var rowCount = DataSource.ToDoEntities.Count;
					foreach (NSView subview in view.Subviews)
					{
						var addbtn = subview as NSButton;
						var shouldAssignBtnTag = addbtn != null && row == rowCount - 1 ;
						addbtn.Tag = rowCount - 1;
						var tempRow = row;

						//Remove the Button if the Row is not the last row of the list
						//Logic to be fixed
						while(tempRow < rowCount)
                        {
							if(tempRow != rowCount - 1)
                            {
								addbtn.RemoveFromSuperview();
								
							}

							tempRow++;
                        }
                        
						
					}
					break;
					
			}

			return view;

		}

        #endregion
        #endregion

    }
}
