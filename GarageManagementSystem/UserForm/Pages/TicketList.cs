﻿using Bunifu.UI.WinForms.BunifuButton;
using GarageManagementSystem.Component;
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

namespace GarageManagementSystem.FormUser.Pages
{
    public partial class TicketList : UserControl
    {
        public BusManageContext _context;
        private string DepartPlace;
        private string DepartTime;
        private string ArrivalPlace;
        private string ArrivalTime;

        private bool isReloading = false;
        private bool isReturn = false;
        public TicketList(
            string departPlace="", string arrivalPlace="",
            string departTime="",string arrivalTime=""
        )
        {
            InitializeComponent();
            _context = new BusManageContext();
            DepartPlace = departPlace;
            ArrivalPlace = arrivalPlace;
            DepartTime = departTime;
            ArrivalTime = arrivalTime;

            if(arrivalTime != "")
            {
                btnGo.Visible = true;
                btnReturn.Visible = true;
            }
        }


        private void TicketList_Load(object sender, EventArgs e)
        {
            try
            {
                string timeToParse = isReturn ? ArrivalTime : DepartTime;
                if (!DateTime.TryParse(timeToParse, out DateTime parsedDepartDate))
                {
                    MessageBox.Show("Invalid departure time format.");
                    return;
                }

                string startLocation = isReturn ? ArrivalPlace : DepartPlace;
                string endLocation = isReturn ? DepartPlace : ArrivalPlace;

                // Query tickets, routes, buses, and schedules using RouteID from Schedules table
                var tickets = _context.Tickets
                    .Join(
                        _context.Schedules,  // Join with Schedules to filter by ScheduleID
                        ticket => ticket.ScheduleID,
                        schedule => schedule.ScheduleID,
                        (ticket, schedule) => new { ticket, schedule }
                    )
                    .Join(
                        _context.BusRoutes,  // Join with BusRoutes to get Route information
                        ts => ts.schedule.RouteID,
                        route => route.RouteID,
                        (ts, route) => new { ts.ticket, ts.schedule, route }
                    )
                    .Join(
                        _context.Buses,  // Join with Buses to get Bus information
                        tr => tr.ticket.BusID,
                        bus => bus.BusID,
                        (tr, bus) => new { tr.ticket, tr.schedule, tr.route, bus }
                    )
                    .Where(tr =>
                        tr.schedule.Date == parsedDepartDate.Date &&  // Compare the Schedule Date with parsedDepartDate
                        tr.route.StartLocation == startLocation &&    // Filter by start location
                        tr.route.EndLocation == endLocation           // Filter by end location
                    )
                    .ToList();

                if (!tickets.Any())
                {
                    flowLayoutPanel.Controls.Clear();
                    if (isReturn)
                    {
                        MessageBox.Show(
                            $"Hiện tại, không có chuyến đi nào trong ngày {ArrivalTime:dd/MM/yyyy}. " +
                            "Vui lòng kiểm tra lại ngày khởi hành hoặc chọn ngày khác.",
                            "Thông Báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            $"Hiện tại, không có chuyến về nào trong ngày {DepartTime:dd/MM/yyyy}. " +
                            "Vui lòng kiểm tra lại ngày khởi hành hoặc chọn ngày khác.",
                            "Thông Báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    return;
                }

                int time1Count = tickets.Count(tr =>
                {
                    var arrivalTime = _context.ScheduleStops
                        .Where(ss => ss.ScheduleID == tr.schedule.ScheduleID)
                        .OrderBy(ss => ss.ScheduleStopID)
                        .Select(ss => ss.ArrivalTime)
                        .FirstOrDefault();

                    return arrivalTime.Hour >= 0 && arrivalTime.Hour < 6;
                });
                int time2Count = tickets.Count(tr =>
                {
                    var arrivalTime = _context.ScheduleStops
                        .Where(ss => ss.ScheduleID == tr.schedule.ScheduleID)
                        .OrderBy(ss => ss.ScheduleStopID)
                        .Select(ss => ss.ArrivalTime)
                        .FirstOrDefault();

                    return arrivalTime.Hour >= 6 && arrivalTime.Hour < 12;
                });
                int time3Count = tickets.Count(tr =>
                {
                    var arrivalTime = _context.ScheduleStops
                        .Where(ss => ss.ScheduleID == tr.schedule.ScheduleID)
                        .OrderBy(ss => ss.ScheduleStopID)
                        .Select(ss => ss.ArrivalTime)
                        .FirstOrDefault();

                    return arrivalTime.Hour >= 12 && arrivalTime.Hour < 18;
                });
                int time4Count = tickets.Count(tr =>
                {
                    var arrivalTime = _context.ScheduleStops
                        .Where(ss => ss.ScheduleID == tr.schedule.ScheduleID)
                        .OrderBy(ss => ss.ScheduleStopID)
                        .Select(ss => ss.ArrivalTime)
                        .FirstOrDefault();

                    return arrivalTime.Hour >= 18 && arrivalTime.Hour < 24;
                });

                // Update labels with time range counts
                lbTime1.Text = $"Sáng sớm 00:00 - 06:00 ({time1Count})";
                lbTime2.Text = $"Buổi sáng 06:00 - 12:00 ({time2Count})";
                lbTime3.Text = $"Buổi chiều 12:00 - 18:00 ({time3Count})";
                lbTime4.Text = $"Buổi tối 18:00 - 24:00 ({time4Count})";

                // Apply time filters based on selected checkboxes (combine them using OR logic)
                var filteredTickets = tickets.AsQueryable();

                // Filter tickets based on time ranges selected
                if (cBTime1.Checked || cBTime2.Checked || cBTime3.Checked || cBTime4.Checked)
                {
                    filteredTickets = filteredTickets.Where(tr =>
                        (cBTime1.Checked && _context.ScheduleStops
                            .Where(ss => ss.ScheduleID == tr.schedule.ScheduleID)
                            .Select(ss => ss.ArrivalTime).FirstOrDefault().Hour >= 0 &&
                            _context.ScheduleStops.Where(ss => ss.ScheduleID == tr.schedule.ScheduleID)
                            .Select(ss => ss.ArrivalTime).FirstOrDefault().Hour < 6) ||
                        (cBTime2.Checked && _context.ScheduleStops
                            .Where(ss => ss.ScheduleID == tr.schedule.ScheduleID)
                            .Select(ss => ss.ArrivalTime).FirstOrDefault().Hour >= 6 &&
                            _context.ScheduleStops.Where(ss => ss.ScheduleID == tr.schedule.ScheduleID)
                            .Select(ss => ss.ArrivalTime).FirstOrDefault().Hour < 12) ||
                        (cBTime3.Checked && _context.ScheduleStops
                            .Where(ss => ss.ScheduleID == tr.schedule.ScheduleID)
                            .Select(ss => ss.ArrivalTime).FirstOrDefault().Hour >= 12 &&
                            _context.ScheduleStops.Where(ss => ss.ScheduleID == tr.schedule.ScheduleID)
                            .Select(ss => ss.ArrivalTime).FirstOrDefault().Hour < 18) ||
                        (cBTime4.Checked && _context.ScheduleStops
                            .Where(ss => ss.ScheduleID == tr.schedule.ScheduleID)
                            .Select(ss => ss.ArrivalTime).FirstOrDefault().Hour >= 18 &&
                            _context.ScheduleStops.Where(ss => ss.ScheduleID == tr.schedule.ScheduleID)
                            .Select(ss => ss.ArrivalTime).FirstOrDefault().Hour < 24)
                    );
                }

                // Clear the flowLayoutPanel before adding new components
                flowLayoutPanel.Controls.Clear();

                // Display filtered tickets
                foreach (var tr in filteredTickets)
                {
                    var ticket = tr.ticket;
                    var route = tr.route;

                    // Fetch bus stops for the current route
                    var busStops = _context.BusStops
                        .Where(bs => bs.RouteID == route.RouteID)
                        .OrderBy(bs => bs.StopID)
                        .ToList();

                    // Get the first and last bus stop names
                    string busStopBegin = busStops.FirstOrDefault()?.StopName ?? "N/A";
                    string busStopEnd = busStops.LastOrDefault()?.StopName ?? "N/A";

                    // Fetch ArrivalTime from ScheduleStops based on ScheduleID
                    var arrivalTime = _context.ScheduleStops
                        .Where(ss => ss.ScheduleID == tr.schedule.ScheduleID)
                        .OrderBy(ss => ss.ScheduleStopID)
                        .Select(ss => ss.ArrivalTime)
                        .FirstOrDefault();

                    // Use the ArrivalTime from ScheduleStops for departHour
                    string departHour = arrivalTime.ToString("HH:mm");  // Display time portion

                    TicketComp ticketComp = new TicketComp(
                        ticketId: ticket.TicketID,
                        departHour: departHour,  // Use ArrivalTime for time display
                        estimatedHour: route.EstimatedTime,
                        busType: tr.bus.BusType,
                        seatCapacity: tr.bus.SeatCapacity,
                        fare: ticket.Fare,
                        busStopBegin: busStopBegin,
                        busStopEnd: busStopEnd,
                        busStops: busStops
                    );
                    flowLayoutPanel.Controls.Add(ticketComp);
                }

                lbFromTo.Text = isReturn
                     ? $"{ArrivalPlace} - {DepartPlace} ({filteredTickets.Count()})"
                     : $"{DepartPlace} - {ArrivalPlace} ({filteredTickets.Count()})";
                TicketInfomation.departPlace = isReturn ? ArrivalPlace : DepartPlace;
                TicketInfomation.arrivalPlace = isReturn ? DepartPlace : ArrivalPlace;
                TicketInfomation.departTime = isReturn ? ArrivalTime : DepartTime;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }








        private void lbDeleteFilter_Click(object sender, EventArgs e)
        {
            // Uncheck all time filters if they are checked
            if (cBTime1.Checked) cBTime1.Checked = false;
            if (cBTime2.Checked) cBTime2.Checked = false;
            if (cBTime3.Checked) cBTime3.Checked = false;
            if (cBTime4.Checked) cBTime4.Checked = false;

            // Uncheck all bus type filters if they are checked
            if (cBSeat.Checked) cBSeat.Checked = false;
            if (cBBed.Checked) cBBed.Checked = false;
            if (cBLimousine.Checked) cBLimousine.Checked = false;

            // Uncheck additional bus filters if they are checked
            if (cBUpbed.Checked) cBUpbed.Checked = false;
            if (cBDownbed.Checked) cBDownbed.Checked = false;

            if (cBFront.Checked) cBFront.Checked = false;
            if (cBMiddle.Checked) cBMiddle.Checked = false;
            if (cBBehind.Checked) cBBehind.Checked = false;

            // Call the TicketList_Load method to refresh the displayed tickets without the filters
            TicketList_Load(sender, e);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (cBTime1.Checked) cBTime1.Checked = false;
            if (cBTime2.Checked) cBTime2.Checked = false;
            if (cBTime3.Checked) cBTime3.Checked = false;
            if (cBTime4.Checked) cBTime4.Checked = false;

            // Uncheck all bus type filters if they are checked
            if (cBSeat.Checked) cBSeat.Checked = false;
            if (cBBed.Checked) cBBed.Checked = false;
            if (cBLimousine.Checked) cBLimousine.Checked = false;

            // Uncheck additional bus filters if they are checked
            if (cBUpbed.Checked) cBUpbed.Checked = false;
            if (cBDownbed.Checked) cBDownbed.Checked = false;

            if (cBFront.Checked) cBFront.Checked = false;
            if (cBMiddle.Checked) cBMiddle.Checked = false;
            if (cBBehind.Checked) cBBehind.Checked = false;
            isReturn = false;
            TicketList_Load(sender, e);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (cBTime1.Checked) cBTime1.Checked = false;
            if (cBTime2.Checked) cBTime2.Checked = false;
            if (cBTime3.Checked) cBTime3.Checked = false;
            if (cBTime4.Checked) cBTime4.Checked = false;

            // Uncheck all bus type filters if they are checked
            if (cBSeat.Checked) cBSeat.Checked = false;
            if (cBBed.Checked) cBBed.Checked = false;
            if (cBLimousine.Checked) cBLimousine.Checked = false;

            // Uncheck additional bus filters if they are checked
            if (cBUpbed.Checked) cBUpbed.Checked = false;
            if (cBDownbed.Checked) cBDownbed.Checked = false;

            if (cBFront.Checked) cBFront.Checked = false;
            if (cBMiddle.Checked) cBMiddle.Checked = false;
            if (cBBehind.Checked) cBBehind.Checked = false;
            isReturn = true;
            TicketList_Load(sender, e);
        }
    }
    public static class TicketInfomation
    {
        public static string departPlace { get; set; }
        public static string arrivalPlace { get; set; }
        public static string departTime { get; set; }
    }
}