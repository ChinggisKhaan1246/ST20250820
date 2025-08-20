namespace ST
{
    partial class Zform
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.Zeelner = new DevExpress.XtraEditors.TextEdit();
            this.Zeelutas = new DevExpress.XtraEditors.TextEdit();
            this.Zeelcar = new DevExpress.XtraEditors.TextEdit();
            this.Zeeladdress = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton10 = new DevExpress.XtraEditors.SimpleButton();
            this.zeeltulsun = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.Zeelner.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zeelutas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zeelcar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zeeladdress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zeeltulsun.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(41, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Овог нэр";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Утасны дугаар";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 107);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(81, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Машины дугаар";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(63, 145);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(23, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Хаяг";
            // 
            // Zeelner
            // 
            this.Zeelner.Location = new System.Drawing.Point(96, 25);
            this.Zeelner.Name = "Zeelner";
            this.Zeelner.Size = new System.Drawing.Size(200, 20);
            this.Zeelner.TabIndex = 4;
            // 
            // Zeelutas
            // 
            this.Zeelutas.Location = new System.Drawing.Point(96, 63);
            this.Zeelutas.Name = "Zeelutas";
            this.Zeelutas.Size = new System.Drawing.Size(200, 20);
            this.Zeelutas.TabIndex = 5;
            // 
            // Zeelcar
            // 
            this.Zeelcar.Location = new System.Drawing.Point(96, 100);
            this.Zeelcar.Name = "Zeelcar";
            this.Zeelcar.Size = new System.Drawing.Size(200, 20);
            this.Zeelcar.TabIndex = 6;
            // 
            // Zeeladdress
            // 
            this.Zeeladdress.Location = new System.Drawing.Point(96, 138);
            this.Zeeladdress.Name = "Zeeladdress";
            this.Zeeladdress.Size = new System.Drawing.Size(200, 20);
            this.Zeeladdress.TabIndex = 7;
            // 
            // simpleButton10
            // 
            this.simpleButton10.Image = global::ST.Properties.Resources._1490886;
            this.simpleButton10.Location = new System.Drawing.Point(96, 226);
            this.simpleButton10.Name = "simpleButton10";
            this.simpleButton10.Size = new System.Drawing.Size(123, 38);
            this.simpleButton10.TabIndex = 8;
            this.simpleButton10.Text = "&Төлбөр тооцоо";
            this.simpleButton10.Click += new System.EventHandler(this.simpleButton10_Click);
            // 
            // zeeltulsun
            // 
            this.zeeltulsun.EditValue = "0";
            this.zeeltulsun.Location = new System.Drawing.Point(96, 175);
            this.zeeltulsun.Name = "zeeltulsun";
            this.zeeltulsun.Properties.Mask.EditMask = "n";
            this.zeeltulsun.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.zeeltulsun.Size = new System.Drawing.Size(200, 20);
            this.zeeltulsun.TabIndex = 10;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(30, 182);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(56, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Төлсөн дүн";
            // 
            // Zform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 300);
            this.Controls.Add(this.zeeltulsun);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.simpleButton10);
            this.Controls.Add(this.Zeeladdress);
            this.Controls.Add(this.Zeelcar);
            this.Controls.Add(this.Zeelutas);
            this.Controls.Add(this.Zeelner);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "Zform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Зээлээр авсан иргэний мэдээлэл";
            this.Load += new System.EventHandler(this.Zform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Zeelner.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zeelutas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zeelcar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Zeeladdress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zeeltulsun.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton10;
        public DevExpress.XtraEditors.TextEdit Zeelner;
        public DevExpress.XtraEditors.TextEdit Zeelutas;
        public DevExpress.XtraEditors.TextEdit Zeelcar;
        public DevExpress.XtraEditors.TextEdit Zeeladdress;
        public DevExpress.XtraEditors.TextEdit zeeltulsun;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}