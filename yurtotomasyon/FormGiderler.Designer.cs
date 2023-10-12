namespace yurtotomasyon
{
    partial class FormGiderler
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
            txtelektrik = new TextBox();
            txtsu = new TextBox();
            label2 = new Label();
            txtdogalgaz = new TextBox();
            label3 = new Label();
            txtinternet = new TextBox();
            label4 = new Label();
            txtgida = new TextBox();
            label5 = new Label();
            txtpersonel = new TextBox();
            label6 = new Label();
            txtdiger = new TextBox();
            label7 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(27, 23);
            label1.Name = "label1";
            label1.Size = new Size(82, 25);
            label1.TabIndex = 0;
            label1.Text = "Elektrik :";
            // 
            // txtelektrik
            // 
            txtelektrik.Location = new Point(115, 24);
            txtelektrik.Name = "txtelektrik";
            txtelektrik.Size = new Size(170, 27);
            txtelektrik.TabIndex = 1;
            // 
            // txtsu
            // 
            txtsu.Location = new Point(115, 74);
            txtsu.Name = "txtsu";
            txtsu.Size = new Size(170, 27);
            txtsu.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(67, 74);
            label2.Name = "label2";
            label2.Size = new Size(42, 25);
            label2.TabIndex = 2;
            label2.Text = "Su :";
            // 
            // txtdogalgaz
            // 
            txtdogalgaz.Location = new Point(115, 125);
            txtdogalgaz.Name = "txtdogalgaz";
            txtdogalgaz.Size = new Size(170, 27);
            txtdogalgaz.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(4, 127);
            label3.Name = "label3";
            label3.Size = new Size(105, 25);
            label3.TabIndex = 4;
            label3.Text = "Doğal Gaz :";
            // 
            // txtinternet
            // 
            txtinternet.Location = new Point(115, 168);
            txtinternet.Name = "txtinternet";
            txtinternet.Size = new Size(170, 27);
            txtinternet.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(20, 168);
            label4.Name = "label4";
            label4.Size = new Size(89, 25);
            label4.TabIndex = 6;
            label4.Text = "İnternet :";
            // 
            // txtgida
            // 
            txtgida.Location = new Point(115, 206);
            txtgida.Name = "txtgida";
            txtgida.Size = new Size(170, 27);
            txtgida.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(50, 206);
            label5.Name = "label5";
            label5.Size = new Size(59, 25);
            label5.TabIndex = 8;
            label5.Text = "Gıda :";
            // 
            // txtpersonel
            // 
            txtpersonel.Location = new Point(115, 251);
            txtpersonel.Name = "txtpersonel";
            txtpersonel.Size = new Size(170, 27);
            txtpersonel.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(16, 253);
            label6.Name = "label6";
            label6.Size = new Size(93, 25);
            label6.TabIndex = 10;
            label6.Text = "Personel :";
            // 
            // txtdiger
            // 
            txtdiger.Location = new Point(115, 296);
            txtdiger.Name = "txtdiger";
            txtdiger.Size = new Size(170, 27);
            txtdiger.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(42, 298);
            label7.Name = "label7";
            label7.Size = new Size(67, 25);
            label7.TabIndex = 12;
            label7.Text = "Diğer :";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(303, 330);
            button1.Name = "button1";
            button1.Size = new Size(161, 43);
            button1.TabIndex = 14;
            button1.Text = "Kaydet";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormGiderler
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(485, 387);
            Controls.Add(button1);
            Controls.Add(txtdiger);
            Controls.Add(label7);
            Controls.Add(txtpersonel);
            Controls.Add(label6);
            Controls.Add(txtgida);
            Controls.Add(label5);
            Controls.Add(txtinternet);
            Controls.Add(label4);
            Controls.Add(txtdogalgaz);
            Controls.Add(label3);
            Controls.Add(txtsu);
            Controls.Add(label2);
            Controls.Add(txtelektrik);
            Controls.Add(label1);
            Name = "FormGiderler";
            Text = "FormGiderler";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtelektrik;
        private TextBox txtsu;
        private Label label2;
        private TextBox txtdogalgaz;
        private Label label3;
        private TextBox txtinternet;
        private Label label4;
        private TextBox txtgida;
        private Label label5;
        private TextBox txtpersonel;
        private Label label6;
        private TextBox txtdiger;
        private Label label7;
        private Button button1;
    }
}