using System;
using UIKit;
using Foundation;

namespace PlanA
{
    public class HomeTableSource : UITableViewSource
    {
        HomeController owner;
        string[,] TableItems;
        string CellIdentifier = "TableCell";
        int totalCells;


        public HomeTableSource(string[,] items, HomeController owner)
        {
            TableItems = items;
            this.owner = owner;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            int counter = 0;
            for (int i = 0; i < TableItems.Length / 3; i++)
            {
                if (TableItems[i, 0] != null)
                {
                    counter++;
                }
            }
            totalCells = counter + 1;
            return counter + 1;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Row <= totalCells - 2)
            {
                UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
                string item = TableItems[indexPath.Row, 0];
                string openStatus;
                if (TableItems[indexPath.Row, 2].Equals("0"))
                {
                    openStatus = "Open";
                }
                else
                {
                    openStatus = "Closed";
                }

                //---- if there are no cells to reuse, create a new one
                if (cell == null)
                { cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier); }

                cell.TextLabel.Text = item;
                cell.DetailTextLabel.Text = openStatus;

                return cell;
            }
            else
            {
                UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);

                //---- if there are no cells to reuse, create a new one
                if (cell == null)
                {
                    cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
                }

                cell.TextLabel.Text = "LOGOUT";

                return cell;
            }
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            UIStoryboard board = owner.Storyboard;
            if (indexPath.Row <= totalCells - 2)
            {
                string eventID = TableItems[indexPath.Row, 1];

                string[] eventInfo = AppDelegate.sqlHandler.getEventInfo(eventID);

                if (eventInfo[6].Equals("0"))
                {
                    var selectedEvent = (DisplayEventController)board.InstantiateViewController("DisplayEventController");

                    selectedEvent.EventID = eventID;

                    selectedEvent.EventInfo = eventInfo;

                    owner.NavigationController.PushViewController(selectedEvent, true);
                }

                else if (eventInfo[6].Equals("1"))
                {
                    var selectedEvent = (DisplayClosedEventController)board.InstantiateViewController("DisplayClosedEventController");

                    selectedEvent.EventID = eventID;

                    selectedEvent.EventInfo = eventInfo;

                    owner.NavigationController.PushViewController(selectedEvent, true);
                }
            }
            if(indexPath.Row == totalCells - 1)
            {
                AppDelegate.username = null;
                var homeView = (LoginController)AppDelegate.Storyboard.InstantiateViewController("LoginController");
                owner.View.Window.RootViewController = homeView;
                owner.RemoveFromParentViewController();
            }
        }

    }
}
