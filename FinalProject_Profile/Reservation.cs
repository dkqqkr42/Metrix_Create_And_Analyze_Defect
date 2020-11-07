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

// MetroFramework 이용해서 폼 외형 변경

namespace FinalProject_Profile
{
    public partial class Reservation : MetroForm                                    // Form → MetroForm 변경
    {
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";    // Oracle계정 MAT_MGR 연결
        List<string> GetWC_CODE = new List<string>();
        List<string> GetJob_No = new List<string>();
        List<string> GetReserve_Rank = new List<string>();
        DataTable table = null;
        WorkPlan wp = null;
        public Reservation()
        {
            InitializeComponent();
        }

        public Reservation(DataTable dt)
        {
            InitializeComponent();
            table = dt;
            metroGrid2.DataSource = table;
        }

        public Reservation(WorkPlan _wp, DataTable dt)
        {
            InitializeComponent();
            table = dt;
            metroGrid2.DataSource = table;
            wp = _wp;
        }

        public Reservation(WorkPlan _wp)
        {
            InitializeComponent();
            wp = _wp;
            FillGird();
        }

        private void Child3_Load(object sender, EventArgs e)                        // 실행되었을때, 어떤 항목을 추가해주려고 미리 만들어놓음
        {

        }

        public void FillGird()
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
                    CommandText = "SELECT A.PROD_CODE as 제품내역, B.PROD_NAME as 제품명, A.PROD_UNIT as 제품단위, A.ORDER_M as 작업지시량, A.ADD_GOOD_QTY as 누적양품량, TO_CHAR(CASE WHEN A.ORDER_M = 0 THEN 0 ELSE A.ADD_GOOD_QTY / A.ORDER_M * 100 END, '990.0') as 누적양품비율, DECODE(A.GUBUN, 'A', '내수', 'B', '수출', 'C', '특판', ' ') 주문형식, DECODE(A.WORK_GUBUN, 'A', '정상작업', 'U', '재작업', 'R', '연구개발', 'T', '기술테스트', 'S', 'S/BOOK', 'C', 'C/MATCH', ' ') 작업구분, DECODE(A.NOTE_FLAG, 'Y', '★', ' ') NOTE_FLAG, DECODE(A.PROC_STATUS, 'Y', '가능', 'A', '예약', 'B', '진행', 'C', '생산', 'E', '종료', 'D', '취소', ' ') 생산상태, TO_CHAR(A.START_DATE, 'YYYY-MM-DD HH24:MI') 시작일자, TO_CHAR(A.END_DATE, 'YYYY-MM-DD HH24:MI') 종료일자, A.JOB_NO as 작업번호, A.ORDER_NO || '-' || A.ORDER_SEQ as 주문번호 , A.NOTE0 as 비고, A.NOTE1 as 비고2, B.MRP_MGR as MRP관리자 FROM TBL_PRODUCTPLAN A, TBL_ProductMaster B WHERE A.PROD_CODE = B.PROD_CODE AND A.PLANT_CODE = :IN_PLANT_CODE AND A.PROC_STATUS IN('D','Y','A') AND A.DEL_FLAG = 'A' ORDER BY A.START_DATE, A.JOB_NO"
                };


                cmd.Parameters.Add("IN_PLANT_CODE", "2020");


                OracleDataReader reader = cmd.ExecuteReader();

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                table = ds.Tables[0];
                metroGrid2.DataSource = table;


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

