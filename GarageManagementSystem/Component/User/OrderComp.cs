using GarageManagementSystem.Model;
using iText.Layout.Borders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagementSystem.Component
{
    public partial class OrderComp : UserControl
    {
        BusManageContext _context;
        public OrderComp(int orderId)
        {
            InitializeComponent();
            LoadOrderData(orderId);
        }

        private void LoadOrderData(int orderId)
        {
            using (_context = new BusManageContext())
            {
                // Fetch the order from the database using the OrderId
                var order = _context.Orders
                    .Where(o => o.OrderID == orderId)
                    .Include(o => o.User) // Include User data for related information
                    .FirstOrDefault();

                if (order != null)
                {
                    // Populate the labels with data from the order
                    lbOrderId.Text = "Mã hóa đơn: " + order.OrderID.ToString();
                    lbTotalBill.Text = $"{order.TotalBill:N0} đ"; // Format the total bill as currency
                    lbFareNumber.Text = order.NumberOfTickets.ToString();
                    lbCreatedTime.Text = order.DateCreated?.ToString("dd/MM/yyyy HH:mm:ss") ?? "N/A"; // Format the date
                    lbPaymentMethod.Text = order.PaymentMethod;
                }
                else
                {
                    MessageBox.Show("Order not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void OrderComp_Load(object sender, EventArgs e)
        {
            // You can call LoadOrderData here if you want to load the order when the control is loaded
        }
    }
}
