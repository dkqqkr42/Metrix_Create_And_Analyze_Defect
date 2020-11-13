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
    public partial class Defect : MetroForm
    {
        Main main;
        public Defect()
        {
            InitializeComponent();
        }
        public Defect(Main mainForm)
        {
            InitializeComponent();
            main = mainForm;
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Child8 child8 = new Child8();
            child8.Show();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void tile_WorkPlan_Click(object sender, EventArgs e)
        {
            main.CallWorkPlan();
        }

        private void tile_Working_Click(object sender, EventArgs e)
        {
            main.CallWorking();
        }

        private void tile_Inspection_Click(object sender, EventArgs e)
        {
            main.CalIInspection();
        }
    }
}
