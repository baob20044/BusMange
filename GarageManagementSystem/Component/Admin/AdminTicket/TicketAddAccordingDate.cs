using GarageManagementSystem.Component.Admin.AdminSchedule;
using GarageManagementSystem.Model;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GarageManagementSystem.Component.Admin.AdminTicket
{
    public partial class TicketAddAccordingDate : UserControl
    {
        BusManageContext _context;
        public event Action ScheduleStopAdded;
        public TicketAddAccordingDate(string date)
        {
            InitializeComponent();
            SelectedDate = DateTime.Parse(date); // Parse the input string date
        }

        private DateTime SelectedDate { get; set; }

        private void TicketAddAccordingDate_Load(object sender, EventArgs e)
        {
            using (_context = new BusManageContext())
            {
                // Fetch all buses from the database
                var buses = _context.Buses.ToList();

                // Populate cbBusNumber ComboBox with BusNumbers and set BusID as value
                cbBusNumber.DisplayMember = "BusNumber";  // Display BusNumber
                cbBusNumber.ValueMember = "BusID";        // Store BusID as value
                cbBusNumber.DataSource = buses;

                // Parse the selected date into DateTime
                DateTime dateToFilter = SelectedDate.Date;

                // Fetch schedules for the selected date with route information
                var schedules = _context.Schedules
                    .Where(schedule => DbFunctions.TruncateTime(schedule.Date) == dateToFilter) // Compare only the date part
                    .Join(_context.BusRoutes,
                        schedule => schedule.RouteID,
                        route => route.RouteID,
                        (schedule, route) => new
                        {
                            ScheduleID = schedule.ScheduleID,
                            StartLocation = route.StartLocation,
                            EndLocation = route.EndLocation,
                            TotalDistance = route.TotalDistance
                        })
                    .ToList() // Fetch data into memory
                    .Select(data => new
                    {
                        ScheduleID = data.ScheduleID,
                        Display = $"{data.StartLocation} - {data.EndLocation} : {data.TotalDistance} km"
                    })
                    .ToList();

                // Populate cbSchedule ComboBox
                cbSchedule.DisplayMember = "Display";     // Display StartLocation - EndLocation : TotalDistance
                cbSchedule.ValueMember = "ScheduleID";    // Store ScheduleID as value
                cbSchedule.DataSource = schedules;

                // Show a message if no schedules are found for the selected date
                if (!schedules.Any())
                {
                    MessageBox.Show("No schedules available for the selected date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (_context = new BusManageContext())
            {
                // Get the selected ScheduleID from cbSchedule
                int selectedScheduleID = (int)cbSchedule.SelectedValue;

                // Get the selected BusID from cbBusNumber
                int selectedBusID = (int)cbBusNumber.SelectedValue;

                // Get the Fare value from txtPrice
                decimal fare = decimal.TryParse(txtPrice.Text, out var parsedFare) ? parsedFare : 0;

                // Check if Fare is valid
                if (fare <= 0)
                {
                    MessageBox.Show("Please enter a valid fare amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create a new Ticket object
                Ticket newTicket = new Ticket
                {
                    BusID = selectedBusID,
                    Fare = fare,
                    ScheduleID = selectedScheduleID
                };

                // Add the new Ticket object to the Tickets table
                _context.Tickets.Add(newTicket);

                // Save the changes to the database
                try
                {
                    _context.SaveChanges();
                    MessageBox.Show("Ticket added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload the parent control to update ticket list
                    ScheduleStopAdded?.Invoke();

                    this.Parent.Controls.Remove(this);  // Remove the current "Add Ticket" view
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while adding the ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }


        private void btnAddBus_Click(object sender, EventArgs e)
        {
            var existing = this.Controls.OfType<BusAdd>().FirstOrDefault();

            if (existing == null)
            {
                var add = new BusAdd(); // Pass ScheduleID here
                this.Parent.Controls.Add(add);
                add.Dock = DockStyle.None;

                add.Location = new Point(
                    (this.Parent.Width - add.Width) / 2,
                    (this.Parent.Height - add.Height) / 2
                );
                add.BringToFront();
            }
            else
            {
                existing.BringToFront();
            }
            this.Parent.Controls.Remove(this);
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            var existing = this.Controls.OfType<BusDetail>().FirstOrDefault();

            if (existing == null)
            {
                var add = new BusDetail(); // Pass ScheduleID here
                this.Parent.Controls.Add(add);
                add.Dock = DockStyle.None;

                add.Location = new Point(
                    (this.Parent.Width - add.Width) / 2,
                    (this.Parent.Height - add.Height) / 2
                );
                add.BringToFront();
            }
            else
            {
                existing.BringToFront();
            }
            this.Parent.Controls.Remove(this);
        }
    }
}
