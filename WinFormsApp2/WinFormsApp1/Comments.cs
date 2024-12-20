using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Comments : Form
    {
        private FetchDataTimer fetchDataTimer;
        private string accessKey;

        public Comments(string accessKey)
        {
            InitializeComponent();
            this.accessKey = accessKey;
            fetchDataTimer = new FetchDataTimer(FetchDataTimerCallback);
            this.Shown += Comments_Shown; // Subscribe to the Shown event
        }

        private async void Comments_Shown(object sender, EventArgs e)
        {
            await FetchDataAsync(); // Fetch data asynchronously when the form is shown
            fetchDataTimer.Start(); // Start the timer after the first data fetch
        }

        // Timer callback method
        private async void FetchDataTimerCallback()
        {
            await FetchDataAsync(); // Call the async fetch method
        }
        // Create a panel to display a Facebook post with comments
        private Panel CreatePostPanel(string message)
        {
            // Create a parent panel for the post and its comments
            var panel = new Panel
            {
                Width = 400,
                AutoSize = true, // Automatically resize based on content
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightBlue // Set the background color to blue
            };

            // Create a TableLayoutPanel for structured layout
            var layoutPanel = new TableLayoutPanel
            {
                ColumnCount = 1,
                RowCount = 2,
                AutoSize = true,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            panel.Controls.Add(layoutPanel);

            // Add a label for the post message
            var messageLabel = new Label
            {
                Text = message,
                AutoSize = true, // Automatically adjust size to fit content
                Margin = new Padding(10),
                Font = new Font("Tahoma", 10, FontStyle.Bold),
                ForeColor = Color.DarkBlue, // Darker blue text for contrast
                TextAlign = ContentAlignment.TopLeft,
                BackColor = Color.LightBlue // Background color for the message
            };
            layoutPanel.Controls.Add(messageLabel, 0, 0);

            // Create a FlowLayoutPanel for the comments
            var commentsPanel = new FlowLayoutPanel
            {
                AutoSize = true, // Automatically adjust size to fit comments
                FlowDirection = FlowDirection.TopDown,
                Margin = new Padding(10),
                BackColor = Color.White // Set a white background for comments
            };
            layoutPanel.Controls.Add(commentsPanel, 0, 1);

            return panel;
        }

        // Modified FetchDataAsync to add comments into the FlowLayoutPanel
        private async Task FetchDataAsync()
        {
            if (!commentsFlowPanel.IsHandleCreated)
            {
                commentsFlowPanel.HandleCreated += (s, e) => FetchDataAsync();
                return;
            }

            List<object> commentsData = await Task.Run(() => DataFetcher.FetchAllComments(accessKey));

            if (commentsData != null)
            {
                commentsFlowPanel.Invoke(new Action(() => commentsFlowPanel.Controls.Clear()));

                foreach (var postWithComments in commentsData)
                {
                    var postData = postWithComments as dynamic;
                    string postMessage = postData.PostMessage;

                    // Create a panel for the post and its comments
                    var postPanel = CreatePostPanel(postMessage);

                    // Add comments to the FlowLayoutPanel inside the postPanel
                    foreach (var comment in postData.Comments)
                    {
                        var commentData = comment as dynamic;
                        string commentMessage = commentData.Message;
                        string commentFrom = commentData.From;

                        Label commentLabel = new Label
                        {
                            Text = $"{commentFrom}: {commentMessage}",
                            AutoSize = true,
                            ForeColor = Color.Black, // Change text color to black for visibility
                            BackColor = Color.Transparent,
                            Margin = new Padding(5)
                        };

                        // Find the comments FlowLayoutPanel inside the post panel and add the label
                        var commentsPanel = (FlowLayoutPanel)postPanel.Controls[0].Controls[1]; // Correctly access the comments panel
                        commentsPanel.Controls.Add(commentLabel);
                    }

                    commentsFlowPanel.Invoke(new Action(() => commentsFlowPanel.Controls.Add(postPanel)));
                }
            }
            else
            {
                MessageBox.Show("Failed to fetch comments. Please check your access key or network connection.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Comments_Load(object sender, EventArgs e)
        {

        }
    }
}
