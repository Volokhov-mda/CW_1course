﻿namespace ProblemsGeneratorForm
{
    partial class Generator
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.programName_label = new System.Windows.Forms.Label();
            this.selectExpressionType_label = new System.Windows.Forms.Label();
            this.selectExpressionType_comboBox = new System.Windows.Forms.ComboBox();
            this.generate_button = new System.Windows.Forms.Button();
            this.tasksNumber_textBox = new System.Windows.Forms.TextBox();
            this.tasksNumber_label = new System.Windows.Forms.Label();
            this.tasksNumberWarning_label = new System.Windows.Forms.Label();
            this.expressionsNumber_label = new System.Windows.Forms.Label();
            this.expressionsNumber_textBox = new System.Windows.Forms.TextBox();
            this.expressionsNumberWarning_label = new System.Windows.Forms.Label();
            this.back_button = new System.Windows.Forms.Button();
            this.programNameSubTitle_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // programName_label
            // 
            this.programName_label.AutoSize = true;
            this.programName_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.programName_label.Location = new System.Drawing.Point(405, 38);
            this.programName_label.Name = "programName_label";
            this.programName_label.Size = new System.Drawing.Size(740, 76);
            this.programName_label.TabIndex = 0;
            this.programName_label.Text = "Генератор задач №12";
            // 
            // selectExpressionType_label
            // 
            this.selectExpressionType_label.AutoSize = true;
            this.selectExpressionType_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectExpressionType_label.Location = new System.Drawing.Point(93, 222);
            this.selectExpressionType_label.Name = "selectExpressionType_label";
            this.selectExpressionType_label.Size = new System.Drawing.Size(600, 92);
            this.selectExpressionType_label.TabIndex = 1;
            this.selectExpressionType_label.Text = "Выберите тип выражения,\nкоторый хотите сгенерировать";
            // 
            // selectExpressionType_comboBox
            // 
            this.selectExpressionType_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectExpressionType_comboBox.Items.AddRange(new object[] {
            "Исследование степенных и иррациональных функций",
            "Исследование частных",
            "Исследование показательных функций и произведений",
            "Исследование логарифмических функций",
            "Исследование тригонометрических функций",
            "Исследование функций без помощи производной"});
            this.selectExpressionType_comboBox.Location = new System.Drawing.Point(101, 332);
            this.selectExpressionType_comboBox.Name = "selectExpressionType_comboBox";
            this.selectExpressionType_comboBox.Size = new System.Drawing.Size(632, 33);
            this.selectExpressionType_comboBox.TabIndex = 2;
            this.selectExpressionType_comboBox.SelectedIndexChanged += new System.EventHandler(this.selectExpressionType_comboBox_SelectedIndexChanged);
            // 
            // generate_button
            // 
            this.generate_button.BackColor = System.Drawing.Color.LightSeaGreen;
            this.generate_button.Enabled = false;
            this.generate_button.FlatAppearance.BorderSize = 0;
            this.generate_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generate_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generate_button.Location = new System.Drawing.Point(570, 640);
            this.generate_button.Name = "generate_button";
            this.generate_button.Size = new System.Drawing.Size(410, 153);
            this.generate_button.TabIndex = 3;
            this.generate_button.Text = "СГЕНЕРИРОВАТЬ ЗАДАЧИ";
            this.generate_button.UseVisualStyleBackColor = false;
            this.generate_button.Click += new System.EventHandler(this.generate_button_Click);
            // 
            // tasksNumber_textBox
            // 
            this.tasksNumber_textBox.Location = new System.Drawing.Point(858, 334);
            this.tasksNumber_textBox.Name = "tasksNumber_textBox";
            this.tasksNumber_textBox.Size = new System.Drawing.Size(100, 31);
            this.tasksNumber_textBox.TabIndex = 4;
            this.tasksNumber_textBox.TextChanged += new System.EventHandler(this.tasksNumber_textBox_TextChanged);
            // 
            // tasksNumber_label
            // 
            this.tasksNumber_label.AutoSize = true;
            this.tasksNumber_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tasksNumber_label.Location = new System.Drawing.Point(850, 222);
            this.tasksNumber_label.Name = "tasksNumber_label";
            this.tasksNumber_label.Size = new System.Drawing.Size(515, 92);
            this.tasksNumber_label.TabIndex = 5;
            this.tasksNumber_label.Text = "Сколько вариантов\nвы хотите сгенерировать?";
            // 
            // tasksNumberWarning_label
            // 
            this.tasksNumberWarning_label.AutoSize = true;
            this.tasksNumberWarning_label.ForeColor = System.Drawing.Color.Red;
            this.tasksNumberWarning_label.Location = new System.Drawing.Point(853, 373);
            this.tasksNumberWarning_label.Name = "tasksNumberWarning_label";
            this.tasksNumberWarning_label.Size = new System.Drawing.Size(621, 25);
            this.tasksNumberWarning_label.TabIndex = 6;
            this.tasksNumberWarning_label.Text = "Количество вариантов должно быть положительным числом";
            this.tasksNumberWarning_label.Visible = false;
            // 
            // expressionsNumber_label
            // 
            this.expressionsNumber_label.AutoSize = true;
            this.expressionsNumber_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expressionsNumber_label.Location = new System.Drawing.Point(850, 411);
            this.expressionsNumber_label.Name = "expressionsNumber_label";
            this.expressionsNumber_label.Size = new System.Drawing.Size(559, 92);
            this.expressionsNumber_label.TabIndex = 8;
            this.expressionsNumber_label.Text = "Сколько задач должно быть\nв каждом варианте?";
            // 
            // expressionsNumber_textBox
            // 
            this.expressionsNumber_textBox.Location = new System.Drawing.Point(858, 523);
            this.expressionsNumber_textBox.Name = "expressionsNumber_textBox";
            this.expressionsNumber_textBox.Size = new System.Drawing.Size(100, 31);
            this.expressionsNumber_textBox.TabIndex = 7;
            this.expressionsNumber_textBox.TextChanged += new System.EventHandler(this.expressionsNumber_textBox_TextChanged);
            // 
            // expressionsNumberWarning_label
            // 
            this.expressionsNumberWarning_label.AutoSize = true;
            this.expressionsNumberWarning_label.ForeColor = System.Drawing.Color.Red;
            this.expressionsNumberWarning_label.Location = new System.Drawing.Point(853, 566);
            this.expressionsNumberWarning_label.Name = "expressionsNumberWarning_label";
            this.expressionsNumberWarning_label.Size = new System.Drawing.Size(575, 25);
            this.expressionsNumberWarning_label.TabIndex = 9;
            this.expressionsNumberWarning_label.Text = "Количество задач должно быть положительным числом";
            this.expressionsNumberWarning_label.Visible = false;
            // 
            // back_button
            // 
            this.back_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.back_button.Location = new System.Drawing.Point(30, 60);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(150, 55);
            this.back_button.TabIndex = 12;
            this.back_button.Text = "← НАЗАД";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // programNameSubTitle_label
            // 
            this.programNameSubTitle_label.AutoSize = true;
            this.programNameSubTitle_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.programNameSubTitle_label.Location = new System.Drawing.Point(630, 128);
            this.programNameSubTitle_label.Name = "programNameSubTitle_label";
            this.programNameSubTitle_label.Size = new System.Drawing.Size(290, 39);
            this.programNameSubTitle_label.TabIndex = 22;
            this.programNameSubTitle_label.Text = "Генератор задач";
            // 
            // Generator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 879);
            this.Controls.Add(this.programNameSubTitle_label);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.expressionsNumberWarning_label);
            this.Controls.Add(this.expressionsNumber_label);
            this.Controls.Add(this.expressionsNumber_textBox);
            this.Controls.Add(this.tasksNumberWarning_label);
            this.Controls.Add(this.tasksNumber_label);
            this.Controls.Add(this.tasksNumber_textBox);
            this.Controls.Add(this.generate_button);
            this.Controls.Add(this.selectExpressionType_comboBox);
            this.Controls.Add(this.selectExpressionType_label);
            this.Controls.Add(this.programName_label);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1550, 950);
            this.Name = "Generator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генератор задач из 12 номера ЕГЭ по профильной математике";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Generator_FormClosed);
            this.Load += new System.EventHandler(this.Generator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label programName_label;
        private System.Windows.Forms.Label selectExpressionType_label;
        private System.Windows.Forms.ComboBox selectExpressionType_comboBox;
        private System.Windows.Forms.Button generate_button;
        private System.Windows.Forms.TextBox tasksNumber_textBox;
        private System.Windows.Forms.Label tasksNumber_label;
        private System.Windows.Forms.Label tasksNumberWarning_label;
        private System.Windows.Forms.Label expressionsNumber_label;
        private System.Windows.Forms.TextBox expressionsNumber_textBox;
        private System.Windows.Forms.Label expressionsNumberWarning_label;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Label programNameSubTitle_label;
    }
}

