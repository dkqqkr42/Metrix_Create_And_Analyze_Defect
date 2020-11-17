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

namespace Upsert
{
    public partial class Parent : MetroForm
    {
        private ProgramManage programManage = null;
        private ProductMaster productMaster = null;
        private Employee employee = null;
        private WorkCenter workCenter = null;
        private Worker worker = null;
        private DownTime downTime = null;
        private Defect defect = null;
        private Inspector inspector = null;
        private DEPT dept = null;
        private Team team = null;
        private COMMONCODE commonCode = null;
        private DownTimeDTL downTimeDTL = null;
        private DefectDTL defectDTL = null;
        private Slocation slocation = null;
        private Plant plant = null;

        public Parent()
        {
            InitializeComponent();
        }

        private Form ShowOrActiveForm(Form form, Type t)
        {
            if (form == null)
            {
                form = (Form)Activator.CreateInstance(t);
                form.MdiParent = this;
                form.StartPosition = FormStartPosition.CenterParent;
                //form.WindowState = FormWindowState.Minimized;
                form.Dock = DockStyle.Fill;
                //form.WindowState = FormWindowState.Maximized;
                form.Show();
                //form.WindowState = FormWindowState.Normal;
            }
            else
            {
                if (form.IsDisposed)
                {
                    form = (Form)Activator.CreateInstance(t);
                    form.MdiParent = this;
                    form.StartPosition = FormStartPosition.CenterParent;
                    //form.WindowState = FormWindowState.Minimized;
                    form.Dock = DockStyle.Fill;
                    //form.WindowState = FormWindowState.Maximized;
                    form.Show();
                    //form.WindowState = FormWindowState.Normal;
                }
                else
                {
                    form.Activate();
                }
            }
            lbl_MessageText.Text = "폼이 로드되었습니다.";
            return form;
        }

        private void Parent_Load(object sender, EventArgs e)
        {

        }

        private void SelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IChildForm child = ActiveMdiChild as IChildForm;
            if (child == null) return;

            Cursor.Current = Cursors.WaitCursor;

            /*            
            switch (command)
            {
                case "New": child.New(); break;
                case "Save": child.Save(); break;
                case "Search": child.Search(); break;
                case "Delete": child.Delete(); break;
                default: break;
            }
            */

            child.SelectItem();

            Cursor.Current = Cursors.Default;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IChildForm child = ActiveMdiChild as IChildForm;
            if (child == null) return;

            Cursor.Current = Cursors.WaitCursor;

            /*            
            switch (command)
            {
                case "New": child.New(); break;
                case "Save": child.Save(); break;
                case "Search": child.Search(); break;
                case "Delete": child.Delete(); break;
                default: break;
            }
            */

            child.SaveItem();

            Cursor.Current = Cursors.Default;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            IChildForm child = ActiveMdiChild as IChildForm;
            if (child == null) return;

            Cursor.Current = Cursors.WaitCursor;

            /*            
            switch (command)
            {
                case "New": child.New(); break;
                case "Save": child.Save(); break;
                case "Search": child.Search(); break;
                case "Delete": child.Delete(); break;
                default: break;
            }
            */

            int i_cnt = child.SelectItem();

            if (i_cnt > 0)
                lbl_MessageText.Text = $"{i_cnt}건의 데이터가 조회 되었습니다.";
            else
                lbl_MessageText.Text = "데이터를 조회하는데 문제가 발생하였습니다.";
            Cursor.Current = Cursors.Default;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            IChildForm child = ActiveMdiChild as IChildForm;
            if (child == null) return;

            Cursor.Current = Cursors.WaitCursor;

            /*            
            switch (command)
            {
                case "New": child.New(); break;
                case "Save": child.Save(); break;
                case "Search": child.Search(); break;
                case "Delete": child.Delete(); break;
                default: break;
            }
            */

            if (child.SaveItem())
            {
                if (child.SelectItem() > 0)
                    lbl_MessageText.Text = "데이터 저장 완료.";
                else
                    lbl_MessageText.Text = "데이터 저장은 완료됬지만 데이터를 불러오는데 문제가 발생하였습니다.";
            }

            else
            {
                lbl_MessageText.Text = "데이터 저장에 문제가 발생하였습니다.";
            }


            Cursor.Current = Cursors.Default;
        }

