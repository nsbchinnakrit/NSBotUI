using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;
using System.Net.Http.Headers;

namespace update
{
    public partial class Form1 : Form
    {
        private string latestVersion = null;
        private string JsonVersion = null;
        private string updatefilesize = null;
        private string roundoption = null;
        private string theme = null;
        private string disc = null;
        private bool tomb = false;
        private bool snowball = false;
        private bool azure = false;
        private bool kuro = false;
        private double TotalSize = 0;
        private double TotalSizeMB = 0;
        private double getdownloadedSize = 0;

        private double FIND_IMG_DELAY = 0.8;
        private bool WQ_JADE = false;
        private bool WQ_COIN = false;
        private bool WQ_SUSHI = false;
        private bool WQ_FOOD = false;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += cancel_btn_Click;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadJson();
            ReadConfigJson();
            GetTagNameFromApi();
        }

        private class VersionData
        {
            public string version { get; set; }
            public string eventtext { get; set; }
            public string roundoption { get; set; }
            public string theme { get; set; }
            public string disc { get; set; }
            public bool tomb { get; set; }
            public bool snowball { get; set; }
            public bool azure { get; set; }
            public bool kuro { get; set; }
            public string changelog { get; set; }
        }
        
        private class ConfigData
        {
            public string FIND_IMG_DELAY { get; set; }
            public bool WQ_JADE { get; set; }
            public bool WQ_COIN { get; set; }
            public bool WQ_SUSHI { get; set; }
            public bool WQ_FOOD { get; set; }
        }

        private void ReadJson()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json");
                string jsonContent = File.ReadAllText(jsonPath);

                VersionData jsonData = JsonConvert.DeserializeObject<VersionData>(jsonContent);

