using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Messenger : Form
    {
        private FetchDataTimer fetchDataTimer;
        private string accessKey;

        public Messenger(string accessKey)
        {
            InitializeComponent();
            this.accessKey = accessKey;
            fetchDataTimer = new FetchDataTimer(FetchDataTimerCallback);
            this.Shown += Messenger_Shown; // Subscribe to the Shown event
        }

        private async void Messenger_Shown(object sender, EventArgs e)
        {
            await FetchDataAsync(); // Fetch data asynchronously when the form is shown
            fetchDataTimer.Start(); // Start the timer after the first data fetch
        }

        // Timer callback method
        private async void FetchDataTimerCallback()
        {
            await FetchDataAsync(); // Call the async fetch method
        }

        // Asynchronously fetches chat data and displays it if available
        private async Task FetchDataAsync()
        {
            var chats = await Task.Run(() => DataFetcher.FetchAllChats(accessKey));

            // If chats were fetched, display them
            if (chats != null && chats.Count > 0)
            {
                DisplayChats(chats);
            }
        }

        private void DisplayChats(List<object> chats)
        {
            // Clear any existing chat panels
            chatsFlowPanel.Controls.Clear();

            foreach (var chatObj in chats)
            {
                dynamic chat = chatObj;
                var chatPanel = CreateChatPanel();

                int totalHeight = 10; // Start with some padding
                foreach (var message in chat.Messages)
                {
                    AddMessageToPanel(chatPanel, message, ref totalHeight);
                }

                // Set the height of the chat panel based on the total height of its messages
                chatPanel.Height = totalHeight;

                // Add the created chat panel to the FlowLayoutPanel
                chatsFlowPanel.Controls.Add(chatPanel);
            }
        }

        private Panel CreateChatPanel()
        {
            return new Panel
            {
                Width = chatsFlowPanel.Width - 20,
                Padding = new Padding(10),
                BackColor = Color.White,
                Margin = new Padding(10)
            };
        }

        private void AddMessageToPanel(Panel chatPanel, dynamic message, ref int totalHeight)
        {
            var senderLabel = CreateSenderLabel(message.Sender, totalHeight);
            var messageLabel = CreateMessageLabel(message.Content, senderLabel.Bottom + 5);

            chatPanel.Controls.Add(senderLabel);
            chatPanel.Controls.Add(messageLabel);

            totalHeight = messageLabel.Bottom + 10; // Add padding below each message
        }

        private Label CreateSenderLabel(string sender, int top)
        {
            return new Label
            {
                Text = sender,
                Font = new Font("Tahoma", 12, FontStyle.Bold),
                ForeColor = Color.Blue, // Use a distinct color for the sender
                AutoSize = true,
                Location = new Point(10, top) // Position with padding
            };
        }

        private Label CreateMessageLabel(string content, int top)
        {
            return new Label
            {
                Text = content,
                Font = new Font("Tahoma", 10, FontStyle.Regular),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(10, top) // Position below the sender
            };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void Messenger_Load(object sender, EventArgs e)
        {
        }
    }
}
