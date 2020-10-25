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
    public partial class ProductMaster : MetroForm, IChildForm
    {
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";
        InputPopup_ProductMaster popup;
        List<string> list = new List<string>();
        public ProductMaster()
        {
            InitializeComponent();
        }
        public string StoredProcedureName() => "PRODUCTMASTER_UPSERT";

        private void DieaseUpdateEventMethod(object sender)
        {
            //폼2에서 델리게이트로 이벤트 발생하면 현재 함수 Call
            list = (List<string>)sender;
            SaveItem();
            SelectItem();
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
                    CommandText = "select trim(PROD_CODE), trim(PLANT_CODE), trim(MRP_MGR), PROD_NAME, trim(PROD_TYPE), trim(PROD_UNIT), PROD_SIZE, PROD_THICK, PROD_WIDTH, PROD_LENGTH, PROD_HYRACH, trim(WEIGHT_UNIT), BASE_QTY, TOT_WEIGHT, trim(PI_MEMO), trim(MAT_TYPE), trim(MAT_GROUP), trim(BATCH_GUBUN), trim(S_LOCATION), trim(DEL_FLAG), CHECK_FLAG, trim(MULU_CODE), INSERT_DATE, INSERT_USER, UPDATE_DATE, UPDATE_USER, trim(IPS_YN), PLT_QTY, PROC_MSG from TBL_ProductMaster where trim(PROD_CODE) like '%' || :SeachVal || '%' AND DEL_FLAG = 'A'"
                };

                if (txt_SeachVal.Text.Equals("") && ckb_DelFlag.Checked)
                    cmd.CommandText = "select trim(PROD_CODE), trim(PLANT_CODE), trim(MRP_MGR), PROD_NAME, trim(PROD_TYPE), trim(PROD_UNIT), PROD_SIZE, PROD_THICK, PROD_WIDTH, PROD_LENGTH, PROD_HYRACH, trim(WEIGHT_UNIT), BASE_QTY, TOT_WEIGHT, trim(PI_MEMO), trim(MAT_TYPE), trim(MAT_GROUP), trim(BATCH_GUBUN), trim(S_LOCATION), trim(DEL_FLAG), CHECK_FLAG, trim(MULU_CODE), INSERT_DATE, INSERT_USER, UPDATE_DATE, UPDATE_USER, trim(IPS_YN), PLT_QTY, PROC_MSG from TBL_ProductMaster";
                
                else if (txt_SeachVal.Text.Equals("") && !ckb_DelFlag.Checked)
                    cmd.CommandText = "select trim(PROD_CODE), trim(PLANT_CODE), trim(MRP_MGR), PROD_NAME, trim(PROD_TYPE), trim(PROD_UNIT), PROD_SIZE, PROD_THICK, PROD_WIDTH, PROD_LENGTH, PROD_HYRACH, trim(WEIGHT_UNIT), BASE_QTY, TOT_WEIGHT, trim(PI_MEMO), trim(MAT_TYPE), trim(MAT_GROUP), trim(BATCH_GUBUN), trim(S_LOCATION), trim(DEL_FLAG), CHECK_FLAG, trim(MULU_CODE), INSERT_DATE, INSERT_USER, UPDATE_DATE, UPDATE_USER, trim(IPS_YN), PLT_QTY, PROC_MSG from TBL_ProductMaster where DEL_FLAG = 'A'";

                else if (!txt_SeachVal.Text.Equals("") && ckb_DelFlag.Checked)
                    cmd.CommandText = "select trim(PROD_CODE), trim(PLANT_CODE), trim(MRP_MGR), PROD_NAME, trim(PROD_TYPE), trim(PROD_UNIT), PROD_SIZE, PROD_THICK, PROD_WIDTH, PROD_LENGTH, PROD_HYRACH, trim(WEIGHT_UNIT), BASE_QTY, TOT_WEIGHT, trim(PI_MEMO), trim(MAT_TYPE), trim(MAT_GROUP), trim(BATCH_GUBUN), trim(S_LOCATION), trim(DEL_FLAG), CHECK_FLAG, trim(MULU_CODE), INSERT_DATE, INSERT_USER, UPDATE_DATE, UPDATE_USER, trim(IPS_YN), PLT_QTY, PROC_MSG from TBL_ProductMaster where trim(PROD_CODE) like '%' || :SeachVal || '%'";

                cmd.Parameters.Add("SeachVal", txt_SeachVal.Text);

                /*OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                FillGrid(ds);*/
                
                OracleDataReader reader = cmd.ExecuteReader();

                grd_Result.Rows.Clear();

                int i_cnt = 0;

                while (reader.Read())
                {
                    grd_Result.Rows.Add(++i_cnt, reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8], reader[9], reader[10], reader[11], reader[12], reader[13], reader[14], reader[15], reader[16], reader[17], reader[18], reader[19], reader[20], reader[21], reader[22], reader[23], reader[24], reader[25], reader[26], reader[27], reader[28]);
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
            int i_RowIndex = grd_Result.CurrentRow.Index;

            List<string> list = new List<string>();

            foreach (DataGridViewCell item in grd_Result.Rows[i_RowIndex].Cells)
            {
                list.Add(item.Value.ToString());
            }

            popup = new InputPopup_ProductMaster(list);
            popup.FormSendEvent += new InputPopup_ProductMaster.FormSendDataHandler(DieaseUpdateEventMethod);
            popup.ShowDialog();

            /*txt_ID.Text = grd_Result.Rows[rowIndex].Cells[1].Value.ToString();
            txt_Name.Text = grd_Result.Rows[rowIndex].Cells[2].Value.ToString();
            txt_Path.Text = grd_Result.Rows[rowIndex].Cells[3].Value.ToString();
            txt_Version.Text = grd_Result.Rows[rowIndex].Cells[4].Value.ToString();
            txt_Class.Text = grd_Result.Rows[rowIndex].Cells[5].Value.ToString();*/
        }

        private void grd_Data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i_RowIndex = grd_Result.CurrentRow.Index;

            List<string> list = new List<string>();

            foreach (DataGridViewCell item in grd_Result.Rows[i_RowIndex].Cells)
            {
                list.Add(item.Value.ToString());
            }

            popup = new InputPopup_ProductMaster(list);
            popup.FormSendEvent += new InputPopup_ProductMaster.FormSendDataHandler(DieaseUpdateEventMethod);
            popup.ShowDialog();

            /*txt_ID.Text = grd_Result.Rows[rowIndex].Cells[0].Value.ToString();
            txt_Name.Text = grd_Result.Rows[rowIndex].Cells[1].Value.ToString();
            txt_Path.Text = grd_Result.Rows[rowIndex].Cells[2].Value.ToString();
            txt_Version.Text = grd_Result.Rows[rowIndex].Cells[3].Value.ToString();
            txt_Class.Text = grd_Result.Rows[rowIndex].Cells[4].Value.ToString();*/
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

                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection,
                    CommandText = StoredProcedureName()
                };

                cmd.Parameters.Add("IN_PROD_CODE", list[0]);
                cmd.Parameters.Add("IN_PLANT_CODE", list[1]);
                cmd.Parameters.Add("IN_MRP_MGR", list[2]);
                cmd.Parameters.Add("IN_PROD_NAME", list[3]);
                cmd.Parameters.Add("IN_PROD_TYPE", list[4]);
                cmd.Parameters.Add("IN_PROD_UNIT", list[5]);
                cmd.Parameters.Add("IN_PROD_SIZE", list[6]);
                cmd.Parameters.Add("IN_PROD_THICK", list[7]);
                cmd.Parameters.Add("IN_PROD_WIDTH", list[8]);
                cmd.Parameters.Add("IN_PROD_LENGTH", list[9]);
                cmd.Parameters.Add("IN_PROD_HYRACH", list[10]);
                cmd.Parameters.Add("IN_WEIGHT_UNIT", list[11]);
                cmd.Parameters.Add("IN_BASE_QTY", list[12]);
                cmd.Parameters.Add("IN_TOT_WEIGHT", list[13]);
                cmd.Parameters.Add("IN_PI_MEMO", list[14]);
                cmd.Parameters.Add("IN_MAT_TYPE", list[15]);
                cmd.Parameters.Add("IN_MAT_GROUP", list[16]);
                cmd.Parameters.Add("IN_BATCH_GUBUN", list[17]);
                cmd.Parameters.Add("IN_S_LOCATION", list[18]);
                cmd.Parameters.Add("IN_DEL_FLAG", list[19]);
                cmd.Parameters.Add("IN_CHECK_FLAG", list[20]);
                cmd.Parameters.Add("IN_MULU_CODE", list[21]);
                //cmd.Parameters.Add("IN_INSERT_DATE", list[22]);
                cmd.Parameters.Add("IN_INSERT_USER", list[23]);
                //cmd.Parameters.Add("IN_UPDATE_DATE", list[24]);
                cmd.Parameters.Add("IN_UPDATE_USER", list[25]);
                cmd.Parameters.Add("IN_IPS_YN", list[26]);
                cmd.Parameters.Add("IN_PLT_QTY", list[27]);
                cmd.Parameters.Add("IN_PROC_MSG", list[28]);

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
                string s_DelPrimaryKey = grd_Result.Rows[i_RowIndex].Cells[1].Value.ToString();

                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "update TBL_ProductMaster set DEL_FLAG = 'D', update_date = SYSDATE where trim(PROD_CODE) = :DeleteVal"
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

        private void txt_TEAM_CODE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //todo productmaster
                popup = new InputPopup_ProductMaster(txt_PROD_CODE.Text, txt_PLANT_CODE.Text, txt_MRP_MGR.Text);
                popup.FormSendEvent += new InputPopup_ProductMaster.FormSendDataHandler(DieaseUpdateEventMethod);
                popup.ShowDialog();
            }
        }

        private void ProductMaster_Load(object sender, EventArgs e)
        {
            txt_SeachVal.CharacterCasing = CharacterCasing.Upper;
        }
    }
}
