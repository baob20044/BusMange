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
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
using GarageManagementSystem.FormUser.Pages;
using System.Data.Entity;
using System.Net.Sockets;
namespace GarageManagementSystem.Component
{
    public partial class TicketScheduleList : UserControl
    {
        List<BusStop> BusStops = new List<BusStop>();
        BusManageContext _context = new BusManageContext();
        public TicketScheduleList(List<BusStop> busStops = null)
        {
            InitializeComponent();
            BusStops = busStops;
            _context = new BusManageContext();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void TicketScheduleList_Load(object sender, EventArgs e)
        {
            using (var _context = new BusManageContext())
            {
                // Assuming TicketInformation.departTime is a string and needs to be parsed into DateTime
                DateTime departTime;
                if (!DateTime.TryParse(TicketInfomation.departTime, out departTime))
                {
                    MessageBox.Show("Invalid departure time format.");
                    return;
                }

                foreach (var busStop in BusStops)
                {
                    // Fetch the corresponding ScheduleStop for the current bus stop
                    var scheduleStop = _context.ScheduleStops
                        .Where(ss => ss.StopID == busStop.StopID) // Filter by StopID
                        .Where(ss => DbFunctions.TruncateTime(ss.ArrivalTime) == departTime.Date) // Use DbFunctions.TruncateTime to remove the time component
                        .OrderBy(ss => ss.ArrivalTime) // Ensure the earliest ArrivalTime is selected
                        .FirstOrDefault(); // Get the first matching schedule stop

                    string departTimeStr = scheduleStop != null
                        ? scheduleStop.ArrivalTime.ToString("HH:mm") // Format the ArrivalTime
                        : "N/A"; // Default to "N/A" if no matching ScheduleStop is found

                    // Create a new TicketSchedule for each BusStop
                    TicketSchedule ticketSchedule = new TicketSchedule(
                        departTime: departTimeStr,        // Use the fetched or default departure time
                        busStopName: busStop.StopName,    // Pass the bus stop name
                        busStopAddress: busStop.StopAddress // Pass the bus stop address
                    );

                    flowLayoutPanel.Controls.Add(ticketSchedule); // Add the ticketSchedule to the flow layout panel
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Parse the departure time
            DateTime departTime;
            if (!DateTime.TryParse(TicketInfomation.departTime, out departTime))
            {
                MessageBox.Show("Invalid departure time format.");
                return;
            }

            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Ticket Schedule List";

            // Create a new page
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Verdana", 10);

            // Set up position for writing on the page
            double x = 40;
            double y = 40;
            double lineHeight = 20;

            using (var _context = new BusManageContext())
            {
                foreach (var busStop in BusStops)
                {
                    // Fetch the corresponding ScheduleStop for the current bus stop
                    var scheduleStop = _context.ScheduleStops
                        .Where(ss => ss.StopID == busStop.StopID) // Filter by StopID
                        .Where(ss => DbFunctions.TruncateTime(ss.ArrivalTime) == departTime.Date) // Match departure date
                        .OrderBy(ss => ss.ArrivalTime) // Ensure the earliest ArrivalTime is selected
                        .FirstOrDefault(); // Get the first matching schedule stop

                    // Use the fetched arrival time or fallback to "N/A"
                    string arrivalTime = scheduleStop != null
                        ? scheduleStop.ArrivalTime.ToString("HH:mm") // Format as HH:mm
                        : "N/A";

                    // Write the bus stop information to the PDF
                    string text = $"{busStop.StopName} - {busStop.StopAddress} - Arrival: {arrivalTime}";
                    gfx.DrawString(text, font, XBrushes.Black, x, y);
                    y += lineHeight;

                    // Check if the page height limit is reached
                    if (y > page.Height - 40)
                    {
                        // Add a new page and reset position
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        y = 40;
                    }
                }
            }

            // Save the PDF to a file
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TicketScheduleList.pdf");
            document.Save(filePath);

            // Notify the user that the PDF was generated
            MessageBox.Show($"PDF saved to {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
