namespace FingerprintCFF
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
            btnRegister = new Button();
            btnVerify = new Button();
            SuspendLayout();
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(319, 109);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(187, 47);
            btnRegister.TabIndex = 0;
            btnRegister.Text = "Registrar";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += button1_Click;
            // 
            // btnVerify
            // 
            btnVerify.Location = new Point(319, 174);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(187, 45);
            btnVerify.TabIndex = 1;
            btnVerify.Text = "Verificar";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += btnVerify_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVerify);
            Controls.Add(btnRegister);
            Name = "Form1";
            Text = "Huella Digital";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnRegister;
        private Button btnVerify;
    }
}