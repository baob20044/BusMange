using GarageManagementSystem.Component.Admin.AdminScheduleComp;
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
using GarageManagementSystem.Component.Admin.AdminSchedule1;

namespace GarageManagementSystem
{
    public partial class ScheduleAdd : UserControl
    {
        BusManageContext _context;
        private int RouteId = 0;
        private int ScheduleId = 0;
        public ScheduleAdd()
        {
            InitializeComponent();
        }

        private void ScheduleAdd_Load(object sender, EventArgs e)
        {
            using (_context = new BusManageContext())
            {
                // Fetch all unique StartLocation values from BusRoutes
                var startLocations = _context.BusRoutes
                    .Select(route => route.StartLocation)
                    .Distinct()
                    .ToList();

                // Add StartLocation values to cbStart
                cbStart.Items.AddRange(startLocations.ToArray());
            }

            // Attach event handlers
            cbStart.SelectedIndexChanged += CbStart_SelectedIndexChanged;
            cbEnd.SelectedIndexChanged += CbEnd_SelectedIndexChanged;
        }

        private void CbStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStartLocation = cbStart.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedStartLocation))
            {
                LoadEndLocations(selectedStartLocation);
            }
        }

        private void LoadEndLocations(string startLocation)
        {
            using (_context = new BusManageContext())
            {
                // Fetch EndLocation values for the selected StartLocation
                var endLocations = _context.BusRoutes
                    .Where(route => route.StartLocation == startLocation)
                    .Select(route => route.EndLocation)
                    .Distinct()
                    .ToList();

                // Clear and populate cbEnd with EndLocation values
                cbEnd.Items.Clear();
                cbEnd.Items.AddRange(endLocations.ToArray());
            }
        }

        private void CbEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStartLocation = cbStart.SelectedItem?.ToString();
            string selectedEndLocation = cbEnd.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedStartLocation) && !string.IsNullOrEmpty(selectedEndLocation))
            {
                LoadTotalDistance(selectedStartLocation, selectedEndLocation);
            }
        }

        private void LoadTotalDistance(string startLocation, string endLocation)
        {
            using (_context = new BusManageContext())
            {
                // Fetch TotalDistance for the selected StartLocation and EndLocation
                var distances = _context.BusRoutes
                    .Where(route => route.StartLocation == startLocation && route.EndLocation == endLocation)
                    .Select(route => route.TotalDistance)
                    .Distinct()
                    .ToList();

                // Clear and populate cbDistance with TotalDistance values
                cbDistance.Items.Clear();
                foreach (var distance in distances)
                {
                    cbDistance.Items.Add($"{distance} km");
                }

                // Optionally, select the first item by default
                if (cbDistance.Items.Count > 0)
                {
                    cbDistance.SelectedIndex = 0;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Close the current UserControl
            this.Parent.Controls.Remove(this);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            // Handle selection logic if needed
        }

        private void btnSelectRoute_Click(object sender, EventArgs e)
        {
            string selectedStartLocation = cbStart.SelectedItem?.ToString();
            string selectedEndLocation = cbEnd.SelectedItem?.ToString();
            string selectedDistanceText = cbDistance.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedStartLocation) &&
                !string.IsNullOrEmpty(selectedEndLocation) &&
                !string.IsNullOrEmpty(selectedDistanceText))
            {
                // Parse the selected distance (e.g., "100 km" -> 100)
                if (decimal.TryParse(selectedDistanceText.Replace(" km", ""), out decimal selectedDistance))
                {
                    using (_context = new BusManageContext())
                    {
                        // Find the RouteID based on the selected criteria
                        var route = _context.BusRoutes
                            .FirstOrDefault(r =>
                                r.StartLocation == selectedStartLocation &&
                                r.EndLocation == selectedEndLocation &&
                                r.TotalDistance == selectedDistance);

                        if (route != null)
                        {
                            RouteId = route.RouteID;
                            txtRouteInfo.Text = $"{cbStart.SelectedItem?.ToString()} - {cbEnd.SelectedItem?.ToString()} - {cbDistance.SelectedItem?.ToString()}";
                            LoadBusStopList();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy tuyến đường với tiêu chí đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Khoảng cách được chọn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng đảm bảo tất cả các trường đều được chọn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void LoadBusStopList()
        {
            flowLayoutPanel.Controls.Clear();
            int selectedRouteId = RouteId; // Assuming RouteId is already set
            DateTime selectedDate = datepicker1.Value.Date;
            string selectedDate1 = datepicker1.Value.Date.ToString("yyyy/MM/dd");
            using (_context = new BusManageContext())
            {
                // Fetch the ScheduleID based on RouteID and selected Date
                var scheduleIdQuery = _context.Schedules
                    .Where(schedule => schedule.RouteID == selectedRouteId && schedule.Date == selectedDate)
                    .Select(schedule => schedule.ScheduleID)
                    .FirstOrDefault();
                ScheduleId = scheduleIdQuery;
                // If ScheduleID is found, proceed to fetch ScheduleStops
                if (scheduleIdQuery > 0)
                {
                    // Fetch the ScheduleStopID, ScheduleID, and StopID based on ScheduleID
                    var scheduleStops = _context.ScheduleStops
                        .Where(stop => stop.ScheduleID == scheduleIdQuery)
                        .ToList();

                    // Create ScheduleStopComp instances for each ScheduleStop
                    foreach (var scheduleStop in scheduleStops)
                    {
                    ScheduleStopComp scheduleStopComp = new ScheduleStopComp(scheduleStop.StopID, selectedDate1, ScheduleId);
                    flowLayoutPanel.Controls.Add(scheduleStopComp);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lịch trình cho tuyến đường và ngày đã chọn. Vui lòng thêm tuyến đường", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            if (RouteId == 0)
            {
                MessageBox.Show("Vui lòng chọn tuyến đường trước khi thêm lịch trình.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime selectedDate = datepicker1.Value.Date;

            using (_context = new BusManageContext())
            {
                // Check if a schedule already exists for the selected route and date
                var existingSchedule = _context.Schedules
                    .FirstOrDefault(s => s.RouteID == RouteId && s.Date == selectedDate);

                if (existingSchedule != null)
                {
                    MessageBox.Show("Lịch trình cho tuyến đường này và ngày đã chọn đã tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a new schedule
                var newSchedule = new Schedule
                {
                    RouteID = RouteId,
                    Date = selectedDate
                };

                // Add the new schedule to the database
                _context.Schedules.Add(newSchedule);
                _context.SaveChanges();

                MessageBox.Show("Lịch trình đã được thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void datepicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadBusStopList();
        }

        private void btnAddStop_Click(object sender, EventArgs e)
        {
            if (RouteId == 0)
            {
                MessageBox.Show("Vui lòng chọn tuyến đường trước khi thêm điểm dừng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime selectedDate = datepicker1.Value.Date;

            using (_context = new BusManageContext())
            {
                // Fetch the ScheduleID based on RouteID and selected Date
                var scheduleIdQuery = _context.Schedules
                    .Where(schedule => schedule.RouteID == RouteId && schedule.Date == selectedDate)
                    .Select(schedule => schedule.ScheduleID)
                    .FirstOrDefault();
                ScheduleId = scheduleIdQuery;
                if (scheduleIdQuery > 0)
                {
                    // Pass the ScheduleID to the ScheduleStopAdd control
                    var existing = this.Controls.OfType<ScheduleStopAdd>().FirstOrDefault();

                    if (existing == null)
                    {
                        var add = new ScheduleStopAdd(scheduleIdQuery); // Pass ScheduleID here
                        add.ScheduleStopAdded += RefreshBusStopList;
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
                else
                {
                    MessageBox.Show("Không tìm thấy lịch trình cho tuyến đường và ngày đã chọn. Vui lòng thêm lịch trình trước.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void RefreshBusStopList()
        {
            LoadBusStopList();
        }
    }
}


