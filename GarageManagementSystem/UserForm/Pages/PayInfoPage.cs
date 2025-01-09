using GarageManagementSystem.Component;
using GarageManagementSystem.Model;
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

namespace GarageManagementSystem.FormUser.Pages
{
    public partial class PayInfoPage : UserControl
    {
        private BusManageContext _context;
        public PayInfoPage()
        {
            InitializeComponent();
        }

        private void PayInfoPage_Load(object sender, EventArgs e)
        {
            txtFullName.Text = UserSession.FullName;
            txtPhoneNumber.Text = UserSession.PhoneNumber;
            txtEmail.Text = UserSession.Email;

            lbFromTo.Text = $"{TicketInfomation.departPlace} - {TicketInfomation.arrivalPlace}";

            // Format departTime to DD/MM/YYYY
            if (DateTime.TryParse(TicketInfomation.departTime, out DateTime formattedDepartTime))
            {
                lbDate.Text = formattedDepartTime.ToString("dd/MM/yyyy");
            }

            lbTotalMoney.Text = $"{TicketHelper.Price:N0} đ";
            lbPrice.Text = $"{TicketHelper.Price:N0} đ";
            lbTotalGo.Text = $"{TicketHelper.Price:N0} đ";
            lbTotalFare.Text = $"{TicketHelper.Price:N0} đ";

            lbSeatList.Text = TicketHelper.SeatList;
            lbSeatCount.Text = TicketHelper.SeatCount.ToString() + " chỗ";

            using (_context = new BusManageContext())
            {
                var RouteId = _context.Tickets.Where(s => s.TicketID == TicketHelper.ticketId).FirstOrDefault()?.RouteID;
                string dateToSchedule = StopBySchedule.date;
                if (DateTime.TryParse(dateToSchedule, out DateTime scheduleDate))
                {
                    var scheduleId = _context.Schedules
                        .Where(s => s.RouteID == RouteId && s.Date == scheduleDate)
                        .Select(s => s.ScheduleID)
                        .FirstOrDefault();
                    StopBySchedule.scheduleid = scheduleId;
                }

                var scheduleStops = _context.ScheduleStops
                    .Where(ss => ss.ScheduleID == StopBySchedule.scheduleid)
                    .Join(
                        _context.BusStops,
                        ss => ss.StopID,
                        bs => bs.StopID,
                        (ss, bs) => new { ss, bs }
                    )
                    .OrderBy(joined => joined.ss.ArrivalTime) // Order by ArrivalTime
                    .ToList();

                int lastIndex = scheduleStops.Count - 1;
                int currentIndex = 0;
                string FromStop = "";
                string ToStop = "";
                string departTimeFromStop1 = null;

                foreach (var stop in scheduleStops)
                {
                    if (currentIndex == 0)
                    {
                        FromStop = stop.bs.StopName; // Take StopName from BusStops
                        departTimeFromStop1 = stop.ss.ArrivalTime.ToString("dd/MM/yyyy HH:mm"); // Format ArrivalTime to DD/MM/YYYY
                    }

                    if (currentIndex != lastIndex)
                    {
                        cbPickSite.Items.Add(stop.bs.StopName);
                    }
                    currentIndex++;
                }

                var lastStop = scheduleStops.LastOrDefault();
                if (lastStop != null)
                {
                    ToStop = lastStop.bs.StopName;
                    cbToSite.Items.Add(ToStop);
                    cbToSite.SelectedItem = ToStop;
                }

                AddTicketInfo.arrivalStop = FromStop;
                lbFromToStop.Text = $"{FromStop} đến {ToStop}";
                AddTicketInfo.FromToStop = lbFromToStop.Text;
                lbToPlace.Text = ToStop;
                AddTicketInfo.ToPlace = lbToPlace.Text;

                // Format departTimeFromStop1 to DD/MM/YYYY
                lbDateGo.Text = departTimeFromStop1;
                AddTicketInfo.DateGo = lbDateGo.Text;
            }
        }

