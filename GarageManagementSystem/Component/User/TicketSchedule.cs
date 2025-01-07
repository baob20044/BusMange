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
    public partial class TicketSchedule : UserControl
    {
        public TicketSchedule(string departTime="", string busStopName ="",string busStopAddress="")
        {
            InitializeComponent();

            lbDepartTime.Text = departTime;
            lbStopName.Text = busStopName;
            lbStopAddress.Text = busStopAddress;
        }

        private void TicketSchedule_Load(object sender, EventArgs e)
        {

        }
    }
}
