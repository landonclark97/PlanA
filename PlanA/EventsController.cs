
using System;
using UIKit;
using System.Data;

namespace PlanA
{
    public partial class EventsController : UITableViewController
    {
        public EventsController (IntPtr handle) : base (handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), "TableCell");
            TableView.Source = null;
        }

		/*public override void ViewDidLoad()
		{
            base.ViewDidLoad();
            UITableView table = new UITableView(View.Bounds);

            string[,] tableItems = AppDelegate.sqlHandler.getCreatedEvents(AppDelegate.username);

            table.Source = new EventsTableSource(tableItems, this);
            Add(table);
		}*/

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            UITableView table = new UITableView(View.Frame);
            if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
                table.CellLayoutMarginsFollowReadableWidth = false;

            string[,] tableItems = AppDelegate.sqlHandler.getCreatedEvents(AppDelegate.username);

            table.Source = new EventsTableSource(tableItems, this);
            Add(table);
        }
	}
}