using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;

namespace FinalProject_Profile
{
    public partial class Child2 : MetroForm
    {
        public Child2()
        {
            InitializeComponent();

            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            for (int i = 0; i < 10; i++)
            {
                metroGrid1.Rows.Add("1", "1234", "2020/09/20", "2020/09/20", "내수", "11", "M", "1000", "생산가능");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroTabControl1.ItemSize = new Size(metroTabControl1.Width / metroTabControl1.TabCount-2, 0);
        }
    }
}
