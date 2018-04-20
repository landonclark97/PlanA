using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace PlanA
{
    public partial class TimesListController : UITableViewController
    {
        public string EventID { get; set; }

        public TimesListController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            UITableView table = new UITableView(View.Bounds);

            List<string> times = AppDelegate.sqlHandler.getEventTimes(EventID);

            table.Source = new TimesTableSource(times, this);
            Add(table);
        }
    }
}