namespace FinalProject_Profile
{
    partial class SAPOrder
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dtp_INSERT_DATE_END = new System.Windows.Forms.DateTimePicker();
            this.dtp_INSERT_DATE_START = new System.Windows.Forms.DateTimePicker();
            this.lbl_what = new MetroFramework.Controls.MetroLabel();
            this.cbo_WORKCENTER = new MetroFramework.Controls.MetroComboBox();
            this.lbl_DATE = new MetroFramework.Controls.MetroLabel();
            this.btn_Select = new MetroFramework.Controls.MetroButton();
            this.lbl_WORKCENTER = new MetroFramework.Controls.MetroLabel();
            this.btn_Insert = new MetroFramework.Controls.MetroButton();
            this.btn_Decide = new MetroFramework.Controls.MetroButton();
            this.lbl_ORDER_TYPE = new MetroFramework.Controls.MetroLabel();
            this.cbo_ORDER_TYPE = new MetroFramework.Controls.MetroComboBox();
            this.lbl_TEAM = new MetroFramework.Controls.MetroLabel();
            this.cbo_TEAM = new MetroFramework.Controls.MetroComboBox();
            this.grd_Result = new MetroFramework.Controls.MetroGrid();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Result)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PowderBlue;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19F);
            this.label1.Location = new System.Drawing.Point(848, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 48);
            this.label1.TabIndex = 14;
            this.label1.Text = "생산계획접수";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 13;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.17841F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.552806F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.178464F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.102331F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.626224F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.68813F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.766993F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.57769F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.687509F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.302922F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.139623F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.139623F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.059273F));
            this.tableLayoutPanel3.Controls.Add(this.cbo_TEAM, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_TEAM, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbo_ORDER_TYPE, 9, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_ORDER_TYPE, 8, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_Decide, 12, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_Insert, 11, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_WORKCENTER, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_Select, 10, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_DATE, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbo_WORKCENTER, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbl_what, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtp_INSERT_DATE_START, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtp_INSERT_DATE_END, 7, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1832, 97);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // dtp_INSERT_DATE_END
            // 
            this.dtp_INSERT_DATE_END.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtp_INSERT_DATE_END.Font = new System.Drawing.Font("굴림", 14F);
            this.dtp_INSERT_DATE_END.Location = new System.Drawing.Point(1028, 34);
            this.dtp_INSERT_DATE_END.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_INSERT_DATE_END.Name = "dtp_INSERT_DATE_END";
            this.dtp_INSERT_DATE_END.Size = new System.Drawing.Size(259, 29);
            this.dtp_INSERT_DATE_END.TabIndex = 4;
            // 
            // dtp_INSERT_DATE_START
            // 
            this.dtp_INSERT_DATE_START.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtp_INSERT_DATE_START.Font = new System.Drawing.Font("굴림", 14F);
            this.dtp_INSERT_DATE_START.Location = new System.Drawing.Point(727, 34);
            this.dtp_INSERT_DATE_START.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_INSERT_DATE_START.Name = "dtp_INSERT_DATE_START";
            this.dtp_INSERT_DATE_START.Size = new System.Drawing.Size(261, 29);
            this.dtp_INSERT_DATE_START.TabIndex = 3;
            // 
            // lbl_what
            // 
            this.lbl_what.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_what.AutoSize = true;
            this.lbl_what.Location = new System.Drawing.Point(999, 39);
            this.lbl_what.Name = "lbl_what";
            this.lbl_what.Size = new System.Drawing.Size(18, 19);
            this.lbl_what.TabIndex = 7;
            this.lbl_what.Text = "~";
            // 
            // cbo_WORKCENTER
            // 
            this.cbo_WORKCENTER.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbo_WORKCENTER.FormattingEnabled = true;
            this.cbo_WORKCENTER.ItemHeight = 23;
            this.cbo_WORKCENTER.Items.AddRange(new object[] {
            "전체",
            "1호카매트",
            "2호카매트"});
            this.cbo_WORKCENTER.Location = new System.Drawing.Point(453, 34);
            this.cbo_WORKCENTER.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_WORKCENTER.Name = "cbo_WORKCENTER";
            this.cbo_WORKCENTER.Size = new System.Drawing.Size(133, 29);
            this.cbo_WORKCENTER.TabIndex = 2;
            this.cbo_WORKCENTER.UseSelectable = true;
            // 
            // lbl_DATE
            // 
            this.lbl_DATE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_DATE.AutoSize = true;
            this.lbl_DATE.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_DATE.Location = new System.Drawing.Point(630, 36);
            this.lbl_DATE.Name = "lbl_DATE";
            this.lbl_DATE.Size = new System.Drawing.Size(66, 25);
            this.lbl_DATE.TabIndex = 3;
            this.lbl_DATE.Text = "추가일";
            this.lbl_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Select
            // 
            this.btn_Select.BackgroundImage = global::FinalProject_Profile.Properties.Resources.조회;
            this.btn_Select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Select.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Select.Location = new System.Drawing.Point(1549, 4);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(87, 89);
            this.btn_Select.TabIndex = 6;
            this.btn_Select.UseSelectable = true;
            this.btn_Select.Click += new System.EventHandler(this.metroButton3_Click);
            this.btn_Select.MouseDown += new System.Windows.Forms.MouseEventHandler(this.metroButton3_MouseDown);
            this.btn_Select.MouseUp += new System.Windows.Forms.MouseEventHandler(this.metroButton3_MouseUp);
            // 
            // lbl_WORKCENTER
            // 
            this.lbl_WORKCENTER.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_WORKCENTER.AutoSize = true;
            this.lbl_WORKCENTER.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_WORKCENTER.Location = new System.Drawing.Point(348, 36);
            this.lbl_WORKCENTER.Name = "lbl_WORKCENTER";
            this.lbl_WORKCENTER.Size = new System.Drawing.Size(46, 25);
            this.lbl_WORKCENTER.TabIndex = 3;
            this.lbl_WORKCENTER.Text = "W/C";
            this.lbl_WORKCENTER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Insert
            // 
            this.btn_Insert.BackgroundImage = global::FinalProject_Profile.Properties.Resources.입력;
            this.btn_Insert.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Insert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Insert.Location = new System.Drawing.Point(1643, 4);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(87, 89);
            this.btn_Insert.TabIndex = 7;
            this.btn_Insert.UseSelectable = true;
            this.btn_Insert.Click += new System.EventHandler(this.metroButton2_Click);
            this.btn_Insert.MouseDown += new System.Windows.Forms.MouseEventHandler(this.metroButton2_MouseDown);
            this.btn_Insert.MouseUp += new System.Windows.Forms.MouseEventHandler(this.metroButton2_MouseUp);
            // 
            // btn_Decide
            // 
            this.btn_Decide.BackgroundImage = global::FinalProject_Profile.Properties.Resources.확정;
            this.btn_Decide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Decide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Decide.Location = new System.Drawing.Point(1737, 4);
            this.btn_Decide.Name = "btn_Decide";
            this.btn_Decide.Size = new System.Drawing.Size(91, 89);
            this.btn_Decide.TabIndex = 8;
            this.btn_Decide.UseSelectable = true;
            this.btn_Decide.Click += new System.EventHandler(this.metroButton1_Click);
            this.btn_Decide.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Decide_MouseDown);
            this.btn_Decide.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Decide_MouseUp);
            // 
            // lbl_ORDER_TYPE
            // 
            this.lbl_ORDER_TYPE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_ORDER_TYPE.AutoSize = true;
            this.lbl_ORDER_TYPE.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_ORDER_TYPE.Location = new System.Drawing.Point(1300, 36);
            this.lbl_ORDER_TYPE.Name = "lbl_ORDER_TYPE";
            this.lbl_ORDER_TYPE.Size = new System.Drawing.Size(84, 25);
            this.lbl_ORDER_TYPE.TabIndex = 3;
            this.lbl_ORDER_TYPE.Text = "주문구분";
            this.lbl_ORDER_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbo_ORDER_TYPE
            // 
            this.cbo_ORDER_TYPE.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbo_ORDER_TYPE.FormattingEnabled = true;
            this.cbo_ORDER_TYPE.ItemHeight = 23;
            this.cbo_ORDER_TYPE.Items.AddRange(new object[] {
            "전체",
            "계획",
            "주문"});
            this.cbo_ORDER_TYPE.Location = new System.Drawing.Point(1420, 34);
            this.cbo_ORDER_TYPE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_ORDER_TYPE.Name = "cbo_ORDER_TYPE";
            this.cbo_ORDER_TYPE.Size = new System.Drawing.Size(100, 29);
            this.cbo_ORDER_TYPE.TabIndex = 5;
            this.cbo_ORDER_TYPE.UseSelectable = true;
            // 
            // lbl_TEAM
            // 
            this.lbl_TEAM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_TEAM.AutoSize = true;
            this.lbl_TEAM.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_TEAM.Location = new System.Drawing.Point(33, 36);
            this.lbl_TEAM.Name = "lbl_TEAM";
            this.lbl_TEAM.Size = new System.Drawing.Size(66, 25);
            this.lbl_TEAM.TabIndex = 3;
            this.lbl_TEAM.Text = "생산팀";
            this.lbl_TEAM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbo_TEAM
            // 
            this.cbo_TEAM.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbo_TEAM.FormattingEnabled = true;
            this.cbo_TEAM.ItemHeight = 23;
            this.cbo_TEAM.Items.AddRange(new object[] {
            "전체",
            "카매트생산팀"});
            this.cbo_TEAM.Location = new System.Drawing.Point(154, 34);
            this.cbo_TEAM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_TEAM.Name = "cbo_TEAM";
            this.cbo_TEAM.Size = new System.Drawing.Size(129, 29);
            this.cbo_TEAM.TabIndex = 1;
            this.cbo_TEAM.UseSelectable = true;
            this.cbo_TEAM.SelectedIndexChanged += new System.EventHandler(this.cbo_TEAM_SelectedIndexChanged);
            // 
            // grd_Result
            // 
            this.grd_Result.AllowUserToAddRows = false;
            this.grd_Result.AllowUserToDeleteRows = false;
            this.grd_Result.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grd_Result.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grd_Result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grd_Result.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grd_Result.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grd_Result.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grd_Result.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_Result.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grd_Result.ColumnHeadersHeight = 50;
            this.grd_Result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grd_Result.DefaultCellStyle = dataGridViewCellStyle3;
            this.grd_Result.EnableHeadersVisualStyles = false;
            this.grd_Result.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grd_Result.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.grd_Result.Location = new System.Drawing.Point(1, 103);
            this.grd_Result.Margin = new System.Windows.Forms.Padding(0);
            this.grd_Result.MultiSelect = false;
            this.grd_Result.Name = "grd_Result";
            this.grd_Result.ReadOnly = true;
            this.grd_Result.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grd_Result.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grd_Result.RowHeadersVisible = false;
            this.grd_Result.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grd_Result.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grd_Result.RowTemplate.Height = 27;
            this.grd_Result.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grd_Result.Size = new System.Drawing.Size(1838, 615);
            this.grd_Result.TabIndex = 5;
            this.grd_Result.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grd_Result_CellFormatting);
            // 
            // Column11
            // 
            this.Column11.HeaderText = "상태";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "주문량";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "단위";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "제품내역";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "제품코드";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "시장";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "납기요청일";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "추가일";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "주문번호";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "W/C";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "NO";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.grd_Result, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(18, 60);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.36691F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.63309F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1840, 896);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // SAPOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1876, 972);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SAPOrder";
            this.Padding = new System.Windows.Forms.Padding(18, 60, 18, 16);
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "생산계획접수";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Result)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MetroFramework.Controls.MetroComboBox cbo_TEAM;
        private MetroFramework.Controls.MetroLabel lbl_TEAM;
        private MetroFramework.Controls.MetroComboBox cbo_ORDER_TYPE;
        private MetroFramework.Controls.MetroLabel lbl_ORDER_TYPE;
        private MetroFramework.Controls.MetroButton btn_Decide;
        private MetroFramework.Controls.MetroButton btn_Insert;
        private MetroFramework.Controls.MetroLabel lbl_WORKCENTER;
        private MetroFramework.Controls.MetroButton btn_Select;
        private MetroFramework.Controls.MetroLabel lbl_DATE;
        private MetroFramework.Controls.MetroComboBox cbo_WORKCENTER;
        private MetroFramework.Controls.MetroLabel lbl_what;
        private System.Windows.Forms.DateTimePicker dtp_INSERT_DATE_START;
        private System.Windows.Forms.DateTimePicker dtp_INSERT_DATE_END;
        private MetroFramework.Controls.MetroGrid grd_Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

