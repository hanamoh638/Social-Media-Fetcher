using System;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class SocialMediaForm : Form
    {
        private FlowLayoutPanel flowPanel;

        public SocialMediaForm()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Create a FlowLayoutPanel for posts
            flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            this.Controls.Add(flowPanel);

            // Example data fetching
            LoadPosts();
        }

        private async void LoadPosts()
        {
            // Generate 20 posts
            var posts = Enumerable.Range(1, 20).Select(i => new
            {
                Text = $"Post {i}",
                ImageUrl = "https://scontent-iad3-2.cdninstagram.com/v/t51.29350-15/469734276_573664345414145_222666484954297840_n.jpg?_nc_cat=103&ccb=1-7&_nc_sid=18de74&_nc_ohc=R9wSv1u0M-QQ7kNvgHVBSwX&_nc_zt=23&_nc_ht=scontent-iad3-2.cdninstagram.com&edm=ANo9K5cEAAAA&_nc_gid=A0dwXApNxCc6kvpVGNHgviK&oh=00_AYBcENfVTtoFGFDa1JFT3f940eAk5cMUQU_9OlFJtBxHjw&oe=676128E6" // Replace with real image URL if available
            }).ToArray();

            //create panel for each post
            foreach (var post in posts)
            {
                var postPanel = CreatePostPanel(post.Text, post.ImageUrl);
                flowPanel.Controls.Add(postPanel);
            }
        }

        // create panel to display each post 
        private Panel CreatePostPanel(string text, string imageUrl)
        {
            var panel = new Panel
            {
                Width = 300,
                Height = 200,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };

            var label = new Label
            {
                Text = text,
                AutoSize = false,
                Width = 280,
                Height = 50,
                Top = 10,
                Left = 10
            };

            var pictureBox = new PictureBox
            {
                Width = 280,
                Height = 130,
                Top = 70,
                Left = 10,
                SizeMode = PictureBoxSizeMode.Zoom,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Load the image asynchronously
            LoadImageAsync(pictureBox, imageUrl);

            panel.Controls.Add(label);
            panel.Controls.Add(pictureBox);

            return panel;
        }

        // load the image into the PictureBox from a URL asynchronously
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
    }
}
