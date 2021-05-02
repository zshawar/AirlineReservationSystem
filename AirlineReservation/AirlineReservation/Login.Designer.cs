
namespace AirlineReservation
{
    partial class Login
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
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.incorrectUser = new System.Windows.Forms.Label();
            this.incorrectPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 236);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(410, 260);
            this.password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(250, 26);
            this.password.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(405, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Username";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(410, 154);
            this.userName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(250, 26);
            this.userName.TabIndex = 6;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(453, 355);
            this.loginButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(152, 48);
            this.loginButton.TabIndex = 10;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // incorrectUser
            // 
            this.incorrectUser.AutoSize = true;
            this.incorrectUser.Location = new System.Drawing.Point(419, 197);
            this.incorrectUser.Name = "incorrectUser";
            this.incorrectUser.Size = new System.Drawing.Size(0, 20);
            this.incorrectUser.TabIndex = 11;
            // 
            // incorrectPass
            // 
            this.incorrectPass.AutoSize = true;
            this.incorrectPass.Location = new System.Drawing.Point(419, 302);
            this.incorrectPass.Name = "incorrectPass";
            this.incorrectPass.Size = new System.Drawing.Size(0, 20);
            this.incorrectPass.TabIndex = 12;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.incorrectPass);
            this.Controls.Add(this.incorrectUser);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userName);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label incorrectUser;
        private System.Windows.Forms.Label incorrectPass;
    }
}