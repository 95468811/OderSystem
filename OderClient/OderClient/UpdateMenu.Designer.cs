namespace OderClient
{
    partial class UpdateMenu
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
            this.lb_mail = new System.Windows.Forms.Label();
            this.txtBox_mail = new System.Windows.Forms.TextBox();
            this.btn_selectMenu = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_mail
            // 
            this.lb_mail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_mail.AutoSize = true;
            this.lb_mail.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_mail.Location = new System.Drawing.Point(233, 318);
            this.lb_mail.Name = "lb_mail";
            this.lb_mail.Size = new System.Drawing.Size(104, 19);
            this.lb_mail.TabIndex = 3;
            this.lb_mail.Text = "電子信箱：";
            // 
            // txtBox_mail
            // 
            this.txtBox_mail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBox_mail.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBox_mail.Location = new System.Drawing.Point(343, 315);
            this.txtBox_mail.Name = "txtBox_mail";
            this.txtBox_mail.Size = new System.Drawing.Size(223, 30);
            this.txtBox_mail.TabIndex = 2;
            this.txtBox_mail.Text = "@gmail.com";
            // 
            // btn_selectMenu
            // 
            this.btn_selectMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_selectMenu.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_selectMenu.Location = new System.Drawing.Point(263, 382);
            this.btn_selectMenu.Name = "btn_selectMenu";
            this.btn_selectMenu.Size = new System.Drawing.Size(94, 34);
            this.btn_selectMenu.TabIndex = 4;
            this.btn_selectMenu.Text = "查詢記錄";
            this.btn_selectMenu.UseVisualStyleBackColor = true;
            this.btn_selectMenu.Click += new System.EventHandler(this.btn_selectMenu_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Update.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Update.Location = new System.Drawing.Point(436, 382);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(94, 34);
            this.btn_Update.TabIndex = 5;
            this.btn_Update.Text = "確認刪除";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // UpdateMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_selectMenu);
            this.Controls.Add(this.lb_mail);
            this.Controls.Add(this.txtBox_mail);
            this.Name = "UpdateMenu";
            this.Text = "UpdateMenu";
            this.Load += new System.EventHandler(this.UpdateMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_mail;
        private System.Windows.Forms.TextBox txtBox_mail;
        private System.Windows.Forms.Button btn_selectMenu;
        private System.Windows.Forms.Button btn_Update;
    }
}