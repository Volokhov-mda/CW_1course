namespace ProblemsGeneratorForm
{
    partial class TaskConstructor
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
            this.programName_label = new System.Windows.Forms.Label();
            this.tasksNumberWarning_label = new System.Windows.Forms.Label();
            this.tasksNumber_label = new System.Windows.Forms.Label();
            this.tasksNumber_textBox = new System.Windows.Forms.TextBox();
            this.numOfEveryExprTitle_label = new System.Windows.Forms.Label();
            this.powerExpr_label = new System.Windows.Forms.Label();
            this.quotientExpr_label = new System.Windows.Forms.Label();
            this.expExpr_label = new System.Windows.Forms.Label();
            this.logExpr_label = new System.Windows.Forms.Label();
            this.trigExpr_label = new System.Windows.Forms.Label();
            this.notDerivativeExpr_label = new System.Windows.Forms.Label();
            this.generate_button = new System.Windows.Forms.Button();
            this.powerExpr_textBox = new System.Windows.Forms.TextBox();
            this.quotientExpr_textBox = new System.Windows.Forms.TextBox();
            this.expExpr_textBox = new System.Windows.Forms.TextBox();
            this.logExpr_textBox = new System.Windows.Forms.TextBox();
            this.trigExpr_textBox = new System.Windows.Forms.TextBox();
            this.notDerivativeExpr_textBox = new System.Windows.Forms.TextBox();
            this.back_button = new System.Windows.Forms.Button();
            this.programNameSubTitle_label = new System.Windows.Forms.Label();
            this.expressionsNumberWarning_label = new System.Windows.Forms.Label();
            this.powerExprWarning_label = new System.Windows.Forms.Label();
            this.quotientExprWarning_label = new System.Windows.Forms.Label();
            this.expExprWarning_label = new System.Windows.Forms.Label();
            this.logExprWarning_label = new System.Windows.Forms.Label();
            this.trigExprWarning_label = new System.Windows.Forms.Label();
            this.notDerivativeExprWarning_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // programName_label
            // 
            this.programName_label.AutoSize = true;
            this.programName_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.programName_label.Location = new System.Drawing.Point(405, 38);
            this.programName_label.Name = "programName_label";
            this.programName_label.Size = new System.Drawing.Size(740, 76);
            this.programName_label.TabIndex = 1;
            this.programName_label.Text = "Генератор задач №12";
            // 
            // tasksNumberWarning_label
            // 
            this.tasksNumberWarning_label.AutoSize = true;
            this.tasksNumberWarning_label.ForeColor = System.Drawing.Color.Red;
            this.tasksNumberWarning_label.Location = new System.Drawing.Point(209, 322);
            this.tasksNumberWarning_label.Name = "tasksNumberWarning_label";
            this.tasksNumberWarning_label.Size = new System.Drawing.Size(621, 25);
            this.tasksNumberWarning_label.TabIndex = 9;
            this.tasksNumberWarning_label.Text = "Количество вариантов должно быть положительным числом";
            this.tasksNumberWarning_label.Visible = false;
            // 
            // tasksNumber_label
            // 
            this.tasksNumber_label.AutoSize = true;
            this.tasksNumber_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tasksNumber_label.Location = new System.Drawing.Point(95, 207);
            this.tasksNumber_label.Name = "tasksNumber_label";
            this.tasksNumber_label.Size = new System.Drawing.Size(515, 92);
            this.tasksNumber_label.TabIndex = 8;
            this.tasksNumber_label.Text = "Сколько вариантов\nвы хотите сгенерировать?";
            // 
            // tasksNumber_textBox
            // 
            this.tasksNumber_textBox.Location = new System.Drawing.Point(103, 319);
            this.tasksNumber_textBox.Name = "tasksNumber_textBox";
            this.tasksNumber_textBox.Size = new System.Drawing.Size(100, 31);
            this.tasksNumber_textBox.TabIndex = 7;
            this.tasksNumber_textBox.TextChanged += new System.EventHandler(this.tasksNumber_textBox_TextChanged);
            // 
            // numOfEveryExprTitle_label
            // 
            this.numOfEveryExprTitle_label.AutoSize = true;
            this.numOfEveryExprTitle_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfEveryExprTitle_label.Location = new System.Drawing.Point(93, 384);
            this.numOfEveryExprTitle_label.Name = "numOfEveryExprTitle_label";
            this.numOfEveryExprTitle_label.Size = new System.Drawing.Size(562, 55);
            this.numOfEveryExprTitle_label.TabIndex = 10;
            this.numOfEveryExprTitle_label.Text = "Количество задач типа:";
            // 
            // powerExpr_label
            // 
            this.powerExpr_label.AutoSize = true;
            this.powerExpr_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.powerExpr_label.Location = new System.Drawing.Point(95, 448);
            this.powerExpr_label.Name = "powerExpr_label";
            this.powerExpr_label.Size = new System.Drawing.Size(1069, 46);
            this.powerExpr_label.TabIndex = 11;
            this.powerExpr_label.Text = "• Исследование степенных и иррациональных функций:";
            // 
            // quotientExpr_label
            // 
            this.quotientExpr_label.AutoSize = true;
            this.quotientExpr_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quotientExpr_label.Location = new System.Drawing.Point(95, 508);
            this.quotientExpr_label.Name = "quotientExpr_label";
            this.quotientExpr_label.Size = new System.Drawing.Size(488, 46);
            this.quotientExpr_label.TabIndex = 12;
            this.quotientExpr_label.Text = "• Исследование частных:";
            // 
            // expExpr_label
            // 
            this.expExpr_label.AutoSize = true;
            this.expExpr_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expExpr_label.Location = new System.Drawing.Point(95, 568);
            this.expExpr_label.Name = "expExpr_label";
            this.expExpr_label.Size = new System.Drawing.Size(1103, 46);
            this.expExpr_label.TabIndex = 13;
            this.expExpr_label.Text = "• Исследование показательных функций и произведений:";
            // 
            // logExpr_label
            // 
            this.logExpr_label.AutoSize = true;
            this.logExpr_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logExpr_label.Location = new System.Drawing.Point(95, 628);
            this.logExpr_label.Name = "logExpr_label";
            this.logExpr_label.Size = new System.Drawing.Size(860, 46);
            this.logExpr_label.TabIndex = 14;
            this.logExpr_label.Text = "• Исследование логарифмических функций:";
            // 
            // trigExpr_label
            // 
            this.trigExpr_label.AutoSize = true;
            this.trigExpr_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trigExpr_label.Location = new System.Drawing.Point(95, 688);
            this.trigExpr_label.Name = "trigExpr_label";
            this.trigExpr_label.Size = new System.Drawing.Size(903, 46);
            this.trigExpr_label.TabIndex = 15;
            this.trigExpr_label.Text = "• Исследование тригонометрических функций:";
            // 
            // notDerivativeExpr_label
            // 
            this.notDerivativeExpr_label.AutoSize = true;
            this.notDerivativeExpr_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.notDerivativeExpr_label.Location = new System.Drawing.Point(95, 748);
            this.notDerivativeExpr_label.Name = "notDerivativeExpr_label";
            this.notDerivativeExpr_label.Size = new System.Drawing.Size(995, 46);
            this.notDerivativeExpr_label.TabIndex = 16;
            this.notDerivativeExpr_label.Text = "• Исследование функций без помощи производной:";
            // 
            // generate_button
            // 
            this.generate_button.BackColor = System.Drawing.Color.LightSeaGreen;
            this.generate_button.Enabled = false;
            this.generate_button.FlatAppearance.BorderSize = 0;
            this.generate_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generate_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generate_button.Location = new System.Drawing.Point(570, 839);
            this.generate_button.Name = "generate_button";
            this.generate_button.Size = new System.Drawing.Size(410, 153);
            this.generate_button.TabIndex = 17;
            this.generate_button.Text = "СГЕНЕРИРОВАТЬ ЗАДАЧИ";
            this.generate_button.UseVisualStyleBackColor = false;
            this.generate_button.Click += new System.EventHandler(this.generate_button_Click);
            // 
            // powerExpr_textBox
            // 
            this.powerExpr_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.powerExpr_textBox.Location = new System.Drawing.Point(1225, 458);
            this.powerExpr_textBox.Name = "powerExpr_textBox";
            this.powerExpr_textBox.Size = new System.Drawing.Size(100, 32);
            this.powerExpr_textBox.TabIndex = 19;
            this.powerExpr_textBox.TextChanged += new System.EventHandler(this.powerExpr_textBox_TextChanged);
            // 
            // quotientExpr_textBox
            // 
            this.quotientExpr_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quotientExpr_textBox.Location = new System.Drawing.Point(1225, 518);
            this.quotientExpr_textBox.Name = "quotientExpr_textBox";
            this.quotientExpr_textBox.Size = new System.Drawing.Size(100, 32);
            this.quotientExpr_textBox.TabIndex = 20;
            this.quotientExpr_textBox.TextChanged += new System.EventHandler(this.quotientExpr_textBox_TextChanged);
            // 
            // expExpr_textBox
            // 
            this.expExpr_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expExpr_textBox.Location = new System.Drawing.Point(1225, 578);
            this.expExpr_textBox.Name = "expExpr_textBox";
            this.expExpr_textBox.Size = new System.Drawing.Size(100, 32);
            this.expExpr_textBox.TabIndex = 21;
            this.expExpr_textBox.TextChanged += new System.EventHandler(this.expExpr_textBox_TextChanged);
            // 
            // logExpr_textBox
            // 
            this.logExpr_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logExpr_textBox.Location = new System.Drawing.Point(1225, 638);
            this.logExpr_textBox.Name = "logExpr_textBox";
            this.logExpr_textBox.Size = new System.Drawing.Size(100, 32);
            this.logExpr_textBox.TabIndex = 22;
            this.logExpr_textBox.TextChanged += new System.EventHandler(this.logExpr_textBox_TextChanged);
            // 
            // trigExpr_textBox
            // 
            this.trigExpr_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.trigExpr_textBox.Location = new System.Drawing.Point(1225, 698);
            this.trigExpr_textBox.Name = "trigExpr_textBox";
            this.trigExpr_textBox.Size = new System.Drawing.Size(100, 32);
            this.trigExpr_textBox.TabIndex = 23;
            this.trigExpr_textBox.TextChanged += new System.EventHandler(this.trigExpr_textBox_TextChanged);
            // 
            // notDerivativeExpr_textBox
            // 
            this.notDerivativeExpr_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.notDerivativeExpr_textBox.Location = new System.Drawing.Point(1225, 758);
            this.notDerivativeExpr_textBox.Name = "notDerivativeExpr_textBox";
            this.notDerivativeExpr_textBox.Size = new System.Drawing.Size(100, 32);
            this.notDerivativeExpr_textBox.TabIndex = 24;
            this.notDerivativeExpr_textBox.TextChanged += new System.EventHandler(this.notDerivativeExpr_textBox_TextChanged);
            // 
            // back_button
            // 
            this.back_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.back_button.Location = new System.Drawing.Point(30, 60);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(150, 55);
            this.back_button.TabIndex = 25;
            this.back_button.Text = "← НАЗАД";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // programNameSubTitle_label
            // 
            this.programNameSubTitle_label.AutoSize = true;
            this.programNameSubTitle_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.programNameSubTitle_label.Location = new System.Drawing.Point(575, 128);
            this.programNameSubTitle_label.Name = "programNameSubTitle_label";
            this.programNameSubTitle_label.Size = new System.Drawing.Size(399, 39);
            this.programNameSubTitle_label.TabIndex = 26;
            this.programNameSubTitle_label.Text = "Конструктор вариантов";
            // 
            // expressionsNumberWarning_label
            // 
            this.expressionsNumberWarning_label.AutoSize = true;
            this.expressionsNumberWarning_label.ForeColor = System.Drawing.Color.Red;
            this.expressionsNumberWarning_label.Location = new System.Drawing.Point(1220, 364);
            this.expressionsNumberWarning_label.Name = "expressionsNumberWarning_label";
            this.expressionsNumberWarning_label.Size = new System.Drawing.Size(0, 25);
            this.expressionsNumberWarning_label.TabIndex = 27;
            this.expressionsNumberWarning_label.Visible = false;
            // 
            // powerExprWarning_label
            // 
            this.powerExprWarning_label.AutoSize = true;
            this.powerExprWarning_label.ForeColor = System.Drawing.Color.Red;
            this.powerExprWarning_label.Location = new System.Drawing.Point(1331, 448);
            this.powerExprWarning_label.Name = "powerExprWarning_label";
            this.powerExprWarning_label.Size = new System.Drawing.Size(161, 50);
            this.powerExprWarning_label.TabIndex = 28;
            this.powerExprWarning_label.Text = "Некорректное \r\nзначение";
            this.powerExprWarning_label.Visible = false;
            // 
            // quotientExprWarning_label
            // 
            this.quotientExprWarning_label.AutoSize = true;
            this.quotientExprWarning_label.ForeColor = System.Drawing.Color.Red;
            this.quotientExprWarning_label.Location = new System.Drawing.Point(1331, 508);
            this.quotientExprWarning_label.Name = "quotientExprWarning_label";
            this.quotientExprWarning_label.Size = new System.Drawing.Size(161, 50);
            this.quotientExprWarning_label.TabIndex = 29;
            this.quotientExprWarning_label.Text = "Некорректное \r\nзначение";
            this.quotientExprWarning_label.Visible = false;
            // 
            // expExprWarning_label
            // 
            this.expExprWarning_label.AutoSize = true;
            this.expExprWarning_label.ForeColor = System.Drawing.Color.Red;
            this.expExprWarning_label.Location = new System.Drawing.Point(1331, 568);
            this.expExprWarning_label.Name = "expExprWarning_label";
            this.expExprWarning_label.Size = new System.Drawing.Size(161, 50);
            this.expExprWarning_label.TabIndex = 30;
            this.expExprWarning_label.Text = "Некорректное \r\nзначение";
            this.expExprWarning_label.Visible = false;
            // 
            // logExprWarning_label
            // 
            this.logExprWarning_label.AutoSize = true;
            this.logExprWarning_label.ForeColor = System.Drawing.Color.Red;
            this.logExprWarning_label.Location = new System.Drawing.Point(1331, 628);
            this.logExprWarning_label.Name = "logExprWarning_label";
            this.logExprWarning_label.Size = new System.Drawing.Size(161, 50);
            this.logExprWarning_label.TabIndex = 31;
            this.logExprWarning_label.Text = "Некорректное \r\nзначение";
            this.logExprWarning_label.Visible = false;
            // 
            // trigExprWarning_label
            // 
            this.trigExprWarning_label.AutoSize = true;
            this.trigExprWarning_label.ForeColor = System.Drawing.Color.Red;
            this.trigExprWarning_label.Location = new System.Drawing.Point(1331, 688);
            this.trigExprWarning_label.Name = "trigExprWarning_label";
            this.trigExprWarning_label.Size = new System.Drawing.Size(161, 50);
            this.trigExprWarning_label.TabIndex = 32;
            this.trigExprWarning_label.Text = "Некорректное \r\nзначение";
            this.trigExprWarning_label.Visible = false;
            // 
            // notDerivativeExprWarning_label
            // 
            this.notDerivativeExprWarning_label.AutoSize = true;
            this.notDerivativeExprWarning_label.ForeColor = System.Drawing.Color.Red;
            this.notDerivativeExprWarning_label.Location = new System.Drawing.Point(1331, 748);
            this.notDerivativeExprWarning_label.Name = "notDerivativeExprWarning_label";
            this.notDerivativeExprWarning_label.Size = new System.Drawing.Size(161, 50);
            this.notDerivativeExprWarning_label.TabIndex = 33;
            this.notDerivativeExprWarning_label.Text = "Некорректное \r\nзначение";
            this.notDerivativeExprWarning_label.Visible = false;
            // 
            // TaskConstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 1029);
            this.Controls.Add(this.notDerivativeExprWarning_label);
            this.Controls.Add(this.trigExprWarning_label);
            this.Controls.Add(this.logExprWarning_label);
            this.Controls.Add(this.expExprWarning_label);
            this.Controls.Add(this.quotientExprWarning_label);
            this.Controls.Add(this.powerExprWarning_label);
            this.Controls.Add(this.expressionsNumberWarning_label);
            this.Controls.Add(this.programNameSubTitle_label);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.notDerivativeExpr_textBox);
            this.Controls.Add(this.trigExpr_textBox);
            this.Controls.Add(this.logExpr_textBox);
            this.Controls.Add(this.expExpr_textBox);
            this.Controls.Add(this.quotientExpr_textBox);
            this.Controls.Add(this.powerExpr_textBox);
            this.Controls.Add(this.generate_button);
            this.Controls.Add(this.notDerivativeExpr_label);
            this.Controls.Add(this.trigExpr_label);
            this.Controls.Add(this.logExpr_label);
            this.Controls.Add(this.expExpr_label);
            this.Controls.Add(this.quotientExpr_label);
            this.Controls.Add(this.powerExpr_label);
            this.Controls.Add(this.numOfEveryExprTitle_label);
            this.Controls.Add(this.tasksNumberWarning_label);
            this.Controls.Add(this.tasksNumber_label);
            this.Controls.Add(this.tasksNumber_textBox);
            this.Controls.Add(this.programName_label);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1550, 1100);
            this.Name = "TaskConstructor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конструктор вариантов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TaskConstructor_FormClosed);
            this.Load += new System.EventHandler(this.TaskConstructor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label programName_label;
        private System.Windows.Forms.Label tasksNumberWarning_label;
        private System.Windows.Forms.Label tasksNumber_label;
        private System.Windows.Forms.TextBox tasksNumber_textBox;
        private System.Windows.Forms.Label numOfEveryExprTitle_label;
        private System.Windows.Forms.Label powerExpr_label;
        private System.Windows.Forms.Label quotientExpr_label;
        private System.Windows.Forms.Label expExpr_label;
        private System.Windows.Forms.Label logExpr_label;
        private System.Windows.Forms.Label trigExpr_label;
        private System.Windows.Forms.Label notDerivativeExpr_label;
        private System.Windows.Forms.Button generate_button;
        private System.Windows.Forms.TextBox powerExpr_textBox;
        private System.Windows.Forms.TextBox quotientExpr_textBox;
        private System.Windows.Forms.TextBox expExpr_textBox;
        private System.Windows.Forms.TextBox logExpr_textBox;
        private System.Windows.Forms.TextBox trigExpr_textBox;
        private System.Windows.Forms.TextBox notDerivativeExpr_textBox;
        private System.Windows.Forms.Button back_button;
        private System.Windows.Forms.Label programNameSubTitle_label;
        private System.Windows.Forms.Label expressionsNumberWarning_label;
        private System.Windows.Forms.Label powerExprWarning_label;
        private System.Windows.Forms.Label quotientExprWarning_label;
        private System.Windows.Forms.Label expExprWarning_label;
        private System.Windows.Forms.Label logExprWarning_label;
        private System.Windows.Forms.Label trigExprWarning_label;
        private System.Windows.Forms.Label notDerivativeExprWarning_label;
    }
}