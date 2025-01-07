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
    public partial class DoneTicket : UserControl
    {
        private BusManageContext _context;
        public DoneTicket()
        {
            InitializeComponent();
        }

        private void DoneTicket_Load(object sender, EventArgs e)
        {
            lbFullName.Text = UserSession.FullName;
            lbPhoneNumber.Text = UserSession.PhoneNumber;
            lbEmail.Text = UserSession.Email;

            lbTotalMoney.Text = TicketHelper.Price.ToString() + "đ";
            lbPayMethod.Text = AddTicketInfo.PayMethod;

            lbSendToEmail.Text = $"FUTA Bus Lines đã gửi thông tin vé đặt về địa chỉ email {UserSession.Email}. Vui lòng kiểm tra lại.";
            foreach (int bookedTicket in AddTicketInfo.bookedTicketIds)
            {
                using (var _context = new BusManageContext())
                {
                    int seatNumber = _context.BookedTickets
                        .Where(s => s.BookingID == bookedTicket)
                        .Select(s => s.SeatNumber)
                        .FirstOrDefault();
                    PhysicalTicket physicalTicket = new PhysicalTicket(bookedTicket, seatNumber);
                    flowLayoutPanel.Controls.Add(physicalTicket);
                }
            }
            AddTicketInfo.bookedTicketIds.Clear();
        }
    }
}
