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

// MetroFramework 이용해서 폼 외형 변경

namespace FinalProject_Profile
{
    public partial class Reservation : MetroForm                                    // Form → MetroForm 변경
    {
        public Reservation()
        {
            InitializeComponent();
            for (int i = 0; i < 30; i++)
            {
                // 임시 Data값 (☆ 추후에 주석처리나, 삭제 예정 ☆)
                metroGrid2.Rows.Add($"{i+1}", "1234", "2020/09/20", "2020/09/20", "내수", "11", "M", "1000", "생산가능");
            }
        }

        private void Child3_Load(object sender, EventArgs e)                        // 실행되었을때, 어떤 항목을 추가해주려고 미리 만들어놓음
        {

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
            DataGridViewRow selectedRow = metroGrid2.Rows[rowIndex];                // DataGridViewRow = DataGridView의 행을 나타냄. selectedRow라는 지역 변수로 지정.
                                                                                    // rowIndex에 해당하는 Metro Grid의 모든 행들을 가져와줌. (?)
            metroGrid2.Rows.Remove(selectedRow);                                    // metroGrid.Rows (행을 포함하는 컬렉션) 에서 selectedRow (= 위에서 지정한 변수) 를 제거
            metroGrid2.Rows.Insert(rowIndex - 1, selectedRow);                      // 제거했던 내용을 삽입해주는데, 기존 rowIndex의 -1 만큼 (한 줄 위) 의 위치에다가!!
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
            DataGridViewRow selectedRow = metroGrid2.Rows[rowIndex];
            metroGrid2.Rows.Remove(selectedRow);
            metroGrid2.Rows.Insert(rowIndex + 1, selectedRow);                      // 지정된 selectedRow를 rowIndex +1(한 줄 아래) 만큼 행에다 삽입.
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
            DataGridViewRow selectedRow = metroGrid2.Rows[rowIndex];
            metroGrid2.Rows.Remove(selectedRow);
            metroGrid2.Rows.Insert(0, selectedRow);
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
            DataGridViewRow selectedRow = metroGrid2.Rows[rowIndex];                    // selectedRow라는 지역 변수 = 
            metroGrid2.Rows.Remove(selectedRow);                                        // 기존 줄에 있는 선택된 selectedRow 제거
            metroGrid2.Rows.Insert(metroGrid2.Rows.Count - 1, selectedRow);             // 기존 줄에 있는 선택된 selectedRowf 를 카운트값 -1 만큼의 위치에 삽입
            metroGrid2.ClearSelection();                                                // 선택된 셀의 선택을 취소한다(?)
            metroGrid2.Rows[metroGrid2.Rows.Count-1].Cells[colIndex].Selected = true;   // metroGrid2.Rows[] 항목에다 metroGrid2.Rows.Count -1 값을 넣어주면 행 마지막으로 감.
        }
    }
}
/*
 * 쩜(.)을 찍어갈수록 더 소집합의 항목
 * ex) 큰 항목.작은 항목. .... 요런식으로
 */