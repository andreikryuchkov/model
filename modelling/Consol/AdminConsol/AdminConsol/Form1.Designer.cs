namespace AdminConsol
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.Password1 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Enter Login";
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(139, 46);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(132, 20);
            this.Login.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(316, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Password1
            // 
            this.Password1.AutoSize = true;
            this.Password1.Location = new System.Drawing.Point(24, 77);
            this.Password1.Name = "Password1";
            this.Password1.Size = new System.Drawing.Size(80, 13);
            this.Password1.TabIndex = 3;
            this.Password1.Text = "Enter password";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(139, 73);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(132, 20);
            this.Password.TabIndex = 4;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(435, 136);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Password1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label Password1;
        private System.Windows.Forms.TextBox Password;
    }
}

