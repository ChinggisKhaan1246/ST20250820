namespace ST
{
    partial class FUTUREINNOVATION
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FUTUREINNOVATION));
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.regText = new System.Windows.Forms.TextBox();
            this.keyText = new System.Windows.Forms.TextBox();
            this.lookUpEdit1 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Register";
            this.label1.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(438, 120);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(140, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "Гарах";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(259, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(155, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Худалдан авах";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(72, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Хадгалах";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "License Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Register";
            // 
            // regText
            // 
            this.regText.Location = new System.Drawing.Point(92, 51);
            this.regText.Name = "regText";
            this.regText.ReadOnly = true;
            this.regText.Size = new System.Drawing.Size(496, 20);
            this.regText.TabIndex = 19;
            // 
            // keyText
            // 
            this.keyText.Location = new System.Drawing.Point(92, 83);
            this.keyText.Name = "keyText";
            this.keyText.Size = new System.Drawing.Size(496, 20);
            this.keyText.TabIndex = 18;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.EditValue = "Та 99991246, 88992842 дугаарт залгаж програмын ашиглах эрх LICENSE KEY худалдаж а" +
    "вна уу. ";
            this.lookUpEdit1.Location = new System.Drawing.Point(92, 25);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.lookUpEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lookUpEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.lookUpEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.lookUpEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lookUpEdit1.Properties.NullText = "[EditValue is null]";
            this.lookUpEdit1.Size = new System.Drawing.Size(496, 18);
            this.lookUpEdit1.TabIndex = 26;
            this.lookUpEdit1.EditValueChanged += new System.EventHandler(this.lookUpEdit1_EditValueChanged);
            // 
            // FUTUREINNOVATION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 155);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.regText);
            this.Controls.Add(this.keyText);
            this.Controls.Add(this.lookUpEdit1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FUTUREINNOVATION";
            this.Opacity = 0.2D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Эрхийн зөвшөөрөл";
            this.Activated += new System.EventHandler(this.FUTUREINNOVATION_Activated);
            this.Load += new System.EventHandler(this.FUTUREINNOVATION_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox regText;
        private System.Windows.Forms.TextBox keyText;
        private DevExpress.XtraEditors.TextEdit lookUpEdit1;
    }
}