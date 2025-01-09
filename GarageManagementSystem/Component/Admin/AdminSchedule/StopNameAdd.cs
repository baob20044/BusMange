using GarageManagementSystem.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GarageManagementSystem.Component.Admin.AdminSchedule
{
    public partial class StopNameAdd : UserControl
    {
        private readonly BusManageContext _context;
        private readonly int _routeId;

        public StopNameAdd(int routeID)
        {
            InitializeComponent();
            _routeId = routeID;
            _context = new BusManageContext();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void btnAddStop_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtStopName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên điểm dừng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ điểm dừng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create a new BusStop object
                var newStop = new BusStop
                {
                    RouteID = _routeId,
                    StopName = txtStopName.Text.Trim(),
                    StopAddress = txtAddress.Text.Trim()
                };

                // Add the new stop to the database
                _context.BusStops.Add(newStop);
                _context.SaveChanges();

                MessageBox.Show("Điểm dừng mới đã được thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally clear inputs for further additions
                this.Parent.Controls.Remove(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi thêm điểm dừng mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
