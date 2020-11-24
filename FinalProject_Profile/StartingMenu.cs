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
using LiveCharts;
using LiveCharts.Wpf;
//using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts.WinForms;


namespace FinalProject_Profile
{
    public partial class StartingMenu : MetroForm
    {
        Main main;
        LiveCharts.WinForms.PieChart pieChart1;
        LiveCharts.WinForms.CartesianChart cartesianChart1;
        LiveCharts.WinForms.CartesianChart cartesianChart2;
        protected const string connectionString = "DATA SOURCE=220.69.249.228:1521/xe;PASSWORD=1234;PERSIST SECURITY INFO=True;USER ID=MAT_MGR";
        List<PlanData> planList = new List<PlanData>();
        List<DefectData> defectList = new List<DefectData>();
        public StartingMenu(Main mainForm)
        {
            InitializeComponent();
            main = mainForm;
        }
        public StartingMenu()
        {
            InitializeComponent();
        }

        public void SelectData()
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
                    CommandText = "SELECT trim(A.PROD_CODE), nvl(sum(B.ORDER_M),0), nvl(sum(C.INSU_QTY),0) FROM tbl_productmaster A ,(select * from TBL_PRODUCTPLAN WHERE JOB_DATE BETWEEN to_date(:START_DATE,'yyyymmdd') AND to_date(:END_DATE,'yyyymmdd') AND PROC_STATUS NOT IN('D')) B, TBL_PRODRSLT C where A.PROD_CODE = B.PROD_CODE(+) AND B.JOB_NO = C.JOB_NO(+) GROUP BY A.PROD_CODE, B.PROD_CODE ORDER BY A.PROD_CODE"
                };