        private void programManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != programManage)  // 열려있는 자식폼이 Form2 이 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                programManage = ShowOrActiveForm(programManage, typeof(ProgramManage)) as ProgramManage;
                btn_Save.Enabled = true;
            }
            else
            {
                programManage = ShowOrActiveForm(programManage, typeof(ProgramManage)) as ProgramManage;
                btn_Save.Enabled = true;
            }*/
            programManage = ShowOrActiveForm(programManage, typeof(ProgramManage)) as ProgramManage;
            btn_Save.Enabled = true;
        }

        private void productMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != productMaster)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                productMaster = ShowOrActiveForm(productMaster, typeof(ProductMaster)) as ProductMaster;
                btn_Save.Enabled = false;
            }
            else
            {
                productMaster = ShowOrActiveForm(productMaster, typeof(ProductMaster)) as ProductMaster;
                btn_Save.Enabled = false;
            }*/
            productMaster = ShowOrActiveForm(productMaster, typeof(ProductMaster)) as ProductMaster;
            btn_Save.Enabled = false;

        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != employee)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                employee = ShowOrActiveForm(employee, typeof(Employee)) as Employee;
                btn_Save.Enabled = false;
            }
            else
            {
                employee = ShowOrActiveForm(employee, typeof(Employee)) as Employee;
                btn_Save.Enabled = false;
            }*/
            employee = ShowOrActiveForm(employee, typeof(Employee)) as Employee;
            btn_Save.Enabled = false;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            IChildForm child = ActiveMdiChild as IChildForm;
            if (child == null) return;

            Cursor.Current = Cursors.WaitCursor;

            if (child.DeleteItem())
            {
                lbl_MessageText.Text = "데이터 삭제 완료.";
                child.SelectItem();
            }

            else
            {
                lbl_MessageText.Text = "데이터 삭제에 문제가 발생하였습니다.";
            }
        }


        private void workerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != worker)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                worker = ShowOrActiveForm(worker, typeof(Worker)) as Worker;
                btn_Save.Enabled = false;
            }
            else
            {
                worker = ShowOrActiveForm(worker, typeof(Worker)) as Worker;
                btn_Save.Enabled = false;
            }*/
            worker = ShowOrActiveForm(worker, typeof(Worker)) as Worker;
            btn_Save.Enabled = false;
        }

        private void downTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != downTime)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                downTime = ShowOrActiveForm(downTime, typeof(DownTime)) as DownTime;
                btn_Save.Enabled = true;
            }
            else
            {
                downTime = ShowOrActiveForm(downTime, typeof(DownTime)) as DownTime;
                btn_Save.Enabled = true;
            }*/
            downTime = ShowOrActiveForm(downTime, typeof(DownTime)) as DownTime;
            btn_Save.Enabled = true;
        }

        private void workCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != workCenter)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                workCenter = ShowOrActiveForm(workCenter, typeof(WorkCenter)) as WorkCenter;
                btn_Save.Enabled = false;
            }
            else
            {
                workCenter = ShowOrActiveForm(workCenter, typeof(WorkCenter)) as WorkCenter;
                btn_Save.Enabled = false;
            }*/
            workCenter = ShowOrActiveForm(workCenter, typeof(WorkCenter)) as WorkCenter;
            btn_Save.Enabled = false;
        }

        private void defectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != defect)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                defect = ShowOrActiveForm(defect, typeof(Defect)) as Defect;
                btn_Save.Enabled = true;
            }
            else
            {
                defect = ShowOrActiveForm(defect, typeof(Defect)) as Defect;
                btn_Save.Enabled = true;
            }*/
            defect = ShowOrActiveForm(defect, typeof(Defect)) as Defect;
            btn_Save.Enabled = true;
        }

        private void inspectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != inspector)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                inspector = ShowOrActiveForm(inspector, typeof(Inspector)) as Inspector;
                btn_Save.Enabled = true;
            }
            else
            {
                inspector = ShowOrActiveForm(inspector, typeof(Inspector)) as Inspector;
                btn_Save.Enabled = true;
            }*/
            inspector = ShowOrActiveForm(inspector, typeof(Inspector)) as Inspector;
            btn_Save.Enabled = true;
        }

        private void dEPTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != dept)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                dept = ShowOrActiveForm(dept, typeof(DEPT)) as DEPT;
                btn_Save.Enabled = true;
            }
            else
            {
                dept = ShowOrActiveForm(dept, typeof(DEPT)) as DEPT;
                btn_Save.Enabled = true;
            }*/
            dept = ShowOrActiveForm(dept, typeof(DEPT)) as DEPT;
            btn_Save.Enabled = true;
        }

        private void teamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != team)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                team = ShowOrActiveForm(team, typeof(Team)) as Team;
                btn_Save.Enabled = true;
            }
            else
            {
                team = ShowOrActiveForm(team, typeof(Team)) as Team;
                btn_Save.Enabled = true;
            }*/
            team = ShowOrActiveForm(team, typeof(Team)) as Team;
            btn_Save.Enabled = true;
        }

        private void commonCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != team)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                commonCode = ShowOrActiveForm(commonCode, typeof(COMMONCODE)) as COMMONCODE;
                btn_Save.Enabled = true;
            }
            else
            {
                commonCode = ShowOrActiveForm(commonCode, typeof(COMMONCODE)) as COMMONCODE;
                btn_Save.Enabled = true;
            }*/
            commonCode = ShowOrActiveForm(commonCode, typeof(COMMONCODE)) as COMMONCODE;
            btn_Save.Enabled = true;
        }

        private void dowinTimeDTLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != downTimeDTL)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                downTimeDTL = ShowOrActiveForm(downTimeDTL, typeof(DownTimeDTL)) as DownTimeDTL;
                btn_Save.Enabled = true;
            }
            else
            {
                downTimeDTL = ShowOrActiveForm(downTimeDTL, typeof(DownTimeDTL)) as DownTimeDTL;
                btn_Save.Enabled = true;
            }*/
            downTimeDTL = ShowOrActiveForm(downTimeDTL, typeof(DownTimeDTL)) as DownTimeDTL;
            btn_Save.Enabled = true;
        }

        private void defectDTLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != defectDTL)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                defectDTL = ShowOrActiveForm(defectDTL, typeof(DefectDTL)) as DefectDTL;
                btn_Save.Enabled = true;
            }
            else
            {
                defectDTL = ShowOrActiveForm(defectDTL, typeof(DefectDTL)) as DefectDTL;
                btn_Save.Enabled = true;
            }*/
            defectDTL = ShowOrActiveForm(defectDTL, typeof(DefectDTL)) as DefectDTL;
            btn_Save.Enabled = true;
        }

        private void slocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != slocation)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                slocation = ShowOrActiveForm(slocation, typeof(Slocation)) as Slocation;
                btn_Save.Enabled = true;
            }
            else
            {
                slocation = ShowOrActiveForm(slocation, typeof(Slocation)) as Slocation;
                btn_Save.Enabled = true;
            }*/
            slocation = ShowOrActiveForm(slocation, typeof(Slocation)) as Slocation;
            btn_Save.Enabled = true;
        }

        private void plantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*if (ActiveMdiChild != null)  // 자식폼이 열려 있으면
            {
                if (this.ActiveMdiChild != plant)  // 열려있는 자식폼이 Form2 가 아니면
                {
                    ActiveMdiChild.Close(); // 현재 활성화된 창을 닫아라
                }
                plant = ShowOrActiveForm(plant, typeof(Plant)) as Plant;
                btn_Save.Enabled = true;
            }
            else
            {
                plant = ShowOrActiveForm(plant, typeof(Plant)) as Plant;
                btn_Save.Enabled = true;
            }*/
            plant = ShowOrActiveForm(plant, typeof(Plant)) as Plant;
            btn_Save.Enabled = true;
        }
        private void btn_Delete_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Delete.BackgroundImage = Upsert.Properties.Resources.삭제;
        }

        private void btn_Delete_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Delete.BackgroundImage = Upsert.Properties.Resources.삭제클릭;
        }


        private void btn_Save_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Save.BackgroundImage = Upsert.Properties.Resources.저장;
        }

        private void btn_Save_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Save.BackgroundImage = Upsert.Properties.Resources.저장클릭;
        }

        private void btn_Select_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Select.BackgroundImage = Upsert.Properties.Resources.조회;
        }

        private void btn_Select_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Select.BackgroundImage = Upsert.Properties.Resources.조회클릭;
        }
    }
}
