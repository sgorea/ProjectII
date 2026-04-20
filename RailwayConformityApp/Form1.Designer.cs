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
            ((System.ComponentModel.ISupportInitialize)dgvElements).BeginInit();
            SuspendLayout();
            // 
            // dgvElements
            // 
            dgvElements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvElements.Location = new Point(48, 21);
            dgvElements.Name = "dgvElements";
            dgvElements.Size = new Size(176, 97);
            dgvElements.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(48, 134);
            button1.Name = "button1";
            button1.Size = new Size(176, 36);
            button1.TabIndex = 1;
            button1.Text = "Actualizeaza lista";
            button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(375, 77);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // txtName
            // 
            txtName.Location = new Point(343, 95);
            txtName.Name = "txtName";
            txtName.Size = new Size(99, 23);
            txtName.TabIndex = 3;
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Location = new Point(343, 147);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(99, 23);
            cmbType.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(375, 173);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(529, 77);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 6;
            label3.Text = "label3";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(498, 95);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(100, 23);
            txtPosition.TabIndex = 7;
            // 
            // btnAddElement
            // 
            btnAddElement.Location = new Point(490, 147);
            btnAddElement.Name = "btnAddElement";
            btnAddElement.Size = new Size(108, 23);
            btnAddElement.TabIndex = 8;
            btnAddElement.Text = "Adauga Element";
            btnAddElement.UseVisualStyleBackColor = true;
            btnAddElement.Click += btnAddElement_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(498, 192);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 23);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Buton stergere";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
