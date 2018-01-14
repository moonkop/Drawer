using Drawer.UserControls;

namespace Drawer.Forms
{
    partial class NewMutiplyDrawer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewMutiplyDrawer));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.sizeDragger1 = new Drawer.UserControls.SizeDragger();
            this.toolBoxGroup1 = new Drawer.UserControls.ToolBoxGroup();
            this.BtnSave = new Drawer.UserControls.ToolBoxItem();
            this.BtnMinimize = new Drawer.UserControls.ToolBoxItem();
            this.BtnClose = new Drawer.UserControls.ToolBoxItem();
            this.toolBoxGroup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(870, 663);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(854, 651);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "  ";
            // 
            // sizeDragger1
            // 
            this.sizeDragger1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sizeDragger1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sizeDragger1.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.sizeDragger1.DynamicSizeChangeEnabled = false;
            this.sizeDragger1.Location = new System.Drawing.Point(856, 649);
            this.sizeDragger1.Name = "sizeDragger1";
            this.sizeDragger1.Size = new System.Drawing.Size(15, 14);
            this.sizeDragger1.TabIndex = 12;
            // 
            // toolBoxGroup1
            // 
            this.toolBoxGroup1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toolBoxGroup1.AutoSize = true;
            this.toolBoxGroup1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toolBoxGroup1.BackColor = System.Drawing.Color.White;
            this.toolBoxGroup1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolBoxGroup1.Controls.Add(this.BtnSave);
            this.toolBoxGroup1.Controls.Add(this.BtnMinimize);
            this.toolBoxGroup1.Controls.Add(this.BtnClose);
            this.toolBoxGroup1.Items.Add(this.BtnSave);
            this.toolBoxGroup1.Items.Add(this.BtnMinimize);
            this.toolBoxGroup1.Items.Add(this.BtnClose);
            this.toolBoxGroup1.Location = new System.Drawing.Point(780, 0);
            this.toolBoxGroup1.Name = "toolBoxGroup1";
            this.toolBoxGroup1.Size = new System.Drawing.Size(92, 32);
            this.toolBoxGroup1.TabIndex = 7;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnSave.BackgroundImage = global::Drawer.Properties.Resources.save;
            this.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnSave.Location = new System.Drawing.Point(2, 0);
            this.BtnSave.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(30, 30);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnMinimize.BackgroundImage")));
            this.BtnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnMinimize.Location = new System.Drawing.Point(32, 0);
            this.BtnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(30, 30);
            this.BtnMinimize.TabIndex = 0;
            this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnClose.BackgroundImage = global::Drawer.Properties.Resources.close_600px_1181428_easyicon_net;
            this.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnClose.Location = new System.Drawing.Point(62, 0);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(0);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(30, 30);
            this.BtnClose.TabIndex = 1;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // NewMutiplyDrawer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(870, 663);
            this.Controls.Add(this.sizeDragger1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolBoxGroup1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewMutiplyDrawer";
            this.Text = "NewMutiplyDrawer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewMutiplyDrawer_FormClosing);
            this.Load += new System.EventHandler(this.NewMutiplyDrawer_Load);
            this.toolBoxGroup1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private UserControls.SizeDragger sizeDragger1;
        private UserControls.ToolBoxGroup toolBoxGroup1;
        private ToolBoxItem BtnMinimize;
        private ToolBoxItem BtnClose;
        private ToolBoxItem BtnSave;
    }
}