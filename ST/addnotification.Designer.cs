namespace ST
{
    partial class addnotification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addnotification));
            this.label17 = new System.Windows.Forms.Label();
            this.ognoo = new DevExpress.XtraEditors.DateEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.Nofi = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.username = new DevExpress.XtraEditors.LookUpEdit();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ognoo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ognoo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nofi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.username.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(313, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 72;
            this.label17.Text = "Огноо";
            // 
            // ognoo
            // 
            this.ognoo.EditValue = null;
            this.ognoo.Location = new System.Drawing.Point(354, 12);
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
            this.ognoo.TabIndex = 53;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "мэдэгдэл";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(368, 126);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(148, 42);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Илгээх";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Nofi
            // 
            this.Nofi.Location = new System.Drawing.Point(12, 38);
            this.Nofi.Name = "Nofi";
            this.Nofi.Size = new System.Drawing.Size(504, 73);
            this.Nofi.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(102, 140);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 74;
            this.labelControl2.Text = "Хэн рүү:";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(148, 137);
            this.username.Name = "username";
            this.username.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.username.Properties.NullText = "";
            this.username.Size = new System.Drawing.Size(171, 20);
            this.username.TabIndex = 4;
            this.username.EditValueChanged += new System.EventHandler(this.username_EditValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(15, 126);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "SMS";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(15, 149);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(55, 17);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Etusul";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // addnotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 199);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.ognoo);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Nofi);
            this.Name = "addnotification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Мэдэгдэл илгээх ";
            this.Load += new System.EventHandler(this.addnotification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ognoo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ognoo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nofi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.username.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        public DevExpress.XtraEditors.DateEdit ognoo;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.MemoEdit Nofi;
        public DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit username;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}