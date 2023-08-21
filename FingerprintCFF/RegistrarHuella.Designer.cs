namespace FingerprintCFF
{
    partial class RegistrarHuella
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
            label1 = new Label();
            label2 = new Label();
            txtCodeStudent = new TextBox();
            txtFingerprint = new TextBox();
            btnRegistrarHuella = new Button();
            btnAgregar = new Button();
            dgvListar = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvListar).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 42);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Codigo:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 72);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 1;
            label2.Text = "Huella:";
            // 
            // txtCodeStudent
            // 
            txtCodeStudent.Location = new Point(121, 34);
            txtCodeStudent.Name = "txtCodeStudent";
            txtCodeStudent.Size = new Size(100, 23);
            txtCodeStudent.TabIndex = 2;
            // 
            // txtFingerprint
            // 
            txtFingerprint.Location = new Point(121, 64);
            txtFingerprint.Name = "txtFingerprint";
            txtFingerprint.Size = new Size(100, 23);
            txtFingerprint.TabIndex = 3;
            // 
            // btnRegistrarHuella
            // 
            btnRegistrarHuella.Location = new Point(253, 68);
            btnRegistrarHuella.Name = "btnRegistrarHuella";
            btnRegistrarHuella.Size = new Size(75, 23);
            btnRegistrarHuella.TabIndex = 4;
            btnRegistrarHuella.Text = "Agregar";
            btnRegistrarHuella.UseVisualStyleBackColor = true;
            btnRegistrarHuella.Click += btnRegistrarHuella_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Enabled = false;
            btnAgregar.Location = new Point(58, 135);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(91, 35);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Registrar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvListar
            // 
            dgvListar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListar.Location = new Point(58, 195);
            dgvListar.Name = "dgvListar";
            dgvListar.RowTemplate.Height = 25;
            dgvListar.Size = new Size(379, 191);
            dgvListar.TabIndex = 6;
            dgvListar.CellContentClick += dgvListar_CellContentClick;
            // 
            // RegistrarHuella
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvListar);
            Controls.Add(btnAgregar);
            Controls.Add(btnRegistrarHuella);
            Controls.Add(txtFingerprint);
            Controls.Add(txtCodeStudent);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegistrarHuella";
            Text = "RegistrarHuella";
            Load += RegistrarHuella_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtCodeStudent;
        private TextBox txtFingerprint;
        private Button btnRegistrarHuella;
        private Button btnAgregar;
        private DataGridView dgvListar;
    }
}