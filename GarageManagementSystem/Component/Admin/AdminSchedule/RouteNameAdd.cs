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

using System;
using System.Linq;
using System.Windows.Forms;
using GarageManagementSystem.Model;

namespace GarageManagementSystem.Component.Admin.AdminSchedule
{
    public partial class RouteNameAdd : UserControl
    {
        private BusManageContext _context;

        public RouteNameAdd()
        {
            InitializeComponent();
            LoadLocations(); // Load available locations into the combo boxes
        }

        // Load StartLocation and EndLocation options into the combo boxes
        private void LoadLocations()
        {
            using (_context = new BusManageContext())
            {
                var locations = _context.BusRoutes
                    .SelectMany(route => new[] { route.StartLocation, route.EndLocation })
                    .Distinct()
                    .ToList();

                cBFrom.Items.AddRange(locations.ToArray());
                cBTo.Items.AddRange(locations.ToArray());
            }
        }
        public event Action RouteAdded;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string startLocation = cBFrom.SelectedItem?.ToString();
            string endLocation = cBTo.SelectedItem?.ToString();
            decimal distance;
            decimal estimatedTime;

            // Validate input
            if (string.IsNullOrEmpty(startLocation) || string.IsNullOrEmpty(endLocation))
            {
                MessageBox.Show("Vui lòng chọn địa điểm bắt đầu và kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (startLocation == endLocation)
            {
                MessageBox.Show("Địa điểm bắt đầu và kết thúc không thể giống nhau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtDistance.Text, out distance) || distance <= 0)
            {
                MessageBox.Show("Vui lòng nhập khoảng cách hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtEstimatedTime.Text, out estimatedTime) || estimatedTime <= 0)
            {
                MessageBox.Show("Vui lòng nhập thời gian ước tính hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new BusManageContext())
            {
                var newRoute = new BusRoute
                {
                    StartLocation = startLocation,
                    EndLocation = endLocation,
                    TotalDistance = distance,
                    EstimatedTime = estimatedTime.ToString() + " giờ",
                };

                context.BusRoutes.Add(newRoute);
                context.SaveChanges();

                MessageBox.Show("Tuyến đường mới đã được thêm thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Notify subscribers that a route has been added
                RouteAdded?.Invoke();
                this.Parent.Controls.Remove(this);
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}

