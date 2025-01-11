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
    public partial class BusAdd : UserControl
    {
        BusManageContext _context;
        public BusAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (_context = new BusManageContext())
            {
                // Check if all required fields are filled
                if (string.IsNullOrEmpty(txtBusNumber.Text))
                {
                    MessageBox.Show("Please enter the bus number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (numbericNumber.Value <= 0)
                {
                    MessageBox.Show("Please enter a valid seat capacity.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbBusType.SelectedItem == null)
                {
                    MessageBox.Show("Please select a bus type.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a new Bus object and set its properties
                Bus newBus = new Bus
                {
                    BusNumber = txtBusNumber.Text,
                    SeatCapacity = (int)numbericNumber.Value,
                    BusType = cbBusType.SelectedItem.ToString() // Assuming the bus type is a string
                };

                // Add the new Bus object to the Buses table
                _context.Buses.Add(newBus);

                // Save changes to the database
                try
                {
                    _context.SaveChanges();
                    MessageBox.Show("New bus added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Parent.Controls.Remove(this); // Close the form or reload the parent control
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while adding the bus: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbBusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBusType.SelectedItem == "Ghế")
            {
                numbericNumber.Value = 28;
                return;
            }
            if (cbBusType.SelectedItem == "Giường")
            {
                numbericNumber.Value = 36;
                return;
            }
            if (cbBusType.SelectedItem == "Limousine")
            {
                numbericNumber.Value = 11;
                return;
            }
        }
    }
}
