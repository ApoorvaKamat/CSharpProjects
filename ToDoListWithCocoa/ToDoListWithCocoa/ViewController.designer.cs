// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ToDoListWithCocoa
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTableColumn DescriptionColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn ItemColumn { get; set; }

		[Outlet]
		AppKit.NSTableView ToDoTable { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ToDoTable != null) {
				ToDoTable.Dispose ();
				ToDoTable = null;
			}

			if (ItemColumn != null) {
				ItemColumn.Dispose ();
				ItemColumn = null;
			}

			if (DescriptionColumn != null) {
				DescriptionColumn.Dispose ();
				DescriptionColumn = null;
			}
		}
	}
}
