using System;
using UIKit;
using Foundation;

namespace PlanA
{
    public class EventsTableSource : UITableViewSource
    {
        EventsController owner;
        string[,] TableItems;
        string CellIdentifier = "TableCell";

        public EventsTableSource(string[,] items, EventsController owner)
        {
            TableItems = items;
            this.owner = owner;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            int counter = 0;
            System.Diagnostics.Debug.WriteLine(TableItems.Length);
            for (int i = 0; i < TableItems.Length/2; i++)
            {
                if(TableItems[i,0] != null)
                {
                    counter++;
                }
            }
            return counter;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            string item = TableItems[indexPath.Row,0] + ": " + TableItems[indexPath.Row, 1];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

            cell.TextLabel.Text = item;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            UIAlertController okAlertController = UIAlertController.Create("Row Selected", TableItems[indexPath.Row,0], UIAlertControllerStyle.Alert);
            okAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
            owner.PresentViewController(okAlertController, true, null);
            tableView.DeselectRow(indexPath, true);
        }
    }
}
