using GarageManagementSystem.Component;
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

namespace GarageManagementSystem.FormUser.Pages
{
    public partial class OrderHistory : UserControl
    {
        int UserId = UserSession.UserId;
        public OrderHistory()
        {
            InitializeComponent();

        }

        private void OrderHistory_Load(object sender, EventArgs e)
        {
            using (var context = new BusManageContext())
            {
                // Fetch orders for the current user
                var userOrders = context.Orders
                    .Where(order => order.UserID == UserId) // Filter by UserId
                    .OrderByDescending(order => order.DateCreated) // Sort by DateCreated, latest first
                    .ToList();

                if (userOrders.Any())
                {
                    foreach (var order in userOrders)
                    {
                        // Create an instance of OrderComp for each order
                        var orderComp = new OrderComp(order.OrderID)
                        {
                            Dock = DockStyle.Top,
                            Margin = new Padding(10) // Add some spacing
                        };

                        // Add the order component to the flowLayoutPanel
                        flowLayoutPanel.Controls.Add(orderComp);
                    }
                }
                else
                {
                    // Display a message if no orders are found
                    Label noOrdersLabel = new Label
                    {
                        Text = "Không tìm thấy hóa đơn.",
                        AutoSize = true,
                        Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Italic),
                        ForeColor = System.Drawing.Color.Gray,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Top
                    };
                    flowLayoutPanel.Controls.Add(noOrdersLabel);
                }
            }
        }


    }
}
