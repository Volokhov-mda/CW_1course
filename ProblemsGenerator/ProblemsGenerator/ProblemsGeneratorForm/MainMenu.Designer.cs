namespace ProblemsGeneratorForm
{
    partial class MainMenu
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
            this.programNameTitle_label = new System.Windows.Forms.Label();
            this.openGenerator_button = new System.Windows.Forms.Button();
            this.openRandomGenerator_button = new System.Windows.Forms.Button();
            this.openTaskConstructor_button = new System.Windows.Forms.Button();
            this.programNameSubTitle_label = new System.Windows.Forms.Label();
            this.generateKeyWarning_label = new System.Windows.Forms.Label();
            this.generateKey_button = new System.Windows.Forms.Button();
            this.generateKey_textBox = new System.Windows.Forms.TextBox();
            this.generateKey_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // programNameTitle_label
            // 
            this.programNameTitle_label.AutoSize = true;
            this.programNameTitle_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.programNameTitle_label.Location = new System.Drawing.Point(405, 173);
            this.programNameTitle_label.Name = "programNameTitle_label";
            this.programNameTitle_label.Size = new System.Drawing.Size(740, 76);
            this.programNameTitle_label.TabIndex = 1;
            this.programNameTitle_label.Text = "Генератор задач №12";
            // 
            // openGenerator_button
            // 
            this.openGenerator_button.BackColor = System.Drawing.Color.LightSeaGreen;
            this.openGenerator_button.FlatAppearance.BorderSize = 0;
            this.openGenerator_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openGenerator_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openGenerator_button.Location = new System.Drawing.Point(70, 359);
            this.openGenerator_button.Name = "openGenerator_button";
            this.openGenerator_button.Size = new System.Drawing.Size(410, 153);
            this.openGenerator_button.TabIndex = 18;
            this.openGenerator_button.Text = "ГЕНЕРАТОР ЗАДАЧ";
            this.openGenerator_button.UseVisualStyleBackColor = false;
            this.openGenerator_button.Click += new System.EventHandler(this.openGenerator_button_Click);
            // 
            // openRandomGenerator_button
            // 
            this.openRandomGenerator_button.BackColor = System.Drawing.Color.LightSeaGreen;
            this.openRandomGenerator_button.FlatAppearance.BorderSize = 0;
            this.openRandomGenerator_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openRandomGenerator_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openRandomGenerator_button.Location = new System.Drawing.Point(550, 359);
            this.openRandomGenerator_button.Name = "openRandomGenerator_button";
            this.openRandomGenerator_button.Size = new System.Drawing.Size(450, 153);
            this.openRandomGenerator_button.TabIndex = 19;
            this.openRandomGenerator_button.Text = "ГЕНЕРАТОР СЛУЧАЙНЫХ ЗАДАЧ";
            this.openRandomGenerator_button.UseMnemonic = false;
            this.openRandomGenerator_button.UseVisualStyleBackColor = false;
            this.openRandomGenerator_button.Click += new System.EventHandler(this.openRandomGenerator_Click);
            // 
            // openTaskConstructor_button
            // 
            this.openTaskConstructor_button.BackColor = System.Drawing.Color.LightSeaGreen;
            this.openTaskConstructor_button.FlatAppearance.BorderSize = 0;
            this.openTaskConstructor_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openTaskConstructor_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openTaskConstructor_button.Location = new System.Drawing.Point(1070, 359);
            this.openTaskConstructor_button.Name = "openTaskConstructor_button";
            this.openTaskConstructor_button.Size = new System.Drawing.Size(410, 153);
            this.openTaskConstructor_button.TabIndex = 20;
            this.openTaskConstructor_button.Text = "КОНСТРУКТОР ВАРИАНТОВ";
            this.openTaskConstructor_button.UseVisualStyleBackColor = false;
            this.openTaskConstructor_button.Click += new System.EventHandler(this.openTaskConstructor_button_Click);
            // 
            // programNameSubTitle_label
            // 
            this.programNameSubTitle_label.AutoSize = true;
            this.programNameSubTitle_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.programNameSubTitle_label.Location = new System.Drawing.Point(501, 263);
            this.programNameSubTitle_label.Name = "programNameSubTitle_label";
            this.programNameSubTitle_label.Size = new System.Drawing.Size(548, 39);
            this.programNameSubTitle_label.TabIndex = 21;
            this.programNameSubTitle_label.Text = "ЕГЭ по профильной математике";
            // 
            // generateKeyWarning_label
            // 
            this.generateKeyWarning_label.AutoSize = true;
            this.generateKeyWarning_label.ForeColor = System.Drawing.Color.Red;
            this.generateKeyWarning_label.Location = new System.Drawing.Point(764, 593);
            this.generateKeyWarning_label.Name = "generateKeyWarning_label";
            this.generateKeyWarning_label.Size = new System.Drawing.Size(245, 25);
            this.generateKeyWarning_label.TabIndex = 32;
            this.generateKeyWarning_label.Text = "Введен неверный ключ";
            this.generateKeyWarning_label.Visible = false;
            // 
            // generateKey_button
            // 
            this.generateKey_button.BackColor = System.Drawing.Color.LightSeaGreen;
            this.generateKey_button.Enabled = false;
            this.generateKey_button.FlatAppearance.BorderSize = 0;
            this.generateKey_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateKey_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateKey_button.Location = new System.Drawing.Point(528, 709);
            this.generateKey_button.Name = "generateKey_button";
            this.generateKey_button.Size = new System.Drawing.Size(480, 51);
            this.generateKey_button.TabIndex = 31;
            this.generateKey_button.Text = "СГЕНЕРИРОВАТЬ";
            this.generateKey_button.UseVisualStyleBackColor = false;
            this.generateKey_button.Click += new System.EventHandler(this.generateKey_button_Click);
            // 
            // generateKey_textBox
            // 
            this.generateKey_textBox.Location = new System.Drawing.Point(769, 621);
            this.generateKey_textBox.Name = "generateKey_textBox";
            this.generateKey_textBox.Size = new System.Drawing.Size(236, 31);
            this.generateKey_textBox.TabIndex = 30;
            this.generateKey_textBox.TextChanged += new System.EventHandler(this.generateKey_textBox_TextChanged);
            // 
            // generateKey_label
            // 
            this.generateKey_label.AutoSize = true;
            this.generateKey_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateKey_label.Location = new System.Drawing.Point(522, 587);
            this.generateKey_label.Name = "generateKey_label";
            this.generateKey_label.Size = new System.Drawing.Size(231, 93);
            this.generateKey_label.TabIndex = 29;
            this.generateKey_label.Text = "Сгенерировать \r\nзадачи по ключу \r\nгенерации:";
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 879);
            this.Controls.Add(this.generateKeyWarning_label);
            this.Controls.Add(this.generateKey_button);
            this.Controls.Add(this.generateKey_textBox);
            this.Controls.Add(this.generateKey_label);
            this.Controls.Add(this.programNameSubTitle_label);
            this.Controls.Add(this.openTaskConstructor_button);
            this.Controls.Add(this.openRandomGenerator_button);
            this.Controls.Add(this.openGenerator_button);
            this.Controls.Add(this.programNameTitle_label);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1550, 950);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label programNameTitle_label;
        private System.Windows.Forms.Button openGenerator_button;
        private System.Windows.Forms.Button openRandomGenerator_button;
        private System.Windows.Forms.Button openTaskConstructor_button;
        private System.Windows.Forms.Label programNameSubTitle_label;
        private System.Windows.Forms.Label generateKeyWarning_label;
        private System.Windows.Forms.Button generateKey_button;
        private System.Windows.Forms.TextBox generateKey_textBox;
        private System.Windows.Forms.Label generateKey_label;
    }
}