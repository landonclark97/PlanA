using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace PlanA
{
    public class TimesTableSource : UITableViewSource
    {
        TimesListController owner;
        List<string> TableItems;
        string CellIdentifier = "TableCell";

        public TimesTableSource(List<string> items, TimesListController owner)
        {
            TableItems = items;
            this.owner = owner;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            string item = TableItems[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

            cell.TextLabel.Text = item;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            AppDelegate.sqlHandler.voteOnTime(owner.EventID, TableItems[indexPath.Row]);
        }
    }
}
