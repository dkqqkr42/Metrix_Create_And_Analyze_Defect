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

namespace FinalProject_Profile.PopupForm
{
    public partial class InputPopup_SAPOrder : MetroForm
    {
        public InputPopup_SAPOrder()
        {
            InitializeComponent();
        }

        private void btn_Save_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Save.BackgroundImage = FinalProject_Profile.Properties.Resources.저장;
        }

        private void btn_Save_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Save.BackgroundImage = FinalProject_Profile.Properties.Resources.저장클릭;
        }

        private void btn_Close_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Close.BackgroundImage = FinalProject_Profile.Properties.Resources.닫기;
        }

        private void btn_Close_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Close.BackgroundImage = FinalProject_Profile.Properties.Resources.닫기클릭;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
