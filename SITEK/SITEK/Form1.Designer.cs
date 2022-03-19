namespace SITEK
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rkkButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveAsTxtButton = new System.Windows.Forms.Button();
            this.rkkLabel = new System.Windows.Forms.Label();
            this.appealLabel = new System.Windows.Forms.Label();
            this.appealButton = new System.Windows.Forms.Button();
            this.selectedRkkFile = new System.Windows.Forms.Label();
            this.selectedAppealFile = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Responsible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RKK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Appeals = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fillButton = new System.Windows.Forms.Button();
            this.workTime = new System.Windows.Forms.Label();
            this.workTimeValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // rkkButton
            // 
            this.rkkButton.Location = new System.Drawing.Point(193, 8);
            this.rkkButton.Name = "rkkButton";
            this.rkkButton.Size = new System.Drawing.Size(75, 23);
            this.rkkButton.TabIndex = 0;
            this.rkkButton.Text = "Выбрать";
            this.rkkButton.UseVisualStyleBackColor = true;
            this.rkkButton.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveAsTxtButton
            // 
            this.saveAsTxtButton.Location = new System.Drawing.Point(713, 415);
            this.saveAsTxtButton.Name = "saveAsTxtButton";
            this.saveAsTxtButton.Size = new System.Drawing.Size(75, 23);
            this.saveAsTxtButton.TabIndex = 1;
            this.saveAsTxtButton.Text = "Save as txt";
            this.saveAsTxtButton.UseVisualStyleBackColor = true;
            this.saveAsTxtButton.Click += new System.EventHandler(this.SaveAsTxtButton_Click);
            // 
            // rkkLabel
            // 
            this.rkkLabel.AutoSize = true;
            this.rkkLabel.Location = new System.Drawing.Point(12, 16);
            this.rkkLabel.Name = "rkkLabel";
            this.rkkLabel.Size = new System.Drawing.Size(81, 15);
            this.rkkLabel.TabIndex = 2;
            this.rkkLabel.Text = "Select RKK file";
            // 
            // appealLabel
            // 
            this.appealLabel.AutoSize = true;
            this.appealLabel.Location = new System.Drawing.Point(12, 55);
            this.appealLabel.Name = "appealLabel";
            this.appealLabel.Size = new System.Drawing.Size(100, 15);
            this.appealLabel.TabIndex = 4;
            this.appealLabel.Text = "Select appeals file";
            this.appealLabel.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // appealButton
            // 
            this.appealButton.Location = new System.Drawing.Point(193, 51);
            this.appealButton.Name = "appealButton";
            this.appealButton.Size = new System.Drawing.Size(75, 23);
            this.appealButton.TabIndex = 3;
            this.appealButton.Text = "Выбрать";
            this.appealButton.UseVisualStyleBackColor = true;
            this.appealButton.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // selectedRkkFile
            // 
            this.selectedRkkFile.AutoSize = true;
            this.selectedRkkFile.Location = new System.Drawing.Point(339, 16);
            this.selectedRkkFile.Name = "selectedRkkFile";
            this.selectedRkkFile.Size = new System.Drawing.Size(0, 15);
            this.selectedRkkFile.TabIndex = 5;
            // 
            // selectedAppealFile
            // 
            this.selectedAppealFile.AutoSize = true;
            this.selectedAppealFile.Location = new System.Drawing.Point(339, 55);
            this.selectedAppealFile.Name = "selectedAppealFile";
            this.selectedAppealFile.Size = new System.Drawing.Size(0, 15);
            this.selectedAppealFile.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Responsible,
            this.RKK,
            this.Appeals,
            this.Total});
            this.dataGridView1.Location = new System.Drawing.Point(120, 125);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(587, 313);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.Columns[0].Width = 250;
            dataGridView1.SortCompare += DataGridView1_SortCompare;

            // 
            // Responsible
            // 
            this.Responsible.HeaderText = "Name";
            this.Responsible.Name = "Name";
            // 
            // RKK
            // 
            this.RKK.HeaderText = "RKK";
            this.RKK.Name = "RKK";
            // 
            // Appeals
            // 
            this.Appeals.HeaderText = "Appeals";
            this.Appeals.Name = "Appeals";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // fillButton
            // 
            this.fillButton.Location = new System.Drawing.Point(120, 96);
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(75, 23);
            this.fillButton.TabIndex = 9;
            this.fillButton.Text = "Fill";
            this.fillButton.UseVisualStyleBackColor = true;
            this.fillButton.Click += new System.EventHandler(this.FillButton_Click);
            // 
            // workTime
            // 
            this.workTime.AutoSize = true;
            this.workTime.Location = new System.Drawing.Point(319, 104);
            this.workTime.Name = "workTime";
            this.workTime.Size = new System.Drawing.Size(70, 15);
            this.workTime.TabIndex = 10;
            this.workTime.Text = "Work Time: ";
            // 
            // workTimeValue
            // 
            this.workTimeValue.AutoSize = true;
            this.workTimeValue.Location = new System.Drawing.Point(395, 104);
            this.workTimeValue.Name = "workTimeValue";
            this.workTimeValue.Size = new System.Drawing.Size(0, 15);
            this.workTimeValue.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.workTimeValue);
            this.Controls.Add(this.workTime);
            this.Controls.Add(this.fillButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.selectedAppealFile);
            this.Controls.Add(this.selectedRkkFile);
            this.Controls.Add(this.appealLabel);
            this.Controls.Add(this.appealButton);
            this.Controls.Add(this.rkkLabel);
            this.Controls.Add(this.saveAsTxtButton);
            this.Controls.Add(this.rkkButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button rkkButton;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button saveAsTxtButton;
        private Label rkkLabel;
        private Label appealLabel;
        private Button appealButton;
        private Label selectedRkkFile;
        private Label selectedAppealFile;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Responsible;
        private DataGridViewTextBoxColumn RKK;
        private DataGridViewTextBoxColumn Appeals;
        private DataGridViewTextBoxColumn Total;
        private Button fillButton;
        private Label workTime;
        private Label workTimeValue;
    }
}