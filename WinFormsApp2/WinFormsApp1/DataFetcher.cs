using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WinFormsApp1;
using Message = WinFormsApp1.Message;

public class DataFetcher
{
    private static readonly Mutex mutex = new Mutex(); // Create a Mutex instance
    // A function to get the full path for each machine instead of typing it
    private static string GetProjectRoot()
    {
        return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
    }
    // fetches data from a URL using HTTP request
    private static string FetchDataFromApi(string url)
    {
        mutex.WaitOne(); // Wait until it is safe to enter

        try
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(url).Result;

                    // If the response is not successful, show error and return null
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Failed to fetch data from URL: {url}");
                        return null;
                    }
                    // Return the content of the response as a string
                    return response.Content.ReadAsStringAsync().Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching data: {ex.Message}");
                    return null;
                }
            }
        }
        finally
        {
            mutex.ReleaseMutex(); // Release the mutex
        }
    }

    // fetches all chats for the given access token from the Messenger API
    public static List<object> FetchAllChats(string accessToken)
    {
        Console.OutputEncoding = Encoding.UTF8;

        try
        {
            JArray conversations = FetchConversations(accessToken);

            // if no conversations return an empty list
            if (conversations == null || conversations.Count == 0)
                return new List<object>();

            var allChatsData = new List<object>();

            // iterate over each conversation and fetch messages
            foreach (var conversation in conversations)
            {
                string conversationId = conversation["id"].ToString();
                JObject messagesData = FetchMessagesForConversation(conversationId, accessToken);

                if (messagesData != null)
                {
                    var chatData = ProcessChat(messagesData, accessToken);
                    if (chatData != null)
                        allChatsData.Add(chatData);// add chat messages to the list
                }
            }
            // save messenger chats data to a file (MessengerData.json)
            string jsonFilePath = Path.Combine(GetProjectRoot(), "MessengerData.json");
            SavingData.SaveChatsToFile(allChatsData, jsonFilePath);

            foreach (var chat in allChatsData)
            {
                Console.WriteLine(chat);
            }

            return allChatsData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return new List<object>();
        }
    }

    // fetches a list of conversations 
    private static JArray FetchConversations(string accessToken)
    {
        string url = $"https://graph.facebook.com/v21.0/me/conversations?platform=MESSENGER&access_token={accessToken}";
        string response = FetchDataFromApi(url);

        if (string.IsNullOrEmpty(response))
            return null;

        JObject data = JObject.Parse(response);
        return (JArray)data["data"];  // extract conversation data from the response
    }

    // fetche the messages for a conversation using the conversation id
    private static JObject FetchMessagesForConversation(string conversationId, string accessToken)
    {
        string url = $"https://graph.facebook.com/v21.0/{conversationId}?fields=id,messages,senders,message_count&access_token={accessToken}";
        string response = FetchDataFromApi(url);

        return string.IsNullOrEmpty(response) ? null : JObject.Parse(response);
    }

    // fetches the details for a message using the message id
    private static JObject FetchMessageDetails(string messageId, string accessToken)
    {
        string url = $"https://graph.facebook.com/v21.0/{messageId}?fields=message,id,to,from&access_token={accessToken}";
        string response = FetchDataFromApi(url);

        return string.IsNullOrEmpty(response) ? null : JObject.Parse(response);
    }


    private static Chat ProcessChat(JObject messagesData, string accessToken)
    {
        // extract senders and messages data from the response
        JArray senders = (JArray)messagesData["senders"]["data"];
        JArray messages = (JArray)messagesData["messages"]["data"];

        var chat = new Chat
        {
            // create a list of senders names
            Participants = senders.Select(s => s["name"].ToString()).ToList(),
            Messages = new List<Message>()
        };

        foreach (var message in messages)
        {
            //extract details for each message

            string messageId = message["id"].ToString();
            JObject messageDetails = FetchMessageDetails(messageId, accessToken);

            if (messageDetails != null)
            {
                // extract the content of message and sender name from the details
                string messageContent = messageDetails["message"]?.ToString();
                string senderName = messageDetails["from"]?["name"]?.ToString();

                if (!string.IsNullOrEmpty(messageContent))
                { // add the message to the chat
                    chat.Messages.Add(new Message
                    {
                        Sender = senderName,
                        Content = messageContent
                    });
                }
            }
        }

        return chat;
    }
    public static List<InstagramPost> FetchInstagramPosts(string accessToken)
    {
        // Append the access token to the Instagram API URL
        string instagramApiUrl = $"https://graph.instagram.com/me/media?fields=id,caption,media_type,media_url,thumbnail_url,timestamp,permalink&access_token={accessToken}";

        // Fetch data from the API
        string jsonResponse = FetchDataFromApi(instagramApiUrl);

        if (jsonResponse != null)
        {
            try
            {
                // Parse the JSON response
                JObject jsonObject = JObject.Parse(jsonResponse);
                JArray postsArray = (JArray)jsonObject["data"];

                var posts = new List<InstagramPost>();

                // Extract relevant data for each post
                foreach (var post in postsArray)
                {
                    posts.Add(new InstagramPost
                    {
                        Caption = (string)post["caption"],
                        MediaUrl = (string)post["media_url"]
                    });
                }

                string jsonFilePath = Path.Combine(GetProjectRoot(), "InstagramPosts.json");
                SavingData.SaveInstagramPostsToFile(posts, jsonFilePath);
                return posts;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing Instagram posts: {ex.Message}");
            }
        }

        return null;
    }
    public static JArray FetchPosts(string accessToken)
    {
        string url = $"https://graph.facebook.com/v21.0/me/posts?access_token={accessToken}";
        string response = FetchDataFromApi(url);

        if (string.IsNullOrEmpty(response))
            return null;

        JObject data = JObject.Parse(response);
        return (JArray)data["data"]; // Extract post data from the response
    }

    public static List<(string Message, string CreatedTime)> GetAllPosts(string accessToken)
    {
        JArray posts = FetchPosts(accessToken);

        if (posts == null || !posts.Any())
        {
            Console.WriteLine("No posts available.");
            return new List<(string, string)>();
        }

        var postList = new List<(string Message, string CreatedTime)>();

        foreach (var post in posts)
        {
            string message = post["message"]?.ToString();
            string createdTime = post["created_time"]?.ToString();

            if (!string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(createdTime))
            {
                postList.Add((message, createdTime)); // Add message and created time
            }
        }
        string jsonFilePath = Path.Combine(GetProjectRoot(), "FacebookPosts.json");
        SavingData.SaveToJsonFile(posts, jsonFilePath);

        return postList;
    }
    public static JArray FetchComments(string postId, string accessToken)
    {
        string url = $"https://graph.facebook.com/v21.0/{postId}/comments?access_token={accessToken}";
        string response = FetchDataFromApi(url);

        if (string.IsNullOrEmpty(response))
            return null;

        JObject data = JObject.Parse(response);
        return (JArray)data["data"];
    }

    // Fetch comments for a specific post using the post ID
    public static JArray FetchCommentsForPost(string postId, string accessToken)
    {
        return FetchComments(postId, accessToken);
    }

    // Fetch all comments from all posts made by the user
    public static List<object> FetchAllComments(string accessToken)
    {
        JArray posts = FetchPosts(accessToken);
        if (posts == null || !posts.Any())
        {
            Console.WriteLine("No posts available to fetch comments.");
            return new List<object>();
        }

        var allCommentsList = new List<object>();

        foreach (var post in posts)
        {
            string postId = post["id"].ToString();
            string postMessage = post["message"]?.ToString(); // Get the post message
            Console.WriteLine($"Fetching comments for post: {postMessage}");

            JArray comments = FetchComments(postId, accessToken);
            if (comments != null)
            {
                var commentsData = comments.Select(comment => new
                {
                    Message = comment["message"]?.ToString(), // Only return the message
                    From = comment["from"]?["name"]?.ToString()
                }).ToList();

                allCommentsList.Add(new
                {
                    PostMessage = postMessage, // Include the post message
                    Comments = commentsData
                });
            }
        }
        string jsonFilePath = Path.Combine(GetProjectRoot(), "CommentsData.json");
        // Optionally save all comments to a file
        SavingData.SaveToJsonFile(allCommentsList, jsonFilePath);
        return allCommentsList;
    }


}