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

namespace GarageManagementSystem.Component
{
    public partial class ScheduleComp : UserControl
    {
        private int _routeId;
        private int _scheduleId;
        BusManageContext _context;

        public ScheduleComp(int routeId, int scheduleId)
        {
            InitializeComponent();
            _routeId = routeId; // Store RouteId for later use
            _scheduleId = scheduleId; // Store ScheduleId for later use
        }

        private void ScheduleComp_Load(object sender, EventArgs e)
        {
            using (_context = new BusManageContext())
            {
                // Fetch the BusRoute corresponding to the RouteID
                var route = _context.BusRoutes
                    .Where(r => r.RouteID == _routeId)
                    .FirstOrDefault();

                if (route != null)
                {
                    // Set the StartLocation and EndLocation to the label
                    lbFromTo.Text = $"{route.StartLocation} → {route.EndLocation}";
                }
                else
                {
                    lbFromTo.Text = "Không tìm thấy tuyến đường.";
                }

                // Fetch the first ArrivalTime and DepartureTime for the given ScheduleID
                var firstScheduleStop = _context.ScheduleStops
                    .Where(ss => ss.ScheduleID == _scheduleId)
                    .OrderBy(ss => ss.ArrivalTime)
                    .FirstOrDefault();

                if (firstScheduleStop != null)
                {
                    // Set Arrival and Departure times
                    lbDepartTime.Text = $"Giờ đi: {firstScheduleStop.ArrivalTime:HH:mm}"; // Example: Departure is 15 minutes earlier
                }
                else
                {
                    lbDepartTime.Text = "Không có thông tin giờ đi.";
                }
            }
        }
    }
}
