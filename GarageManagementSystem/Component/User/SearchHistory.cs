using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarageManagementSystem.Component
{
    public partial class SearchHistory : UserControl
    {
        public SearchHistory(string from, string to)
        {
            InitializeComponent();
            lbFrom.Text = from;
            lbTo.Text = to;

        }
    }
}
