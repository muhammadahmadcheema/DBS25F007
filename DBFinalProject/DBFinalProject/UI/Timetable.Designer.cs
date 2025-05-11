namespace DBFinalProject.UI
{
    partial class Timetable
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonHeader3 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtStartTime = new System.Windows.Forms.MaskedTextBox();
            this.txtEndTime = new System.Windows.Forms.MaskedTextBox();
            this.cmbType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.editTimetable = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTimetable)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.kryptonHeader3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.kryptonDataGridView1, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel12, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.kryptonLabel2, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.kryptonButton1, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.kryptonButton2, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.txtStartTime, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtEndTime, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.cmbType, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.editTimetable, 1, 4);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(227, 84);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.34021F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.536082F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.505155F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.474227F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.731959F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.1134F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.04124F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(599, 388);
            this.tableLayoutPanel3.TabIndex = 23;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kryptonLabel3.Location = new System.Drawing.Point(117, 87);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel3.TabIndex = 29;
            this.kryptonLabel3.Values.Text = "End Time:";
            // 
            // kryptonHeader3
            // 
            this.kryptonHeader3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kryptonHeader3.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Custom1;
            this.kryptonHeader3.Location = new System.Drawing.Point(58, 6);
            this.kryptonHeader3.Name = "kryptonHeader3";
            this.kryptonHeader3.Size = new System.Drawing.Size(183, 31);
            this.kryptonHeader3.TabIndex = 25;
            this.kryptonHeader3.Values.Description = "";
            this.kryptonHeader3.Values.Heading = "Add/Edit Timetable";
            this.kryptonHeader3.Values.Image = null;
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kryptonDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(3, 223);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.Size = new System.Drawing.Size(293, 162);
            this.kryptonDataGridView1.TabIndex = 1;
            this.kryptonDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kryptonDataGridView1_CellClick);
            // 
            // kryptonLabel12
            // 
            this.kryptonLabel12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kryptonLabel12.Location = new System.Drawing.Point(115, 52);
            this.kryptonLabel12.Name = "kryptonLabel12";
            this.kryptonLabel12.Size = new System.Drawing.Size(69, 20);
            this.kryptonLabel12.TabIndex = 26;
            this.kryptonLabel12.Values.Text = "Start Time:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kryptonLabel4.Location = new System.Drawing.Point(112, 118);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel4.TabIndex = 30;
            this.kryptonLabel4.Values.Text = "Select Type:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kryptonLabel2.Location = new System.Drawing.Point(82, 148);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(135, 20);
            this.kryptonLabel2.TabIndex = 28;
            this.kryptonLabel2.Values.Text = "Select TimeSlot to Edit:";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kryptonButton1.Location = new System.Drawing.Point(74, 178);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(151, 36);
            this.kryptonButton1.TabIndex = 31;
            this.kryptonButton1.Values.Text = "Add Slot";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kryptonButton2.Location = new System.Drawing.Point(373, 178);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(151, 36);
            this.kryptonButton2.TabIndex = 32;
            this.kryptonButton2.Values.Text = "Edit Slot";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // txtStartTime
            // 
            this.txtStartTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStartTime.Location = new System.Drawing.Point(367, 52);
            this.txtStartTime.Mask = "00:00";
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(163, 20);
            this.txtStartTime.TabIndex = 33;
            // 
            // txtEndTime
            // 
            this.txtEndTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEndTime.Location = new System.Drawing.Point(367, 87);
            this.txtEndTime.Mask = "00:00";
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(163, 20);
            this.txtEndTime.TabIndex = 34;
            // 
            // cmbType
            // 
            this.cmbType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbType.DropDownWidth = 146;
            this.cmbType.Items.AddRange(new object[] {
            "Lecture",
            "Break"});
            this.cmbType.Location = new System.Drawing.Point(376, 118);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(146, 21);
            this.cmbType.TabIndex = 35;
            // 
            // editTimetable
            // 
            this.editTimetable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.editTimetable.DropDownWidth = 146;
            this.editTimetable.Location = new System.Drawing.Point(376, 147);
            this.editTimetable.Name = "editTimetable";
            this.editTimetable.Size = new System.Drawing.Size(146, 21);
            this.editTimetable.TabIndex = 36;
            // 
            // Timetable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(825, 474);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "Timetable";
            this.Controls.SetChildIndex(this.tableLayoutPanel3, 0);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTimetable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private System.Windows.Forms.MaskedTextBox txtStartTime;
        private System.Windows.Forms.MaskedTextBox txtEndTime;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbType;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox editTimetable;
    }
}
