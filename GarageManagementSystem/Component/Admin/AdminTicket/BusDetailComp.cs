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

namespace GarageManagementSystem.Component.Admin.AdminTicket
{
    public partial class BusDetailComp : UserControl
    {
        private BusManageContext _context;
        private int BusID; // Bus ID for fetching details

        public BusDetailComp(int busID)
        {
            InitializeComponent();
            BusID = busID; // Assign the busID parameter to the BusID field
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            var existing = this.Controls.OfType<StaffInBus>().FirstOrDefault();

            if (existing == null)
            {
                var add = new StaffInBus(BusID); // Pass ScheduleID here
                this.Parent.Parent.Controls.Add(add);
                add.Dock = DockStyle.None;

                add.Location = new Point(
                    (this.Parent.Parent.Width - add.Width) / 2,
                    (this.Parent.Parent.Height - add.Height) / 2
                );
                add.BringToFront();
            }
            else
            {
                existing.BringToFront();
            }
        }

        private void BusDetailComp_Load(object sender, EventArgs e)
        {
            using (_context = new BusManageContext())
            {
                try
                {
                    // Fetch the bus details based on BusID
                    var bus = _context.Buses.FirstOrDefault(s => s.BusID == BusID);
                    if (bus == null)
                    {
                        MessageBox.Show($"Bus with ID {BusID} not found.");
                        return;
                    }

                    // Populate UI elements with bus details
                    lbBusId.Text = bus.BusID.ToString();
                    lbBusNumber.Text = bus.BusNumber;
                    lbType.Text = bus.BusType;
                    lbSeat.Text = bus.SeatCapacity.ToString();
                }
                catch (Exception error)
                {
                    MessageBox.Show($"Error loading bus details: {error.Message}");
                }
            }
        }
    }
}
