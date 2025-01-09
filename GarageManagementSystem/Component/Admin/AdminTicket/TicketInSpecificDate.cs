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
    public partial class TicketInSpecificDate : UserControl
    {
        BusManageContext _context;

        public TicketInSpecificDate(int ticketID)
        {
            InitializeComponent();
            using (_context = new BusManageContext())
            {
                // Fetch the ticket with its related schedule and bus route details
                var ticketDetails = (from ticket in _context.Tickets
                                     join schedule in _context.Schedules on ticket.ScheduleID equals schedule.ScheduleID
                                     join busRoute in _context.BusRoutes on ticket.RouteID equals busRoute.RouteID
                                     join bus in _context.Buses on ticket.RouteID equals bus.RouteID
                                     where ticket.TicketID == ticketID
                                     select new
                                     {
                                         busRoute.StartLocation,
                                         busRoute.EndLocation,
                                         busRoute.TotalDistance,
                                         ticket.Fare,
                                         bus.BusType,
                                         bus.BusNumber
                                     }).FirstOrDefault();

                if (ticketDetails != null)
                {
                    // Populate the UI elements with the ticket details
                    lbRouteName.Text = $"{ticketDetails.StartLocation} - {ticketDetails.EndLocation} : {ticketDetails.TotalDistance} km";
                    lbPrice.Text = ticketDetails.Fare.ToString("#,0 đ");
                    lbBusType.Text = ticketDetails.BusType;
                    lbBusNumber.Text = ticketDetails.BusNumber;
                }
                else
                {
                    // If ticket details are not found
                    MessageBox.Show("Ticket details not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
