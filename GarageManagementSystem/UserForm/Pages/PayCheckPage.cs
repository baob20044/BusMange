using GarageManagementSystem.Component;
using GarageManagementSystem.Model;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
using PdfSharp.Drawing;
using System.Drawing.Imaging;
using PdfSharp.Drawing.Layout;

namespace GarageManagementSystem.FormUser.Pages
{
    public partial class PayCheckPage : UserControl
    {
        private Timer countdownTimer;
        private int remainingMinutes = 20; // Start at 20 minutes
        private int remainingSeconds = 0;  // Start at 0 seconds
        private int BookingId;
        private BusManageContext _context;
        public PayCheckPage()
        {
            InitializeComponent();

            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; // Update every 1 second (1000 ms)
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();
        }

        private void PayCheckPage_Load(object sender, EventArgs e)
        {
            lbFullName.Text = UserSession.FullName;
            lbPhoneNumber.Text = UserSession.PhoneNumber;
            lbEmail.Text = UserSession.Email;

            lbFromTo.Text = $"{TicketInfomation.departPlace} - {TicketInfomation.arrivalPlace}";
            lbDate.Text = TicketInfomation.departTime;

            lbTotalMoney.Text = $"{TicketHelper.Price:N0} đ";
            lbPrice.Text = $"{TicketHelper.Price:N0} đ";
            lbTotalFare.Text = $"{TicketHelper.Price:N0} đ";
            lbTotalTurnGo.Text = $"{TicketHelper.Price:N0} đ";

            lbSeatList.Text = TicketHelper.SeatList;
            lbSeatCount.Text = TicketHelper.SeatCount.ToString() + " chỗ";

            lbFromStop.Text = AddTicketInfo.FromStop;
            lbDepartTimeStop.Text = AddTicketInfo.departTimeStop;

            lbFromToStop.Text = AddTicketInfo.FromToStop;
            lbDateGo.Text = AddTicketInfo.DateGo;
            lbToStop.Text = AddTicketInfo.ToPlace;
        }
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            // Update seconds first
            remainingSeconds--;

            // If seconds reach below 0, reduce minutes by 1
            if (remainingSeconds < 0)
            {
                remainingSeconds = 59;
                remainingMinutes--;

                // Stop the countdown when it reaches 00:00
                if (remainingMinutes < 0)
                {
                    lbTimeLeft.Text = "00:00"; // Countdown complete
                    countdownTimer.Stop();
                    return;
                }
            }

            // Display the remaining time in "MM:SS" format
            lbTimeLeft.Text = $"Thời gian giữ chỗ còn lại {remainingMinutes:D2}:{remainingSeconds:D2}";
        }
        private void cbMomo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMomo.Checked == true)
            {
                pbQrIcon.Image = System.Drawing.Image.FromFile(@"D:\Code\Bài tập cô Miên\GarageManagementSystem\GarageManagementSystem\Resources\momo.png");
            }
            else if (cbFuta.Checked == true)
            {
                pbQrIcon.Image = System.Drawing.Image.FromFile(@"D:\Code\Bài tập cô Miên\GarageManagementSystem\GarageManagementSystem\Resources\futapay.png");
            }
            else if (cbShopee.Checked == true)
            {
                pbQrIcon.Image = System.Drawing.Image.FromFile(@"D:\Code\Bài tập cô Miên\GarageManagementSystem\GarageManagementSystem\Resources\Logo_ShopeePay_2024.png");
            }
            else if (cbViettelMoney.Checked == true)
            {
                pbQrIcon.Image = System.Drawing.Image.FromFile(@"D:\Code\Bài tập cô Miên\GarageManagementSystem\GarageManagementSystem\Resources\viettelpay.png");
            }
            else if (cbVNPay.Checked == true)
            {
                pbQrIcon.Image = System.Drawing.Image.FromFile(@"D:\Code\Bài tập cô Miên\GarageManagementSystem\GarageManagementSystem\Resources\vnpay.png");
            }
            else if (cbZalo.Checked == true)
            {
                pbQrIcon.Image = System.Drawing.Image.FromFile(@"D:\Code\Bài tập cô Miên\GarageManagementSystem\GarageManagementSystem\Resources\Logo_App_Co_Stroke.png");
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            // Determine the selected payment method
            if (cbMomo.Checked)
                AddTicketInfo.PayMethod = "Momo";
            else if (cbFuta.Checked)
                AddTicketInfo.PayMethod = "FUTAPay";
            else if (cbShopee.Checked)
                AddTicketInfo.PayMethod = "ShopeePay";
            else if (cbViettelMoney.Checked)
                AddTicketInfo.PayMethod = "ViettelMoney";
            else if (cbVNPay.Checked)
                AddTicketInfo.PayMethod = "VNPay";
            else if (cbZalo.Checked)
                AddTicketInfo.PayMethod = "ZaloPay";
            else
            {
                MessageBox.Show("Please select a payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> selectedSeats = TicketHelper.SelectedSeats;
            int ticketId = TicketHelper.ticketId;

            // Validate inputs
            if (selectedSeats == null || selectedSeats.Count == 0)
            {
                MessageBox.Show("No seats selected. Please select seats before completing the booking.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(lbPrice.Text))
            {
                MessageBox.Show("Price information is missing. Please ensure the total price is displayed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse the price and handle any formatting issues
            if (!decimal.TryParse(lbPrice.Text.Replace("đ", "").Trim(), out decimal totalBill))
            {
                MessageBox.Show("Invalid price format. Please check the displayed price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var _context = new BusManageContext())
            {
                try
                {
                    // Update booking statuses
                    foreach (string seat in selectedSeats)
                    {
                        if (int.TryParse(seat, out int seatNumber))
                        {
                            var booking = _context.BookedTickets
                                .FirstOrDefault(b => b.TicketID == ticketId && b.SeatNumber == seatNumber);

                            if (booking != null)
                            {
                                booking.Status = "Đã xác nhận";
                                BookingId = booking.BookingID;
                            }
                            else
                            {
                                MessageBox.Show($"Seat {seatNumber} not found for ticket ID {ticketId}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Invalid seat number: {seat}.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // Validate that the ticket ID exists in the database
                    var ticketExists = _context.BookedTickets.Any(b => b.TicketID == ticketId);
                    if (!ticketExists)
                    {
                        MessageBox.Show("Invalid ticket ID. Order creation failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Create a new order
                    var newOrder = new Order
                    {
                        UserID = UserSession.UserId,
                        PaymentMethod = AddTicketInfo.PayMethod,
                        DateCreated = DateTime.Now,
                        TotalBill = totalBill,
                        NumberOfTickets = selectedSeats.Count
                    };

                    _context.Orders.Add(newOrder);

                    // Save changes to the database
                    _context.SaveChanges();

                    MessageBox.Show("Booking completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    string errorMessage = $"An error occurred while completing the booking: {ex.Message}";
                    if (ex.InnerException != null)
                    {
                        errorMessage += $"\nInner Exception: {ex.InnerException.Message}";
                        if (ex.InnerException.InnerException != null)
                        {
                            errorMessage += $"\nDeeper Exception: {ex.InnerException.InnerException.Message}";
                        }
                    }

                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Clear selected seats after successful booking
            TicketHelper.SelectedSeats.Clear();

            // Navigate to the DoneTicket page
            DoneTicket doneTicket = new DoneTicket();
            var mainPage = this.FindForm() as MainForm;
            mainPage.flowLayoutPanel.Controls.Clear();
            mainPage.flowLayoutPanel.Controls.Add(doneTicket);
        }





    }
}