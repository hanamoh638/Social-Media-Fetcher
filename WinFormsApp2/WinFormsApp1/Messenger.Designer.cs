namespace WinFormsApp1
{
    partial class Messenger
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private PictureBox pictureBox1;
        private FlowLayoutPanel chatsFlowPanel; // FlowLayoutPanel to display chats dynamically

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
            chatsFlowPanel = new FlowLayoutPanel();
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
            label1.Size = new Size(238, 48);
            label1.TabIndex = 0;
            label1.Text = "Messenger";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Facebook_Messenger_logo_2020_svg__1_;
            pictureBox1.Location = new Point(200, 10);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // chatsFlowPanel
            // 
            chatsFlowPanel.AutoScroll = true;
            chatsFlowPanel.BackColor = Color.LightGray;
            chatsFlowPanel.Location = new Point(50, 130);
            chatsFlowPanel.Name = "chatsFlowPanel";
            chatsFlowPanel.Size = new Size(1100, 580);
            chatsFlowPanel.TabIndex = 4;
            // 
            // Messenger
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1217, 732);
            Controls.Add(chatsFlowPanel);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Name = "Messenger";
            Text = "Messenger";
            Load += Messenger_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
