using GarageManagementSystem.FormUser.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using PdfSharp.Drawing;
using System.IO;
namespace GarageManagementSystem.Component
{
    public partial class PhysicalTicket : UserControl
    {
        private string DepartTime1;
        public PhysicalTicket(int bookedTicketId, int seatNumber, string TookPlace = "",string BusStopBegin="",string BusStopLast="" ,string DepartTime ="", string Address="",string Fare="")
        {
            InitializeComponent();

            if (TookPlace == "")
            {
                lbFromToStop.Text = AddTicketInfo.FromToStop;
                DateTime departDateTime = DateTime.Parse(AddTicketInfo.departTimeStop);
                lbDepartTimeStop.Text = departDateTime.ToString("yyyy-MM-dd HH:mm");
                lbSeatNumber.Text = seatNumber.ToString();
                lbFromStop.Text = AddTicketInfo.FromStop;
                lbAddress.Text = AddTicketInfo.stopAddress;

                lbTotalFare.Text = $"{TicketHelper.PricePerTicket:N0} đ";

                lbTicketId.Text = $"Mã vé {bookedTicketId}";
            }
            else
            {
                lbFromToStop.Text = $"{BusStopBegin} - {BusStopLast}";
                DateTime departDateTime = DateTime.Parse(DepartTime);
                lbDepartTimeStop.Text = departDateTime.ToString("yyyy-MM-dd HH:mm");

                lbFromStop.Text = TookPlace;
                lbAddress.Text = Address;

                lbTotalFare.Text = $"{Fare:N0}đ";
            }
            lbSeatNumber.Text = seatNumber.ToString();
            lbTicketId.Text = $"Mã vé {bookedTicketId}";
            DepartTime1 = DepartTime;
        }

        private void PhysicalTicket_Load(object sender, EventArgs e)
        {
            if (DateTime.TryParse(DepartTime1, out DateTime departTime))
            {
                if (departTime < DateTime.Now)
                {
                    pbTimeError.Visible = true;
                }
            }
                try
            {
                // Attempt to parse DepartTime1 into a DateTime

                // Generate QR code if ticket is valid
                string qrCodeData = $"TicketID: {lbTicketId.Text}";
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeDataObject = qrGenerator.CreateQrCode(qrCodeData, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeDataObject);

                Bitmap qrCodeImage = qrCode.GetGraphic(5);
                pBQrCode.Image = qrCodeImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void pbDownload_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new PDF document
                PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
                document.Info.Title = "Physical Ticket";

                // Add a new page
                PdfSharp.Pdf.PdfPage page = document.AddPage();
                page.Width = XUnit.FromMillimeter(85); // Width for 310px equivalent in mm
                page.Height = XUnit.FromMillimeter(150); // Height for 545px equivalent in mm

                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Define fonts
                XFont titleFont = new XFont("Verdana", 12);
                XFont regularFont = new XFont("Verdana", 10);
                XBrush brush = XBrushes.Black;

                // Set positions
                double qrCodeWidth = XUnit.FromMillimeter(50); // 202px equivalent in mm
                double qrCodeHeight = XUnit.FromMillimeter(47); // 190px equivalent in mm
                double qrCodeX = (page.Width - qrCodeWidth) / 2;
                double qrCodeY = XUnit.FromMillimeter(10); // Position from top

                double textX = XUnit.FromMillimeter(10);
                double textY = qrCodeY + qrCodeHeight + XUnit.FromMillimeter(5);
                double lineHeight = XUnit.FromMillimeter(6);

                // Draw ticket ID above QR code
                gfx.DrawString(lbTicketId.Text, titleFont, brush, qrCodeX + (qrCodeWidth / 2), qrCodeY - 15, XStringFormats.Center);

                // Generate QR code
                string qrCodeData = $"TicketID: {lbTicketId.Text} © 2025 DINH QUOC BAO. All rights reserved.";
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeDataObject = qrGenerator.CreateQrCode(qrCodeData, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeDataObject);
                Bitmap qrCodeImage = qrCode.GetGraphic(5);

                // Save QR code as temporary image and draw it on the PDF
                using (MemoryStream stream = new MemoryStream())
                {
                    qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    stream.Position = 0;
                    XImage qrImage = XImage.FromStream(stream);
                    gfx.DrawImage(qrImage, qrCodeX, qrCodeY, qrCodeWidth, qrCodeHeight);
                }

                // Draw information below the QR code
                gfx.DrawString($"From - To: {lbFromToStop.Text}", regularFont, brush, textX, textY);
                textY += lineHeight;
                gfx.DrawString($"Departure Time: {lbDepartTimeStop.Text}", regularFont, brush, textX, textY);
                textY += lineHeight;
                gfx.DrawString($"Seat Number: {lbSeatNumber.Text}", regularFont, brush, textX, textY);
                textY += lineHeight;
                gfx.DrawString($"Pickup Stop: {lbFromStop.Text}", regularFont, brush, textX, textY);
                textY += lineHeight;
                gfx.DrawString($"Address: {lbAddress.Text}", regularFont, brush, textX, textY);
                textY += lineHeight;
                gfx.DrawString($"Total Fare: {lbTotalFare.Text}", regularFont, brush, textX, textY);

                // Save PDF to desktop
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PhysicalTicket.pdf");
                document.Save(filePath);

                // Notify the user and open the PDF
                MessageBox.Show($"PDF saved to {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
