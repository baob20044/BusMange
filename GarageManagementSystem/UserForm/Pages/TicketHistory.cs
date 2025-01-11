using GarageManagementSystem.Component;
using GarageManagementSystem.Model;
using Guna.UI2.WinForms.Suite;
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

namespace GarageManagementSystem.FormUser.Pages
{
    public partial class TicketHistory : UserControl
    {
        BusManageContext _context;
        public TicketHistory()
        {
            InitializeComponent();
        }

        // Event handler for the DateTimePicker value change
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Filter the tickets based on the selected date from DateTimePicker
            LoadTicketHistory(DateTimePicker.Value);
        }

        // Modified TicketHistory_Load method to include filtering
        private void LoadTicketHistory(DateTime selectedDate)
        {
            try
            {
                using (var _context = new BusManageContext())
                {
                    // Filter booked tickets based on the selected date
                    var bookedTickets = _context.BookedTickets
                        .Where(s => s.UserID == UserSession.UserId)
                        .OrderByDescending(s => s.BookingID)
                        .ToList();

                    // Filter the tickets by the selected date
                    var filteredTickets = bookedTickets.Where(bookedTicket =>
                    {
                        // Get ticket details and the associated schedule
                        var ticket = _context.Tickets
                            .Join(_context.Schedules,
                                  t => t.ScheduleID,
                                  s => s.ScheduleID,
                                  (t, s) => new { t, s.RouteID, s.Date }) // Join Tickets with Schedules to get RouteID and Date
                            .Where(ts => ts.t.TicketID == bookedTicket.TicketID)
                            .FirstOrDefault();

                        if (ticket == null) return false;

                        // Check if the ticket departure date matches the selected date
                        return ticket.Date.Date == selectedDate.Date;
                    }).ToList();

                    // Clear existing controls in the flowLayoutPanel
                    flowLayoutPanel.Controls.Clear();

                    // Add filtered tickets to the flowLayoutPanel
                    foreach (var bookedTicket in filteredTickets)
                    {
                        int bookedTicketId = bookedTicket.BookingID;
                        int seatNumber = bookedTicket.SeatNumber;
                        string tookPlace = bookedTicket.TookPlace;

                        // Get ticket details
                        // Get ticket details
                        var ticket = _context.Tickets.FirstOrDefault(t => t.TicketID == bookedTicket.TicketID);
                        if (ticket == null) continue;

                        // Get the RouteID from the Schedules table using the ScheduleID from the ticket
                        var schedule = _context.Schedules
                            .Where(s => s.ScheduleID == ticket.ScheduleID)  // Using ScheduleID from the ticket
                            .FirstOrDefault();

                        if (schedule == null) continue;

                        // Now you have the RouteID from the Schedule
                        var route = _context.BusRoutes.FirstOrDefault(r => r.RouteID == schedule.RouteID);
                        if (route == null) continue;

                        // Continue with the rest of your logic...


                        // Query ScheduleStops and BusStops to find matches with TookPlace and the departure date
                        var busStops = _context.BusStops
                            .Where(bs => bs.RouteID == route.RouteID)  // Filter by route
                            .Join(
                                _context.ScheduleStops,  // Join with ScheduleStops to get ArrivalTime
                                bs => bs.StopID,         // Match BusStop StopID with ScheduleStop StopID
                                ss => ss.StopID,         // Match ScheduleStop StopID with BusStop StopID
                                (bs, ss) => new {        // Create an anonymous object with BusStop and ArrivalTime
                                    bs.StopName,
                                    bs.StopID,
                                    ss.ArrivalTime,
                                    ss.ScheduleID  // Include the ScheduleID for the join with Schedules
                                })
                            .Join(
                                _context.Schedules,  // Join with Schedules to get DepartureTime
                                ss => ss.ScheduleID, // Match ScheduleID from ScheduleStops to Schedules
                                s => s.ScheduleID,   // Match ScheduleID from Schedules to ScheduleStops
                                (ss, s) => new {     // Create an anonymous object with Schedule, ArrivalTime, and BusStop
                                    ss.StopName,
                                    ss.StopID,
                                    ss.ArrivalTime,
                                    s.Date            // Date of the schedule (departure date)
                                })
                            .ToList();

                        // Find the bus stop that matches TookPlace and filter by Date
                        var matchedBusStop = busStops
                            .FirstOrDefault(bs => bs.StopName == tookPlace && bs.Date.Date == selectedDate.Date);

                        string busStopBegin = matchedBusStop?.StopName ?? "";
                        string busStopLast = busStops.LastOrDefault()?.StopName ?? "";

                        // Get the ArrivalTime for the specific "tookPlace" and filter by date
                        var matchedArrivalTime = busStops
                            .FirstOrDefault(bs => bs.StopName == tookPlace && bs.Date.Date == selectedDate.Date)?.ArrivalTime;

                        string arrivalTimeStr = matchedArrivalTime.HasValue
                            ? matchedArrivalTime.Value.ToString("yyyy-MM-dd HH:mm:ss")
                            : "N/A";

                        // Get stop details for "tookPlace"
                        var stopDetails = _context.BusStops.FirstOrDefault(bs => bs.StopName == tookPlace);
                        string address = stopDetails?.StopAddress ?? "";
                        string fare = $"{ticket.Fare:N0}";
                        // Create a PhysicalTicket instance and add it to the flowLayoutPanel
                        PhysicalTicket physicalTicket = new PhysicalTicket(bookedTicketId, seatNumber, tookPlace, busStopBegin, busStopLast, arrivalTimeStr, address, fare);
                        flowLayoutPanel.Controls.Add(physicalTicket);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }



        // Call LoadTicketHistory initially to load tickets
        private void TicketHistory_Load(object sender, EventArgs e)
        {
            // Load tickets for the default (current) date
            LoadTicketHistory(DateTime.Now);
        }
    }
}
