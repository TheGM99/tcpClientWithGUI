﻿
namespace tcpClientWithGUI
{
    partial class FuncForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.textSender = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MessBox = new System.Windows.Forms.TextBox();
            this.ActiveUsersBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(763, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 59);
            this.button2.TabIndex = 1;
            this.button2.Text = "Log out";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // textSender
            // 
            this.textSender.Location = new System.Drawing.Point(303, 408);
            this.textSender.Name = "textSender";
            this.textSender.Size = new System.Drawing.Size(452, 27);
            this.textSender.TabIndex = 2;
            this.textSender.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textSender_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lista Aktywnych Użytkowników";
            // 
            // MessBox
            // 
            this.MessBox.Location = new System.Drawing.Point(303, 25);
            this.MessBox.Multiline = true;
            this.MessBox.Name = "MessBox";
            this.MessBox.ReadOnly = true;
            this.MessBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessBox.Size = new System.Drawing.Size(452, 355);
            this.MessBox.TabIndex = 5;
            // 
            // ActiveUsersBox
            // 
            this.ActiveUsersBox.FormattingEnabled = true;
            this.ActiveUsersBox.ItemHeight = 20;
            this.ActiveUsersBox.Location = new System.Drawing.Point(8, 35);
            this.ActiveUsersBox.Name = "ActiveUsersBox";
            this.ActiveUsersBox.Size = new System.Drawing.Size(280, 344);
            this.ActiveUsersBox.TabIndex = 6;
            this.ActiveUsersBox.Click += new System.EventHandler(this.ActiveUsersBox_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(784, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Zalogowany jako:";
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Location = new System.Drawing.Point(818, 192);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(50, 20);
            this.UserLabel.TabIndex = 9;
            this.UserLabel.Text = "label3";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(13, 385);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(275, 49);
            this.RefreshButton.TabIndex = 10;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.Location = new System.Drawing.Point(763, 87);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(166, 62);
            this.ChangeButton.TabIndex = 11;
            this.ChangeButton.Text = "Change Password";
            this.ChangeButton.UseVisualStyleBackColor = true;
            this.ChangeButton.Click += new System.EventHandler(this.ChangeButton_Click);
            // 
            // FuncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 460);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ActiveUsersBox);
            this.Controls.Add(this.MessBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textSender);
            this.Controls.Add(this.button2);
            this.Name = "FuncForm";
            this.Text = "Functions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textSender;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MessBox;
        private System.Windows.Forms.ListBox ActiveUsersBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button ChangeButton;
    }
}