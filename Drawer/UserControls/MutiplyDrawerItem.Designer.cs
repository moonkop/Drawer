namespace Drawer.UserControls
{
    partial class MutiplyDrawerItem
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxGrade = new System.Windows.Forms.TextBox();
            this.textBoxClassNum = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.buttonSkip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxGrade
            // 
            this.textBoxGrade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxGrade.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxGrade.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxGrade.Location = new System.Drawing.Point(0, 240);
            this.textBoxGrade.Name = "textBoxGrade";
            this.textBoxGrade.Size = new System.Drawing.Size(178, 22);
            this.textBoxGrade.TabIndex = 2;
            // 
            // textBoxClassNum
            // 
            this.textBoxClassNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxClassNum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxClassNum.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxClassNum.Location = new System.Drawing.Point(0, 218);
            this.textBoxClassNum.Name = "textBoxClassNum";
            this.textBoxClassNum.Size = new System.Drawing.Size(178, 22);
            this.textBoxClassNum.TabIndex = 1;
            // 
            // textBoxName
            // 
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxName.Location = new System.Drawing.Point(0, 196);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(178, 22);
            this.textBoxName.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(178, 196);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
  
            // 
            // buttonSkip
            // 
            this.buttonSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSkip.Location = new System.Drawing.Point(124, 173);
            this.buttonSkip.Name = "buttonSkip";
            this.buttonSkip.Size = new System.Drawing.Size(54, 23);
            this.buttonSkip.TabIndex = 4;
            this.buttonSkip.Text = "换一个";
            this.buttonSkip.UseVisualStyleBackColor = true;
            // 
            // MutiplyDrawerItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSkip);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxClassNum);
            this.Controls.Add(this.textBoxGrade);
            this.Name = "MutiplyDrawerItem";
            this.Size = new System.Drawing.Size(178, 262);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxGrade;
        private System.Windows.Forms.TextBox textBoxClassNum;
        private System.Windows.Forms.TextBox textBoxName;
        public System.Windows.Forms.PictureBox pictureBox;
        public System.Windows.Forms.Button buttonSkip;
    }
}
