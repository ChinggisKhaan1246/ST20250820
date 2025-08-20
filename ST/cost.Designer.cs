namespace ST
{
    partial class cost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cost));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label18 = new System.Windows.Forms.Label();
            this.ognoo = new DevExpress.XtraEditors.DateEdit();
            this.projectID = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.costname = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.projectName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ognoo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ognoo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.label18);
            this.panelControl1.Controls.Add(this.ognoo);
            this.panelControl1.Controls.Add(this.projectID);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.textEdit3);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.costname);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.projectName);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(500, 161);
            this.panelControl1.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(280, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 13);
            this.label18.TabIndex = 25;
            this.label18.Text = "Oгноо";
            // 
            // ognoo
            // 
            this.ognoo.EditValue = null;
            this.ognoo.Location = new System.Drawing.Point(321, 67);
            this.ognoo.Name = "ognoo";
            this.ognoo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ognoo.Properties.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.ognoo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ognoo.Properties.EditFormat.FormatString = "yyyy/MM/dd";
            this.ognoo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ognoo.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.ognoo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ognoo.Size = new System.Drawing.Size(162, 20);
            this.ognoo.TabIndex = 4;
            // 
            // projectID
            // 
            this.projectID.Enabled = false;
            this.projectID.Location = new System.Drawing.Point(276, 108);
            this.projectID.Name = "projectID";
            this.projectID.Size = new System.Drawing.Size(71, 20);
            this.projectID.TabIndex = 16;
            this.projectID.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(353, 102);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(130, 42);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Хадгалах";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(84, 67);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new System.Drawing.Size(129, 20);
            this.textEdit3.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(44, 70);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Зардал";
            // 
            // costname
            // 
            this.costname.Location = new System.Drawing.Point(84, 41);
            this.costname.Name = "costname";
            this.costname.Size = new System.Drawing.Size(399, 20);
            this.costname.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Зардлын нэр";
            // 
            // projectName
            // 
            this.projectName.Enabled = false;
            this.projectName.Location = new System.Drawing.Point(84, 15);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(399, 20);
            this.projectName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Төслийн нэр";
            // 
            // cost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 161);
            this.Controls.Add(this.panelControl1);
            this.KeyPreview = true;
            this.Name = "cost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Зардал бүртгэх";
            this.Load += new System.EventHandler(this.cost_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cost_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ognoo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ognoo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label18;
        private DevExpress.XtraEditors.DateEdit ognoo;
        public DevExpress.XtraEditors.TextEdit projectID;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit costname;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit projectName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}