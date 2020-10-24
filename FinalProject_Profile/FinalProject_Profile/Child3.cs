using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace FinalProject_Profile
{
    public partial class Child3 : MetroForm
    {
        public Child3()
        {
            InitializeComponent();
            for (int i = 0; i < 30; i++)
            {
                // metroGrid1.Rows.Add("1", "1234", "2020/09/20", "2020/09/20", "내수", "11", "M", "1000", "생산가능");
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
