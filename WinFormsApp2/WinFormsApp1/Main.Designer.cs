namespace WinFormsApp1
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            MessengerCheckBox = new CheckBox();
            FacebookCheckBox = new CheckBox();
            InstagramCheckBox = new CheckBox();
            CommentCheckBox = new CheckBox();
            label5 = new Label();
            textBox1 = new TextBox();
            StartButton = new Button();
            textBox2 = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(169, 130);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(147, 137);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.Location = new Point(402, 125);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(151, 152);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.Location = new Point(644, 125);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(150, 152);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = Properties.Resources.commentlinear_1062301;
            pictureBox4.Location = new Point(866, 130);
            pictureBox4.Margin = new Padding(3, 2, 3, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(151, 137);
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.DeepPink;
            label1.Location = new Point(531, 18);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DeepPink;
            label2.Location = new Point(263, 18);
            label2.Name = "label2";
            label2.Size = new Size(623, 39);
            label2.TabIndex = 5;
            label2.Text = "Welcome to our social media fetcher !";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(528, 81);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DeepPink;
            label4.Location = new Point(422, 62);
            label4.Name = "label4";
            label4.Size = new Size(356, 36);
            label4.TabIndex = 7;
            label4.Text = "Choose your platforms";
            // 
            // MessengerCheckBox
            // 
            MessengerCheckBox.AutoSize = true;
            MessengerCheckBox.BackColor = Color.FromArgb(50, 50, 50);
            MessengerCheckBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MessengerCheckBox.ForeColor = Color.White;
            MessengerCheckBox.Location = new Point(644, 271);
            MessengerCheckBox.Margin = new Padding(3, 2, 3, 2);
            MessengerCheckBox.Name = "MessengerCheckBox";
            MessengerCheckBox.Size = new Size(150, 36);
            MessengerCheckBox.TabIndex = 8;
            MessengerCheckBox.Text = "Messenger";
            MessengerCheckBox.UseVisualStyleBackColor = false;
            // 
            // FacebookCheckBox
            // 
            FacebookCheckBox.AutoSize = true;
            FacebookCheckBox.BackColor = Color.FromArgb(50, 50, 50);
            FacebookCheckBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FacebookCheckBox.ForeColor = Color.White;
            FacebookCheckBox.Location = new Point(182, 271);
            FacebookCheckBox.Margin = new Padding(3, 2, 3, 2);
            FacebookCheckBox.Name = "FacebookCheckBox";
            FacebookCheckBox.Size = new Size(134, 36);
            FacebookCheckBox.TabIndex = 12;
            FacebookCheckBox.Text = "Facebook";
            FacebookCheckBox.UseVisualStyleBackColor = false;
            // 
            // InstagramCheckBox
            // 
            InstagramCheckBox.AutoSize = true;
            InstagramCheckBox.BackColor = Color.FromArgb(50, 50, 50);
            InstagramCheckBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InstagramCheckBox.ForeColor = Color.White;
            InstagramCheckBox.Location = new Point(402, 271);
            InstagramCheckBox.Margin = new Padding(3, 2, 3, 2);
            InstagramCheckBox.Name = "InstagramCheckBox";
            InstagramCheckBox.Size = new Size(138, 36);
            InstagramCheckBox.TabIndex = 13;
            InstagramCheckBox.Text = "Instagram";
            InstagramCheckBox.UseVisualStyleBackColor = false;
            // 
            // CommentCheckBox
            // 
            CommentCheckBox.AutoSize = true;
            CommentCheckBox.BackColor = Color.FromArgb(50, 50, 50);
            CommentCheckBox.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CommentCheckBox.ForeColor = Color.White;
            CommentCheckBox.Location = new Point(866, 271);
            CommentCheckBox.Margin = new Padding(3, 2, 3, 2);
            CommentCheckBox.Name = "CommentCheckBox";
            CommentCheckBox.Size = new Size(139, 36);
            CommentCheckBox.TabIndex = 14;
            CommentCheckBox.Text = "Comment";
            CommentCheckBox.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DeepPink;
            label5.Location = new Point(342, 434);
            label5.Name = "label5";
            label5.Size = new Size(480, 33);
            label5.TabIndex = 15;
            label5.Text = "Enter your Instagram Access key :";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(182, 380);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(835, 38);
            textBox1.TabIndex = 16;
            // 
            // StartButton
            // 
            StartButton.BackColor = Color.DarkSeaGreen;
            StartButton.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartButton.Location = new Point(554, 532);
            StartButton.Margin = new Padding(3, 2, 3, 2);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(128, 38);
            StartButton.TabIndex = 17;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButton_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(182, 473);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Both;
            textBox2.Size = new Size(835, 38);
            textBox2.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Tahoma", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DeepPink;
            label6.Location = new Point(314, 332);
            label6.Name = "label6";
            label6.Size = new Size(542, 33);
            label6.TabIndex = 18;
            label6.Text = "Enter your Facebook Page Access key :";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaptionText;
            ClientSize = new Size(1174, 562);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(StartButton);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(CommentCheckBox);
            Controls.Add(InstagramCheckBox);
            Controls.Add(FacebookCheckBox);
            Controls.Add(MessengerCheckBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Main";
            Text = "Form1";
            Load += Main_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private CheckBox MessengerCheckBox;
        private CheckBox FacebookCheckBox;
        private CheckBox InstagramCheckBox;
        private CheckBox CommentCheckBox;
        private Label label5;
        private TextBox textBox1;
        private Button StartButton;
        private TextBox textBox2;
        private Label label6;
    }
}