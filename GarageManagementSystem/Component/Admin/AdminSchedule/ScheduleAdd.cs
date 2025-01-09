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
using GarageManagementSystem.Component.Admin.AdminSchedule;
using iText.Kernel.Pdf.Canvas.Parser.ClipperLib;

namespace GarageManagementSystem
{
    public partial class ScheduleAdd : UserControl
    {
        BusManageContext _context;
        private int RouteId = 0;
        private int ScheduleId = 0;

        private int ScheduleViewDetailId;
        private string startViewDetail;
        private string endViewDetail;
        private string distanceViewDetail;
        private string dateViewDetail;
        public ScheduleAdd(int scheduleId = 0, string start = "", string end = "", decimal distance = 0, string date = "")
        {
            InitializeComponent();
            if (scheduleId != 0)
            {
                ScheduleViewDetailId = scheduleId;
                startViewDetail = start;
                endViewDetail = end;
                distanceViewDetail = distance.ToString();
                dateViewDetail = date.ToString();
            }

            // Subscribe to the RouteAdded event

        }

        private void ReloadRoutes()
        {
            // Clear and reload Start and End locations
            cbStart.Items.Clear();
            cbEnd.Items.Clear();
            cbDistance.Items.Clear();
            using (var context = new BusManageContext())
            {
                var startLocations = context.BusRoutes
                    .Select(route => route.StartLocation)
                    .Distinct()
                    .ToList();

                cbStart.Items.AddRange(startLocations.ToArray());
            }
        }
        private void ReloadDistance()
        {
            LoadTotalDistance(cbStart.SelectedItem?.ToString(),cbEnd.SelectedItem?.ToString());
            using (var context = new BusManageContext())
            {
                var startLocations = context.BusRoutes
                    .Select(route => route.StartLocation)
                    .Distinct()
                    .ToList();

                cbStart.Items.AddRange(startLocations.ToArray());
            }
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

            if(ScheduleViewDetailId != 0)
            {
                cbStart.SelectedItem = startViewDetail;
                cbEnd.SelectedItem = endViewDetail;
                cbDistance.SelectedItem = distanceViewDetail.ToString();
                using (_context = new BusManageContext())
                {
                    // Find the RouteID based on the selected criteria
                    var route = _context.BusRoutes
                        .FirstOrDefault(r =>
                            r.StartLocation == startViewDetail &&
                            r.EndLocation == endViewDetail );

                    if (route != null)
                    {
                        RouteId = route.RouteID;
                    }
                    txtRouteInfo.Text = $"{cbStart.SelectedItem?.ToString()} - {cbEnd.SelectedItem?.ToString()} - {cbDistance.SelectedItem?.ToString()}";
                }
                DateTime parsedDate;
                if (DateTime.TryParse(dateViewDetail, out parsedDate))
                {
                    datepicker1.Value = parsedDate; // Set the DateTime value
                }
                else
                {
                    MessageBox.Show("Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
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
                            //MessageBox.Show("Không tìm thấy tuyến đường với tiêu chí đã chọn. Vui lòng thêm tuyến đường.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //string selectedStartLocation = cbStart.SelectedItem?.ToString();
            //string selectedEndLocation = cbEnd.SelectedItem?.ToString();
            //string selectedDistanceText = cbDistance.SelectedItem?.ToString();

            //if (!string.IsNullOrEmpty(selectedStartLocation) &&
            //    !string.IsNullOrEmpty(selectedEndLocation) &&
            //    !string.IsNullOrEmpty(selectedDistanceText))
            //{
            //    // Parse the selected distance (e.g., "100 km" -> 100)
            //    if (decimal.TryParse(selectedDistanceText.Replace(" km", ""), out decimal selectedDistance))
            //    {
            //        using (_context = new BusManageContext())
            //        {
            //            // Find the RouteID based on the selected criteria
            //            var route = _context.BusRoutes
            //                .FirstOrDefault(r =>
            //                    r.StartLocation == selectedStartLocation &&
            //                    r.EndLocation == selectedEndLocation &&
            //                    r.TotalDistance == selectedDistance);

            //            if (route != null)
            //            {
            //                RouteId = route.RouteID;
            //                txtRouteInfo.Text = $"{cbStart.SelectedItem?.ToString()} - {cbEnd.SelectedItem?.ToString()} - {cbDistance.SelectedItem?.ToString()}";
            //                LoadBusStopList();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Không tìm thấy tuyến đường với tiêu chí đã chọn. Vui lòng thêm tuyến đường.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Khoảng cách được chọn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng đảm bảo tất cả các trường đều được chọn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
        public void LoadBusStopList()
        {
            flowLayoutPanel.Controls.Clear();

            if (RouteId == 0)
            {
                MessageBox.Show("RouteId chưa được chọn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime selectedDate = datepicker1.Value.Date;
            string selectedDate1 = selectedDate.ToString("yyyy/MM/dd");

            using (_context = new BusManageContext())
            {
                try
                {
                    // Fetch the ScheduleID based on RouteID and selected Date
                    var scheduleIdQuery = _context.Schedules
                        .Where(schedule => schedule.RouteID == RouteId && schedule.Date == selectedDate)
                        .Select(schedule => schedule.ScheduleID)
                        .FirstOrDefault();

                    if (scheduleIdQuery <= 0)
                    {
                        return;
                    }

                    ScheduleId = scheduleIdQuery;

                    // Fetch the ScheduleStopID, ScheduleID, and StopID based on ScheduleID
                    var scheduleStops = _context.ScheduleStops
                        .Where(stop => stop.ScheduleID == scheduleIdQuery)
                        .ToList();

                    if (scheduleStops.Count == 0)
                    {
                        Label noScheduleStopsLabel = new Label
                        {
                            Text = "Tuyến đường này chưa có chạm dừng. Vui lòng thêm ít nhất 2 trạm.",
                            AutoSize = true,
                            ForeColor = System.Drawing.Color.Red,
                            Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold)
                        };

                        flowLayoutPanel.Controls.Add(noScheduleStopsLabel);
                    }
                    else
                    {
                        // Create ScheduleStopComp instances for each ScheduleStop
                        foreach (var scheduleStop in scheduleStops)
                        {
                            ScheduleStopComp scheduleStopComp = new ScheduleStopComp(scheduleStop.StopID, selectedDate1, ScheduleId,RouteId);
                            flowLayoutPanel.Controls.Add(scheduleStopComp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi tải danh sách trạm dừng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        var add = new ScheduleStopAdd(scheduleIdQuery,datepicker1.Value.ToString(),RouteId); // Pass ScheduleID here
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

        private void btnAddStopName_Click(object sender, EventArgs e)
        {
            if(RouteId != 0)
            {
                var existing = this.Controls.OfType<StopNameAdd>().FirstOrDefault();

                if (existing == null)
                {
                    var add = new StopNameAdd(RouteId); // Pass ScheduleID here
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
                MessageBox.Show("Vui lòng chọn tuyến đường cần thêm");
            }
        }

        private void btnDeleteRoute_Click(object sender, EventArgs e)
        {
            // Check if RouteId is selected
            if (RouteId == 0)
            {
                MessageBox.Show("Vui lòng chọn tuyến đường cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime selectedDate = datepicker1.Value.Date; // This removes the time part, sets to 00:00

            // Ask for confirmation before proceeding with the deletion
            DialogResult dialogResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa tuyến đường và các điểm dừng không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogResult == DialogResult.Yes)
            {
                using (_context = new BusManageContext())
                {
                    // Fetch the ScheduleID based on RouteID and selected Date (including time)
                    var schedule = _context.Schedules
                        .FirstOrDefault(s => s.RouteID == RouteId && s.Date == selectedDate);

                    if (schedule == null)
                    {
                        MessageBox.Show("Không tìm thấy lịch trình cho tuyến đường và ngày đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Delete related ScheduleStops first
                    var scheduleStops = _context.ScheduleStops
                        .Where(ss => ss.ScheduleID == schedule.ScheduleID)
                        .ToList();

                    _context.ScheduleStops.RemoveRange(scheduleStops); // Remove all associated ScheduleStops

                    // Now delete the Schedule
                    _context.Schedules.Remove(schedule);

                    try
                    {
                        _context.SaveChanges();
                        LoadBusStopList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // User clicked "No", do nothing
                MessageBox.Show("Hủy thao tác xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnViewDetailRoute_Click(object sender, EventArgs e)
        {
            if (RouteId != 0)
            {
                var existing = this.Controls.OfType<RouteViewDetail>().FirstOrDefault();

                if (existing == null)
                {
                    var add = new RouteViewDetail(RouteId,startViewDetail,endViewDetail); // Pass ScheduleID here
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
                MessageBox.Show("Vui lòng chọn tuyến đường cần thêm");
            }
        }

        private void btbAddRouteName_Click(object sender, EventArgs e)
        {
            var existing = this.Controls.OfType<RouteNameAdd>().FirstOrDefault();

            if (existing == null)
            {
            var add = new RouteNameAdd(); // Pass ScheduleID here
            this.Parent.Controls.Add(add);
            add.Dock = DockStyle.None;

            add.Location = new Point(
                (this.Parent.Width - add.Width) / 2,
                (this.Parent.Height - add.Height) / 2
            );
            add.BringToFront();
            add.RouteAdded += ReloadRoutes;
            }
            else
            {
            existing.BringToFront();
            }
        }

        private void btnEditDistance_Click(object sender, EventArgs e)
        {
            if (RouteId != 0)
            {
                var existing = this.Controls.OfType<DistanceEdit>().FirstOrDefault();

                if (existing == null)
                {
                    var add = new DistanceEdit(RouteId); // Pass ScheduleID here
                    this.Parent.Controls.Add(add);
                    add.Dock = DockStyle.None;

                    add.Location = new Point(
                        (this.Parent.Width - add.Width) / 2,
                        (this.Parent.Height - add.Height) / 2
                    );
                    add.BringToFront();
                    add.RouteAdded += ReloadDistance;
                }
                else
                {
                    existing.BringToFront();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tuyến đường cần thêm");
            }
        }

        private void cbDistance_SelectedIndexChanged(object sender, EventArgs e)
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
                            //MessageBox.Show("Không tìm thấy tuyến đường với tiêu chí đã chọn. Vui lòng thêm tuyến đường.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}


