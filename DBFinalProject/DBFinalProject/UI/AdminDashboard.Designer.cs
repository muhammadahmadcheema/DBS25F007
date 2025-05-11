namespace DBFinalProject.UI
{
    partial class AdminDashboard
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Add/Edit Admin");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Add/Edit Faculty");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Add/Edit Student");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Add/Edit Department Head");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Add/ Edit Technical Staff");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Add/Edit User", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("View/ Change Admin Status");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("View/ Change Faculty Status");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("View/ Change Student Status");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("View/ Change Department Head Status");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("View/ Change Technical Staff");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("View/Change User Status", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Add/Edit Course");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("View/ Remove Course");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Generate Timetable");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Add/Edit Room");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("View/ Remove Rooms");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Add/Edit Semesters");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("View/ Remove Semesters");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Generate / Edit Fee Challan");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Generate Reports");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("AddOrEditDepartment");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("ViewOrRemoveDepartment");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("AddOrEditGrade");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("ViewOrRemoveGrade");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Generate/ EditTimetable");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Assign Course to Faculty");
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.kryptonHeader2 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonTreeView1 = new ComponentFactory.Krypton.Toolkit.KryptonTreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonHeader1.Location = new System.Drawing.Point(3, 3);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.Size = new System.Drawing.Size(819, 71);
            this.kryptonHeader1.TabIndex = 1;
            this.kryptonHeader1.Values.Description = "";
            this.kryptonHeader1.Values.Heading = "UNIVERSITY MANAGEMENT SYSTEM\r\n";
            this.kryptonHeader1.Values.Image = null;
            // 
            // kryptonHeader2
            // 
            this.kryptonHeader2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonHeader2.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this.kryptonHeader2.Location = new System.Drawing.Point(3, 3);
            this.kryptonHeader2.Name = "kryptonHeader2";
            this.kryptonHeader2.Size = new System.Drawing.Size(215, 59);
            this.kryptonHeader2.TabIndex = 21;
            this.kryptonHeader2.Values.Description = "";
            this.kryptonHeader2.Values.Heading = "Admin Dashboard";
            this.kryptonHeader2.Values.Image = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.kryptonHeader1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(825, 77);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // kryptonTreeView1
            // 
            this.kryptonTreeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.kryptonTreeView1.Location = new System.Drawing.Point(3, 68);
            this.kryptonTreeView1.Name = "kryptonTreeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Add/Edit Admin";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Add/Edit Faculty";
            treeNode3.Name = "Node3";
            treeNode3.Text = "Add/Edit Student";
            treeNode4.Name = "Node4";
            treeNode4.Text = "Add/Edit Department Head";
            treeNode5.Name = "Node5";
            treeNode5.Text = "Add/ Edit Technical Staff";
            treeNode6.Name = "Node0";
            treeNode6.Text = "Add/Edit User";
            treeNode7.Name = "Node7";
            treeNode7.Text = "View/ Change Admin Status";
            treeNode8.Name = "Node8";
            treeNode8.Text = "View/ Change Faculty Status";
            treeNode9.Name = "Node9";
            treeNode9.Text = "View/ Change Student Status";
            treeNode10.Name = "Node10";
            treeNode10.Text = "View/ Change Department Head Status";
            treeNode11.Name = "Node11";
            treeNode11.Text = "View/ Change Technical Staff";
            treeNode12.Name = "Node6";
            treeNode12.Text = "View/Change User Status";
            treeNode13.Name = "Node12";
            treeNode13.Text = "Add/Edit Course";
            treeNode14.Name = "Node13";
            treeNode14.Text = "View/ Remove Course";
            treeNode15.Name = "Node14";
            treeNode15.Text = "Generate Timetable";
            treeNode16.Name = "Node15";
            treeNode16.Text = "Add/Edit Room";
            treeNode17.Name = "Node16";
            treeNode17.Text = "View/ Remove Rooms";
            treeNode18.Name = "Node17";
            treeNode18.Text = "Add/Edit Semesters";
            treeNode19.Name = "Node18";
            treeNode19.Text = "View/ Remove Semesters";
            treeNode20.Name = "Node19";
            treeNode20.Text = "Generate / Edit Fee Challan";
            treeNode21.Name = "Node20";
            treeNode21.Text = "Generate Reports";
            treeNode22.Name = "Node21";
            treeNode22.Text = "AddOrEditDepartment";
            treeNode23.Name = "Node22";
            treeNode23.Text = "ViewOrRemoveDepartment";
            treeNode24.Name = "Node23";
            treeNode24.Text = "AddOrEditGrade";
            treeNode25.Name = "Node24";
            treeNode25.Text = "ViewOrRemoveGrade";
            treeNode26.Name = "Node25";
            treeNode26.Text = "Generate/ EditTimetable";
            treeNode27.Name = "Node26";
            treeNode27.Text = "Assign Course to Faculty";
            this.kryptonTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27});
            this.kryptonTreeView1.Size = new System.Drawing.Size(215, 330);
            this.kryptonTreeView1.StateCommon.Back.Color1 = System.Drawing.Color.AliceBlue;
            this.kryptonTreeView1.StateCommon.Node.Content.ShortText.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonTreeView1.TabIndex = 6;
            this.kryptonTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.kryptonTreeView1_AfterSelect);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.kryptonHeader2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.kryptonTreeView1, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 72);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.36598F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.63402F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(221, 401);
            this.tableLayoutPanel2.TabIndex = 22;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 474);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(841, 513);
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        protected ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        protected ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTreeView kryptonTreeView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}