using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Facebook : Form
    {
        private FetchDataTimer fetchDataTimer;
        private string accessKey;

        public Facebook(string accessKey)
        {
            InitializeComponent();
            this.accessKey = accessKey;
            fetchDataTimer = new FetchDataTimer(FetchDataTimerCallback);
            this.Shown += Facebook_Shown; // Subscribe to the Shown event
        }

        private async void Facebook_Shown(object sender, EventArgs e)
        {
            await FetchDataAsync(); // Fetch data asynchronously when the form is shown
            fetchDataTimer.Start(); // Start the timer after the first data fetch
        }

        // Timer callback method
        private async void FetchDataTimerCallback()
        {
            await FetchDataAsync(); // Call the async fetch method
        }

        // Asynchronously fetches Facebook posts and displays them if available
        private async Task FetchDataAsync()
        {
            // Ensure the control handle is created before invoking
            if (!postsPanel.IsHandleCreated)
            {
                postsPanel.HandleCreated += (s, e) => FetchDataAsync();
                return;
            }

            List<(string Message, string CreatedTime)> posts = await Task.Run(() => DataFetcher.GetAllPosts(accessKey));

            if (posts != null)
            {
                // Clear the existing posts from the panel
                postsPanel.Invoke(new Action(() => postsPanel.Controls.Clear()));

                foreach (var post in posts)
                {
                    var postPanel = CreatePostPanel(post.Message, post.CreatedTime);
                    postsPanel.Invoke(new Action(() => postsPanel.Controls.Add(postPanel)));
                }
            }
            else
            {
                // Show an error message if posts couldn't be fetched
                MessageBox.Show("Failed to fetch Facebook posts. Please check your access key or network connection.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Create a panel to display a Facebook post with text and created time
        private Panel CreatePostPanel(string message, string createdTime)
        {
            var panel = new Panel
            {
                Width = 400,
                Height = 100,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightBlue // Set the background color to blue
            };

            var messageLabel = new Label
            {
                Text = message,
                AutoSize = false,
                Width = 380,
                Height = 50,
                Top = 10,
                Left = 10,
                Font = new Font("Tahoma", 10, FontStyle.Bold),
                ForeColor = Color.DarkBlue, // Darker blue text for contrast
                TextAlign = ContentAlignment.TopLeft,
            };

            var timeLabel = new Label
            {
                Text = $"Posted on: {createdTime}",
                AutoSize = false,
                Width = 380,
                Height = 30,
                Top = 60,
                Left = 10,
                Font = new Font("Tahoma", 9, FontStyle.Italic),
                ForeColor = Color.Navy, // Navy blue for the created time
                TextAlign = ContentAlignment.TopLeft,
            };

            panel.Controls.Add(messageLabel);
            panel.Controls.Add(timeLabel);

            return panel;
        }

        private void Facebook_Load(object sender, EventArgs e)
        {

        }
    }
}
