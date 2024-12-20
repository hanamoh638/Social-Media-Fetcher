namespace WinFormsApp1
{
    partial class Comments
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private PictureBox pictureBox1;
        private FlowLayoutPanel commentsFlowPanel; // FlowLayoutPanel to display comments dynamically

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            pictureBox1 = new PictureBox();
            commentsFlowPanel = new FlowLayoutPanel();
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
            label1.Size = new Size(236, 48);
            label1.TabIndex = 0;
            label1.Text = "Comments";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.commentlinear_1062301;
            pictureBox1.Location = new Point(200, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // commentsFlowPanel
            // 
            commentsFlowPanel.AutoScroll = true;
            commentsFlowPanel.BackColor = Color.LightGray;
            commentsFlowPanel.Location = new Point(50, 130);
            commentsFlowPanel.Name = "commentsFlowPanel";
            commentsFlowPanel.Size = new Size(1100, 580);
            commentsFlowPanel.TabIndex = 4;
            // 
            // Comments
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1217, 732);
            Controls.Add(commentsFlowPanel);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "Comments";
            Text = "Comments";
            Load += Comments_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
