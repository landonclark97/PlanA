
using Foundation;
using System;
using UIKit;

namespace PlanA
{
    public partial class HomeController : UITableViewController
    {
        public HomeController (IntPtr handle) : base (handle)
        {
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
            UITableView table = new UITableView(View.Bounds);

            string[,] tableItems = AppDelegate.sqlHandler.getAllEvents();

            table.Source = new HomeTableSource(tableItems, this);
            Add(table);
		}
	}
}