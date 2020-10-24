using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace FinalProject_Profile
{
    public partial class Child4 : MetroForm
    {
        public Child4()
        {
            InitializeComponent();
            for (int i = 0; i < 1; i++)
            {
                metroGrid1.Rows.Add("1", "1234", "2020/09/20", "2020/09/20", "내수");
            }
        }

        private void metroTabControl1_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void Child4_Load(object sender, EventArgs e)
        {
            // metroTabControl1.ItemSize = new Size(metroTabControl1.Width / metroTabControl1.TabCount-2, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
