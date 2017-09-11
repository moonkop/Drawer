namespace Drawer.UserControls
{
    partial class ToolBoxGroup
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
            this.toolBoxItem1 = new Drawer.Forms.ToolBoxItem();
            this.SuspendLayout();
            // 
            // toolBoxItem1
            // 
            this.toolBoxItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.toolBoxItem1.Location = new System.Drawing.Point(3, 3);
            this.toolBoxItem1.Name = "toolBoxItem1";
            this.toolBoxItem1.Size = new System.Drawing.Size(21, 20);
            this.toolBoxItem1.TabIndex = 0;
            // 
            // ToolBoxGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.toolBoxItem1);
            this.Name = "ToolBoxGroup";
            this.Size = new System.Drawing.Size(27, 26);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.ToolBoxItem toolBoxItem1;
    }
}
