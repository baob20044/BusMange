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
    public partial class DistanceEdit : UserControl
    {
        BusManageContext _context;

        // Store the RouteID for this instance
        private int _routeId;
        public event Action RouteAdded;
        public DistanceEdit(int routeId)
        {
            InitializeComponent();
            _routeId = routeId;

            // Load data when the control is initialized
            LoadRouteDetails();
        }

        private void LoadRouteDetails()
        {
            using (_context = new BusManageContext())
            {
                // Fetch the route details based on RouteID
                var route = _context.BusRoutes.FirstOrDefault(r => r.RouteID == _routeId);

                if (route != null)
                {
                    // Populate the controls with route details
                    cBFrom.SelectedItem = route.StartLocation;
                    cBTo.SelectedItem = route.EndLocation;
                    txtDistance.Text = route.TotalDistance.ToString();

                    // Extract the numeric part of EstimatedTime and set it to the NumericUpDown control
                    string estimatedTime = route.EstimatedTime;
                    string numericPart = new string(estimatedTime.Where(char.IsDigit).ToArray()); // Get only digits

                    // Set the numeric value in the NumericUpDown
                    if (decimal.TryParse(numericPart, out decimal result))
                    {
                        numbericNumber.Value = result;
                    }
                    else
                    {
                        numbericNumber.Value = 0; // Default to 0 if parsing fails
                    }

                    // Optionally, set combo box values if not already in the list
                    if (!cBFrom.Items.Contains(route.StartLocation))
                    {
                        cBFrom.Items.Add(route.StartLocation);
                    }

                    if (!cBTo.Items.Contains(route.EndLocation))
                    {
                        cBTo.Items.Add(route.EndLocation);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tuyến đường với RouteID đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Get values from controls
            string startLocation = cBFrom.SelectedItem?.ToString();
            string endLocation = cBTo.SelectedItem?.ToString();
            string totalDistance = txtDistance.Text;
            decimal estimatedTime = numbericNumber.Value;

            // Validate input values
            if (string.IsNullOrEmpty(startLocation) || string.IsNullOrEmpty(endLocation))
            {
                MessageBox.Show("Vui lòng chọn đầy đủ thông tin (Từ, Đến).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(totalDistance) || !decimal.TryParse(totalDistance, out _))
            {
                MessageBox.Show("Vui lòng nhập khoảng cách hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (_context = new BusManageContext())
            {
                // Fetch the route based on RouteID
                var route = _context.BusRoutes.FirstOrDefault(r => r.RouteID == _routeId);

                if (route != null)
                {
                    // Update route details
                    route.StartLocation = startLocation;
                    route.EndLocation = endLocation;
                    route.TotalDistance = decimal.Parse(totalDistance); // Assuming it's stored as a decimal
                    route.EstimatedTime = estimatedTime.ToString() + " giờ"; // Assuming it's stored as a string in the format "X giờ"

                    // Save changes to the database
                    _context.SaveChanges();

                    // Notify user of success
                    MessageBox.Show("Thông tin tuyến đường đã được cập nhật.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RouteAdded?.Invoke();
                    this.Parent.Controls.Remove(this);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tuyến đường để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
