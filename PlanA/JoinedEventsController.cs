using Foundation;
using System;
using UIKit;

namespace PlanA
{
    public partial class JoinedEventsController : UITableViewController
    {
        public JoinedEventsController (IntPtr handle) : base (handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell),"TableCell");
            TableView.Source = null;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            UITableView table = new UITableView(View.Frame);
            if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
                table.CellLayoutMarginsFollowReadableWidth = false;

            string[,] tableItems = AppDelegate.sqlHandler.getJoinedEvents(AppDelegate.username);

            table.Source = new JoinedEventsTableSource(tableItems, this);
            Add(table);
        }
    }
}