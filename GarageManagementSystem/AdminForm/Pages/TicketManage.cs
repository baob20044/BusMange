using GarageManagementSystem.Component.Admin.AdminSchedule;
using GarageManagementSystem.Component.Admin.AdminTicket;
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

namespace GarageManagementSystem.AdminForm.Pages
{
    public partial class TicketManage : UserControl
    {
        private BusManageContext _context;
        private int currentPage = 1; // Start with the first page
        private int pageSize = 15; // Number of tickets to show per page
        private int totalTickets;

        public TicketManage()
        {
            InitializeComponent();
            LoadTickets();
        }

        // Load tickets for the current page
        private void LoadTickets()
        {
            using (_context = new BusManageContext())
            {
                totalTickets = _context.Tickets.Count(); // Get total number of tickets

                // Determine the sorting order based on the selected radio button
                IQueryable<Ticket> ticketsQuery = _context.Tickets;

                if (rbASC.Checked)
                {
                    ticketsQuery = ticketsQuery.OrderBy(t => t.TicketID); // Ascending order
                }
                else if (rbDESC.Checked)
                {
                    ticketsQuery = ticketsQuery.OrderByDescending(t => t.TicketID); // Descending order
                }

                // Apply pagination (skip and take)
                var tickets = ticketsQuery
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(); // Fetch tickets for the current page

                flowLayoutPanel.Controls.Clear(); // Clear existing controls

                foreach (Ticket ticket in tickets)
                {
                    AdminTicketComp adminTicketComp = new AdminTicketComp(ticket.TicketID);
                    flowLayoutPanel.Controls.Add(adminTicketComp);
                }

                lbPageNumber.Text = $"{currentPage}/{Math.Ceiling((double)totalTickets / pageSize)}"; // Show the current page and total pages
            }
        }

        // Navigate to the next page
        private void btnNext_Click(object sender, EventArgs e)
        {
            if ((currentPage * pageSize) < totalTickets) // If not on the last page
            {
                currentPage++;
                LoadTickets(); // Load the tickets for the new page
            }
        }

        // Navigate to the previous page
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) // If not on the first page
            {
                currentPage--;
                LoadTickets(); // Load the tickets for the new page
            }
        }

        private void rbASC_CheckedChanged(object sender, EventArgs e)
        {
            currentPage = 1; // Reset to the first page when sorting changes
            LoadTickets();
        }

        private void rbDESC_CheckedChanged(object sender, EventArgs e)
        {
            currentPage = 1; // Reset to the first page when sorting changes
            LoadTickets();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Check if Enter key is pressed
            {
                SearchTickets(txtSearch.Text); // Call a method to handle the search
            }
        }
        private void SearchTickets(string searchText)
        {
            using (_context = new BusManageContext())
            {
                var ticketsQuery = _context.Tickets.AsQueryable();

                // Check if search text is not empty or null
                if (!string.IsNullOrEmpty(searchText))
                {
                    ticketsQuery = ticketsQuery.Where(t => t.TicketID.ToString().Contains(searchText) ||
                                                            t.Fare.ToString().Contains(searchText)); // Modify as per search logic
                }

                totalTickets = ticketsQuery.Count(); // Get total number of tickets based on the search
                var tickets = ticketsQuery
                    .OrderBy(t => t.TicketID) // Apply sorting as needed
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList(); // Fetch tickets for the current page

                flowLayoutPanel.Controls.Clear(); // Clear existing controls

                foreach (Ticket ticket in tickets)
                {
                    AdminTicketComp adminTicketComp = new AdminTicketComp(ticket.TicketID);
                    flowLayoutPanel.Controls.Add(adminTicketComp);
                }

                lbPageNumber.Text = $"{currentPage}/{Math.Ceiling((double)totalTickets / pageSize)}"; // Show the current page and total pages
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var existing = this.Controls.OfType<TicketAdd>().FirstOrDefault();

            if (existing == null)
            {
                var add = new TicketAdd(); // Pass ScheduleID here
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
    }
}
