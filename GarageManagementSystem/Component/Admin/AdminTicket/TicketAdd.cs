using GarageManagementSystem.Component.Admin.AdminSchedule;
using GarageManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagementSystem.Component.Admin.AdminTicket
{
    public partial class TicketAdd : UserControl
    {
        BusManageContext _context;

        public TicketAdd()
        {
            InitializeComponent();
        }
        private void TicketAdd_Load(object sender, EventArgs e)
        {
            using (_context = new BusManageContext())
            {
                var tickets = (from ticket in _context.Tickets
                                 join schedule in _context.Schedules
                                 on ticket.ScheduleID equals schedule.ScheduleID
                                 where DbFunctions.TruncateTime(schedule.Date) == datepicker1.Value.Date
                                 select new
                                 {
                                     ticket.TicketID
                                 }).ToList();
                
                foreach (var ticket in tickets)
                {
                    TicketInSpecificDate ticketInSpecificDate = new TicketInSpecificDate(ticket.TicketID);
                    flowLayoutPanel.Controls.Add(ticketInSpecificDate);
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void datepicker1_ValueChanged(object sender, EventArgs e)
        {
            flowLayoutPanel.Controls.Clear();
            TicketAdd_Load(sender, e);
        }

        private void btnAddTicket_Click(object sender, EventArgs e)
        {
            var existing = this.Controls.OfType<TicketAddAccordingDate>().FirstOrDefault();

            if (existing == null)
            {
                var add = new TicketAddAccordingDate(); // Pass ScheduleID here
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
        }
    }
}
