namespace FingerprintCFF
{
    partial class EventForm
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
            comboEvents = new ComboBox();
            btnNext = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(118, 53);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "ELIGE EL EVENTO ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 82);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 1;
            label2.Text = "Eventos";
            // 
            // comboEvents
            // 
            comboEvents.FormattingEnabled = true;
            comboEvents.Location = new Point(65, 112);
            comboEvents.Name = "comboEvents";
            comboEvents.Size = new Size(229, 23);
            comboEvents.TabIndex = 2;
            comboEvents.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(196, 184);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(124, 33);
            btnNext.TabIndex = 3;
            btnNext.Text = "Continuar";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += button1_Click;
            // 
            // EventForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(392, 248);
            Controls.Add(btnNext);
            Controls.Add(comboEvents);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EventForm";
            Text = "EventForm";
            Load += EventForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox comboEvents;
        private Button btnNext;
    }
}