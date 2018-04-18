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
            string item = TableItems[indexPath.Row,0];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

            cell.TextLabel.Text = item;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            UIStoryboard board = owner.Storyboard;

          

            var selectedEvent = (DisplayEventController)board.InstantiateViewController("DisplayEventController");

            selectedEvent.EventID = TableItems[indexPath.Row, 1];

            owner.NavigationController.PushViewController(selectedEvent, true);

        }
    }
}
