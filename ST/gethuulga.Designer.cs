namespace ST
{
    partial class gethuulga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gethuulga));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.projectID = new DevExpress.XtraEditors.TextEdit();
            this.projectName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 553);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1141, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.progressBarControl1);
            this.panelControl1.Controls.Add(this.projectID);
            this.panelControl1.Controls.Add(this.projectName);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1141, 64);
            this.panelControl1.TabIndex = 2;
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarControl1.Location = new System.Drawing.Point(2, 52);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(1137, 10);
            this.progressBarControl1.TabIndex = 31;
            // 
            // projectID
            // 
            this.projectID.Enabled = false;
            this.projectID.Location = new System.Drawing.Point(626, 12);
            this.projectID.Name = "projectID";
            this.projectID.Size = new System.Drawing.Size(71, 20);
            this.projectID.TabIndex = 30;
            this.projectID.Visible = false;
            // 
            // projectName
            // 
            this.projectName.Enabled = false;
            this.projectName.Location = new System.Drawing.Point(86, 12);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(520, 20);
            this.projectName.TabIndex = 29;
            this.projectName.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 28;
            this.labelControl1.Text = "Төслийн нэр";
            this.labelControl1.Visible = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(993, 5);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(96, 42);
            this.simpleButton2.TabIndex = 27;
            this.simpleButton2.Text = "Хуулга..";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "\"Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls|All Files (*.*)|*.*";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.gridControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 64);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1141, 489);
            this.panelControl2.TabIndex = 3;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1141, 489);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Enabled = false;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(809, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(97, 36);
            this.simpleButton1.TabIndex = 32;
            this.simpleButton1.Text = "Анализ...";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gethuulga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 575);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "gethuulga";
            this.Text = "Хуулга унших";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.gethuulga_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        public DevExpress.XtraEditors.TextEdit projectName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit projectID;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}