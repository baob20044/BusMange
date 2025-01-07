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

using System.Linq;
using System.Data.Entity;

namespace GarageManagementSystem.Component.Admin.AdminSchedule1
{
    public partial class ScheduleStopAdd : UserControl
    {
        BusManageContext _context;
        private int ScheduleId;
        public event Action ScheduleStopAdded;

        public ScheduleStopAdd(int ScheduleID = 0)
        {
            InitializeComponent();
            ScheduleId = ScheduleID;

            using (_context = new BusManageContext())
            {
                // Fetch StopID and StopName from the BusStops table
                var busStops = _context.BusStops
                    .Select(bs => new { bs.StopID, bs.StopName })
                    .ToList();

                // Set the ComboBox data source
                cbStopName.DataSource = busStops;
                cbStopName.DisplayMember = "StopName";  // Display the StopName in ComboBox
                cbStopName.ValueMember = "StopID";      // Store the corresponding StopID

                // Set ComboBox to show 5 items and add a scrollbar
                cbStopName.DropDownHeight = 5 * cbStopName.ItemHeight; // Display 5 items
                cbStopName.MaxDropDownItems = 5; // Maximum number of visible items in dropdown
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void btnAddScheduleStop_Click(object sender, EventArgs e)
        {
            using (_context = new BusManageContext())
            {
                // Get the selected StopID from the ComboBox
                int stopID = (int)cbStopName.SelectedValue;
                DateTime arrivalTime = dateTimePicker1.Value;

                // Check if a ScheduleStop with the same ScheduleID, StopID, and ArrivalTime already exists
                var existingScheduleStop = _context.ScheduleStops
                    .FirstOrDefault(ss => ss.ScheduleID == ScheduleId &&
                                          ss.StopID == stopID &&
                                          DbFunctions.TruncateTime(ss.ArrivalTime) == arrivalTime.Date);

                if (existingScheduleStop != null)
                {
                    // Show an error message if the stop already exists
                    MessageBox.Show("Điểm dừng này đã tồn tại trong lịch trình. Vui lòng chọn điểm dừng khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  // Exit the method without adding a new stop
                }

                // Create a new ScheduleStop object if the stop doesn't already exist
                ScheduleStop newScheduleStop = new ScheduleStop
                {
                    ScheduleID = ScheduleId,    // Use the provided ScheduleID
                    StopID = stopID,            // Use the selected StopID
                    ArrivalTime = arrivalTime   // Use the selected arrival time
                };

                // Add the new ScheduleStop to the context
                _context.ScheduleStops.Add(newScheduleStop);

                // Save changes to the database
                _context.SaveChanges();

                // Trigger the ScheduleStopAdded event
                ScheduleStopAdded?.Invoke();

                // Show a success message
                MessageBox.Show("Thêm điểm dừng lịch trình thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the current UserControl (optional)
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
