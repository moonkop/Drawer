namespace WindowsFormsApplication1
{
    partial class StudentStatus
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.textBoxPicPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPickPic = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxClass = new System.Windows.Forms.TextBox();
            this.checkBoxSingle = new System.Windows.Forms.CheckBox();
            this.checkBoxMutiply = new System.Windows.Forms.CheckBox();
            this.checkBoxReport = new System.Windows.Forms.CheckBox();
            this.textBoxMutiplyScore = new System.Windows.Forms.TextBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(266, 376);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // textBoxPicPath
            // 
            this.textBoxPicPath.Location = new System.Drawing.Point(51, 396);
            this.textBoxPicPath.Name = "textBoxPicPath";
            this.textBoxPicPath.Size = new System.Drawing.Size(168, 21);
            this.textBoxPicPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "照片";
            // 
            // buttonPickPic
            // 
            this.buttonPickPic.Location = new System.Drawing.Point(225, 396);
            this.buttonPickPic.Name = "buttonPickPic";
            this.buttonPickPic.Size = new System.Drawing.Size(53, 21);
            this.buttonPickPic.TabIndex = 3;
            this.buttonPickPic.Text = "浏览";
            this.buttonPickPic.UseVisualStyleBackColor = true;
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxID.Location = new System.Drawing.Point(354, 42);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(148, 29);
            this.textBoxID.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(298, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "学号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(298, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "姓名";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxName.Location = new System.Drawing.Point(354, 77);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(148, 29);
            this.textBoxName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(298, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "班级";
            // 
            // textBoxClass
            // 
            this.textBoxClass.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxClass.Location = new System.Drawing.Point(354, 112);
            this.textBoxClass.Name = "textBoxClass";
            this.textBoxClass.Size = new System.Drawing.Size(148, 29);
            this.textBoxClass.TabIndex = 8;
            // 
            // checkBoxSingle
            // 
            this.checkBoxSingle.AutoSize = true;
            this.checkBoxSingle.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.checkBoxSingle.Location = new System.Drawing.Point(303, 158);
            this.checkBoxSingle.Name = "checkBoxSingle";
            this.checkBoxSingle.Size = new System.Drawing.Size(107, 29);
            this.checkBoxSingle.TabIndex = 10;
            this.checkBoxSingle.Text = "单次已抽";
            this.checkBoxSingle.UseVisualStyleBackColor = true;
            // 
            // checkBoxMutiply
            // 
            this.checkBoxMutiply.AutoSize = true;
            this.checkBoxMutiply.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.checkBoxMutiply.Location = new System.Drawing.Point(303, 193);
            this.checkBoxMutiply.Name = "checkBoxMutiply";
            this.checkBoxMutiply.Size = new System.Drawing.Size(107, 29);
            this.checkBoxMutiply.TabIndex = 11;
            this.checkBoxMutiply.Text = "提问已抽";
            this.checkBoxMutiply.UseVisualStyleBackColor = true;
            // 
            // checkBoxReport
            // 
            this.checkBoxReport.AutoSize = true;
            this.checkBoxReport.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.checkBoxReport.Location = new System.Drawing.Point(303, 228);
            this.checkBoxReport.Name = "checkBoxReport";
            this.checkBoxReport.Size = new System.Drawing.Size(107, 29);
            this.checkBoxReport.TabIndex = 12;
            this.checkBoxReport.Text = "报告已抽";
            this.checkBoxReport.UseVisualStyleBackColor = true;
            // 
            // textBoxMutiplyScore
            // 
            this.textBoxMutiplyScore.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxMutiplyScore.Location = new System.Drawing.Point(416, 193);
            this.textBoxMutiplyScore.Name = "textBoxMutiplyScore";
            this.textBoxMutiplyScore.Size = new System.Drawing.Size(94, 29);
            this.textBoxMutiplyScore.TabIndex = 13;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.buttonConfirm.Location = new System.Drawing.Point(432, 373);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(70, 38);
            this.buttonConfirm.TabIndex = 14;
            this.buttonConfirm.Text = "确定";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("微软雅黑", 14.25F);
            this.buttonCancel.Location = new System.Drawing.Point(341, 373);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(69, 38);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // StudentStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 429);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textBoxMutiplyScore);
            this.Controls.Add(this.checkBoxReport);
            this.Controls.Add(this.checkBoxMutiply);
            this.Controls.Add(this.checkBoxSingle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxClass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.buttonPickPic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPicPath);
            this.Controls.Add(this.pictureBox);
            this.Name = "StudentStatus";
            this.Text = "StudentStatus";
            this.Load += new System.EventHandler(this.StudentStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TextBox textBoxPicPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPickPic;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxClass;
        private System.Windows.Forms.CheckBox checkBoxSingle;
        private System.Windows.Forms.CheckBox checkBoxMutiply;
        private System.Windows.Forms.CheckBox checkBoxReport;
        private System.Windows.Forms.TextBox textBoxMutiplyScore;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
    }
}