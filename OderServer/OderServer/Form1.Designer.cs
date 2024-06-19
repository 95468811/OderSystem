namespace _20113131
{
    partial class OderingManager
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OderingManager));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GoOrder = new System.Windows.Forms.Label();
            this.btn_startAndStop = new System.Windows.Forms.Button();
            this.btn_sendMail = new System.Windows.Forms.Button();
            this.btn_addMenu = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btn_END = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(927, 499);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(108, 676);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "上傳菜單";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(317, 676);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "通知員工";
            // 
            // GoOrder
            // 
            this.GoOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GoOrder.AutoSize = true;
            this.GoOrder.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GoOrder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GoOrder.Location = new System.Drawing.Point(729, 676);
            this.GoOrder.Name = "GoOrder";
            this.GoOrder.Size = new System.Drawing.Size(89, 19);
            this.GoOrder.TabIndex = 6;
            this.GoOrder.Text = "開始點餐";
            // 
            // btn_startAndStop
            // 
            this.btn_startAndStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_startAndStop.BackgroundImage = global::_20113131.Properties.Resources._5453658;
            this.btn_startAndStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_startAndStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_startAndStop.Location = new System.Drawing.Point(717, 546);
            this.btn_startAndStop.Name = "btn_startAndStop";
            this.btn_startAndStop.Size = new System.Drawing.Size(117, 112);
            this.btn_startAndStop.TabIndex = 5;
            this.btn_startAndStop.Tag = "";
            this.btn_startAndStop.UseVisualStyleBackColor = true;
            this.btn_startAndStop.Click += new System.EventHandler(this.btn_startAndStop_Click);
            // 
            // btn_sendMail
            // 
            this.btn_sendMail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_sendMail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_sendMail.BackgroundImage")));
            this.btn_sendMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_sendMail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sendMail.Location = new System.Drawing.Point(305, 546);
            this.btn_sendMail.Name = "btn_sendMail";
            this.btn_sendMail.Size = new System.Drawing.Size(117, 112);
            this.btn_sendMail.TabIndex = 3;
            this.btn_sendMail.Tag = "";
            this.btn_sendMail.UseVisualStyleBackColor = true;
            this.btn_sendMail.Click += new System.EventHandler(this.btn_sendMail_Click);
            // 
            // btn_addMenu
            // 
            this.btn_addMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_addMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_addMenu.BackgroundImage")));
            this.btn_addMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_addMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_addMenu.Location = new System.Drawing.Point(96, 546);
            this.btn_addMenu.Name = "btn_addMenu";
            this.btn_addMenu.Size = new System.Drawing.Size(117, 112);
            this.btn_addMenu.TabIndex = 1;
            this.btn_addMenu.Tag = "";
            this.btn_addMenu.UseVisualStyleBackColor = true;
            this.btn_addMenu.Click += new System.EventHandler(this.btn_addMenu_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(526, 676);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "點餐完成";
            // 
            // btn_END
            // 
            this.btn_END.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_END.BackgroundImage = global::_20113131.Properties.Resources.images__1_;
            this.btn_END.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_END.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_END.Location = new System.Drawing.Point(514, 546);
            this.btn_END.Name = "btn_END";
            this.btn_END.Size = new System.Drawing.Size(117, 112);
            this.btn_END.TabIndex = 7;
            this.btn_END.Tag = "";
            this.btn_END.UseVisualStyleBackColor = true;
            this.btn_END.Click += new System.EventHandler(this.btn_END_Click);
            // 
            // OderingManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(927, 723);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_END);
            this.Controls.Add(this.GoOrder);
            this.Controls.Add(this.btn_startAndStop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_sendMail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_addMenu);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OderingManager";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "點餐系統(整合)";
            this.Load += new System.EventHandler(this.OderingManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_addMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_sendMail;
        private System.Windows.Forms.Label GoOrder;
        private System.Windows.Forms.Button btn_startAndStop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_END;
    }
}

