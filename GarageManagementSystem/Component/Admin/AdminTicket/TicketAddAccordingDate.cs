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
    public partial class TicketAddAccordingDate : UserControl
    {
        BusManageContext _context;

        public TicketAddAccordingDate()
        {
            InitializeComponent();
        }

        private void TicketAddAccordingDate_Load(object sender, EventArgs e)
        {
            using (_context = new BusManageContext())
            {
                // Fetch all buses from the database
                var buses = _context.Buses.ToList();

                // Populate ComboBox with BusNumbers and set BusID as value
                cbBusNumber.DisplayMember = "BusNumber";  // Display BusNumber
                cbBusNumber.ValueMember = "BusID";        // Store BusID as value

                // Add buses to the ComboBox
                cbBusNumber.DataSource = buses;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Example usage: You can access the selected BusID from the ComboBox
            int selectedBusID = (int)cbBusNumber.SelectedValue;

            // Add your logic for the Add button here
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}

