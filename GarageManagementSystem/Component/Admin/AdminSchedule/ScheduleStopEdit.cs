using GarageManagementSystem.Component.Admin.AdminSchedule1;
using GarageManagementSystem.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GarageManagementSystem.Component.Admin.AdminSchedule
{
    public partial class ScheduleStopEdit : UserControl
    {
        private BusManageContext _context;
        private int ScheduleStopID; // Store the provided ScheduleStopID
        private int ScheduleID;
        public event Action ScheduleStopEdited;
        public ScheduleStopEdit(int ScheduleStopID = 0,int RouteId=0)
        {
            InitializeComponent();
            this.ScheduleStopID = ScheduleStopID; // Store ScheduleStopID

            if (this.ScheduleStopID == 0)
            {
                MessageBox.Show("Không có ID ScheduleStop hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (_context = new BusManageContext())
            {
                // Fetch StopID and StopName from the BusStops table
                var busStops = _context.BusStops
                    .Where(s=>s.RouteID == RouteId)
                    .Select(bs => new { bs.StopID, bs.StopName })
                    .ToList();

                // Set the ComboBox data source
                cbStopName.DataSource = busStops;
                cbStopName.DisplayMember = "StopName";  // Display the StopName in ComboBox
                cbStopName.ValueMember = "StopID";      // Store the corresponding StopID

                // Set ComboBox to show 5 items and add a scrollbar
                cbStopName.DropDownHeight = 5 * cbStopName.ItemHeight; // Display 5 items
                cbStopName.MaxDropDownItems = 5; // Maximum number of visible items in dropdown

                // Select the appropriate stop based on ScheduleStopID
                if (ScheduleStopID > 0)
                {
                    var scheduleStop = _context.ScheduleStops
                        .FirstOrDefault(ss => ss.ScheduleStopID == ScheduleStopID);

                    if (scheduleStop != null)
                    {
                        ScheduleID = scheduleStop.ScheduleID; // Store the ScheduleID
                        cbStopName.SelectedValue = scheduleStop.StopID;
                        dateTimePicker1.Value = scheduleStop.ArrivalTime;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy ScheduleStop với ID đã chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // Attach event handler for ComboBox selection change
            cbStopName.SelectedIndexChanged += cbStopName_SelectedIndexChanged;
        }

        // Event handler for ComboBox selection change
        private void cbStopName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbStopName.SelectedValue != null)
            //{
            //    // Get selected StopID from ComboBox
            //    int selectedStopID = (int)cbStopName.SelectedValue;

            //    using (_context = new BusManageContext())
            //    {
            //        var scheduleStop = _context.ScheduleStops
            //            .FirstOrDefault(ss => ss.StopID == selectedStopID);

            //        if (scheduleStop != null)
            //        {
            //            // Set the ArrivalTime to DateTimePicker
            //            dateTimePicker1.Value = scheduleStop.ArrivalTime; // Use current time if ArrivalTime is null
            //        }
            //        else
            //        {
            //            // Handle case where no schedule is found for the selected StopID
            //            dateTimePicker1.Value = DateTime.Now; // You can set a default value here
            //        }
            //    }
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void btnEditScheduleStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbStopName.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn một trạm dừng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dateTimePicker1.Value == null)
                {
                    MessageBox.Show("Vui lòng chọn thời gian đến!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (_context = new BusManageContext())
                {
                    var scheduleStop = _context.ScheduleStops
                        .FirstOrDefault(ss => ss.ScheduleStopID == ScheduleStopID);
                    if (scheduleStop != null)
                    {
                        // Update the StopID and ArrivalTime
                        scheduleStop.StopID = (int)cbStopName.SelectedValue;
                        scheduleStop.ArrivalTime = dateTimePicker1.Value;
                        try
                        {
                            // Save changes to the database
                            _context.SaveChanges();
                            // Show success message
                            ScheduleStopEdited?.Invoke();
                            this.Parent.Controls.Remove(this);
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show("Lỗi khi lưu thay đổi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ScheduleStopEdited?.Invoke();
                            this.Parent.Controls.Remove(this);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy ScheduleStop với ID đã chọn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
