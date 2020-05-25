namespace Task12Generator
{
    partial class RandomGenerator
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
            this.expressionsNumberWarning_label = new System.Windows.Forms.Label();
            this.expressionsNumber_label = new System.Windows.Forms.Label();
            this.expressionsNumber_textBox = new System.Windows.Forms.TextBox();
            this.tasksNumberWarning_label = new System.Windows.Forms.Label();
            this.tasksNumber_label = new System.Windows.Forms.Label();
            this.tasksNumber_textBox = new System.Windows.Forms.TextBox();
            this.generateRandom_button = new System.Windows.Forms.Button();
            this.programNameSubTitle_label = new System.Windows.Forms.Label();
            this.back_button = new System.Windows.Forms.Button();
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
            // expressionsNumberWarning_label
            // 
            this.expressionsNumberWarning_label.AutoSize = true;
            this.expressionsNumberWarning_label.ForeColor = System.Drawing.Color.Red;
            this.expressionsNumberWarning_label.Location = new System.Drawing.Point(851, 395);
            this.expressionsNumberWarning_label.Name = "expressionsNumberWarning_label";
            this.expressionsNumberWarning_label.Size = new System.Drawing.Size(547, 25);
            this.expressionsNumberWarning_label.TabIndex = 16;
            this.expressionsNumberWarning_label.Text = "Количество задач должно быть натуральным числом";
            this.expressionsNumberWarning_label.Visible = false;
            // 
            // expressionsNumber_label
            // 
            this.expressionsNumber_label.AutoSize = true;
            this.expressionsNumber_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expressionsNumber_label.Location = new System.Drawing.Point(848, 240);
            this.expressionsNumber_label.Name = "expressionsNumber_label";
            this.expressionsNumber_label.Size = new System.Drawing.Size(559, 92);
            this.expressionsNumber_label.TabIndex = 15;
            this.expressionsNumber_label.Text = "Сколько задач должно быть\nв каждом варианте?";
            // 
            // expressionsNumber_textBox
            // 
            this.expressionsNumber_textBox.Location = new System.Drawing.Point(856, 352);
            this.expressionsNumber_textBox.Name = "expressionsNumber_textBox";
            this.expressionsNumber_textBox.Size = new System.Drawing.Size(100, 31);
            this.expressionsNumber_textBox.TabIndex = 14;
            this.expressionsNumber_textBox.TextChanged += new System.EventHandler(this.expressionsNumber_textBox_TextChanged);
            // 
            // tasksNumberWarning_label
            // 
            this.tasksNumberWarning_label.AutoSize = true;
            this.tasksNumberWarning_label.ForeColor = System.Drawing.Color.Red;
            this.tasksNumberWarning_label.Location = new System.Drawing.Point(125, 391);
            this.tasksNumberWarning_label.Name = "tasksNumberWarning_label";
            this.tasksNumberWarning_label.Size = new System.Drawing.Size(593, 25);
            this.tasksNumberWarning_label.TabIndex = 13;
            this.tasksNumberWarning_label.Text = "Количество вариантов должно быть натуральным числом";
            this.tasksNumberWarning_label.Visible = false;
            // 
            // tasksNumber_label
            // 
            this.tasksNumber_label.AutoSize = true;
            this.tasksNumber_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tasksNumber_label.Location = new System.Drawing.Point(122, 240);
            this.tasksNumber_label.Name = "tasksNumber_label";
            this.tasksNumber_label.Size = new System.Drawing.Size(515, 92);
            this.tasksNumber_label.TabIndex = 12;
            this.tasksNumber_label.Text = "Сколько вариантов\nвы хотите сгенерировать?";
            // 
            // tasksNumber_textBox
            // 
            this.tasksNumber_textBox.Location = new System.Drawing.Point(130, 352);
            this.tasksNumber_textBox.Name = "tasksNumber_textBox";
            this.tasksNumber_textBox.Size = new System.Drawing.Size(100, 31);
            this.tasksNumber_textBox.TabIndex = 11;
            this.tasksNumber_textBox.TextChanged += new System.EventHandler(this.tasksNumber_textBox_TextChanged);
            // 
            // generateRandom_button
            // 
            this.generateRandom_button.BackColor = System.Drawing.Color.LightSeaGreen;
            this.generateRandom_button.Enabled = false;
            this.generateRandom_button.FlatAppearance.BorderSize = 0;
            this.generateRandom_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateRandom_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateRandom_button.Location = new System.Drawing.Point(545, 500);
            this.generateRandom_button.Name = "generateRandom_button";
            this.generateRandom_button.Size = new System.Drawing.Size(460, 153);
            this.generateRandom_button.TabIndex = 18;
            this.generateRandom_button.Text = "СГЕНЕРИРОВАТЬ СЛУЧАЙНЫЕ ЗАДАЧИ";
            this.generateRandom_button.UseVisualStyleBackColor = false;
            this.generateRandom_button.Click += new System.EventHandler(this.generateRandom_button_Click);
            // 
            // programNameSubTitle_label
            // 
            this.programNameSubTitle_label.AutoSize = true;
            this.programNameSubTitle_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.programNameSubTitle_label.Location = new System.Drawing.Point(537, 128);
            this.programNameSubTitle_label.Name = "programNameSubTitle_label";
            this.programNameSubTitle_label.Size = new System.Drawing.Size(475, 39);
            this.programNameSubTitle_label.TabIndex = 22;
            this.programNameSubTitle_label.Text = "Генератор случайных задач";
            // 
            // back_button
            // 
            this.back_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.back_button.Location = new System.Drawing.Point(30, 60);
            this.back_button.Name = "back_button";
            this.back_button.Size = new System.Drawing.Size(150, 55);
            this.back_button.TabIndex = 23;
            this.back_button.Text = "← НАЗАД";
            this.back_button.UseVisualStyleBackColor = true;
            this.back_button.Click += new System.EventHandler(this.back_button_Click);
            // 
            // RandomGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 729);
            this.Controls.Add(this.back_button);
            this.Controls.Add(this.programNameSubTitle_label);
            this.Controls.Add(this.generateRandom_button);
            this.Controls.Add(this.expressionsNumberWarning_label);
            this.Controls.Add(this.expressionsNumber_label);
            this.Controls.Add(this.expressionsNumber_textBox);
            this.Controls.Add(this.tasksNumberWarning_label);
            this.Controls.Add(this.tasksNumber_label);
            this.Controls.Add(this.tasksNumber_textBox);
            this.Controls.Add(this.programName_label);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1550, 800);
            this.Name = "RandomGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генератор случайных задач";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RandomGenerator_FormClosed);
            this.Load += new System.EventHandler(this.RandomGenerator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label programName_label;
        private System.Windows.Forms.Label expressionsNumberWarning_label;
        private System.Windows.Forms.Label expressionsNumber_label;
        private System.Windows.Forms.TextBox expressionsNumber_textBox;
        private System.Windows.Forms.Label tasksNumberWarning_label;
        private System.Windows.Forms.Label tasksNumber_label;
        private System.Windows.Forms.TextBox tasksNumber_textBox;
        private System.Windows.Forms.Button generateRandom_button;
        private System.Windows.Forms.Label programNameSubTitle_label;
        private System.Windows.Forms.Button back_button;
    }
}