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
        public AdminScheduleComp1(int ScheduleId = 0, string StartLocation = "", string ArrivalLocation = "", decimal TotalDistance = 0 ,string Date = "")
        {
            InitializeComponent();
            scheduleId = ScheduleId;
            lbScheduleId.Text = ScheduleId.ToString();
            lbRouteName.Text = $"{StartLocation} - {ArrivalLocation} {TotalDistance:F2} km";
            lbDate.Text = Date.ToString();
        }

        private void ScheduleComp_Load(object sender, EventArgs e)
        {
            if (scheduleId % 2 != 0)
            {
                this.BackColor = Color.White;
            }
        }
    }
}
