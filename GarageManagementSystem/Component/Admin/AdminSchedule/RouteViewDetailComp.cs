using GarageManagementSystem.Model;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms;

namespace GarageManagementSystem.Component.Admin.AdminSchedule
{
    public partial class RouteViewDetailComp : UserControl
    {
        private BusManageContext _context;
        private int StopId;

        public RouteViewDetailComp(int StopID = 0)
        {
            InitializeComponent();
            StopId = StopID;
            LoadRouteDetails(StopID);
        }

        private void LoadRouteDetails(int StopID)
        {
            using (_context = new BusManageContext())
            {
                var stop = _context.BusStops
                    .Where(s => s.StopID == StopID)
                    .Select(s => new { s.RouteID, s.StopName, s.StopAddress })
                    .FirstOrDefault();

                if (stop != null)
                {
                    lbStopName.Text = stop.StopName ?? "N/A";
                    lbStopAddress.Text = stop.StopAddress ?? "N/A";
                }
                else
                {
                    lbStopName.Text = "Không tìm thấy điểm dừng";
                    lbStopAddress.Text = "Không có thông tin";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa điểm dừng này và tất cả các lịch trình liên quan?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                using (_context = new BusManageContext())
                {
                    var scheduleStopsToDelete = _context.ScheduleStops
                        .Where(s => s.StopID == StopId)
                        .ToList();

                    if (scheduleStopsToDelete.Count > 0)
                    {
                        _context.ScheduleStops.RemoveRange(scheduleStopsToDelete);
                    }

                    var stopToDelete = _context.BusStops
                        .Where(s => s.StopID == StopId)
                        .FirstOrDefault();

                    if (stopToDelete != null)
                    {
                        _context.BusStops.Remove(stopToDelete);
                        _context.SaveChanges();

                        MessageBox.Show("Điểm dừng và các lịch trình liên quan đã được xóa thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Parent.Controls.Remove(this);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy điểm dừng để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (StopId != 0)
            {
                var existing = this.Controls.OfType<StopNameEdit>().FirstOrDefault();

                if (existing == null)
                {
                    var add = new StopNameEdit(StopId);
                    add.StopEdited += LoadRouteDetails; // Subscribe to the event to refresh details
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
        private void LoadRouteDetails()
        {
            using (_context = new BusManageContext())
            {
                // Query to fetch updated details of the bus stop after the edit
                var stop = _context.BusStops
                    .Where(s => s.StopID == StopId)
                    .Select(s => new { s.RouteID, s.StopName, s.StopAddress })
                    .FirstOrDefault();

                if (stop != null)
                {
                    // Update the labels or controls with the new stop details
                    lbStopName.Text = stop.StopName ?? "N/A";
                    lbStopAddress.Text = stop.StopAddress ?? "N/A";
                }
                else
                {
                    lbStopName.Text = "Không tìm thấy điểm dừng";
                    lbStopAddress.Text = "Không có thông tin";
                }
            }
        }

    }

}

