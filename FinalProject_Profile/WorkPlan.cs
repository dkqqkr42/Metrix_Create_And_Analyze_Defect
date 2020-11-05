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
    public partial class WorkPlan : MetroForm
    {
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";

        public WorkPlan()
        {
            InitializeComponent();

            // this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void Form2_Load(object sender, EventArgs e)
        {        
            
        }

        private void btn_plan_Click(object sender, EventArgs e)
        {
           /* OracleConnection connection = null;
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
                    CommandText = "select , trim(factor_code), factor_name, trim(del_flag), insert_user, insert_date, update_user, update_date, trim(rsp_flag) from tbl_downtimedtl where plant_code like '%' || :SeachVal || '%' and DEL_FLAG = 'A'"
                };
                if (txt_SeachVal.Text.Equals("") && ckb_DelFlag.Checked)
                    cmd.CommandText = "select plant_code, trim(factor_code), factor_name, trim(del_flag), insert_user, insert_date, update_user, update_date, trim(rsp_flag) from tbl_downtimedtl";

                else if (txt_SeachVal.Text.Equals("") && !ckb_DelFlag.Checked)
                    cmd.CommandText = "select plant_code, trim(factor_code), factor_name, trim(del_flag), insert_user, insert_date, update_user, update_date, trim(rsp_flag) from tbl_downtimedtl where DEL_FLAG = 'A'";

                else if (!txt_SeachVal.Text.Equals("") && ckb_DelFlag.Checked)
                    cmd.CommandText = "select plant_code, trim(factor_code), factor_name, trim(del_flag), insert_user, insert_date, update_user, update_date, trim(rsp_flag) from tbl_downtimedtl where plant_code like '%' || :SeachVal || '%'";

                cmd.Parameters.Add("SeachVal", txt_SeachVal.Text);


                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                FillGrid(ds);


                OracleDataReader reader = cmd.ExecuteReader();

                grd_Result.Rows.Clear();
                int i_cnt = 0;
                while (reader.Read())
                {
                    grd_Result.Rows.Add(++i_cnt, reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8]);
                }
                return i_cnt;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                connection.Close();
            }*/
        }
    }
}
