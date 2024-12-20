using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Instagram : Form
    {
        private FetchDataTimer fetchDataTimer; // Timer to fetch Instagram posts periodically
        private string accessKey;

        public Instagram(string accessKey)
        {
            InitializeComponent();
            this.accessKey = accessKey;
            fetchDataTimer = new FetchDataTimer(FetchDataTimerCallback);
            this.Shown += Instagram_Shown; // Subscribe to the Shown event
        }

        private async void Instagram_Shown(object sender, EventArgs e)
        {
            await FetchDataAsync(); // Fetch data asynchronously when the form is shown
            fetchDataTimer.Start(); // Start the timer after the first data fetch
        }

        // Timer callback method
        private async void FetchDataTimerCallback()
        {
            await FetchDataAsync(); // Call the async fetch method
        }

        // Asynchronously fetch Instagram posts using the accessKey.
        private async Task FetchDataAsync()
        {
            List<InstagramPost> posts = await Task.Run(() => DataFetcher.FetchInstagramPosts(accessKey));

            if (posts != null)
            {
                // Clear the existing posts from the panel
                postsPanel.Invoke(new Action(() => postsPanel.Controls.Clear()));

                foreach (var post in posts)
                {
                    var postPanel = CreatePostPanel(post.MediaUrl, post.Caption);
                    postsPanel.Invoke(new Action(() => postsPanel.Controls.Add(postPanel)));
                }
            }
            else
            {
                // Show an error message if posts couldn't be fetched
                MessageBox.Show("Failed to fetch Instagram posts. Please check your access key or network connection.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Create a panel to display an Instagram post with image and caption
        private Panel CreatePostPanel(string imageUrl, string caption)
        {
            var panel = new Panel
            {
                Width = 300,
                Height = 320, // Adjusted to fit all elements
                Margin = new Padding(15),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
            };

            var pictureBox = new PictureBox
            {
                Width = 300,
                Height = 250,
                Top = 0,
                Left = 0,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.None
            };

            // Load the image from the URL asynchronously
            LoadImageAsync(pictureBox, imageUrl);

            var captionLabel = new Label
            {
                Text = caption,
                AutoSize = false,
                Width = 300,
                Height = 40,
                Top = 250,
                Left = 0,
                Font = new Font("Tahoma", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.LightPink
            };

            // Add LinkLabel for the clickable image URL
            var linkLabel = new LinkLabel
            {
                Text = imageUrl,  // Display the URL as the link text
                AutoSize = false,
                Width = 300,
                Height = 30, // Make sure it has a proper height
                Top = 290,  // Position it below the caption label
                Left = 0,
                Font = new Font("Tahoma", 8, FontStyle.Underline),
                TextAlign = ContentAlignment.MiddleCenter,
                LinkColor = Color.Blue
            };

            // Handle the LinkClicked event to open the URL
            linkLabel.LinkClicked += (sender, e) =>
            {
                Process.Start(new ProcessStartInfo(imageUrl) { UseShellExecute = true });
            };

            // Add the controls to the panel
            panel.Controls.Add(pictureBox);
            panel.Controls.Add(captionLabel);
            panel.Controls.Add(linkLabel);

            return panel;
        }




        // Loads an image from the URL and puts it in the PictureBox asynchronously
        private async void LoadImageAsync(PictureBox pictureBox, string imageUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var imageData = await client.GetByteArrayAsync(imageUrl);
                    using (var stream = new System.IO.MemoryStream(imageData))
                    {
                        pictureBox.Image = Image.FromStream(stream);
                    }
                }
            }
            catch
            {
                pictureBox.Image = null; // Placeholder if the image fails to load
            }
        }

        private void Instagram_Load(object sender, EventArgs e)
        {
            // Additional load logic can be added here if needed
        }
    }
}