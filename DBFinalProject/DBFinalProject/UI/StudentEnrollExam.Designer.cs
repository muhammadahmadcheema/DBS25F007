namespace DBFinalProject.UI
{
    partial class StudentEnrollExam
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
            this.kryptonHeader3 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.kryptonDataGridView1 = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.kryptonHeader3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.kryptonDataGridView1, 0, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(227, 81);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 264F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(598, 391);
            this.tableLayoutPanel3.TabIndex = 25;
            // 
            // kryptonHeader3
            // 
            this.kryptonHeader3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kryptonHeader3.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Custom1;
            this.kryptonHeader3.Location = new System.Drawing.Point(231, 9);
            this.kryptonHeader3.Name = "kryptonHeader3";
            this.kryptonHeader3.Size = new System.Drawing.Size(136, 31);
            this.kryptonHeader3.TabIndex = 2;
            this.kryptonHeader3.Values.Description = "";
            this.kryptonHeader3.Values.Heading = "Register Exam";
            this.kryptonHeader3.Values.Image = null;
            // 
            // kryptonDataGridView1
            // 
            this.kryptonDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kryptonDataGridView1.Location = new System.Drawing.Point(3, 109);
            this.kryptonDataGridView1.Name = "kryptonDataGridView1";
            this.kryptonDataGridView1.Size = new System.Drawing.Size(592, 258);
            this.kryptonDataGridView1.TabIndex = 3;
            this.kryptonDataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kryptonDataGridView1_CellClick);
            this.kryptonDataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.kryptonDataGridView1_CellFormatting);
            // 
            // StudentEnrollExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(825, 474);
            this.Controls.Add(this.tableLayoutPanel3);
            this.MinimumSize = new System.Drawing.Size(841, 513);
            this.Name = "StudentEnrollExam";
            this.Controls.SetChildIndex(this.tableLayoutPanel3, 0);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader3;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView kryptonDataGridView1;
    }
}
