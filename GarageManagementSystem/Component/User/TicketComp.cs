using GarageManagementSystem.Model;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagementSystem.Component
{
    public partial class TicketComp : UserControl
    {
        private List<BookedTicket> BookedTickets = new List<BookedTicket>();
        private List<BusStop> BusStops = new List<BusStop>();
        private int SelectedSeats = 0;
        private int TicketId = 0;
        private decimal Fare = 0;
        private int Capacity = 0;
        private string BusType = "";
        public TicketComp(
            int ticketId = 0,
            string departHour = "",
            string estimatedHour = "",
            string busType = "",
            int seatCapacity = 0,
            decimal fare = 0,
            string busStopBegin = "",
            string busStopEnd = "",
            List<BusStop> busStops = null
        )
        {
            InitializeComponent();
            BusStops = busStops;
            TicketId = ticketId;
            Fare = fare;
            BusType = busType;
            Capacity = seatCapacity;
            // Set the values to the labels
            lbDepartTime.Text = departHour;
            lbEstimatedTime.Text = estimatedHour;
            lbBusType.Text = busType;
            lbSeatLeft.Text = $"{seatCapacity} chỗ trống";
            lbPrice.Text = $"{fare:N0}đ"; // Format as currency
            lbBusstopBegin.Text = busStopBegin;
            lbBusstopEnd.Text = busStopEnd;
            lbBusstopEnd.Location = new Point(
                lbBusstopEnd.Location.X - lbBusstopEnd.Width+30,  // Adjust by some offset to move left
                lbBusstopEnd.Location.Y
            );

            var departTime = TimeSpan.Parse(departHour); // Convert "HH:mm" to TimeSpan

            // Extract the numeric part of estimatedHour
            var estimatedHourNumber = Convert.ToInt32(estimatedHour.Replace(" giờ", "").Trim());

            // Calculate arrival time
            var arrivalTime = departTime.Add(TimeSpan.FromHours(estimatedHourNumber));

            // Convert arrivalTime to a formatted string (if needed)
            lbArrivedTime.Text = arrivalTime.ToString(@"hh\:mm");
            LoadBookedTickets(ticketId);
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
                    // Compare SeatNumber and disable the checkbox if it matches
                    if (bookedTicket.Status == "Đã xác nhận") // Extract number from "cbX"
                    {
                        SelectedSeats++;
                    }
            }
            var seatLeft = Capacity - SelectedSeats;
            lbSeatLeft.Text = seatLeft.ToString() + " chỗ trống";
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            var existing = this.Controls.OfType<TicketScheduleList>().FirstOrDefault();

            if (existing == null)
            {

                var add = new TicketScheduleList(BusStops);

                this.Parent.Parent.Controls.Add(add);
                add.Dock = DockStyle.None;

                add.Location = new Point(
                    (this.Parent.Parent.Width - add.Width) / 2,
                    (this.Parent.Parent.Height - add.Height) / 2
                );
                add.BringToFront();
            }
            else
            {
                existing.BringToFront();
            }
        }

        private void btnSeat_Click(object sender, EventArgs e)
        {
            if(BusType == "Giường")
            {
                var existing = this.Controls.OfType<SeatBed>().FirstOrDefault();

                if (existing == null)
                {
                    // Replace 123 with the actual TicketID for the current ticket
                    var ticketId = TicketId;
                    var add = new SeatBed(ticketId, Fare);

                    this.Parent.Parent.Controls.Add(add);
                    add.Dock = DockStyle.None;

                    add.Location = new Point(
                        (this.Parent.Parent.Width - add.Width) / 2,
                        (this.Parent.Parent.Height - add.Height) / 2
                    );
                    add.BringToFront();
                }
                else
                {
                    existing.BringToFront();
                }
            }else if(BusType == "Ghế")
            {
                var existing = this.Controls.OfType<SeatDefault>().FirstOrDefault();

                if (existing == null)
                {
                    var ticketId = TicketId;
                    var add = new SeatDefault(ticketId, Fare);

                    this.Parent.Parent.Controls.Add(add);
                    add.Dock = DockStyle.None;

                    add.Location = new Point(
                        (this.Parent.Parent.Width - add.Width) / 2,
                        (this.Parent.Parent.Height - add.Height) / 2
                    );
                    add.BringToFront();
                }
                else
                {
                    existing.BringToFront();
                }
            }
            else if (BusType == "Limousine")
            {
                var existing = this.Controls.OfType<SeatLimousine>().FirstOrDefault();

                if (existing == null)
                {
                    var ticketId = TicketId;
                    var add = new SeatLimousine(ticketId, Fare);

                    this.Parent.Parent.Controls.Add(add);
                    add.Dock = DockStyle.None;

                    add.Location = new Point(
                        (this.Parent.Parent.Width - add.Width) / 2,
                        (this.Parent.Parent.Height - add.Height) / 2
                    );
                    add.BringToFront();
                }
                else
                {
                    existing.BringToFront();
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
            "Vui lòng chọn vị trí ghế ngồi để tiếp tục. Chúng tôi rất hân hạnh phục vụ bạn!",
            "Thông Báo",
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation
            );
        }

        private void btnTransport_Click(object sender, EventArgs e)
        {
            var existing = this.Controls.OfType<HaflTransportNote>().FirstOrDefault();

            if (existing == null)
            {
                var add = new HaflTransportNote();

                this.Parent.Parent.Controls.Add(add);
                add.Dock = DockStyle.None;

                add.Location = new Point(
                    (this.Parent.Parent.Width - add.Width) / 2,
                    (this.Parent.Parent.Height - add.Height) / 2
                );
                add.BringToFront();
            }
            else
            {
                existing.BringToFront();
            }
        }

        private void btnTerm_Click(object sender, EventArgs e)
        {
            var existing = this.Controls.OfType<Term>().FirstOrDefault();

            if (existing == null)
            {
                var add = new Term();

                this.Parent.Parent.Controls.Add(add);
                add.Dock = DockStyle.None;

                add.Location = new Point(
                    (this.Parent.Parent.Width - add.Width) / 2,
                    (this.Parent.Parent.Height - add.Height) / 2
                );
                add.BringToFront();
            }
            else
            {
                existing.BringToFront();
            }
        }
    }
}
