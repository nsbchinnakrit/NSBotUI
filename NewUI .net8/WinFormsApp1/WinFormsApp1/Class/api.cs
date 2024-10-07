using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.NetworkInformation;

namespace NSLaunch.Class
{
    internal class api
    {
        //readjson ReadJsonClass = new NSLaunch.Class.readjson();

        public string latestVersion = null;
        public string JsonVersion = null;
        public string Event = null;
        public string Changelog = null;

        //==============================================Get API===============================================
        public async void GetTagNameFromApi()
        {
            string apiUrl = "https://api.github.com/repos/nsbchinnakrit/NSBotUpdate/releases/latest";
            string token = "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"; // แทนที่ด้วย Token ของ API

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)");

            try
            {
                HttpResponseMessage response = await GetApiResponse(client, apiUrl, token);

                if (response.IsSuccessStatusCode)
                {
                    //MessageBox.Show("With token!");
                    string responseContent = await response.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                    string tagName = jsonResponse["tag_name"];
                    latestVersion = tagName;
                    string body = jsonResponse["body"];
                    Changelog = body;
                }
                else
                {
                    //MessageBox.Show("Without token!");
                    HttpResponseMessage responseWithoutToken = await GetApiResponse(client, apiUrl, null);
                    string responseContent = await responseWithoutToken.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                    string tagName = jsonResponse["tag_name"];
                    latestVersion = tagName;
                    string body = jsonResponse["body"];
                    Changelog = body;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving tag name from API: " + ex.Message);
                latestVersion = JsonVersion;
            }

            Check_Update();
        }

        public async Task<HttpResponseMessage> GetApiResponse(HttpClient client, string apiUrl, string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                client.DefaultRequestHeaders.Authorization = null;
            }

            return await client.GetAsync(apiUrl);
        }
        //====================================================================================================

        public async void Check_Update()
        {
            try
            {
                // อ่านเนื้อหาของไฟล์ version.json
                string jsonContent = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json"));

                // แปลงเนื้อหา JSON เป็นออบเจ็กต์
                dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);

                // ดึงค่าจากส่วน "version" ในออบเจ็กต์ JSON
                string jsonVersion = jsonData.version;

                if (latestVersion != null && latestVersion != jsonVersion && jsonVersion != "Dev")
                {
                    // ลบการจัดรูปแบบ Markdown และสัญลักษณ์ > จาก Changelog
                    string formattedChangelog = RemoveMarkdownFormatting(Changelog);

                    DialogResult result = MessageBox.Show(
                        $"Changelog:\n\n{formattedChangelog}",
                        "Update Available",
                        MessageBoxButtons.YesNo
                    );

                    if (result == DialogResult.Yes)
                    {
                        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                        string updateFilePath = Path.Combine(currentDirectory, "update.exe");
                        string runUpdateFilePath = Path.Combine(currentDirectory, "runupdate.exe");

                        if (File.Exists(updateFilePath))
                        {
                            File.Move(updateFilePath, runUpdateFilePath);
                            Process.Start(runUpdateFilePath);
                            Application.Exit();
                        }
                    }
                    else
                    {
                        Application.Exit();
                    }

                }
            }
            catch (Exception ex)
            {
                // จัดการข้อผิดพลาดในกรณีที่ไม่สามารถอ่านไฟล์ version.json หรือแปลง JSON ได้
                Console.WriteLine("Error checking update: " + ex.Message);
            }
        }

        private string RemoveMarkdownFormatting(string text)
        {
            // ลบเครื่องหมาย ** และ > ออกจากข้อความ
            return text.Replace("**", "").Replace(">", "").Trim();
        }


        public void DeleteRunUpdateFile()
        {
            string programDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(programDirectoryPath, "runupdate.exe");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Console.WriteLine("Deleted runupdate.exe");
            }
            else
            {
                Console.WriteLine("runupdate.exe does not exist. Skipping deletion.");
            }
        }
    }
}
