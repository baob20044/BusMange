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

                    // Filter the tickets by the selected date, comparing the DepartTime
                    var filteredTickets = bookedTickets.Where(bookedTicket =>
                    {
                        // Get ticket details
                        var ticket = _context.Tickets.FirstOrDefault(t => t.TicketID == bookedTicket.TicketID);
                        if (ticket == null) return false;

                        // Get route details
                        var route = _context.BusRoutes.FirstOrDefault(r => r.RouteID == ticket.RouteID);
                        if (route == null) return false;

                        // Get the departure time from the Tickets table (the date only)
                        var departTime = _context.Tickets
                                                  .Where(t => t.TicketID == bookedTicket.TicketID)
                                                  .Join(_context.Schedules,
                                                        t => t.ScheduleID,
                                                        s => s.ScheduleID,
                                                        (t, s) => s.Date)  // Assuming `Date` represents the departure time
                                                  .FirstOrDefault();

                        // Filter based on the selected date (ignoring time)
                        return departTime.Date == selectedDate.Date;
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
                        var ticket = _context.Tickets.FirstOrDefault(t => t.TicketID == bookedTicket.TicketID);
                        if (ticket == null) continue;

                        string fare = $"{ticket.Fare:N0}";

                        // Get route details
                        var route = _context.BusRoutes.FirstOrDefault(r => r.RouteID == ticket.RouteID);
                        if (route == null) continue;

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

                        string arrivalTimeStr = string.Empty;
                        if (matchedArrivalTime.HasValue)
                        {
                            try
                            {
                                // Format the ArrivalTime to "yyyy-MM-dd HH:mm:ss"
                                arrivalTimeStr = matchedArrivalTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            catch (FormatException ex)
                            {
                                // Handle formatting error
                                arrivalTimeStr = "Invalid Date";
                                Console.WriteLine($"Error formatting ArrivalTime: {ex.Message}");
                            }
                        }
                        else
                        {
                            arrivalTimeStr = "N/A"; // Handle null values
                        }

                        // Get stop details for "tookPlace"
                        var stopDetails = _context.BusStops.FirstOrDefault(bs => bs.StopName == tookPlace);
                        string address = stopDetails?.StopAddress ?? "";

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
