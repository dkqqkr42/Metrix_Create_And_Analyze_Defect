using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_Profile
{
    public partial class Working2 : MetroForm
    {
        public Working2()
        {
            InitializeComponent();
        }

        private void btn_InspectionStart_MouseUp(object sender, MouseEventArgs e)
        {
            btn_InspectionStart.BackgroundImage = FinalProject_Profile.Properties.Resources.검사시작;
        }

        private void btn_InspectionStart_MouseDown(object sender, MouseEventArgs e)
        {
            btn_InspectionStart.BackgroundImage = FinalProject_Profile.Properties.Resources.검사시작클릭;
        }
    }
}
