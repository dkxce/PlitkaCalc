namespace PlitkaCalc
{
    partial class CForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StatusList = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйПрофильToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьПрофильToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьПрофильToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьИзображениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateItm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.Angle45 = new System.Windows.Forms.ToolStripMenuItem();
            this.Angle90 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.размерыПлиткиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.узлыПериметраToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.makeImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.tileEnum = new System.Windows.Forms.ToolStripMenuItem();
            this.drawWalls = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.gOneOne = new System.Windows.Forms.ToolStripMenuItem();
            this.gOneTwo = new System.Windows.Forms.ToolStripMenuItem();
            this.gOneThree = new System.Windows.Forms.ToolStripMenuItem();
            this.gOneFour = new System.Windows.Forms.ToolStripMenuItem();
            this.gOneFive = new System.Windows.Forms.ToolStripMenuItem();
            this.gOneTen = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(442, 515);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // StatusList
            // 
            this.StatusList.BackColor = System.Drawing.SystemColors.Control;
            this.StatusList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StatusList.Dock = System.Windows.Forms.DockStyle.Right;
            this.StatusList.Location = new System.Drawing.Point(442, 24);
            this.StatusList.Multiline = true;
            this.StatusList.Name = "StatusList";
            this.StatusList.Size = new System.Drawing.Size(210, 515);
            this.StatusList.TabIndex = 20;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.параметрыToolStripMenuItem,
            this.GMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйПрофильToolStripMenuItem,
            this.загрузитьПрофильToolStripMenuItem,
            this.сохранитьПрофильToolStripMenuItem,
            this.toolStripMenuItem5,
            this.сохранитьИзображениеToolStripMenuItem,
            this.toolStripMenuItem1,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.файлToolStripMenuItem.Text = "&Файл";
            // 
            // новыйПрофильToolStripMenuItem
            // 
            this.новыйПрофильToolStripMenuItem.Name = "новыйПрофильToolStripMenuItem";
            this.новыйПрофильToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.новыйПрофильToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.новыйПрофильToolStripMenuItem.Text = "Новый профиль";
            this.новыйПрофильToolStripMenuItem.Click += new System.EventHandler(this.новыйПрофильToolStripMenuItem_Click);
            // 
            // загрузитьПрофильToolStripMenuItem
            // 
            this.загрузитьПрофильToolStripMenuItem.Name = "загрузитьПрофильToolStripMenuItem";
            this.загрузитьПрофильToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.загрузитьПрофильToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.загрузитьПрофильToolStripMenuItem.Text = "Загрузить профиль...";
            this.загрузитьПрофильToolStripMenuItem.Click += new System.EventHandler(this.загрузитьПрофильToolStripMenuItem_Click);
            // 
            // сохранитьПрофильToolStripMenuItem
            // 
            this.сохранитьПрофильToolStripMenuItem.Name = "сохранитьПрофильToolStripMenuItem";
            this.сохранитьПрофильToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьПрофильToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.сохранитьПрофильToolStripMenuItem.Text = "Сохранить профиль...";
            this.сохранитьПрофильToolStripMenuItem.Click += new System.EventHandler(this.сохранитьПрофильToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(234, 6);
            // 
            // сохранитьИзображениеToolStripMenuItem
            // 
            this.сохранитьИзображениеToolStripMenuItem.Name = "сохранитьИзображениеToolStripMenuItem";
            this.сохранитьИзображениеToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.сохранитьИзображениеToolStripMenuItem.Text = "Сохранить изображение...";
            this.сохранитьИзображениеToolStripMenuItem.Click += new System.EventHandler(this.сохранитьИзображениеToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(234, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateItm,
            this.toolStripMenuItem2,
            this.Angle45,
            this.Angle90,
            this.toolStripMenuItem3,
            this.размерыПлиткиToolStripMenuItem,
            this.узлыПериметраToolStripMenuItem});
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            // 
            // рассчитатьToolStripMenuItem
            // 
            this.calculateItm.Name = "рассчитатьToolStripMenuItem";
            this.calculateItm.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.calculateItm.Size = new System.Drawing.Size(180, 22);
            this.calculateItm.Text = "Рассчитать";
            this.calculateItm.Click += new System.EventHandler(this.Execute_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // Angle45
            // 
            this.Angle45.Checked = true;
            this.Angle45.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Angle45.Name = "Angle45";
            this.Angle45.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.Angle45.Size = new System.Drawing.Size(180, 22);
            this.Angle45.Text = "Угол 45°";
            this.Angle45.Click += new System.EventHandler(this.Angle45_Click);
            // 
            // Angle90
            // 
            this.Angle90.Name = "Angle90";
            this.Angle90.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.Angle90.Size = new System.Drawing.Size(180, 22);
            this.Angle90.Text = "Угол 90°";
            this.Angle90.Click += new System.EventHandler(this.Angle45_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
            // 
            // размерыПлиткиToolStripMenuItem
            // 
            this.размерыПлиткиToolStripMenuItem.Name = "размерыПлиткиToolStripMenuItem";
            this.размерыПлиткиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.размерыПлиткиToolStripMenuItem.Text = "Размеры плитки...";
            this.размерыПлиткиToolStripMenuItem.Click += new System.EventHandler(this.размерыПлиткиToolStripMenuItem_Click);
            // 
            // узлыПериметраToolStripMenuItem
            // 
            this.узлыПериметраToolStripMenuItem.Name = "узлыПериметраToolStripMenuItem";
            this.узлыПериметраToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.узлыПериметраToolStripMenuItem.Text = "Узлы периметра...";
            this.узлыПериметраToolStripMenuItem.Click += new System.EventHandler(this.узлыПериметраToolStripMenuItem_Click);
            // 
            // GMenu
            // 
            this.GMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeImage,
            this.toolStripMenuItem6,
            this.tileEnum,
            this.drawWalls,
            this.toolStripMenuItem4,
            this.gOneOne,
            this.gOneTwo,
            this.gOneThree,
            this.gOneFour,
            this.gOneFive,
            this.gOneTen});
            this.GMenu.Name = "GMenu";
            this.GMenu.Size = new System.Drawing.Size(57, 20);
            this.GMenu.Text = "График";
            // 
            // makeImage
            // 
            this.makeImage.Checked = true;
            this.makeImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.makeImage.Name = "makeImage";
            this.makeImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.makeImage.Size = new System.Drawing.Size(235, 22);
            this.makeImage.Text = "Выводить рисунок";
            this.makeImage.Click += new System.EventHandler(this.makeImage_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(232, 6);
            // 
            // tileEnum
            // 
            this.tileEnum.Checked = true;
            this.tileEnum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tileEnum.Name = "tileEnum";
            this.tileEnum.Size = new System.Drawing.Size(235, 22);
            this.tileEnum.Text = "Выводить нумерацию плиток";
            this.tileEnum.Click += new System.EventHandler(this.tileEnum_Click);
            // 
            // drawWalls
            // 
            this.drawWalls.Name = "drawWalls";
            this.drawWalls.Size = new System.Drawing.Size(235, 22);
            this.drawWalls.Text = "Рисовать стены";
            this.drawWalls.Click += new System.EventHandler(this.drawWalls_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(232, 6);
            // 
            // gOneOne
            // 
            this.gOneOne.Name = "gOneOne";
            this.gOneOne.Size = new System.Drawing.Size(235, 22);
            this.gOneOne.Text = "График 1:1";
            this.gOneOne.Click += new System.EventHandler(this.gOneOne_Click);
            // 
            // gOneTwo
            // 
            this.gOneTwo.Name = "gOneTwo";
            this.gOneTwo.Size = new System.Drawing.Size(235, 22);
            this.gOneTwo.Text = "График 1:2";
            this.gOneTwo.Click += new System.EventHandler(this.gOneTwo_Click);
            // 
            // gOneThree
            // 
            this.gOneThree.Name = "gOneThree";
            this.gOneThree.Size = new System.Drawing.Size(235, 22);
            this.gOneThree.Text = "График 1:3";
            this.gOneThree.Click += new System.EventHandler(this.gOneThree_Click);
            // 
            // gOneFour
            // 
            this.gOneFour.Name = "gOneFour";
            this.gOneFour.Size = new System.Drawing.Size(235, 22);
            this.gOneFour.Text = "График 1:4";
            this.gOneFour.Click += new System.EventHandler(this.gOneFour_Click);
            // 
            // gOneFive
            // 
            this.gOneFive.Name = "gOneFive";
            this.gOneFive.Size = new System.Drawing.Size(235, 22);
            this.gOneFive.Text = "График 1:5";
            this.gOneFive.Click += new System.EventHandler(this.gOneFive_Click);
            // 
            // gOneTen
            // 
            this.gOneTen.Checked = true;
            this.gOneTen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gOneTen.Name = "gOneTen";
            this.gOneTen.Size = new System.Drawing.Size(235, 22);
            this.gOneTen.Text = "График 1:10";
            this.gOneTen.Click += new System.EventHandler(this.gOneTen_Click);
            // 
            // CForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 539);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.StatusList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CForm";
            this.Text = "Расчет плитки";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox StatusList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новыйПрофильToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьПрофильToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьПрофильToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateItm;
        private System.Windows.Forms.ToolStripMenuItem makeImage;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem Angle45;
        private System.Windows.Forms.ToolStripMenuItem Angle90;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem размерыПлиткиToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem сохранитьИзображениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem узлыПериметраToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GMenu;
        private System.Windows.Forms.ToolStripMenuItem gOneFive;
        private System.Windows.Forms.ToolStripMenuItem drawWalls;
        private System.Windows.Forms.ToolStripMenuItem tileEnum;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem gOneTen;
        private System.Windows.Forms.ToolStripMenuItem gOneTwo;
        private System.Windows.Forms.ToolStripMenuItem gOneFour;
        private System.Windows.Forms.ToolStripMenuItem gOneThree;
        private System.Windows.Forms.ToolStripMenuItem gOneOne;
    }
}

