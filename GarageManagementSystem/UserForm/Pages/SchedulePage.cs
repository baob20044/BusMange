using GarageManagementSystem.Component;
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

namespace GarageManagementSystem.FormUser.Pages
{
    public partial class SchedulePage : UserControl
    {
        BusManageContext _context;

        public SchedulePage()
        {
            InitializeComponent();
        }

        private void SchedulePage_Load(object sender, EventArgs e)
        {
            using (_context = new BusManageContext())
            {
                // Get today's date
                var today = DateTime.Today;

                // Fetch schedules for the current date
                var schedules = _context.Schedules
                    .Where(s => s.Date == today) // Filter schedules for today's date
                    .ToList();

                // Add each RouteID to the FlowLayoutPanel
                foreach (var schedule in schedules)
                {
                    // Add a custom user control to display the schedule
                    ScheduleComp scheduleComp = new ScheduleComp(schedule.RouteID,schedule.ScheduleID);
                    flowLayoutPanel.Controls.Add(scheduleComp);
                }

                // Check if no schedules are available for today
                if (!schedules.Any())
                {
                    Label noScheduleLabel = new Label
                    {
                        Text = "Không có chuyến xe nào trong ngày hôm nay.",
                        AutoSize = true,
                        Font = new Font("Arial", 12, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill
                    };
                    flowLayoutPanel.Controls.Add(noScheduleLabel);
                }
            }
        }
    }
}

