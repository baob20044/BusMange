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

namespace GarageManagementSystem.Component.Admin.AdminScheduleComp
{
    public partial class ScheduleStopComp : UserControl
    {
        BusManageContext _context;
        private int StopID;
        private int ScheduleID;
        private DateTime ArrivalTime;

        public ScheduleStopComp(int stopID, string date, int scheduleID)
        {
            InitializeComponent();

            StopID = stopID;
            ScheduleID = scheduleID;

            // Parse the date string outside the LINQ query
            DateTime parsedDate = DateTime.Parse(date);
            ArrivalTime = parsedDate;

            using (_context = new BusManageContext())
            {
                // Modify the LINQ query to find the ScheduleStop
                var scheduleStop = _context.ScheduleStops
                    .Where(ss => ss.StopID == StopID &&
                                 ss.ScheduleID == ScheduleID &&
                                 DbFunctions.TruncateTime(ss.ArrivalTime) == parsedDate.Date)
                    .FirstOrDefault();

                if (scheduleStop != null)
                {
                    // Get the associated BusStop info
                    var busStop = _context.BusStops
                        .Where(s => s.StopID == StopID)
                        .FirstOrDefault();

                    if (busStop != null)
                    {
                        lbStopName.Text = busStop.StopName;
                        lbStopAddress.Text = busStop.StopAddress;
                    }

                    // Display ArrivalTime with full date and time format
                    lbDepartTime.Text = scheduleStop.ArrivalTime.ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy điểm dừng phù hợp với ngày đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void ScheduleStopComp_Load(object sender, EventArgs e)
        {
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Show a confirmation message box
            var confirmResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa điểm dừng này?",  // Confirmation message
                "Xác nhận xóa",  // Title of the message box
                MessageBoxButtons.YesNo,  // Yes/No buttons
                MessageBoxIcon.Question  // Icon type
            );

            if (confirmResult == DialogResult.Yes)
            {
                using (_context = new BusManageContext())
                {
                    // Find the ScheduleStop record based on ScheduleID, StopID, and ArrivalTime
                    var scheduleStopToDelete = _context.ScheduleStops
                        .Where(ss => ss.ScheduleID == ScheduleID &&
                                     ss.StopID == StopID &&
                                     DbFunctions.TruncateTime(ss.ArrivalTime) == ArrivalTime.Date)
                        .FirstOrDefault();

                    if (scheduleStopToDelete != null)
                    {
                        // Remove the found schedule stop record
                        _context.ScheduleStops.Remove(scheduleStopToDelete);
                        _context.SaveChanges();  // Save changes to the database

                        MessageBox.Show("Điểm dừng đã được xóa thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Optionally, remove this control from the parent or refresh UI if necessary
                        this.Parent.Controls.Remove(this);  // Remove this user control from the parent container
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy điểm dừng cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // If "No" is clicked, do nothing and return
                return;
            }
        }
    }
}