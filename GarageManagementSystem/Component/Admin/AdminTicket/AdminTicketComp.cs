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
    public partial class AdminTicketComp : UserControl
    {
        private BusManageContext _context;
        private int TicketID;
        public AdminTicketComp(int ticketID)
        {
            InitializeComponent();
            TicketID = ticketID;
            using (_context = new BusManageContext())
            {
                // Fetch the ticket record by TicketID
                var ticket = _context.Tickets.Where(s => s.TicketID == ticketID).FirstOrDefault();

                if (ticket != null)
                {
                    // Get BusType from Buses table
                    var bus = _context.Buses.Where(b => b.BusID == ticket.BusID).FirstOrDefault();
                    lbBusType.Text = bus != null ? bus.BusType : "N/A";

                    // Get Fare from Tickets table
                    lbPrice.Text = ticket.Fare.ToString();

                    // Get Date from Schedules table
                    var schedule = _context.Schedules.Where(sch => sch.ScheduleID == ticket.ScheduleID).FirstOrDefault();
                    lbDate.Text = schedule != null ? schedule.Date.ToString("dd/MM/yyyy") : "N/A";

                    // Get RouteName from BusRoutes table
                    var route = _context.BusRoutes.Where(r => r.RouteID == ticket.RouteID).FirstOrDefault();
                    if (route != null)
                    {
                        lbRouteName.Text = $"{route.StartLocation} - {route.EndLocation}";
                    }
                    else
                    {
                        lbRouteName.Text = "N/A";
                    }

                    // Set TicketID directly
                    lbTicketId.Text = ticketID.ToString();
                }
                else
                {
                    // Handle the case where the ticket is not found
                    MessageBox.Show("Không tìm thấy vé với TicketID đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AdminTicketComp_Load(object sender, EventArgs e)
        {
            if (TicketID % 2 != 0)
            {
                this.BackColor = Color.White;
            }
        }
    }
}

