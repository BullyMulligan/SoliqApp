namespace SoliqApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelProductInfoSoliq = new System.Windows.Forms.Label();
            this.labelCountChecksSoliq = new System.Windows.Forms.Label();
            this.buttonStartSoliq = new System.Windows.Forms.Button();
            this.buttonLoadPDF = new System.Windows.Forms.Button();
            this.checkedListSoliq = new System.Windows.Forms.CheckedListBox();
            this.comboBoxCheckListSoliq = new System.Windows.Forms.ComboBox();
            this.tableSoliq = new System.Windows.Forms.DataGridView();
            this.psicColumnSoliq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusColumnSoliq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOpenJsonMySoliq = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabTasnif = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonOpenConnectDB = new System.Windows.Forms.ToolStripDropDownButton();
            this.fieldDataBase = new System.Windows.Forms.ToolStripTextBox();
            this.fieldLocalHost = new System.Windows.Forms.ToolStripTextBox();
            this.fieldUserID = new System.Windows.Forms.ToolStripTextBox();
            this.fieldPassword = new System.Windows.Forms.ToolStripTextBox();
            this.buttonConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.labelCheckCountTasnifDB = new System.Windows.Forms.Label();
            this.checkedListTasnifDataBase = new System.Windows.Forms.CheckedListBox();
            this.comboBoxListChecksTasnifDB = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tableTasnifDataBase = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.openFileJson = new System.Windows.Forms.OpenFileDialog();
            this.saveDialogJson = new System.Windows.Forms.SaveFileDialog();
            this.openDialogPDF = new System.Windows.Forms.OpenFileDialog();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.fieldResponse = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableSoliq)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabTasnif.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableTasnifDataBase)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Location = new System.Drawing.Point(4, 3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(796, 446);
            this.tabMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelProductInfoSoliq);
            this.tabPage1.Controls.Add(this.labelCountChecksSoliq);
            this.tabPage1.Controls.Add(this.buttonStartSoliq);
            this.tabPage1.Controls.Add(this.buttonLoadPDF);
            this.tabPage1.Controls.Add(this.checkedListSoliq);
            this.tabPage1.Controls.Add(this.comboBoxCheckListSoliq);
            this.tabPage1.Controls.Add(this.tableSoliq);
            this.tabPage1.Controls.Add(this.buttonOpenJsonMySoliq);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(788, 417);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "My Soliq";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelProductInfoSoliq
            // 
            this.labelProductInfoSoliq.BackColor = System.Drawing.Color.Bisque;
            this.labelProductInfoSoliq.Location = new System.Drawing.Point(535, 82);
            this.labelProductInfoSoliq.Name = "labelProductInfoSoliq";
            this.labelProductInfoSoliq.Size = new System.Drawing.Size(233, 78);
            this.labelProductInfoSoliq.TabIndex = 7;
            // 
            // labelCountChecksSoliq
            // 
            this.labelCountChecksSoliq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCountChecksSoliq.BackColor = System.Drawing.Color.PaleTurquoise;
            this.labelCountChecksSoliq.Location = new System.Drawing.Point(534, 323);
            this.labelCountChecksSoliq.Name = "labelCountChecksSoliq";
            this.labelCountChecksSoliq.Size = new System.Drawing.Size(235, 42);
            this.labelCountChecksSoliq.TabIndex = 6;
            // 
            // buttonStartSoliq
            // 
            this.buttonStartSoliq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartSoliq.Location = new System.Drawing.Point(666, 380);
            this.buttonStartSoliq.Name = "buttonStartSoliq";
            this.buttonStartSoliq.Size = new System.Drawing.Size(103, 30);
            this.buttonStartSoliq.TabIndex = 5;
            this.buttonStartSoliq.Text = "Start";
            this.buttonStartSoliq.UseVisualStyleBackColor = true;
            this.buttonStartSoliq.Visible = false;
            this.buttonStartSoliq.Click += new System.EventHandler(this.buttonStartSoliq_Click);
            // 
            // buttonLoadPDF
            // 
            this.buttonLoadPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadPDF.Location = new System.Drawing.Point(534, 380);
            this.buttonLoadPDF.Name = "buttonLoadPDF";
            this.buttonLoadPDF.Size = new System.Drawing.Size(105, 30);
            this.buttonLoadPDF.TabIndex = 4;
            this.buttonLoadPDF.Text = "PDF-file";
            this.buttonLoadPDF.UseVisualStyleBackColor = true;
            this.buttonLoadPDF.Click += new System.EventHandler(this.buttonLoadPDF_Click);
            // 
            // checkedListSoliq
            // 
            this.checkedListSoliq.FormattingEnabled = true;
            this.checkedListSoliq.Items.AddRange(new object[] { "Сохранять изменения", "Автозамена ИКПУ", "Авто-бэкап до запуска", "Сохранить json после запуска" });
            this.checkedListSoliq.Location = new System.Drawing.Point(534, 212);
            this.checkedListSoliq.Name = "checkedListSoliq";
            this.checkedListSoliq.Size = new System.Drawing.Size(235, 89);
            this.checkedListSoliq.TabIndex = 3;
            // 
            // comboBoxCheckListSoliq
            // 
            this.comboBoxCheckListSoliq.FormattingEnabled = true;
            this.comboBoxCheckListSoliq.Items.AddRange(new object[] { "Все чеки", "Успешные", "ИКПУ не найден", "Все, кроме успешных", "Не пройденные" });
            this.comboBoxCheckListSoliq.Location = new System.Drawing.Point(534, 45);
            this.comboBoxCheckListSoliq.Name = "comboBoxCheckListSoliq";
            this.comboBoxCheckListSoliq.Size = new System.Drawing.Size(237, 24);
            this.comboBoxCheckListSoliq.TabIndex = 2;
            this.comboBoxCheckListSoliq.Text = "Все чеки";
            this.comboBoxCheckListSoliq.SelectedIndexChanged += new System.EventHandler(this.comboBoxCheckListSoliq_SelectedIndexChanged);
            // 
            // tableSoliq
            // 
            this.tableSoliq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tableSoliq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableSoliq.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableSoliq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableSoliq.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.psicColumnSoliq, this.statusColumnSoliq, this.columnStatus });
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableSoliq.DefaultCellStyle = dataGridViewCellStyle2;
            this.tableSoliq.Location = new System.Drawing.Point(6, 45);
            this.tableSoliq.Name = "tableSoliq";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableSoliq.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tableSoliq.RowTemplate.Height = 24;
            this.tableSoliq.Size = new System.Drawing.Size(510, 365);
            this.tableSoliq.TabIndex = 1;
            this.tableSoliq.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableSoliq_CellEnter);
            // 
            // psicColumnSoliq
            // 
            this.psicColumnSoliq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.psicColumnSoliq.HeaderText = "id";
            this.psicColumnSoliq.MinimumWidth = 100;
            this.psicColumnSoliq.Name = "psicColumnSoliq";
            // 
            // statusColumnSoliq
            // 
            this.statusColumnSoliq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.statusColumnSoliq.HeaderText = "psic";
            this.statusColumnSoliq.MinimumWidth = 100;
            this.statusColumnSoliq.Name = "statusColumnSoliq";
            // 
            // columnStatus
            // 
            this.columnStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.columnStatus.HeaderText = "status";
            this.columnStatus.MinimumWidth = 50;
            this.columnStatus.Name = "columnStatus";
            this.columnStatus.Width = 50;
            // 
            // buttonOpenJsonMySoliq
            // 
            this.buttonOpenJsonMySoliq.Location = new System.Drawing.Point(6, 6);
            this.buttonOpenJsonMySoliq.Name = "buttonOpenJsonMySoliq";
            this.buttonOpenJsonMySoliq.Size = new System.Drawing.Size(94, 33);
            this.buttonOpenJsonMySoliq.TabIndex = 0;
            this.buttonOpenJsonMySoliq.Text = "Open Json ";
            this.buttonOpenJsonMySoliq.UseVisualStyleBackColor = true;
            this.buttonOpenJsonMySoliq.Click += new System.EventHandler(this.buttonOpenJsonMySoliq_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabTasnif);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(788, 417);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tasnif";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabTasnif
            // 
            this.tabTasnif.Controls.Add(this.tabPage3);
            this.tabTasnif.Controls.Add(this.tabPage4);
            this.tabTasnif.Controls.Add(this.tabPage5);
            this.tabTasnif.Location = new System.Drawing.Point(2, 3);
            this.tabTasnif.Name = "tabTasnif";
            this.tabTasnif.SelectedIndex = 0;
            this.tabTasnif.Size = new System.Drawing.Size(785, 413);
            this.tabTasnif.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.fieldResponse);
            this.tabPage3.Controls.Add(this.toolStrip1);
            this.tabPage3.Controls.Add(this.labelCheckCountTasnifDB);
            this.tabPage3.Controls.Add(this.checkedListTasnifDataBase);
            this.tabPage3.Controls.Add(this.comboBoxListChecksTasnifDB);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.tableTasnifDataBase);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(777, 384);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "DataBase";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.buttonOpenConnectDB });
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(771, 27);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonOpenConnectDB
            // 
            this.buttonOpenConnectDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonOpenConnectDB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.fieldDataBase, this.fieldLocalHost, this.fieldUserID, this.fieldPassword, this.buttonConnect });
            this.buttonOpenConnectDB.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpenConnectDB.Image")));
            this.buttonOpenConnectDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOpenConnectDB.Name = "buttonOpenConnectDB";
            this.buttonOpenConnectDB.Size = new System.Drawing.Size(161, 24);
            this.buttonOpenConnectDB.Text = "Connect to DataBase";
            // 
            // fieldDataBase
            // 
            this.fieldDataBase.Name = "fieldDataBase";
            this.fieldDataBase.Size = new System.Drawing.Size(100, 27);
            this.fieldDataBase.Text = "10.20.33.5";
            // 
            // fieldLocalHost
            // 
            this.fieldLocalHost.Name = "fieldLocalHost";
            this.fieldLocalHost.Size = new System.Drawing.Size(100, 27);
            this.fieldLocalHost.Text = "paym_eva";
            // 
            // fieldUserID
            // 
            this.fieldUserID.Name = "fieldUserID";
            this.fieldUserID.Size = new System.Drawing.Size(100, 27);
            this.fieldUserID.Text = "dev-base";
            // 
            // fieldPassword
            // 
            this.fieldPassword.Name = "fieldPassword";
            this.fieldPassword.Size = new System.Drawing.Size(100, 27);
            this.fieldPassword.Text = "Xe3nQx287";
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.SystemColors.Info;
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(160, 24);
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // labelCheckCountTasnifDB
            // 
            this.labelCheckCountTasnifDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCheckCountTasnifDB.BackColor = System.Drawing.Color.PaleTurquoise;
            this.labelCheckCountTasnifDB.Location = new System.Drawing.Point(523, 290);
            this.labelCheckCountTasnifDB.Name = "labelCheckCountTasnifDB";
            this.labelCheckCountTasnifDB.Size = new System.Drawing.Size(235, 42);
            this.labelCheckCountTasnifDB.TabIndex = 9;
            // 
            // checkedListTasnifDataBase
            // 
            this.checkedListTasnifDataBase.FormattingEnabled = true;
            this.checkedListTasnifDataBase.Items.AddRange(new object[] { "Сохранять изменения", "Авто-бэкап до запуска", "Сохранить json после запуска" });
            this.checkedListTasnifDataBase.Location = new System.Drawing.Point(523, 200);
            this.checkedListTasnifDataBase.Name = "checkedListTasnifDataBase";
            this.checkedListTasnifDataBase.Size = new System.Drawing.Size(235, 72);
            this.checkedListTasnifDataBase.TabIndex = 8;
            // 
            // comboBoxListChecksTasnifDB
            // 
            this.comboBoxListChecksTasnifDB.FormattingEnabled = true;
            this.comboBoxListChecksTasnifDB.Items.AddRange(new object[] { "Все чеки", "Успешные", "ИКПУ не найден", "Все, кроме успешных", "Не пройденные" });
            this.comboBoxListChecksTasnifDB.Location = new System.Drawing.Point(521, 45);
            this.comboBoxListChecksTasnifDB.Name = "comboBoxListChecksTasnifDB";
            this.comboBoxListChecksTasnifDB.Size = new System.Drawing.Size(237, 24);
            this.comboBoxListChecksTasnifDB.TabIndex = 7;
            this.comboBoxListChecksTasnifDB.Text = "Все чеки";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(655, 348);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // tableTasnifDataBase
            // 
            this.tableTasnifDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tableTasnifDataBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableTasnifDataBase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.tableTasnifDataBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableTasnifDataBase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3 });
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableTasnifDataBase.DefaultCellStyle = dataGridViewCellStyle5;
            this.tableTasnifDataBase.Location = new System.Drawing.Point(-6, 45);
            this.tableTasnifDataBase.Name = "tableTasnifDataBase";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableTasnifDataBase.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.tableTasnifDataBase.RowTemplate.Height = 24;
            this.tableTasnifDataBase.Size = new System.Drawing.Size(508, 333);
            this.tableTasnifDataBase.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(777, 384);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Json";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(777, 384);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Add Category";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // openDialogPDF
            // 
            this.openDialogPDF.FileName = "openFileDialog1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(23, 23);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(23, 23);
            // 
            // fieldResponse
            // 
            this.fieldResponse.Location = new System.Drawing.Point(523, 80);
            this.fieldResponse.Name = "fieldResponse";
            this.fieldResponse.Size = new System.Drawing.Size(234, 66);
            this.fieldResponse.TabIndex = 11;
            this.fieldResponse.Text = "select id, psic_code, psic_text from catalog_categories where psic_code > 0 and s" + "tatus = 1";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(655, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "Response";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn2.HeaderText = "psic";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "product";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableSoliq)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabTasnif.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableTasnifDataBase)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ToolStripDropDownButton buttonOpenConnectDB;

        private System.Windows.Forms.CheckedListBox checkedListTasnifDataBase;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView tableTasnifDataBase;

        private System.Windows.Forms.RichTextBox fieldResponse;

        private System.Windows.Forms.ToolStripMenuItem buttonConnect;

        private System.Windows.Forms.ToolStripTextBox fieldPassword;

        private System.Windows.Forms.ToolStripTextBox fieldUserID;

        private System.Windows.Forms.ToolStripTextBox fieldLocalHost;

        private System.Windows.Forms.ToolStripTextBox fieldDataBase;

        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;

        private System.Windows.Forms.ToolStrip toolStrip1;

        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;

        private System.Windows.Forms.ComboBox comboBoxListChecksTasnifDB;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label labelCheckCountTasnifDB;

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.OpenFileDialog openDialogPDF;

        private System.Windows.Forms.DataGridViewTextBoxColumn columnStatus;

        private System.Windows.Forms.DataGridViewTextBoxColumn psicColumnSoliq;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusColumnSoliq;

        private System.Windows.Forms.SaveFileDialog saveDialogJson;

        private System.Windows.Forms.OpenFileDialog openFileJson;

        private System.Windows.Forms.Label labelProductInfoSoliq;

        private System.Windows.Forms.Button buttonLoadPDF;
        private System.Windows.Forms.Button buttonStartSoliq;
        private System.Windows.Forms.Label labelCountChecksSoliq;

        private System.Windows.Forms.CheckedListBox checkedListSoliq;

        private System.Windows.Forms.ComboBox comboBoxCheckListSoliq;

        private System.Windows.Forms.DataGridView tableSoliq;

        private System.Windows.Forms.Button buttonOpenJsonMySoliq;

        private System.Windows.Forms.TabPage tabPage5;

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabTasnif;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;

        #endregion
    }
}