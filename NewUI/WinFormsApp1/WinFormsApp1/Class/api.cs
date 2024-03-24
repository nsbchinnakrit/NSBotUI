using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NSLaunch.Class
{
    internal class api
    {
        //readjson ReadJsonClass = new NSLaunch.Class.readjson();

        public string latestVersion = null;
        public string JsonVersion = null;
        public string Event = null;

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
                }
                else
                {
                    //MessageBox.Show("Without token!");
                    HttpResponseMessage responseWithoutToken = await GetApiResponse(client, apiUrl, null);
                    string responseContent = await responseWithoutToken.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                    string tagName = jsonResponse["tag_name"];
                    latestVersion = tagName;
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

        public void Check_Update()
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
                    DialogResult result = MessageBox.Show("Update available. Do you want to update?", "Update Available", MessageBoxButtons.YesNo);
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
                    else if (result == DialogResult.No)
                    {
                        // ไม่ต้องการอัปเดต
                    }
                }

            }
            catch (Exception ex)
            {
                // จัดการข้อผิดพลาดในกรณีที่ไม่สามารถอ่านไฟล์ version.json หรือแปลง JSON ได้
                Console.WriteLine("Error checking update: " + ex.Message);
            }
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
