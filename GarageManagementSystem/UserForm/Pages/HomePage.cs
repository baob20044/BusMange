using GarageManagementSystem.Component;
using Guna.UI2.WinForms;
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
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
            datepickerDepart.Value = DateTime.Now;
            datepickerReturn.Value = DateTime.Now;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void btnFindBus_Click(object sender, EventArgs e)
        {
            if (cBFrom.SelectedItem == null || cBTo.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn cả điểm đón và điểm đi");
                return;
            }
            if (rbTwoway.Checked && datepickerDepart.Value > datepickerReturn.Value)
            {
                MessageBox.Show("Ngày đi không thể muộn hơn ngày về.");
                return;
            }

            string fromPlace = cBFrom.SelectedItem.ToString();
            string toPlace = cBTo.SelectedItem.ToString();

            SearchHistory search = new SearchHistory(fromPlace, toPlace);
            flowLayoutPanel.Controls.Add(search);
            string fromPlace1 = cBFrom.SelectedItem.ToString();
            string toPlace1 = cBTo.SelectedItem.ToString();
            string departTime = datepickerDepart.Value.ToString("yyyy-MM-dd");
            string arrivalTime = rbTwoway.Checked ? datepickerReturn.Value.ToString("yyyy-MM-dd") : "";

            StopBySchedule.date = datepickerDepart.Value.ToString("yyyy-MM-dd");
            TicketList ticketList = new TicketList(fromPlace, toPlace, departTime, arrivalTime);

            var mainPage = this.FindForm() as MainForm;
            mainPage.flowLayoutPanel.Controls.Clear();
            mainPage.flowLayoutPanel.Controls.Add(ticketList);
        }

        private void rbTwoway_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTwoway.Checked) 
            {
                datepickerReturn.Enabled = true;
            }
            else
            {
                datepickerReturn.Enabled = false;
            }
        }
    }
    public static class StopBySchedule
    {
        public static int scheduleid;
        public static string date;
    }
}
