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
    public partial class StaffComp : UserControl
    {
        private BusManageContext _context;

        public StaffComp(int StaffID)
        {
            InitializeComponent();
            _context = new BusManageContext();

            try
            {
                // Fetch staff details from the database
                //var staff = _context.Staffs.FirstOrDefault(s => s.StaffID == StaffID);

                //if (staff == null)
                //{
                //    MessageBox.Show(
                //        "Staff not found. Please check the Staff ID.",
                //        "Error",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Error
                //    );
                //    return;
                //}

                //// Populate labels with staff data
                lbFullName.Text =  "N/A";
                lbPhoneNumber.Text =  "N/A";
                lbRole.Text =  "N/A";
                lbStaffId.Text = StaffID.ToString();
            }
            catch (Exception ex)
            {
                // Handle database errors
                MessageBox.Show(
                    $"An error occurred while loading staff data: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}

