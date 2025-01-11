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

namespace GarageManagementSystem.Component.Admin.AdminTicket
{
    public partial class StaffInBus : UserControl
    {
        private BusManageContext _context = new BusManageContext();

        public StaffInBus(int busID)
        {
            InitializeComponent();
            for (int i = 1; i < 6; i++)
            {
                StaffComp staffComp = new StaffComp(i);
                flowLayoutPanel.Controls.Add(staffComp);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Remove the control from its parent container
            this.Parent.Controls.Remove(this);
        }
    }
}
