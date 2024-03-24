using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace getupdate
{
    public partial class Form1 : Form
    {
        string url = "https://g37.update.netease.com/pl/onmyoji2_pp.plist";
        string selectedItem = null;
        string version = null;
        string dl_link = null;
        string shortversion = null;
        string server = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void ServerSelect(object sender, EventArgs e)
        {
            if (CN.Checked)
            {
                this.url = "https://g37.update.netease.com/pl/onmyoji2_pp.plist";
            }
            if (JP.Checked)
            {
                this.url = "https://g37na.update.netease.com/pl/onmyoji2_pp.plist";
            }
            if (GB.Checked)
            {
                this.url = "https://g37gb.update.netease.com/pl/onmyoji2_pp.plist";
            }
            label1.Text = "Click \"Get Version\" to get file version";
            listBox1.Items.Clear();
            Download_button.Visible = false;
        }

        private async void Getver_Button_Click(object sender, EventArgs e)
        {
            //string url = "https://g37gb.update.netease.com/pl/onmyoji2_pp.plist";
            //string url = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "g37gb.update.netease.com_pl_onmyoji2_pp.plist");
            listBox1.Items.Clear();
            try
            {
                // สร้าง HTTP client
                using (HttpClient client = new HttpClient())
                {
                    // ดึงข้อมูลจาก URL
                    string plistData = await client.GetStringAsync(url);

                    // แยกข้อมูลใน plistData เป็นบรรทัด
                    string[] lines = plistData.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                    // เลือกเอาเพียง 5 บรรทัดสุดท้ายที่ไม่ขึ้นต้นด้วย #min_version
                    var filteredLines = lines
                        .Where(line => !line.Trim().StartsWith("#min_version"))
                        .Where(line => !line.Trim().StartsWith("#pioneer_server"))
                        //.Where(line => !line.Trim().StartsWith("#sub_patch_list"))
                        .Skip(Math.Max(0, lines.Length - 11))
                        .ToArray();

                    // เพิ่มข้อมูลใน ListBox1
                    foreach (string line in filteredLines)
                    {
                        string[] parts = line.Split(' ', ',');

                        string version = parts[0];
                        if (version == "#sub_patch_list")
                        {
                            listBox1.Items.Add($"{version}");
                        }
                        else
                        {
                            string size = parts[3];
                            string[] size0 = size.Split('|');
                            string size1 = size0[0];
                            int sizeInBytes = int.Parse(size1);

                            // แปลงขนาดให้อยู่ในหน่วย MB
                            double sizeInMB = sizeInBytes / (1024.0 * 1024.0);

                            listBox1.Items.Add($"{version}\t   Size: {sizeInMB:F2} MB");
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) // ตรวจสอบว่ามีการเลือก Item หรือไม่
            {
                Extract_button.Visible = false;
                string selectedItem = listBox1.SelectedItem.ToString();
                string[] parts = selectedItem.Split('\t');

                if (selectedItem != "#sub_patch_list")
                {
                    // ตัดส่วนของข้อมูล Size ออก

                    this.version = parts[0];

                    string[] versionParts = parts[0].Split('.');
                    this.shortversion = string.Join(".", versionParts.Take(4));

                    // แสดงผลใน TextBox1
                    label1.Text = parts[0];
                    Download_button.Visible = true;
                    Download_button.Enabled = true;
                }
                else
                {
                    // แสดงผลใน TextBox1
                    label1.Text = parts[0];
                    Download_button.Visible = true;
                    Download_button.Enabled = false;
                }


            }
        }

        private async void Download_button_Click(object sender, EventArgs e)
        {
            if (CN.Checked)
            {
                this.dl_link = "https://g37.gph.netease.com/patch_pp_" + version + "/patch_dxt.npk";
                this.server = "CN_";
            }
            if (JP.Checked)
            {
                this.dl_link = "https://g37na.gph.netease.com/patch_pp_" + version + "/patch_dxt.npk";
                this.server = "JP_";
            }
            if (GB.Checked)
            {
                this.dl_link = "https://g37gb.gph.netease.com/patch_pp_" + version + "/patch_dxt.npk";
                this.server = "GB_";
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Download_button.Enabled = false;
                    label1.Text = $"Downloading: {server + shortversion + "_patch_dxt.npk"}";
                    byte[] fileData = await client.GetByteArrayAsync(dl_link); // ดาวน์โหลดไฟล์เป็น ByteArray

                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, server + shortversion + "_patch_dxt.npk");
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        await fs.WriteAsync(fileData, 0, fileData.Length); // บันทึกไฟล์ลงในโฟลเดอร์ที่โปรแกรมอยู่
                    }

                    MessageBox.Show("Download Complete");
                    label1.Text = "Download Complete";
                    Download_button.Enabled = true;
                    Extract_button.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Download Error: " + ex.Message);
                    label1.Text = "Download Error: " + ex.Message;
                    Download_button.Enabled = true;
                }
            }
        }

        private void Extract_button_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, server + shortversion + "_patch_dxt.npk");

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "cmd.exe"; // กำหนดชื่อโปรแกรมที่ใช้เปิดหน้าต่าง Shell
            start.Arguments = "/C python ex.py " + filePath; // กำหนดคำสั่ง Python ที่ต้องการรัน

            // ตัวอย่างการกำหนด working directory (โดยใช้ตำแหน่งปัจจุบันของโปรแกรม C#)
            start.WorkingDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

            // เพิ่มตัวเลือกอื่นๆ ตามความต้องการ เช่นเปิดหน้าต่างคอนโซล
            // start.CreateNoWindow = false;
            // start.UseShellExecute = false;

            // เรียกใช้โปรแกรม cmd.exe เพื่อรันคำสั่ง Python
            using (Process process = Process.Start(start))
            {
            }
        }
    }
}