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

    public partial class Main : MetroForm
    {
        
        private WorkPlan mChildForm1 = null;
        private SAPOrder mChildForm2 = null;
        private Child3 mChildForm3 = null;
        private Child4 mChildForm4 = null;
        private Child5 mChildForm5 = null;
        private Child7 mChildForm7 = null;
        private Child9 mChildForm9 = null;

        public Main()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroContextMenu1.Show(metroButton1, 0, metroButton1.Height);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroContextMenu2.Show(metroButton2, 0, metroButton2.Height);
        }

        private Form ShowOrActiveForm(Form form, Type t)
        {
            if (form == null)
            {
                form = (Form)Activator.CreateInstance(t);
                form.MdiParent = this;
                form.StartPosition = FormStartPosition.CenterParent;
                form.WindowState = FormWindowState.Minimized;
                form.Dock = DockStyle.Fill;
                form.Show();
                //form.WindowState = FormWindowState.Maximized;
                form.WindowState = FormWindowState.Normal;
            }
            else
            {
                if (form.IsDisposed)
                {
                    form = (Form)Activator.CreateInstance(t);
                    form.MdiParent = this;
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.WindowState = FormWindowState.Minimized;
                    form.Dock = DockStyle.Fill;
                    form.Show();
                    //form.WindowState = FormWindowState.Maximized;
                    form.WindowState = FormWindowState.Normal;
                }
                else
                {
                    form.Activate();
                }
            }
            return form;
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != mChildForm1)  // 열려있는 자식폼이 Form1 이 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                mChildForm1 = ShowOrActiveForm(mChildForm1, typeof(WorkPlan)) as WorkPlan;
            }
            else
            {
                mChildForm1 = ShowOrActiveForm(mChildForm1, typeof(WorkPlan)) as WorkPlan;
            }
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != mChildForm2)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                mChildForm2 = ShowOrActiveForm(mChildForm2, typeof(SAPOrder)) as SAPOrder;
            }
            else
            {
                mChildForm2 = ShowOrActiveForm(mChildForm2, typeof(SAPOrder)) as SAPOrder;
            }
        }

        private void form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != mChildForm3)  // 열려있는 자식폼이 Form3 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                mChildForm3 = ShowOrActiveForm(mChildForm3, typeof(Child3)) as Child3;
            }
            else
            {
                mChildForm3 = ShowOrActiveForm(mChildForm3, typeof(Child3)) as Child3;
            }
        }

        private void form4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != mChildForm4)  // 열려있는 자식폼이 Form3 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                mChildForm4 = ShowOrActiveForm(mChildForm4, typeof(Child4)) as Child4;
            }
            else
            {
                mChildForm4 = ShowOrActiveForm(mChildForm4, typeof(Child4)) as Child4;
            }
        }

        private void form5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != mChildForm5)  // 열려있는 자식폼이 Form3 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                mChildForm5 = ShowOrActiveForm(mChildForm5, typeof(Child5)) as Child5;
            }
            else
            {
                mChildForm5 = ShowOrActiveForm(mChildForm5, typeof(Child5)) as Child5;
            }
        }

        private void form7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != mChildForm7)  // 열려있는 자식폼이 Form3 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                mChildForm7 = ShowOrActiveForm(mChildForm7, typeof(Child7)) as Child7;
            }
            else
            {
                mChildForm7 = ShowOrActiveForm(mChildForm7, typeof(Child7)) as Child7;
            }
        }

        private void 공부동ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != mChildForm9)  // 열려있는 자식폼이 Form3 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                mChildForm9 = ShowOrActiveForm(mChildForm9, typeof(Child9)) as Child9;
            }
            else
            {
                mChildForm9 = ShowOrActiveForm(mChildForm9, typeof(Child9)) as Child9;
            }
        }
    }
}
