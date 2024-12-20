namespace WinFormsApp1
{
    partial class Instagram
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private PictureBox pictureBox1;
        private FlowLayoutPanel postsPanel;

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

        private void InitializeComponent()
        {
            label1 = new Label();
            pictureBox1 = new PictureBox();
            postsPanel = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DeepPink;
            label1.Location = new Point(350, 20);
            label1.Name = "label1";
            label1.Size = new Size(231, 48);
            label1.TabIndex = 0;
            label1.Text = "Instagram";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Instagram_icon;
            pictureBox1.Location = new Point(200, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // postsPanel
            // 
            postsPanel.AutoScroll = true;
            postsPanel.BackColor = Color.LightGray;
            postsPanel.Location = new Point(50, 130);
            postsPanel.Name = "postsPanel";
            postsPanel.Size = new Size(1100, 580);
            postsPanel.TabIndex = 4;
            // 
            // Instagram
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1217, 732);
            Controls.Add(postsPanel);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "Instagram";
            Text = "Instagram";
            Load += Instagram_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}