        private void metroTile7_Click(object sender, EventArgs e)                   // 클릭 이벤트 (1칸 UP Button)
        {
            // metroGrid.Rows.Count (= Metro Grid의 모든 행을 포함하는 것을 카운팅 해 줌)
            int totalRows = metroGrid2.Rows.Count;                                  // totalRows (변수) == 카운트값 (모르면 단어 직독직해/마우스 가져다 대보기)

            // get index of the row for the selected cell
            int rowIndex = metroGrid2.SelectedCells[0].OwningRow.Index;             // == 지정된 인덱스의 셀을 가져옵니다.
            if (rowIndex == 0)                                                      // rowIndex (행의 인덱스) 값이 0 이면
                return;                                                             // 리턴

            // get index of the column for the selected cell
            int colIndex = metroGrid2.SelectedCells[0].OwningColumn.Index;          // 요 항목이 포함하는 열을 가져옵니다.
            //DataGridViewRow selectedRow = metroGrid2.Rows[rowIndex];                // DataGridViewRow = DataGridView의 행을 나타냄. selectedRow라는 지역 변수로 지정.
            DataRow oldRow = table.Rows[rowIndex];
            DataRow newRow = table.NewRow();
            newRow.ItemArray = oldRow.ItemArray;

            table.Rows.Remove(oldRow);
            table.Rows.InsertAt(newRow, rowIndex - 1);
                                                                                    // rowIndex에 해당하는 Metro Grid의 모든 행들을 가져와줌. (?)
            //metroGrid2.Rows.Remove(selectedRow);                                    // metroGrid.Rows (행을 포함하는 컬렉션) 에서 selectedRow (= 위에서 지정한 변수) 를 제거
            //metroGrid2.Rows.Insert(rowIndex - 1, selectedRow);                      // 제거했던 내용을 삽입해주는데, 기존 rowIndex의 -1 만큼 (한 줄 위) 의 위치에다가!!
            metroGrid2.ClearSelection();                                            // 기존 셀 선택을 초기화 해줍니다.
            metroGrid2.Rows[rowIndex - 1].Cells[colIndex].Selected = true;          // ??? ( rowIndex-1만큼 Row를 이동 )
        }

        private void metroTile9_Click(object sender, EventArgs e)                   // 클릭 이벤트 (1칸 DOWN Button)
        {
            // metroGrid.Rows.Count (= Metro Grid의 모든 행을 포함하는 것을 카운팅 해 줌)
            int totalRows = metroGrid2.Rows.Count;                                  // totalRows (변수) == metroGrid2 행의 수 (카운트값)

            // get index of the row for the selected cell
            int rowIndex = metroGrid2.SelectedCells[0].OwningRow.Index;             // rowIndex는 metroGrid2.selectedCells[0]에서 포함하는 행
            if (rowIndex == totalRows - 1)                                          // 만약에 rowIndex값이랑 카운팅한 값에서 -1 한 거랑 같으면 (이게 무슨 뜻이람?)
                return;                                                             // 리턴해준다

            // get index of the column for the selected cell
            int colIndex = metroGrid2.SelectedCells[0].OwningColumn.Index;
            //DataGridViewRow selectedRow = metroGrid2.Rows[rowIndex];
            DataRow oldRow = table.Rows[rowIndex];
            DataRow newRow = table.NewRow();
            newRow.ItemArray = oldRow.ItemArray;

            table.Rows.Remove(oldRow);
            table.Rows.InsertAt(newRow, rowIndex + 1);
            //metroGrid2.Rows.Remove(selectedRow);
            //metroGrid2.Rows.Insert(rowIndex + 1, selectedRow);                      // 지정된 selectedRow를 rowIndex +1(한 줄 아래) 만큼 행에다 삽입.
            metroGrid2.ClearSelection();
            metroGrid2.Rows[rowIndex + 1].Cells[colIndex].Selected = true;          // metroGrid2의 행[항목].행 안에 셀[항목].선택됨 = True
        }

        private void metroTile6_Click(object sender, EventArgs e)                   // 클릭 이벤트 (맨 위로)
        {
            // metroGrid.Rows.Count
            int totalRows = metroGrid2.Rows.Count;

            // get index of the row for the selected cell                           // - - 1칸 UP Button과 동일 - -
            int rowIndex = metroGrid2.SelectedCells[0].OwningRow.Index;
            if (rowIndex == 0)
                return;

            // get index of the column for the selected cell
            int colIndex = metroGrid2.SelectedCells[0].OwningColumn.Index;
            //DataGridViewRow selectedRow = metroGrid2.Rows[rowIndex];
            DataRow oldRow = table.Rows[rowIndex];
            DataRow newRow = table.NewRow();
            newRow.ItemArray = oldRow.ItemArray;

            table.Rows.Remove(oldRow);
            table.Rows.InsertAt(newRow, 0);
            //metroGrid2.Rows.Remove(selectedRow);
            //metroGrid2.Rows.Insert(0, selectedRow);
            metroGrid2.ClearSelection();
            metroGrid2.Rows[0].Cells[colIndex].Selected = true;                     // metroGrid2.Rows[] 항목에다 0 집어넣으면, 위치 맨 위로
        }

