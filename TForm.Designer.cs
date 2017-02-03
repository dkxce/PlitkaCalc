namespace PlitkaCalc
{
    partial class TForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tWi = new System.Windows.Forms.TextBox();
            this.tLe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tGa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ширина (мм):";
            // 
            // tWi
            // 
            this.tWi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tWi.Location = new System.Drawing.Point(96, 15);
            this.tWi.Name = "tWi";
            this.tWi.Size = new System.Drawing.Size(88, 20);
            this.tWi.TabIndex = 1;
            this.tWi.TextChanged += new System.EventHandler(this.tWi_TextChanged);
            // 
            // tLe
            // 
            this.tLe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tLe.Location = new System.Drawing.Point(96, 41);
            this.tLe.Name = "tLe";
            this.tLe.Size = new System.Drawing.Size(88, 20);
            this.tLe.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Длина (мм):";
            // 
            // tGa
            // 
            this.tGa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tGa.Location = new System.Drawing.Point(96, 67);
            this.tGa.Name = "tGa";
            this.tGa.Size = new System.Drawing.Size(88, 20);
            this.tGa.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Отступ (мм):";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(19, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TForm
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 133);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tGa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tLe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tWi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры плитки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox tLe;
        public System.Windows.Forms.TextBox tGa;
        public System.Windows.Forms.TextBox tWi;
    }
}