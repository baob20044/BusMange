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

namespace GarageManagementSystem.Component.Admin.AdminSchedule
{
    public partial class StopNameEdit : UserControl
    {
        private BusManageContext _context;
        private int _stopID;

        // Define the event to notify when the stop details are edited
        public event Action StopEdited;

        public StopNameEdit(int StopID = 0)
        {
            InitializeComponent();
            _stopID = StopID;
            LoadStopDetails(StopID); // Load existing stop details when initializing
        }

        private void LoadStopDetails(int StopID)
        {
            using (_context = new BusManageContext())
            {
                var stop = _context.BusStops
                    .Where(s => s.StopID == StopID)
                    .FirstOrDefault();

                if (stop != null)
                {
                    txtStopName.Text = stop.StopName;
                    txtAddress.Text = stop.StopAddress;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy điểm dừng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string newStopName = txtStopName.Text;
            string newAddress = txtAddress.Text;

            if (string.IsNullOrEmpty(newStopName) || string.IsNullOrEmpty(newAddress))
            {
                MessageBox.Show("Tên điểm dừng và địa chỉ không thể trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (_context = new BusManageContext())
            {
                var stop = _context.BusStops
                    .Where(s => s.StopID == _stopID)
                    .FirstOrDefault();

                if (stop != null)
                {
                    stop.StopName = newStopName;
                    stop.StopAddress = newAddress;
                    _context.SaveChanges();

                    MessageBox.Show("Thông tin điểm dừng đã được cập nhật.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Notify that the stop has been edited
                    StopEdited?.Invoke();
                    this.Parent.Controls.Remove(this);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy điểm dừng để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }

}
