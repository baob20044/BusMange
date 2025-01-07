using GarageManagementSystem.Component;
using GarageManagementSystem.Component.Admin;
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

namespace GarageManagementSystem
{
    public partial class ScheduleManage : UserControl
    {
        BusManageContext _context;
        private int currentPage = 1; // Tracks the current page
        private int itemsPerPage = 15; // Number of items per page
        private int totalPages; // Total number of pages

        public ScheduleManage()
        {
            InitializeComponent();
        }

        private void ScheduleManage_Load(object sender, EventArgs e)
        {
            LoadSchedules();
        }

        private void LoadSchedules(string searchQuery = "")
        {
            using (_context = new BusManageContext())
            {
                // Fetch schedules with their related routes
                var schedules = (from schedule in _context.Schedules
                                 join route in _context.BusRoutes
                                 on schedule.RouteID equals route.RouteID
                                 select new
                                 {
                                     ScheduleID = schedule.ScheduleID,
                                     StartLocation = route.StartLocation,
                                     ArrivalLocation = route.EndLocation,
                                     TotalDistance = route.TotalDistance,
                                     Date = schedule.Date
                                 }).ToList();

                // Apply search filter
                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    searchQuery = searchQuery.ToLower(); // Normalize for case-insensitive search
                    schedules = schedules.Where(s =>
                        s.StartLocation.ToLower().Contains(searchQuery) ||
                        s.ArrivalLocation.ToLower().Contains(searchQuery) ||
                        s.Date.ToString("yyyy-MM-dd").Contains(searchQuery)
                    ).ToList();
                }

                // Apply sorting based on selected radio button (by ScheduleID)
                if (rbASC.Checked) // Ascending order
                {
                    schedules = schedules.OrderBy(s => s.ScheduleID).ToList(); // Sort by ScheduleID in ascending order
                }
                else if (rbDESC.Checked) // Descending order
                {
                    schedules = schedules.OrderByDescending(s => s.ScheduleID).ToList(); // Sort by ScheduleID in descending order
                }

                // Calculate total pages
                totalPages = (int)Math.Ceiling(schedules.Count / (double)itemsPerPage);

                // Ensure the current page is within bounds
                if (currentPage > totalPages) currentPage = totalPages > 0 ? totalPages : 1;

                // Get the items for the current page
                var pagedSchedules = schedules
                    .Skip((currentPage - 1) * itemsPerPage)
                    .Take(itemsPerPage)
                    .ToList();

                // Clear previous controls
                flowLayoutPanel.Controls.Clear();

                // Add schedules to the flow layout panel
                foreach (var schedule in pagedSchedules)
                {
                    AdminScheduleComp1 scheduleComp = new AdminScheduleComp1(
                        ScheduleId: schedule.ScheduleID,
                        StartLocation: schedule.StartLocation,
                        ArrivalLocation: schedule.ArrivalLocation,
                        TotalDistance: schedule.TotalDistance,
                        Date: schedule.Date.ToString("yyyy-MM-dd") // Format date as string
                    );

                    flowLayoutPanel.Controls.Add(scheduleComp);
                }

                // Update page number label
                lbPageNumber.Text = $"{currentPage}/{totalPages}";

                // Enable/disable buttons
                btnPrevious.Enabled = currentPage > 1;
                btnNext.Enabled = currentPage < totalPages;
            }
        }



        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadSchedules();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadSchedules();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text;
            currentPage = 1; // Reset to the first page for new search
            LoadSchedules(searchQuery);
        }

        private void rbASC_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ScheduleManage_Load(sender,e);
        }

        private void rbDESC_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ScheduleManage_Load(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var existing = this.Controls.OfType<ScheduleAdd>().FirstOrDefault();

            if (existing == null)
            {

                var add = new ScheduleAdd();

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
