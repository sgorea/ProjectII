namespace RailwayConformityApp
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
            dgvElements = new DataGridView();
            button1 = new Button();
            label1 = new Label();
            txtName = new TextBox();
            cmbType = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            txtPosition = new TextBox();
            btnAddElement = new Button();
            btnDelete = new Button();
            button2 = new Button();
            txtGauge = new TextBox();
            label4 = new Label();
            txtLevel = new TextBox();
            txtArrow = new TextBox();
            label5 = new Label();
            label6 = new Label();
            btnAddMeasurement = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvElements).BeginInit();
            SuspendLayout();
            // 
            // dgvElements
            // 
            dgvElements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvElements.Location = new Point(55, 28);
            dgvElements.Margin = new Padding(3, 4, 3, 4);
            dgvElements.Name = "dgvElements";
            dgvElements.RowHeadersWidth = 51;
            dgvElements.Size = new Size(201, 129);
            dgvElements.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(55, 179);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(201, 48);
            button1.TabIndex = 1;
            button1.Text = "Actualizeaza lista";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(306, 38);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 2;
            label1.Text = "NumeElement";
            // 
            // txtName
            // 
            txtName.Location = new Point(296, 62);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(113, 27);
            txtName.TabIndex = 3;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(296, 149);
            cmbType.Margin = new Padding(3, 4, 3, 4);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(113, 28);
            cmbType.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(306, 125);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 5;
            label2.Text = "TipElement";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(468, 38);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 6;
            label3.Text = "Kilometraj";
            label3.Click += label3_Click;
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(458, 62);
            txtPosition.Margin = new Padding(3, 4, 3, 4);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(114, 27);
            txtPosition.TabIndex = 7;
            // 
            // btnAddElement
            // 
            btnAddElement.Location = new Point(560, 196);
            btnAddElement.Margin = new Padding(3, 4, 3, 4);
            btnAddElement.Name = "btnAddElement";
            btnAddElement.Size = new Size(123, 31);
            btnAddElement.TabIndex = 8;
            btnAddElement.Text = "Adauga Element";
            btnAddElement.UseVisualStyleBackColor = true;
            btnAddElement.Click += btnAddElement_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(569, 256);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(114, 31);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Buton stergere";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(385, 305);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 10;
            button2.Text = "Raport";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // txtGauge
            // 
            txtGauge.Location = new Point(598, 62);
            txtGauge.Name = "txtGauge";
            txtGauge.Size = new Size(125, 27);
            txtGauge.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(633, 39);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 12;
            label4.Text = "Ecartament";
            label4.Click += label4_Click;
            // 
            // txtLevel
            // 
            txtLevel.Location = new Point(447, 149);
            txtLevel.Name = "txtLevel";
            txtLevel.Size = new Size(125, 27);
            txtLevel.TabIndex = 13;
            // 
            // txtArrow
            // 
            txtArrow.Location = new Point(598, 149);
            txtArrow.Name = "txtArrow";
            txtArrow.Size = new Size(125, 27);
            txtArrow.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(468, 125);
            label5.Name = "label5";
            label5.Size = new Size(79, 20);
            label5.TabIndex = 15;
            label5.Text = "Nivel(mm)";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(609, 126);
            label6.Name = "label6";
            label6.Size = new Size(99, 20);
            label6.TabIndex = 16;
            label6.Text = "Sageata(mm)";
            // 
            // btnAddMeasurement
            // 
            btnAddMeasurement.Location = new Point(296, 217);
            btnAddMeasurement.Name = "btnAddMeasurement";
            btnAddMeasurement.Size = new Size(130, 29);
            btnAddMeasurement.TabIndex = 17;
            btnAddMeasurement.Text = "Masuratoare";
            btnAddMeasurement.UseVisualStyleBackColor = true;
            btnAddMeasurement.Click += btnAddMeasurement_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnAddMeasurement);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtArrow);
            Controls.Add(txtLevel);
            Controls.Add(label4);
            Controls.Add(txtGauge);
            Controls.Add(button2);
            Controls.Add(btnDelete);
            Controls.Add(btnAddElement);
            Controls.Add(txtPosition);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbType);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dgvElements);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvElements).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvElements;
        private Button button1;
        private Label label1;
        private TextBox txtName;
        private ComboBox cmbType;
        private Label label2;
        private Label label3;
        private TextBox txtPosition;
        private Button btnAddElement;
        private Button btnDelete;
        private Button button2;
        private TextBox txtGauge;
        private Label label4;
        private TextBox txtLevel;
        private TextBox txtArrow;
        private Label label5;
        private Label label6;
        private Button btnAddMeasurement;
    }
}