                this.roundoption = jsonData.roundoption;
                this.theme = jsonData.theme;
                this.disc = jsonData.disc;
                this.tomb = jsonData.tomb;
                this.snowball = jsonData.snowball;
                this.azure = jsonData.azure;
                this.kuro = jsonData.kuro;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading version from JSON: " + ex.Message);
            }
        }

        private void WriteJson()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json");
                string jsonContent = File.ReadAllText(jsonPath);

                dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);

                jsonData["roundoption"] = roundoption;
                jsonData["theme"] = theme;
                jsonData["disc"] = disc;
                jsonData["tomb"] = tomb;
                jsonData["snowball"] = snowball;
                jsonData["azure"] = azure;
                jsonData["kuro"] = kuro;

                File.WriteAllText(jsonPath, JsonConvert.SerializeObject(jsonData, Formatting.Indented));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading version from JSON: " + ex.Message);
            }
        }

        private void ReadConfigJson()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
                string jsonContent = File.ReadAllText(jsonPath);

                dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);

                this.FIND_IMG_DELAY = jsonData.VALUE.FIND_IMG_DELAY;
                this.WQ_JADE = jsonData.VALUE.WQ_JADE;
                this.WQ_COIN = jsonData.VALUE.WQ_COIN;
                this.WQ_SUSHI = jsonData.VALUE.WQ_SUSHI;
                this.WQ_FOOD = jsonData.VALUE.WQ_FOOD;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading version from JSON: " + ex.Message);
            }
        }

        private void WriteConfigJson()
        {
            try
            {
                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
                string jsonContent = File.ReadAllText(jsonPath);

                dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);

                jsonData.VALUE.FIND_IMG_DELAY = FIND_IMG_DELAY;
                jsonData.VALUE.WQ_JADE = WQ_JADE;
                jsonData.VALUE.WQ_COIN = WQ_COIN;
                jsonData.VALUE.WQ_SUSHI = WQ_SUSHI;
                jsonData.VALUE.WQ_FOOD = WQ_FOOD;

                File.WriteAllText(jsonPath, JsonConvert.SerializeObject(jsonData, Formatting.Indented));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading version from JSON: " + ex.Message);
            }
        }

        //==============================================Get API===============================================
        private async void GetTagNameFromApi()
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
                    string size = jsonResponse["assets"][0]["size"];
                    this.latestVersion = tagName;
                    this.updatefilesize = size;
                }
                else
                {
                    //MessageBox.Show("Without token!");
                    HttpResponseMessage responseWithoutToken = await GetApiResponse(client, apiUrl, null);
                    string responseContent = await responseWithoutToken.Content.ReadAsStringAsync();
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                    string tagName = jsonResponse["tag_name"];
                    string size = jsonResponse["assets"][0]["size"];
                    this.latestVersion = tagName;
                    this.updatefilesize = size;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving tag name from API: " + ex.Message);
                this.latestVersion = JsonVersion;
            }
            process_label.Text = $"latest version {latestVersion}";
            DownloadFileWithProgress();

        }

        private async Task<HttpResponseMessage> GetApiResponse(HttpClient client, string apiUrl, string token)
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

        public void DownloadFileWithProgress()
        {
            string zipUrl = $"https://github.com/nsbchinnakrit/NSBotUpdate/releases/download/{latestVersion}/NSBotUpdate.zip";
            string zipFileName = "NSBotUpdate.zip";
            string totalFileSizeString = updatefilesize;
            double totalFileSize;
            if (double.TryParse(totalFileSizeString, out totalFileSize))
            {
                double totalSizeMB = totalFileSize / (1024.0 * 1024.0);
                double roundedTotalSizeMB = Math.Round(totalSizeMB, 3);
                this.TotalSize = totalFileSize;
                this.TotalSizeMB = roundedTotalSizeMB;
            }
            else
            {
                // จัดการกรณีไม่สามารถแปลงขนาดไฟล์เป็นตัวเลขได้
            }

            using (System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer())
            {
                timer.Interval = 300; // อัพเดตทุกๆ 300ms
                timer.Tick += (sender, e) =>
                {
                    UpdateProgress();
                };

                using (WebClient client = new WebClient())
                {
                    client.DownloadProgressChanged += (sender, e) =>
                    {
                        this.getdownloadedSize = e.BytesReceived;
                        timer.Start(); // เริ่มต้น Timer เมื่อเริ่มรับข้อมูล

                    };

                    client.DownloadFileCompleted += (sender, e) =>
                    {
                        double progressPercentage = (totalFileSize / totalFileSize) * 100;
                        progressBar.Value = (int)progressPercentage;
                        process_label.Text = $"Download complete..";
                        timer.Stop(); // หยุด Timer เมื่อดาวน์โหลดเสร็จสิ้น
                        if (e.Error == null)
                        {
                            // ดาวน์โหลดเสร็จสิ้น
                            Extract_file();
                        }
                        else
                        {
                            // เกิดข้อผิดพลาดในการดาวน์โหลด
                            Console.WriteLine($"Error downloading file: {e.Error.Message}");
                        }
                    };

                    try
                    {
                        // เริ่มดาวน์โหลดไฟล์
                        client.DownloadFileAsync(new Uri(zipUrl), zipFileName);
                    }
                    catch (WebException ex)
                    {
                        // จัดการข้อผิดพลาดที่เกิดขึ้นในการดาวน์โหลด
                    }
                    catch (Exception ex)
                    {
                        // จัดการข้อผิดพลาดที่ไม่ได้เกี่ยวข้องกับการดาวน์โหลด
                    }
                }
            }
        }

        private void UpdateProgress()
        {
            double downloadedSizeMB = getdownloadedSize / (1024.0 * 1024.0);
            double progressPercentage = (getdownloadedSize / TotalSize) * 100;
            double roundedDownloadedSizeMB = Math.Round(downloadedSizeMB, 3);

            progressBar.Value = (int)progressPercentage;
            process_label.Text = $"Downloading {(int)progressPercentage}% ({roundedDownloadedSizeMB} of {TotalSizeMB} MB)...";
        }


        private async void Extract_file()
        {
            progressBar.PerformStep();
            string zipFilePath = "NSBotUpdate.zip";
            string extractPath = "ExtractedFiles";
            process_label.Text = $"Extracting {zipFilePath}";

            try
            {
                // ตรวจสอบว่ามีไดเรกทอรี extractPath อยู่หรือไม่
                if (Directory.Exists(extractPath))
                {
                    // ลบไดเรกทอรีที่มีอยู่ใน extractPath และไฟล์ที่อยู่ภายใน
                    Directory.Delete(extractPath, true);
                }

                await Task.Run(() =>
                {
                    // แตกไฟล์ ZIP
                    DeleteFilesInProgramFolder();
                    ZipFile.ExtractToDirectory(zipFilePath, extractPath);
                    MoveFilesFromExtractedFolder();
                });

            }
            catch (Exception ex)
            {
                // เกิดข้อผิดพลาดในการแตกไฟล์
                MessageBox.Show("Error extracting file: " + ex.Message);
            }
        }


        private void DeleteFilesInProgramFolder()
        {
            string programFolderPath = AppDomain.CurrentDomain.BaseDirectory;
            process_label.Text = "Remove old file..";

            DeleteFilesRecursively(programFolderPath);
        }

        private void DeleteFilesRecursively(string folderPath)
        {
            foreach (string filePath in Directory.GetFiles(folderPath))
            {
                string fileName = Path.GetFileName(filePath);

                if (fileName != "runupdate.exe" && fileName != "NSBotUpdate.zip")
                {
                    File.Delete(filePath);
                }
            }

            foreach (string subFolderPath in Directory.GetDirectories(folderPath))
            {
                // เช็คชื่อโฟลเดอร์ที่ไม่ต้องการลบ
                string folderName = Path.GetFileName(subFolderPath);
                if (folderName != "คนเหลี่ยมๆ")
                {
                    DeleteFilesRecursively(subFolderPath);
                    Directory.Delete(subFolderPath);
                }
            }
        }

        private void MoveFilesFromExtractedFolder()
        {
            process_label.Text = $"Move file to folder..";
            string extractPath = "ExtractedFiles";
            string programFolderPath = AppDomain.CurrentDomain.BaseDirectory;

            // ตรวจสอบว่ามีไดเรกทอรี extractPath อยู่หรือไม่
            if (Directory.Exists(extractPath))
            {
                // หาไฟล์และโฟลเดอร์ทั้งหมดภายใน extractPath รวมถึงโฟลเดอร์ย่อย
                string[] allFiles = Directory.GetFiles(extractPath, "*", SearchOption.AllDirectories);

                // ย้ายไฟล์และโฟลเดอร์ทั้งหมดไปยังโฟลเดอร์ปลายทาง
                foreach (string filePath in allFiles)
                {
                    string relativePath = filePath.Substring(extractPath.Length + 1);
                    string destinationFilePath = Path.Combine(programFolderPath, relativePath);

                    // ตรวจสอบว่าเป็นไฟล์หรือโฟลเดอร์
                    if (File.Exists(filePath))
                    {
                        // ย้ายไฟล์
                        string destinationDirectory = Path.GetDirectoryName(destinationFilePath);
                        Directory.CreateDirectory(destinationDirectory);
                        File.Move(filePath, destinationFilePath);
                    }
                    else if (Directory.Exists(filePath))
                    {
                        // สร้างโฟลเดอร์ปลายทาง
                        Directory.CreateDirectory(destinationFilePath);
                    }
                }

                // ลบโฟลเดอร์ extractPath
                Directory.Delete(extractPath, true);
                OpenNSLaunch();
                OnClosing();
            }
        }
        private void OpenNSLaunch()
        {
            WriteJson();
            WriteConfigJson();

            string programFolderPath = AppDomain.CurrentDomain.BaseDirectory;
            string nsLaunchPath = Path.Combine(programFolderPath, "NSLaunch.exe");

            if (File.Exists(nsLaunchPath))
            {
                try
                {
                    Process.Start(nsLaunchPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error opening NSLaunch.exe: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("NSLaunch.exe not found.");
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            OnClosing();
        }

        private void OnClosing()
        {
            try
            {
                string fileName = "rmzip.bat";
                string fileContent = "@echo off\necho Waiting for 2 seconds...\ntimeout /t 2 >nul\nrd /s /q ExtractedFiles\ndel NSBotUpdate.zip\nren runupdate.exe update.exe\ndel rmzip.bat";

                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write(fileContent);
                }
            }
            catch (Exception)
            {
                // จัดการข้อผิดพลาดที่เกิดขึ้นในการสร้างไฟล์
            }

            Process.Start(new ProcessStartInfo()
            {
                FileName = "rmzip.bat",
                CreateNoWindow = true,
                UseShellExecute = false
            });

            Application.Exit();
        }


        //====================================================================================================
    }
}