using GarageManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagementSystem.Component.Admin.AdminSchedule
{
    public partial class RouteViewDetail : UserControl
    {
        BusManageContext _context;
        private int RouteId;
        public RouteViewDetail(int RouteID = 0,string departPlace = "", string arrivalPlace ="")
        {
            InitializeComponent();
            RouteId = RouteID;
            if(departPlace != "")
            {
                lbFromTo.Text = $"{departPlace} - {arrivalPlace}";
            }
            CenterLabel();
            loadList();
        }
        private void loadList()
        {
            using (_context = new BusManageContext())
            {
                // Fetch the BusStops for the given RouteID
                var routes = _context.BusStops.Where(s => s.RouteID == RouteId).ToList();

                // Clear any existing controls in the flowLayoutPanel
                flowLayoutPanel.Controls.Clear();

                if (routes.Count == 0)
                {
                    // Display a label with the message when no routes are found
                    Label noRoutesLabel = new Label
                    {
                        Text = "Không có trạm dừng nào trên tuyến đường này. Vui lòng thêm trạm dừng.",
                        AutoSize = true,
                        ForeColor = System.Drawing.Color.Red,
                        Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    // Add the label to the flowLayoutPanel
                    flowLayoutPanel.Controls.Add(noRoutesLabel);
                }
                else
                {
                    // Add each BusStop to the flowLayoutPanel
                    foreach (BusStop route in routes)
                    {
                        RouteViewDetailComp routeViewDetailComp = new RouteViewDetailComp(route.StopID);
                        flowLayoutPanel.Controls.Add(routeViewDetailComp);
                    }
                }
            }
        }

        private void CenterLabel()
        {
            // Center the label horizontally in the parent container
            lbFromTo.Left = (this.Width - lbFromTo.Width) / 2;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