                cmd.Parameters.Add("START_DATE", DateTime.Now.AddDays(-7).ToString("yyyyMMdd"));
                cmd.Parameters.Add("END_DATE", DateTime.Now.ToString("yyyyMMdd"));

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //dic.Add(reader[0].ToString(), reader[1].ToString());
                    planList.Add(new PlanData
                    {
                        PROD_CODE = reader[0].ToString(),
                        ORDER_M = Int32.Parse(reader[1].ToString()),
                        INSU_QTY = Int32.Parse(reader[2].ToString())
                    });
                }

                cmd = new OracleCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection,
                    CommandText = "SELECT trim(A.PROD_CODE) 제품코드, nvl(sum(C.BAD_QTY),0) 불량량, nvl(sum(C.GOOD_QTY),0) 양품량 FROM tbl_productmaster A ,(select * from TBL_PRODUCTPLAN WHERE JOB_DATE BETWEEN to_date(:START_DATE,'yyyymmdd') AND to_date(:END_DATE,'yyyymmdd')) B, TBL_PRODRSLT C where A.PROD_CODE = B.PROD_CODE(+) AND B.JOB_NO = C.JOB_NO(+) GROUP BY A.PROD_CODE ORDER BY A.PROD_CODE"
                };

                cmd.Parameters.Add("START_DATE", DateTime.Now.AddDays(-7).ToString("yyyyMMdd"));
                cmd.Parameters.Add("END_DATE", DateTime.Now.ToString("yyyyMMdd"));

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    defectList.Add(new DefectData
                    {
                        PROD_CODE = reader[0].ToString(),
                        BAD_QTY = Int32.Parse(reader[1].ToString()),
                        GOOD_QTY = Int32.Parse(reader[2].ToString())
                    });
                }

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

        public void ProductionStatusChart()
        {
            //**************** 1nd 모델 생산현황 차트(원형 차트) ******************
            Func<ChartPoint, string> labelPoint = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            pieChart1 = new LiveCharts.WinForms.PieChart();
            pieChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            pieChart1.Location = new System.Drawing.Point(0, 0);
            pieChart1.Name = "pieChart1";
            pieChart1.Size = new System.Drawing.Size(608, 366);
            pieChart1.TabIndex = 0;
            pieChart1.Text = "pieChart1";

            panel10.Controls.Add(pieChart1);

            pieChart1.Series = new SeriesCollection();

            foreach (var item in planList)
            {
                pieChart1.Series.Add(new PieSeries
                {
                    Title = item.PROD_CODE,
                    Values = new ChartValues<int> { item.INSU_QTY },
                    DataLabels = true,
                    LabelPoint = labelPoint
                }
                );
            }

            pieChart1.LegendLocation = LegendLocation.Bottom;

            foreach (var item in pieChart1.Series)
            {
                
            }
            
        }

        public void ProgressChart()
        {
            //**************** 2st 계획 대비 진척 차트 ******************

            cartesianChart1 = new LiveCharts.WinForms.CartesianChart();

            cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            cartesianChart1.Location = new System.Drawing.Point(0, 0);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new System.Drawing.Size(991, 366);
            cartesianChart1.TabIndex = 1;
            cartesianChart1.Text = "cartesianChart1";

            panel11.Controls.Add(cartesianChart1);


            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "계획량",
                    Values = new ChartValues<int>()
                }
            };

            //adding series will update and animate the chart automatically
            cartesianChart1.Series.Add(new ColumnSeries
            {
                Title = "생산량",
                Values = new ChartValues<int>()
            });

            //also adding values updates and animates the chart automatically

            foreach (var item in planList)
            {
                cartesianChart1.Series[0].Values.Add(item.ORDER_M);
                cartesianChart1.Series[1].Values.Add(item.INSU_QTY);
            }

            List<string> lables = new List<string>();

            for (int i = 0; i < planList.Count; i++)
            {
                lables.Add(planList[i].PROD_CODE);
            }

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "",
                Labels = lables.ToArray()
                //Labels = new [] { "a", "b", "c", "d", "e" ,"f" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "갯수",
                MinValue = 0,
                LabelFormatter = value => value.ToString("N0")
            });

            cartesianChart1.LegendLocation = LegendLocation.Right;

        }

        public void DefectChart()
        {
            //**************** 3rd 모델별 불량 차트 ******************
            cartesianChart2 = new LiveCharts.WinForms.CartesianChart();

            cartesianChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            cartesianChart2.Location = new System.Drawing.Point(0, 0);
            cartesianChart2.Name = "cartesianChart2";
            cartesianChart2.Size = new System.Drawing.Size(991, 366);
            cartesianChart2.TabIndex = 2;
            cartesianChart2.Text = "cartesianChart2";

            panel12.Controls.Add(cartesianChart2);



            cartesianChart2.Series = new SeriesCollection();

            //adding series updates and animates the chart
            cartesianChart2.Series.Add(new StackedColumnSeries
            {
                Title = "양품량",
                Values = new ChartValues<int>(),
                StackMode = StackMode.Values,
                Fill = System.Windows.Media.Brushes.DarkBlue
            });

            cartesianChart2.Series.Add(new StackedColumnSeries
            {
                Title = "불량량",
                Values = new ChartValues<int>(),
                StackMode = StackMode.Values,
                Fill = System.Windows.Media.Brushes.Chocolate
            });
            

            foreach (var item in defectList)
            {
                cartesianChart2.Series[0].Values.Add(item.GOOD_QTY);
                cartesianChart2.Series[1].Values.Add(item.BAD_QTY);
            }

            List<string> lables = new List<string>();

            for (int i = 0; i < planList.Count; i++)
            {
                lables.Add(planList[i].PROD_CODE);
            }

            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "",
                Labels = lables.ToArray(),
                Separator = DefaultAxes.CleanSeparator
            });

            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "불량량",
                MinValue = 0,
                LabelFormatter = value => value.ToString("N0")
            });

            cartesianChart2.LegendLocation = LegendLocation.Right;
        }

        public void PlanGrid()
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
                    CommandText = "SELECT TRIM(A.PROD_CODE) 제품코드, C.PROD_NAME 제품이름, FUN_DATA_COMMAS(A.ORDER_M) 주문수량, A.JOB_DATE 생산예정일 FROM TBL_PRODUCTPLAN A, TBL_PRODRESERVE B, TBL_PRODUCTMASTER C WHERE A.JOB_NO = B.JOB_NO  AND A.PROD_CODE = C.PROD_CODE ORDER BY B.RESERVE_RANK"
                };

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


        private void StartingMenu_Load(object sender, EventArgs e)
        {
            panel2.BackgroundImage = Properties.Resources.dba_img3;
            label2.Text = DateTime.Now.AddDays(-7).ToString("MM월 dd일") + " ~";
            label3.Text = DateTime.Now.ToString("MM월 dd일") + "  의 자료입니다.";
        }

        private void StartingMenu_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void StartingMenu_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            main.CallSAPOrder();
            this.Close();
        }

        private void StartingMenu_Activated(object sender, EventArgs e)
        {
            SelectData();

            ProgressChart();

            ProductionStatusChart();

            DefectChart();

            PlanGrid();
        }
    }
    public class PlanData
    {
        public string PROD_CODE { get; set; }
        public int ORDER_M { get; set; }
        public int INSU_QTY { get; set; }
        
    }

    public class DefectData
    {
        public string PROD_CODE { get; set; }
        public int BAD_QTY { get; set; }
        public int GOOD_QTY { get; set; }
    }
}