        private void cbPickSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (_context = new BusManageContext())
            {
                // Retrieve the selected stop name
                string selectedStopName = cbPickSite.SelectedItem.ToString();

                // Fetch the StopID from BusStops table for the selected StopName
                var stopId = _context.BusStops
                    .Where(bs => bs.StopName == selectedStopName)
                    .Select(bs => bs.StopID)
                    .FirstOrDefault(); // Get the StopID for the selected StopName

                if (stopId != 0) // Ensure we got a valid StopID
                {
                    // Fetch the DepartureTime from the Tickets table based on the selected TicketID
                    var departureTime = _context.Tickets
                        .Where(t => t.TicketID == TicketHelper.ticketId) // Filter by TicketID
                        .Join(
                            _context.Schedules,  // Join with Schedules table
                            ticket => ticket.ScheduleID,  // Use ScheduleID from Tickets table
                            schedule => schedule.ScheduleID,  // Match with ScheduleID in Schedules table
                            (ticket, schedule) => new { ticket, schedule }  // Project ticket and its associated schedule
                        )
                        .Select(ts => ts.schedule.Date)  // Select DepartureTime from the Schedules table
                        .FirstOrDefault();  // Get the first result (or null if not found)


                    if (departureTime != null)
                    {
                        // Fetch the corresponding ScheduleStop using the StopID and ensure it matches the date of the departureTime
                        var scheduleStop = _context.ScheduleStops
                            .Where(ss => ss.StopID == stopId &&
                                         DbFunctions.TruncateTime(ss.ArrivalTime) == DbFunctions.TruncateTime(departureTime))
                            .Join(_context.BusStops, ss => ss.StopID, bs => bs.StopID, (ss, bs) => new { ss.ArrivalTime, bs.StopAddress })
                            .FirstOrDefault(); // Get the first matching schedule stop for the same day

                        if (scheduleStop != null)
                        {
                            // Create a new DateTime by combining the date from departureTime and the TimeSpan from scheduleStop.ArrivalTime
                            var adjustedArrivalTime = new DateTime(
                                departureTime.Year,
                                departureTime.Month,
                                departureTime.Day,
                                scheduleStop.ArrivalTime.Hour,
                                scheduleStop.ArrivalTime.Minute,
                                scheduleStop.ArrivalTime.Second
                            );

                            // Assign the ArrivalTime from ScheduleStops and StopAddress to AddTicketInfo
                            AddTicketInfo.stopAddress = scheduleStop.StopAddress;

                            // Update lbBookInfo with the selected stop and the adjusted arrival time in DD/MM/YYYY HH:mm format
                            lbBookInfo.Text = $"{selectedStopName} trước {adjustedArrivalTime.ToString("dd/MM/yyyy HH:mm")}";

                            // Set AddTicketInfo.departTimeStop to the adjusted ArrivalTime formatted as DD/MM/YYYY HH:mm
                            AddTicketInfo.departTimeStop = adjustedArrivalTime.ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            // If no schedule stop is found for the same day, show an error message
                            MessageBox.Show("Không tìm thấy điểm dừng trong lịch trình cho ngày này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // If no departure time is found, show an error message
                        MessageBox.Show("Không tìm thấy giờ khởi hành trong vé này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // If StopID is not found, show an error message
                    MessageBox.Show("Không tìm thấy điểm dừng với tên này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }







        private void lbEditName_CheckedChanged(object sender, EventArgs e)
        {
            txtFullName.Text = "";
            txtFullName.Enabled = true;
            lbEditName.Visible = false;
        }

        private void lbEditPhoneNumber_CheckedChanged(object sender, EventArgs e)
        {
            txtPhoneNumber.Text = "";
            txtPhoneNumber.Enabled = true;
            lbEditPhoneNumber.Visible = false;
        }

        private void lbEditEmail_CheckedChanged(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtEmail.Enabled = true;
            lbEditEmail.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            var mainPage = this.FindForm() as MainForm;
            mainPage.flowLayoutPanel.Controls.Clear();
            mainPage.flowLayoutPanel.Controls.Add(homePage);
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            // Check if all fields are filled
            if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Validate email format
            if (!IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại.");
                return;
            }

            // Validate phone number format (assuming the valid phone number is a 10-digit number)
            if (!IsValidPhoneNumber(txtPhoneNumber.Text.Trim()))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại.");
                return;
            }

            // Check if terms and conditions are accepted
            if (!cbAcceptTerm.Checked)
            {
                MessageBox.Show("Vui lòng chấp nhận điều khoản của FUTA Bus Lines trước khi đặt vé.");
                return;
            }

            // Check if pick-up site is selected
            if (cbPickSite.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn điểm đón.");
                return;
            }

            // Save session information
            UserSession.FullName = txtFullName.Text;
            UserSession.PhoneNumber = txtPhoneNumber.Text;
            UserSession.Email = txtEmail.Text;

            // Continue with booking process
            AddTicketInfo.FromStop = cbPickSite.SelectedItem.ToString();
            int ticketId = TicketHelper.ticketId;
            int userId = UserSession.UserId;
            DateTime bookingDate = DateTime.Now;
            string status = "Đang chờ";
            string tookPlace = cbPickSite.SelectedItem.ToString();

            string customerName, customerPhone, customerEmail;
            customerName = UserSession.FullName;
            customerPhone = UserSession.PhoneNumber;
            customerEmail = UserSession.Email;

            List<string> selectedSeats = TicketHelper.SelectedSeats;
            if (AddTicketInfo.bookedTicketIds == null)
            {
                AddTicketInfo.bookedTicketIds = new List<int>();
            }

            foreach (string seat in selectedSeats)
            {
                using (var _context = new BusManageContext())
                {
                    var newBooking = new BookedTicket
                    {
                        TicketID = ticketId,
                        UserID = userId,
                        SeatNumber = int.Parse(seat),
                        BookingDate = bookingDate,
                        Status = status,
                        TookPlace = tookPlace,
                        CustomerName = customerName,
                        CustomerPhone = customerPhone,
                        CustomerEmail = customerEmail
                    };

                    _context.BookedTickets.Add(newBooking);
                    _context.SaveChanges();
                    AddTicketInfo.bookedTicketIds.Add(newBooking.BookingID);
                }
            }

            // Navigate to payment check page
            PayCheckPage payCheckPage = new PayCheckPage();
            var mainPage = this.FindForm() as MainForm;
            mainPage.flowLayoutPanel.Controls.Clear();
            mainPage.flowLayoutPanel.Controls.Add(payCheckPage);
        }

        // Helper function to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new System.Net.Mail.MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Helper function to validate phone number format
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Adjust the pattern to your required phone number format
            var phoneNumberRegex = new System.Text.RegularExpressions.Regex(@"^\d{10}$");
            return phoneNumberRegex.IsMatch(phoneNumber);
        }
    }
    public static class AddTicketInfo
    {
        public static string arrivalStop { get; set; }
        public static string departTimeStop { get; set; }
        public static string FromToStop { get; set; }
        public static string ToPlace { get; set; }
        public static string DateGo { get; set; }
        public static string FromStop { get; set; }
        public static string stopAddress { get; set; }
        public static List<int> bookedTicketIds { get; set; }
        public static string PayMethod { get; set; }
    }
}
