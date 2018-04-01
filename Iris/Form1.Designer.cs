namespace Iris
{
    partial class Iris
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picBackGround = new System.Windows.Forms.PictureBox();
            this.picNextPreview = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBackGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNextPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // picBackGround
            // 
            this.picBackGround.BackColor = System.Drawing.SystemColors.Control;
            this.picBackGround.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBackGround.Location = new System.Drawing.Point(12, 12);
            this.picBackGround.Name = "picBackGround";
            this.picBackGround.Size = new System.Drawing.Size(311, 490);
            this.picBackGround.TabIndex = 0;
            this.picBackGround.TabStop = false;
            // 
            // picNextPreview
            // 
            this.picNextPreview.BackColor = System.Drawing.SystemColors.Control;
            this.picNextPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picNextPreview.Location = new System.Drawing.Point(379, 63);
            this.picNextPreview.Name = "picNextPreview";
            this.picNextPreview.Size = new System.Drawing.Size(112, 107);
            this.picNextPreview.TabIndex = 1;
            this.picNextPreview.TabStop = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Iris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 565);
            this.Controls.Add(this.picNextPreview);
            this.Controls.Add(this.picBackGround);
            this.KeyPreview = true;
            this.Name = "Iris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "俄罗斯方块";
            ((System.ComponentModel.ISupportInitialize)(this.picBackGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNextPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBackGround;
        private System.Windows.Forms.PictureBox picNextPreview;
        private System.Windows.Forms.Timer timer;
    }
}

