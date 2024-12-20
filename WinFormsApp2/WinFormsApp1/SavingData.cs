using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WinFormsApp1
{
    public class SavingData
    {
        // Static method for saving chats to a file
        public static void SaveChatsToFile(List<object> chats, string fileName)
        {
            try
            {
                string jsonData = JArray.FromObject(chats).ToString();
                File.WriteAllText(fileName, jsonData, Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }
        }

        // Static method for saving chats to a file
        public static void SaveInstagramPostsToFile(List<InstagramPost> posts, string fileName)
        {
            try
            {
                string jsonData = JArray.FromObject(posts).ToString();
                File.WriteAllText(fileName, jsonData, Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }
        }
        public static void SaveToJsonFile(object data, string fileName)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(fileName, jsonData, Encoding.UTF8);
            }
            catch (Exception ex)
            {
            }
        }
    }

}
