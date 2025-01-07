using GarageManagementSystem.FormUser.Pages;
using GarageManagementSystem.Model;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagementSystem.Component
{
    public partial class SeatBed : UserControl
    {
        private List<BookedTicket> BookedTickets = new List<BookedTicket>();
        private List<string> SelectedSeats = new List<string>();
        private BusManageContext _context;
        private decimal Fare = 0;
        private int TicketId = 0;
        private decimal TotalPrice = 0;
        public SeatBed(int ticketId, decimal fare)
        {
            InitializeComponent();
            _context = new BusManageContext();
            Fare = fare;
            LoadBookedTickets(ticketId);
            TicketId = ticketId;
            TicketHelper.PricePerTicket = Fare;
        }
        private void LoadBookedTickets(int ticketId)
        {
            using (var _context = new BusManageContext())
            {
                BookedTickets = _context.BookedTickets
                    .Where(bt => bt.TicketID == ticketId)
                    .ToList();
            }

            foreach (var bookedTicket in BookedTickets)
            {
                // Dynamically find the checkbox control by name
                var checkBoxName = $"cb{bookedTicket.SeatNumber}"; // Construct the checkbox name
                var checkBox = this.Controls.Find(checkBoxName, true).FirstOrDefault() as Guna2ImageCheckBox;

                if (checkBox != null)
                {
                    // Compare SeatNumber and disable the checkbox if it matches
                    if (bookedTicket.SeatNumber.ToString() == checkBox.Name.Substring(2) && bookedTicket.Status == "Đã xác nhận") // Extract number from "cbX"
                    {
                        checkBox.Enabled = false; // Disable the checkbox
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is Guna2ImageCheckBox checkBox)
            {
                var seatNumber = checkBox.Name.Substring(2); // Extract seat number

                if (checkBox.Checked)
                {
                    if (SelectedSeats.Count >= 5)
                    {
                        checkBox.Checked = false;
                        MessageBox.Show("Đã chọn đủ số ghế");
                        return;
                    }
                    if (!SelectedSeats.Contains(seatNumber))
                    {
                        SelectedSeats.Add(seatNumber);
                    }

                }
                else
                {
                    SelectedSeats.Remove(seatNumber);
                }

                // Update lbFareList with the selected seats, joined by ", "
                lbFareList.Text = string.Join(", ", SelectedSeats);
            }
            lbFareCount.Text = SelectedSeats.Count.ToString() + " vé";
            var Price = Fare * SelectedSeats.Count();
            TotalPrice = Price;
            lbPrice.Text = $"{Price:N0} đ";
            if (SelectedSeats.Count > 0)
            {
                lbFareCount.Visible = true;
                lbFareList.Visible = true;
                lbTotalText.Visible = true;
                lbPrice.Visible = true;
                btnSelect.Visible = true;
            }
            else
            {
                lbFareCount.Visible = false;
                lbFareList.Visible = false;
                lbTotalText.Visible = false;
                lbPrice.Visible = false;
                btnSelect.Visible = false;
            }
            TicketHelper.SelectedSeats = SelectedSeats;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            TicketHelper.ticketId = TicketId;
            TicketHelper.Price = TotalPrice;
            TicketHelper.SeatCount = SelectedSeats.Count;
            TicketHelper.SeatList = lbFareList.Text;

            PayInfoPage payInfoPage = new PayInfoPage();
            var mainPage = this.FindForm() as MainForm;
            mainPage.flowLayoutPanel.Controls.Clear();
            mainPage.flowLayoutPanel.Controls.Add(payInfoPage);
        }
    }
    public static class TicketHelper
    {
        public static int ticketId { get; set; }
        public static decimal Price { get; set; }
        public static int SeatCount { get; set; }
        public static string SeatList { get; set; }
        public static List<string> SelectedSeats { get; set; }
        public static decimal PricePerTicket { get;  set; }
    }
}
