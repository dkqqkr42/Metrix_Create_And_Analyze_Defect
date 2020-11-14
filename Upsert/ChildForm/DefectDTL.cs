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

/// <summary>
/// 3조 DBA 조재호
/// 2020-10-11
/// </summary>
namespace Upsert
{
    public partial class DefectDTL : MetroForm, IChildForm
    {
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";
        public DefectDTL()
        {
            InitializeComponent();
        }
        public string StoredProcedureName() => "DEFECTDTL_UPSERT";

        private void Child_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 데이터 조회 결과를 adapter로 받아 DataSet을 반환 받은 경우 사용되는 메서드
        /// </summary>
        /// <param name="ds">데이터 조회 결과</param>
        public void FillGrid (DataSet ds)
        {
            grd_Result.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// 데이터베이스에 연결해 데이터를 조회하는 IChildForm 인터페이스 구현
        /// </summary>
        public int SelectItem()
        {
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
                    CommandText = "select PLANT_CODE, trim(FACTOR_CODE), FACTOR_NAME, trim(DEL_FLAG), INSERT_USER, INSERT_DATE, UPDATE_USER, UPDATE_DATE from tbl_defectdtl where trim(FACTOR_CODE) like '%' || :SeachVal || '%' and DEL_FLAG = 'A' order by factor_code"
                };
                if (cbo_SeachVal.Text.Equals("전체") && ckb_DelFlag.Checked)
                    cmd.CommandText = "select PLANT_CODE, trim(FACTOR_CODE), FACTOR_NAME, trim(DEL_FLAG), INSERT_USER, INSERT_DATE, UPDATE_USER, UPDATE_DATE from tbl_defectdtl order by factor_code";

                else if (cbo_SeachVal.Text.Equals("전체") && !ckb_DelFlag.Checked)
                    cmd.CommandText = "select PLANT_CODE, trim(FACTOR_CODE), FACTOR_NAME, trim(DEL_FLAG), INSERT_USER, INSERT_DATE, UPDATE_USER, UPDATE_DATE from tbl_defectdtl where DEL_FLAG = 'A' order by factor_code";

                else if (!cbo_SeachVal.Text.Equals("전체") && ckb_DelFlag.Checked)
                    cmd.CommandText = "select PLANT_CODE, trim(FACTOR_CODE), FACTOR_NAME, trim(DEL_FLAG), INSERT_USER, INSERT_DATE, UPDATE_USER, UPDATE_DATE from tbl_defectdtl where trim(FACTOR_CODE) like '%' || :SeachVal || '%' order by factor_code";
                string seachVal = "";
                switch (cbo_SeachVal.SelectedIndex)
                {
                    case 0: 
                        seachVal = "";
                        break;
                    case 1:
                        seachVal = "A";
                        break;
                    case 2:
                        seachVal = "B";
                        break;
                    case 3:
                        seachVal = "C";
                        break;
                    case 4:
                        seachVal = "D";
                        break;

                }


                cmd.Parameters.Add("SeachVal", seachVal);

                
                /*OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                FillGrid(ds);*/
                

                OracleDataReader reader = cmd.ExecuteReader();

                grd_Result.Rows.Clear();
                int i_cnt = 0;
                while (reader.Read())
                {
                    grd_Result.Rows.Add(++i_cnt, reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7]);
                }
                return i_cnt;

            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
            finally
            {
                connection.Close();
            }
            
        }

        private void grd_Data_KeyUp(object sender, KeyEventArgs e)
        {
            int rowIndex = grd_Result.CurrentRow.Index;

            txt_PLANT_CODE.Text = grd_Result.Rows[rowIndex].Cells[1].Value.ToString();
            txt_FACTOR_CODE.Text = grd_Result.Rows[rowIndex].Cells[2].Value.ToString();
            txt_FACTOR_NAME.Text = grd_Result.Rows[rowIndex].Cells[3].Value.ToString();
            txt_DEL_FLAG.Text = grd_Result.Rows[rowIndex].Cells[4].Value.ToString();
            txt_INSERT_USER.Text = grd_Result.Rows[rowIndex].Cells[5].Value.ToString();
            txt_INSERT_DATE.Text = grd_Result.Rows[rowIndex].Cells[6].Value.ToString();
            txt_UPDATE_USER.Text = grd_Result.Rows[rowIndex].Cells[7].Value.ToString();
            txt_UPDATE_DATE.Text = grd_Result.Rows[rowIndex].Cells[8].Value.ToString();
        }

        private void grd_Data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = grd_Result.CurrentRow.Index;

            txt_PLANT_CODE.Text = grd_Result.Rows[rowIndex].Cells[1].Value.ToString();
            txt_FACTOR_CODE.Text = grd_Result.Rows[rowIndex].Cells[2].Value.ToString();
            txt_FACTOR_NAME.Text = grd_Result.Rows[rowIndex].Cells[3].Value.ToString();
            txt_DEL_FLAG.Text = grd_Result.Rows[rowIndex].Cells[4].Value.ToString();
            txt_INSERT_USER.Text = grd_Result.Rows[rowIndex].Cells[5].Value.ToString();
            txt_INSERT_DATE.Text = grd_Result.Rows[rowIndex].Cells[6].Value.ToString();
            txt_UPDATE_USER.Text = grd_Result.Rows[rowIndex].Cells[7].Value.ToString();
            txt_UPDATE_DATE.Text = grd_Result.Rows[rowIndex].Cells[8].Value.ToString();
        }

        /// <summary>
        /// 저장 프로시저를 불러와서 있는 ID값이면 Update, 없는 ID값이면 Insert를 수행
        /// </summary>
        public bool SaveItem()
        {
            OracleConnection connection = null;
            try
            {
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                if (txt_PLANT_CODE.Text.Equals("") || txt_FACTOR_CODE.Text.Equals(""))
                    throw new ArgumentException("모든 항목을 입력해 주세요");

                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection,
                    CommandText = StoredProcedureName()
                };

                cmd.Parameters.Add("IN_PLANT_CODE", txt_PLANT_CODE.Text);
                cmd.Parameters.Add("IN_FACTOR_CODE", txt_FACTOR_CODE.Text);
                cmd.Parameters.Add("IN_FACTOR_NAME", txt_FACTOR_NAME.Text);
                cmd.Parameters.Add("IN_DEL_FLAG", txt_DEL_FLAG.Text);
                cmd.Parameters.Add("IN_INSERT_USER", txt_INSERT_USER.Text);
                cmd.Parameters.Add("IN_UPDATE_USER", txt_UPDATE_USER.Text);

                cmd.ExecuteNonQuery();

                return true;

            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connection.Close();
            }
            
        }

        public bool DeleteItem()
        {
            OracleConnection connection = null;
            try
            {
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                int i_RowIndex = grd_Result.CurrentRow.Index;
                string s_DelPrimaryKey = grd_Result.Rows[i_RowIndex].Cells[2].Value.ToString();

                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "update tbl_defectdtl set DEL_FLAG = 'D', update_date = SYSDATE where trim(FACTOR_CODE) = :DeleteVal"
                };

                cmd.Parameters.Add("DeleteVal", s_DelPrimaryKey);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                connection.Close();
            }
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
    }
}
