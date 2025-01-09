using GarageManagementSystem.Component.Admin.AdminSchedule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagementSystem.Component.Admin
{
    public partial class AdminScheduleComp1 : UserControl
    {
        private readonly int scheduleId;
        private readonly string startLocatiom;
        private readonly string endLocation;
        private readonly decimal distance;
        public AdminScheduleComp1(int ScheduleId = 0, string StartLocation = "", string ArrivalLocation = "", decimal TotalDistance = 0 ,string Date = "")
        {
            InitializeComponent();
            scheduleId = ScheduleId;
            lbScheduleId.Text = ScheduleId.ToString();
            lbRouteName.Text = $"{StartLocation} - {ArrivalLocation} {TotalDistance:F2} km";
            lbDate.Text = Date.ToString();

            startLocatiom = StartLocation;
            endLocation = ArrivalLocation;
            distance = TotalDistance;
        }

        private void ScheduleComp_Load(object sender, EventArgs e)
        {
            if (scheduleId % 2 != 0)
            {
                this.BackColor = Color.White;
            }
        }

        private void btnViewDetail_Click(object sender, EventArgs e)
        {
            var existing = this.Controls.OfType<ScheduleAdd>().FirstOrDefault();

            if (existing == null)
            {
                var add = new ScheduleAdd(scheduleId, startLocatiom,endLocation,distance, lbDate.Text); // Pass ScheduleID here
                this.Parent.Parent.Parent.Parent.Controls.Add(add);
                add.Dock = DockStyle.None;

                add.Location = new Point(
                    (this.Parent.Parent.Parent.Parent.Width - add.Width) / 2,
                    (this.Parent.Parent.Parent.Parent.Height - add.Height) / 2
                );
                add.BringToFront();
            }
            else
            {
                existing.BringToFront();
            }
        }
    }
}
