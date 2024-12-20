using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Main : Form
    {
        private string fbAccessKey;
        private string instaAccessKey;
        private List<string> selectedPlatforms;
        private List<Form> platformForms; // List to manage platform forms
        private List<Thread> platformThreads; // List to manage platform threads
        private CancellationTokenSource cancellationTokenSource; // Token to signal cancellation

        public Main()
        {
            InitializeComponent();
            selectedPlatforms = new List<string>();
            platformForms = new List<Form>();
            platformThreads = new List<Thread>();
            cancellationTokenSource = new CancellationTokenSource(); // Initialize the cancellation token source
            this.FormClosing += Main_FormClosing; // Subscribe to FormClosing event
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!IsAnyCheckboxChecked())
            {
                MessageBox.Show("Please select at least one social media platform.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (IsFacebookAccessRequired() && string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the Facebook access key.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            fbAccessKey = textBox1.Text;

            if (InstagramCheckBox.Checked && string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter the Instagram access token.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            instaAccessKey = textBox2.Text;

            SaveSelectedPlatforms();
            OpenSelectedPlatformForms();
        }

        private bool IsAnyCheckboxChecked()
        {
            return MessengerCheckBox.Checked || FacebookCheckBox.Checked || InstagramCheckBox.Checked || CommentCheckBox.Checked;
        }

        private bool IsFacebookAccessRequired()
        {
            return MessengerCheckBox.Checked || FacebookCheckBox.Checked || CommentCheckBox.Checked;
        }

        private void SaveSelectedPlatforms()
        {
            selectedPlatforms.Clear();
            if (FacebookCheckBox.Checked) selectedPlatforms.Add("Facebook");
            if (InstagramCheckBox.Checked) selectedPlatforms.Add("Instagram");
            if (MessengerCheckBox.Checked) selectedPlatforms.Add("Messenger");
            if (CommentCheckBox.Checked) selectedPlatforms.Add("Comments");
        }

        private void OpenSelectedPlatformForms()
        {
            foreach (var platform in selectedPlatforms)
            {
                Thread thread = new Thread(() =>
                {
                    Form platformForm = null;
                    switch (platform)
                    {
                        case "Facebook":
                            platformForm = new Facebook(fbAccessKey);
                            break;

                        case "Messenger":
                            platformForm = new Messenger(fbAccessKey);
                            break;

                        case "Instagram":
                            platformForm = new Instagram(instaAccessKey);
                            break;

                        case "Comments":
                            platformForm = new Comments(fbAccessKey);
                            break;
                    }

                    if (platformForm != null)
                    {
                        platformForms.Add(platformForm); // Add form to the list
                        Application.Run(platformForm);
                    }
                });

                thread.SetApartmentState(ApartmentState.STA);
                platformThreads.Add(thread); // Add thread to the list
                thread.Start();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Signal cancellation to threads
            cancellationTokenSource.Cancel();

            // Close all platform forms
            foreach (var form in platformForms)
            {
                if (form.InvokeRequired)
                {
                    form.BeginInvoke(new Action(() => form.Close()));
                }
                else
                {
                    form.Close();
                }
            }

            // Abort all threads (ensure they exit cleanly if possible)
            foreach (var thread in platformThreads)
            {
                if (thread.IsAlive)
                {
                    thread.Join(1); // Wait for a short time for the thread to complete
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
