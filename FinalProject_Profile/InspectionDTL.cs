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
using Oracle.ManagedDataAccess.Client;

namespace FinalProject_Profile
{
    public partial class InspectionDTL : MetroForm
    {
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";
        List<string> list = new List<string>();
        Main main;

        public InspectionDTL()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams     // 폼 화면 빠른 로딩
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }


        public void FillGrid()  // grd_Result에 값 채우기
        {
            string ct2;
            OracleConnection connection = null;
            try
            {
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = ""
                };



                cmd.Parameters.Add("IN_DATE", dtp_DATE.Value.ToString("yyyyMMdd"));

                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                grd_Result.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }



        private void metroButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grd_Result_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
            grd_Result.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
            {
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
            else
            {
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
            }
        }

        private void InspectionDTL_Load(object sender, EventArgs e)  // InspectionDTL 폼이 켜질 때
        {
            FillGrid();
        }

        private void InspectionDTL_Activated(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