        private void metroTile8_Click(object sender, EventArgs e)                   // 클릭 이벤트 (맨 밑으로)
        {
            // metroGrid.Rows.Count (= Metro Grid의 모든 행을 포함하는 것을 카운팅 해 줌)
            int totalRows = metroGrid2.Rows.Count;                                  // totalRows == 행 수 (카운트값)

            // get index of the row for the selected cell                           // - - 1칸 DOWN Button과 동일 - -
            int rowIndex = metroGrid2.SelectedCells[0].OwningRow.Index;
            if (rowIndex == totalRows - 1)
                return;

            // get index of the column for the selected cell
            int colIndex = metroGrid2.SelectedCells[0].OwningColumn.Index;              // colIndex는 metroGrid의 0번째 선택된 셀을 포함하는 열(컬럼)의 인덱스
            //DataGridViewRow selectedRow = metroGrid2.Rows[rowIndex];                    // selectedRow라는 지역 변수 = 
            DataRow oldRow = table.Rows[rowIndex];
            DataRow newRow = table.NewRow();
            newRow.ItemArray = oldRow.ItemArray;

            table.Rows.Remove(oldRow);
            table.Rows.InsertAt(newRow, table.Rows.Count);
            //metroGrid2.Rows.Remove(selectedRow);                                        // 기존 줄에 있는 선택된 selectedRow 제거
            //metroGrid2.Rows.Insert(metroGrid2.Rows.Count, selectedRow);             // 기존 줄에 있는 선택된 selectedRowf 를 카운트값 만큼의 위치에 삽입
            metroGrid2.ClearSelection();                                                // 선택된 셀의 선택을 취소한다(?)
            metroGrid2.Rows[metroGrid2.Rows.Count-1].Cells[colIndex].Selected = true;   // metroGrid2.Rows[] 항목에다 metroGrid2.Rows.Count 값을 넣어주면 행 마지막으로 감.
        }
        /// <summary>
        /// 예약
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                GetJob_No.Add(table.Rows[i][12].ToString());
            }
            
            OracleConnection connection = null;
            try
            {
                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                for (int i = 0; i < table.Rows.Count; i++)
                {

                    OracleCommand cmd = new OracleCommand
                    {
                        CommandType = CommandType.Text,
                        Connection = connection,
                        CommandText = "select trim(wc_code) from tbl_productplan where job_no = :IN_JOB_NO"
                    };


                    cmd.Parameters.Add("IN_JOB_NO", GetJob_No[i]);


                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        GetWC_CODE.Add(reader.GetValue(0).ToString());
                    }
                }

                for (int i = 0; i < table.Rows.Count; i++)
                {

                    OracleCommand cmd = new OracleCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        Connection = connection,
                        CommandText = "PRODRESERVE_UPSERT"
                    };

                    cmd.Parameters.Add("IN_WC_CODE", GetWC_CODE[i]);
                    cmd.Parameters.Add("IN_JOB_NO", GetJob_No[i]);
                    cmd.Parameters.Add("IN_RESERVE_RANK", i+1);


                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
                this.Close();
            }
        }
        /// <summary>
        /// 예약취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton2_Click(object sender, EventArgs e)
        {
            OracleConnection connection = null;
            try
            {
                int rowIndex = metroGrid2.SelectedCells[0].OwningRow.Index;
                DataRow selectedRow = table.Rows[rowIndex];
                string del_Job_No = selectedRow[12].ToString();
                GetJob_No.Remove(del_Job_No);
                table.Rows.Remove(selectedRow);

                connection = new OracleConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();

                OracleCommand cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "delete from TBL_PRODRESERVE where JOB_NO = :IN_JOB_NO"
                };


                cmd.Parameters.Add("IN_JOB_NO", del_Job_No);


                cmd.ExecuteNonQuery();

                cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "Update TBL_PRODUCTPLAN SET PROC_STATUS = 'D' where JOB_NO = :IN_JOB_NO"
                };

                cmd.Parameters.Add("IN_JOB_NO", del_Job_No);

                cmd.ExecuteNonQuery();

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

        private void Reservation_FormClosing(object sender, FormClosingEventArgs e)
        {
            wp.FillGrid();
        }

        private void metroGrid2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 &&
            metroGrid2.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
            {
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
            }
            else
            {
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
            }
        }

        /* 여기서 부터 Q,W,A,S (키보드 버튼) 를(을) 가지고 위아래 순서 조작 하는 기능 */

        private void metroGrid2_KeyDown(object sender, KeyEventArgs e)
        {
            // 줄 1 Up (W키) - 위에 마우스 버튼 클릭 복붙
            if (e.KeyCode == Keys.W)
            {
                // metroGrid.Rows.Count (= Metro Grid의 모든 행을 포함하는 것을 카운팅 해 줌)
                int totalRows = metroGrid2.Rows.Count;                                  // totalRows (변수) == 카운트값 (모르면 단어 직독직해/마우스 가져다 대보기)

                // get index of the row for the selected cell
                int rowIndex = metroGrid2.SelectedCells[0].OwningRow.Index;             // == 지정된 인덱스의 셀을 가져옵니다.
                if (rowIndex == 0)                                                      // rowIndex (행의 인덱스) 값이 0 이면
                    return;                                                             // 리턴

                // get index of the column for the selected cell
                int colIndex = metroGrid2.SelectedCells[0].OwningColumn.Index;          // 요 항목이 포함하는 열을 가져옵니다.
                                                                                        //DataGridViewRow selectedRow = metroGrid2.Rows[rowIndex];                // DataGridViewRow = DataGridView의 행을 나타냄. selectedRow라는 지역 변수로 지정.
                DataRow oldRow = table.Rows[rowIndex];
                DataRow newRow = table.NewRow();
                newRow.ItemArray = oldRow.ItemArray;

                table.Rows.Remove(oldRow);
                table.Rows.InsertAt(newRow, rowIndex - 1);
                // rowIndex에 해당하는 Metro Grid의 모든 행들을 가져와줌. (?)
                //metroGrid2.Rows.Remove(selectedRow);                                    // metroGrid.Rows (행을 포함하는 컬렉션) 에서 selectedRow (= 위에서 지정한 변수) 를 제거
                //metroGrid2.Rows.Insert(rowIndex - 1, selectedRow);                      // 제거했던 내용을 삽입해주는데, 기존 rowIndex의 -1 만큼 (한 줄 위) 의 위치에다가!!
                metroGrid2.ClearSelection();                                            // 기존 셀 선택을 초기화 해줍니다.
                metroGrid2.Rows[rowIndex - 1].Cells[colIndex].Selected = true;          // ??? ( rowIndex-1만큼 Row를 이동 )
            }

            // 줄 1 Down (S키) - 위에 마우스 버튼 클릭 복붙
            else if (e.KeyCode == Keys.S)
            {
                // metroGrid.Rows.Count (= Metro Grid의 모든 행을 포함하는 것을 카운팅 해 줌)
                int totalRows = metroGrid2.Rows.Count;                                  // totalRows (변수) == metroGrid2 행의 수 (카운트값)

                // get index of the row for the selected cell
                int rowIndex = metroGrid2.SelectedCells[0].OwningRow.Index;             // rowIndex는 metroGrid2.selectedCells[0]에서 포함하는 행
                if (rowIndex == totalRows - 1)                                          // 만약에 rowIndex값이랑 카운팅한 값에서 -1 한 거랑 같으면 (이게 무슨 뜻이람?)
                    return;                                                             // 리턴해준다

                // get index of the column for the selected cell
                int colIndex = metroGrid2.SelectedCells[0].OwningColumn.Index;
                //DataGridViewRow selectedRow = metroGrid2.Rows[rowIndex];
                DataRow oldRow = table.Rows[rowIndex];
                DataRow newRow = table.NewRow();
                newRow.ItemArray = oldRow.ItemArray;

                table.Rows.Remove(oldRow);
                table.Rows.InsertAt(newRow, rowIndex + 1);
                //metroGrid2.Rows.Remove(selectedRow);
                //metroGrid2.Rows.Insert(rowIndex + 1, selectedRow);                      // 지정된 selectedRow를 rowIndex +1(한 줄 아래) 만큼 행에다 삽입.
                metroGrid2.ClearSelection();
                metroGrid2.Rows[rowIndex + 1].Cells[colIndex].Selected = true;          // metroGrid2의 행[항목].행 안에 셀[항목].선택됨 = True
            }

            // 줄 맨 위로 Up (Q키) - 위에 마우스 버튼 클릭 복붙
            else if (e.KeyCode == Keys.Q)
            {
                // metroGrid.Rows.Count
                int totalRows = metroGrid2.Rows.Count;

                // get index of the row for the selected cell                           // - - 1칸 UP Button과 동일 - -
                int rowIndex = metroGrid2.SelectedCells[0].OwningRow.Index;
                if (rowIndex == 0)
                    return;

                // get index of the column for the selected cell
                int colIndex = metroGrid2.SelectedCells[0].OwningColumn.Index;
                //DataGridViewRow selectedRow = metroGrid2.Rows[rowIndex];
                DataRow oldRow = table.Rows[rowIndex];
                DataRow newRow = table.NewRow();
                newRow.ItemArray = oldRow.ItemArray;

                table.Rows.Remove(oldRow);
                table.Rows.InsertAt(newRow, 0);
                //metroGrid2.Rows.Remove(selectedRow);
                //metroGrid2.Rows.Insert(0, selectedRow);
                metroGrid2.ClearSelection();
                metroGrid2.Rows[0].Cells[colIndex].Selected = true;                     // metroGrid2.Rows[] 항목에다 0 집어넣으면, 위치 맨 위로
            }

            // 줄 맨 아래로 Down (A키) - 위에 마우스 버튼 클릭 복붙
            else if (e.KeyCode == Keys.A)
            {
                // metroGrid.Rows.Count (= Metro Grid의 모든 행을 포함하는 것을 카운팅 해 줌)
                int totalRows = metroGrid2.Rows.Count;                                  // totalRows == 행 수 (카운트값)

                // get index of the row for the selected cell                           // - - 1칸 DOWN Button과 동일 - -
                int rowIndex = metroGrid2.SelectedCells[0].OwningRow.Index;
                if (rowIndex == totalRows - 1)
                    return;

                // get index of the column for the selected cell
                int colIndex = metroGrid2.SelectedCells[0].OwningColumn.Index;              // colIndex는 metroGrid의 0번째 선택된 셀을 포함하는 열(컬럼)의 인덱스
                                                                                            //DataGridViewRow selectedRow = metroGrid2.Rows[rowIndex];                    // selectedRow라는 지역 변수 = 
                DataRow oldRow = table.Rows[rowIndex];
                DataRow newRow = table.NewRow();
                newRow.ItemArray = oldRow.ItemArray;

                table.Rows.Remove(oldRow);
                table.Rows.InsertAt(newRow, table.Rows.Count);
                //metroGrid2.Rows.Remove(selectedRow);                                        // 기존 줄에 있는 선택된 selectedRow 제거
                //metroGrid2.Rows.Insert(metroGrid2.Rows.Count, selectedRow);             // 기존 줄에 있는 선택된 selectedRowf 를 카운트값 만큼의 위치에 삽입
                metroGrid2.ClearSelection();                                                // 선택된 셀의 선택을 취소한다(?)
                metroGrid2.Rows[metroGrid2.Rows.Count - 1].Cells[colIndex].Selected = true;   // metroGrid2.Rows[] 항목에다 metroGrid2.Rows.Count 값을 넣어주면 행 마지막으로 감.
            }
        }
    }
}
/*
 * 쩜(.)을 찍어갈수록 더 소집합의 항목
 * ex) 큰 항목.작은 항목. .... 요런식으로
 */