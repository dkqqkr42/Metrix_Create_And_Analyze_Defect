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
        private Working mChildForm4 = null;
        private Inspection mChildForm5 = null;
        private Defect mChildForm7 = null;
        private Child9 mChildForm9 = null;
        private StartingMenu mchildForm10 = null;

        public Main()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }


        private Form ShowOrActiveForm(Form form, Type t)
        {
            if (form == null)
            {
                //todo 파라미터 넘겨서 해보기
                form = (Form)Activator.CreateInstance(t, this);
                form.MdiParent = this;
                form.StartPosition = FormStartPosition.CenterParent;
                //form.WindowState = FormWindowState.Minimized;
                form.Dock = DockStyle.Fill;
                form.Show();
                //form.WindowState = FormWindowState.Maximized;
                //form.WindowState = FormWindowState.Normal;
            }
            else
            {
                if (form.IsDisposed)
                {
                    form = (Form)Activator.CreateInstance(t, this);
                    form.MdiParent = this;
                    form.StartPosition = FormStartPosition.CenterParent;
                    //form.WindowState = FormWindowState.Minimized;
                    form.Dock = DockStyle.Fill;
                    form.Show();
                    //form.WindowState = FormWindowState.Maximized;
                    //form.WindowState = FormWindowState.Normal;
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
            CallWorkPlan();
        }

        public void CallWorkPlan()
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
            CallSAPOrder();
        }

        public void CallSAPOrder()
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

        private void form4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CallWorking();
        }

        public void CallWorking()
        {
            if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != mChildForm4)  // 열려있는 자식폼이 Form3 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                mChildForm4 = ShowOrActiveForm(mChildForm4, typeof(Working)) as Working;
            }
            else
            {
                mChildForm4 = ShowOrActiveForm(mChildForm4, typeof(Working)) as Working;
            }
        }

        private void form5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CallInspection();
        }

        public void CallInspection()
        {
            if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != mChildForm5)  // 열려있는 자식폼이 Form3 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                mChildForm5 = ShowOrActiveForm(mChildForm5, typeof(Inspection)) as Inspection;
            }
            else
            {
                mChildForm5 = ShowOrActiveForm(mChildForm5, typeof(Inspection)) as Inspection;
            }
        }

        private void form7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CallDefect();
        }

        public void CallDefect()
        {
            if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != mChildForm7)  // 열려있는 자식폼이 Form3 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                mChildForm7 = ShowOrActiveForm(mChildForm7, typeof(Defect)) as Defect;
            }
            else
            {
                mChildForm7 = ShowOrActiveForm(mChildForm7, typeof(Defect)) as Defect;
            }
        }

        private void form9ToolStripMenuItem_Click(object sender, EventArgs e)
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

        public void CallStartingMenu()
        {
            if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != mchildForm10)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                mchildForm10 = ShowOrActiveForm(mchildForm10, typeof(StartingMenu)) as StartingMenu;
            }
            else
            {
                mchildForm10 = ShowOrActiveForm(mchildForm10, typeof(StartingMenu)) as StartingMenu;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //CallSAPOrder();
            CallStartingMenu();
        }
    }
}
