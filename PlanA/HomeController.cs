
using Foundation;
using System;
using UIKit;

namespace PlanA
{
    public partial class HomeController : UITableViewController
    {
        public HomeController (IntPtr handle) : base (handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), "TableCell");
        }


        /*public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            UITableView table = new UITableView(View.Bounds);

            string[,] tableItems = AppDelegate.sqlHandler.getAllEvents();

            table.Source = new HomeTableSource(tableItems, this);
            Add(table);
        }*/

		public override void ViewWillAppear(bool animated)
		{
            base.ViewWillAppear(animated);
            UITableView table = new UITableView(View.Frame);
            if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0))
                table.CellLayoutMarginsFollowReadableWidth = false;

            string[,] tableItems = AppDelegate.sqlHandler.getAllEvents();

            table.Source = new HomeTableSource(tableItems, this);
            Add(table);
		}

        /*public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            if (segueIdentifier == "HomeToLogin")
            {
                AppDelegate.username = null;
                return true;
            }
            return base.ShouldPerformSegue(segueIdentifier, sender);
        }*/
	}
}