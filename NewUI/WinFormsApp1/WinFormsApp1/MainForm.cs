using Microsoft.Toolkit.Uwp.Notifications;
using Newtonsoft.Json;
using NSLaunch.Class;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;



namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        #region Value Config
        private bool Notify_state = false;

        private string latestVersion = null;
        private string JsonVersion = null;
        private IntPtr hwd = IntPtr.Zero;
        private string gameModeselected = "SingleSoul";
        private string bondlingMode = "Explore";
        private string selectedValue = "GB";
        private string Wantedselected = "";
        private string total = "500";
        private string beforetotal = "0";

        private string crystal_use = "false";
        private string disc = "1";
        private string tomb = "false";
        private string snowball = "false";
        private string azure = "false";
        private string kuro = "false";

        private string findimgdelay = "0.01";
        private string origintotal = null;
        private string totalinfile = null;
        private string argumentsString = null;

        private Process runningProcess;
        private int pid = 0;
        private Point MainLocation;
        private System.Windows.Forms.Timer timer;
        private string themename = null;
        #endregion

        #region DllImport
        public const uint ES_CONTINUOUS = 0x80000000;
        public const uint ES_SYSTEM_REQUIRED = 0x00000001;
        public const uint ES_DISPLAY_REQUIRED = 0x00000002;

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint SetThreadExecutionState([In] uint esFlags);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        [DllImport("UXTheme.dll", SetLastError = true, EntryPoint = "#138")]
        public static extern bool ShouldSystemUseDarkMode();

        [DllImport("DwmApi")] //System.Runtime.InteropServices
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);


        //          resize_Click            //
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        private const uint SWP_SHOWWINDOW = 0x0040;

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_STYLE = -16;
        private const int WS_THICKFRAME = 0x40000;

        internal static class NativeMethods
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        }

        #endregion

        public MainForm()
        {
            InitializeComponent();

            #region From api.cs

            api ApiClass = new NSLaunch.Class.api();
            ApiClass.GetTagNameFromApi();
            ApiClass.DeleteRunUpdateFile();

            #endregion

            #region From readjson.cs
            readjson ReadJsonClass = new NSLaunch.Class.readjson();
            ReadJsonClass.ReadVersionJson();
            ReadJsonClass.ReadConfigJson();
            NSBotVer.Text = ReadJsonClass.JsonVersion;
            changelog.Text = ReadJsonClass.changelog;
            domainUpDown1.Text = ReadJsonClass.findimgdelay;
            Notify.Checked = ReadJsonClass.Notify;
            Basic.Checked = ReadJsonClass.Basic;
            Great.Checked = ReadJsonClass.Great;
            Ultra.Checked = ReadJsonClass.Ultra;
            KeepRound.Checked = ReadJsonClass.KeepRound;
            ResetRound.Checked = ReadJsonClass.ResetRound;
            Tomb.Checked = ReadJsonClass.Tomb;
            Snowball.Checked = ReadJsonClass.Snowball;
            Azure.Checked = ReadJsonClass.Azure;
            Kuro.Checked = ReadJsonClass.Kuro;
            wt_jade.Checked = ReadJsonClass.wt_jade;
            wt_coin.Checked = ReadJsonClass.wt_coin;
            wt_sushi.Checked = ReadJsonClass.wt_sushi;
            wt_food.Checked = ReadJsonClass.wt_food;
            if (ReadJsonClass.Theme == "system")
            { themesys.Checked = true; }

            if (ReadJsonClass.Theme == "dark")
            { themedark.Checked = true; }

            if (ReadJsonClass.Theme == "light")
            { themelight.Checked = true; }

            if (ReadJsonClass.JsonVersion != "Dev")
            { Tools.Visible = false; }

            #endregion

            Check_pact();
            this.Text = "NSBot";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Load += Form1_Load_HWD;
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
        }

        private void Form1_Load_HWD(object sender, EventArgs e)
        {
            #region Interface Setup

            this.total = InputRound.Text.ToString();
            Tiptext1.Text = string.Empty;
            button2.Visible = false;
            button1.Visible = true;
            RaidOption.Visible = false;
            BondlingOption.Visible = true;
            SettingBox1.Location = MainBox.Location;
            SettingBox1.SendToBack();
            AboutBox.Location = MainBox.Location;
            AboutBox.SendToBack();
            BondlingSettingsBox.Location = MainBox.Location;
            BondlingSettingsBox.SendToBack();
            DevBox.Location = MainBox.Location;
            DevBox.SendToBack();

            splitter1.Cursor = Cursors.Arrow;
            splitter2.Cursor = Cursors.Arrow;
            splitter3.Cursor = Cursors.Arrow;

            crystal.Enabled = false;
            rTomb.Visible = false;
            rSnowBall.Visible = false;
            rAzure.Visible = false;
            rKuro.Visible = false;

            panel1.AutoScroll = false;

            panel1.VerticalScroll.Maximum = 0;
            panel1.VerticalScroll.Visible = false;

            panel1.HorizontalScroll.Maximum = 0;
            panel1.HorizontalScroll.Visible = false;

            panel1.AutoScroll = true;

            panel2.AutoScroll = false;

            panel2.VerticalScroll.Maximum = 0;
            panel2.VerticalScroll.Visible = false;

            panel2.HorizontalScroll.Maximum = 0;
            panel2.HorizontalScroll.Visible = false;

            panel2.AutoScroll = true;

            splitter1.SendToBack();
            splitter2.SendToBack();
            this.TopMost = false;

            #endregion

            onMainBox();
            EnableGroupBoxes();
            ThemeMode();
            #region ตรวจสอบ Display scale
            double scale = GetDisplayScale();
            if (scale != 1.0)
            {
                NSLaunch.CustomMessageBox.SettingDPI($"Auto click ของ NSBot ใช้งานได้เฉพาะบน Display Scale 100%\nปัจจุบัน Display Scale ของคุณคือ {scale * 100}% กรุณาเปลี่ยนแปลงการตั้งค่า\n\nสามารถเปลี่ยนการตั้งค่าโดยกดปุ่ม Open Settings และมองหา 'Scale && layout'\nหากตั้งค่าเรียบร้อยแล้ว ให้เปิดโปรแกรมใหม่อีกครั้ง", themename);
                this.Close();
            }
            #endregion ตรวจสอบ Display scale
        }

        #region Check_pact
        private void Check_pact()
        {
            if (Basic.Checked == true)
            { this.disc = "1"; }

            if (Great.Checked == true)
            { this.disc = "2"; }

            if (Ultra.Checked == true)
            { this.disc = "3"; }
            //_________________________________________//
            //                                         //
            if (Tomb.Checked == true)
            { this.tomb = "true"; }

            if (Snowball.Checked == true)
            { this.snowball = "true"; }

            if (Azure.Checked == true)
            { this.azure = "true"; }

            if (Kuro.Checked == true)
            { this.kuro = "true"; }
        }
        #endregion Check_pact

        #region Theme Code
        private void ThemeMode()
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json");
            string jsonContent = File.ReadAllText(jsonPath);

            dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);

            bool bRet = ShouldSystemUseDarkMode();
            if (themesys.Checked)
            {
                if (bRet)
                {
                    DarkColor();
                }
                else
                {
                    LightColor();
                }

                jsonData["theme"] = "system";

            }
            else if (themedark.Checked)
            {
                DarkColor();
                jsonData["theme"] = "dark";
            }

            else if (themelight.Checked)
            {
                LightColor();
                jsonData["theme"] = "light";
            }
            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(jsonData, Formatting.Indented));
            this.Invoke((MethodInvoker)delegate
            {
                WindowInput.ForeColor = ForeColor;

                GameModeBox.ForeColor = ForeColor;
                RoundBox.ForeColor = ForeColor;
                ServerSelectBox.ForeColor = ForeColor;
                RoundOption.ForeColor = ForeColor;
                WantedBox.ForeColor = ForeColor;
                TeamBox.ForeColor = ForeColor;
                RaidOption.ForeColor = ForeColor;
                BondlingOption.ForeColor = ForeColor;


                wnd_defsize.FlatStyle = FlatStyle.Flat;
                wnd_defsize.FlatAppearance.BorderSize = 1;

                InputRound.ForeColor = ForeColor;

                GameMode.ForeColor = ForeColor;
                Setting1.ForeColor = ForeColor;
                About.ForeColor = ForeColor;
            });
        }

        private void DarkColor()
        {
            ForeColor = Color.DarkGray;
            BackColor = Color.FromArgb(38, 38, 38);
            WindowInput.BackColor = Color.FromArgb(32, 32, 32);
            wnd_defsize.BackColor = Color.FromArgb(28, 28, 28);
            InputRound.BackColor = Color.FromArgb(32, 32, 32);
            button1.BackColor = Color.FromArgb(28, 28, 28);
            button1.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            button2.BackColor = Color.FromArgb(20, 20, 20);
            button2.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            splitter3.BackColor = Color.FromArgb(28, 28, 28);
            teamtext.BackColor = Color.FromArgb(28, 28, 28);
            Tiptext1.ForeColor = Color.Salmon;
            GameMode.ForeColor = ForeColor;
            GameMode.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            Setting1.ForeColor = ForeColor;
            Setting1.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            About.ForeColor = ForeColor;
            About.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            BondlingSt.ForeColor = ForeColor;
            BondlingSt.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            Tools.ForeColor = ForeColor;
            Tools.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);

            WindowInput.BorderStyle = BorderStyle.FixedSingle;
            InputRound.BorderStyle = BorderStyle.FixedSingle;
            wnd_defsize.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);

            ChangeGroupBoxPaintEventDark();
            openfolder.ForeColor = Color.Black;
            dl_konleam.ForeColor = Color.Black;
            Kill_process.ForeColor = Color.Black;
            imgdelaysave.ForeColor = Color.Black;

            splitContainer1.ForeColor = Color.Black;

            DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
            string theme = "Dark";
            this.themename = theme;
        }

        private void LightColor()
        {
            ForeColor = DefaultForeColor;
            BackColor = Color.White;
            WindowInput.BackColor = Color.FromArgb(240, 242, 245);
            wnd_defsize.BackColor = DefaultBackColor;
            InputRound.BackColor = Color.FromArgb(240, 242, 245);
            button1.BackColor = DefaultBackColor;
            button1.FlatAppearance.BorderColor = Color.DarkGray;
            button2.BackColor = Color.LavenderBlush;
            button2.FlatAppearance.BorderColor = Color.DarkGray;
            splitter3.BackColor = DefaultBackColor;
            teamtext.BackColor = DefaultBackColor;
            Tiptext1.ForeColor = Color.Brown;
            GameMode.FlatAppearance.BorderColor = Color.FromArgb(206, 208, 212);
            Setting1.ForeColor = DefaultForeColor;
            Setting1.FlatAppearance.BorderColor = Color.FromArgb(206, 208, 212);
            About.ForeColor = DefaultForeColor;
            About.FlatAppearance.BorderColor = Color.FromArgb(206, 208, 212);
            BondlingSt.ForeColor = DefaultForeColor;
            BondlingSt.FlatAppearance.BorderColor = Color.FromArgb(206, 208, 212);
            Tools.ForeColor = DefaultForeColor;
            Tools.FlatAppearance.BorderColor = Color.FromArgb(206, 208, 212);

            WindowInput.BorderStyle = BorderStyle.Fixed3D;
            InputRound.BorderStyle = BorderStyle.Fixed3D;
            wnd_defsize.FlatAppearance.BorderColor = Color.FromArgb(206, 208, 212);


            ChangeGroupBoxPaintEventLight();


            openfolder.ForeColor = ForeColor;
            dl_konleam.ForeColor = ForeColor;
            Kill_process.ForeColor = ForeColor;
            imgdelaysave.ForeColor = ForeColor;

            splitContainer1.ForeColor = Color.Black;

            DwmSetWindowAttribute(Handle, 20, new[] { 0 }, 4);
            string theme = "Light";
            this.themename = theme;
        }

        private void ChangeGroupBoxPaintEventDark()
        {
            List<GroupBox> groupBoxesToChange = new List<GroupBox>
            {
                ServerSelectBox, MainBox, SettingBox1, AboutBox, DevBox,
                BondlingSettingsBox, TeamBox, GameModeBox, WantedBox, RaidOption,
                BondlingOption, konleambox, groupBox1, groupBox2, AfterFinishBox,
                FindIMGBox, ThemeBox, RoundBox, RoundOption
            };
            foreach (var groupBox in groupBoxesToChange)
            {
                groupBox.Paint -= groupBoxLight_Paint;
                groupBox.Paint -= groupBoxDark_Paint;
                groupBox.Paint += groupBoxDark_Paint;
            }
        }

        private void ChangeGroupBoxPaintEventLight()
        {
            List<GroupBox> groupBoxesToChange = new List<GroupBox>
            {
                ServerSelectBox, MainBox, SettingBox1, AboutBox, DevBox,
                BondlingSettingsBox, TeamBox, GameModeBox, WantedBox, RaidOption,
                BondlingOption, konleambox, groupBox1, groupBox2, AfterFinishBox,
                FindIMGBox, ThemeBox, RoundBox, RoundOption
            };
            foreach (var groupBox in groupBoxesToChange)
            {
                groupBox.Paint -= groupBoxLight_Paint;
                groupBox.Paint -= groupBoxDark_Paint;
                groupBox.Paint += groupBoxLight_Paint;
            }
        }

        private void groupBoxDark_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Gainsboro, Color.FromArgb(100, 100, 100));
        }

        private void groupBoxLight_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, Color.Black, Color.FromArgb(206, 208, 212));
        }


        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Brush textBrush = new SolidBrush(textColor);
                    Brush borderBrush = new SolidBrush(borderColor);
                    Pen borderPen = new Pen(borderBrush);
                    SizeF strSize = g.MeasureString(box.Text, box.Font);
                    Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                                   box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                                   box.ClientRectangle.Width - 1,
                                                   box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                    // Clear text and border
                    g.Clear(this.BackColor);

                    // Draw text
                    g.DrawString(box.Text, box.Font, textBrush, Padding.Left + 7, Padding.Top);

                    // Drawing Border
                    //Left
                    g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                    //Right
                    g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                    //Bottom
                    g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                    //Top1
                    g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                    //Top2
                    g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
                });
            }
        }
        #endregion

        #region Check Temp File, Notificationcompleted
        private System.Timers.Timer fileReadTimer;
        private string filePath;

        private void StartUpdatingFileContent()
        {
            string runprocessDirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "runprocess");
            string fileName = $"temp{pid}.txt";
            filePath = Path.Combine(runprocessDirectoryPath, fileName);

            fileReadTimer = new System.Timers.Timer(1000); // อ่านค่าทุกๆ 1000 ms
            fileReadTimer.Elapsed += (sender, e) => UpdateFileContent();
            fileReadTimer.Start();
        }

        string gameMode;
        private void Notificationcompleted()
        {
            if (Notify.Checked && Notify_state == false)
            {
                Notify_state = true;
                if (SoulEvo.Checked)
                {
                    gameMode = "Soul/Evo/Totem";
                }
                else if (Explore.Checked)
                {
                    gameMode = "Explore";
                }
                else if (ExploreRealm.Checked)
                {
                    gameMode = "Explor/Realm";
                }
                else if (RealmRaid.Checked)
                {
                    gameMode = "RealmRaid";
                }
                else if (GuildRealm.Checked)
                {
                    gameMode = "Guild Realm Raid";
                }
                else if (Event.Checked)
                {
                    gameMode = "Event";
                }
                else if (Bondling.Checked)
                {
                    gameMode = "Bondling";
                }

                Random random = new Random();
                int randomNumber = random.Next(1, 10); // สร้างเลขสุ่มระหว่าง 1 ถึง 9
                string imgpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "screenshots\\taskfinished");
                string fileName = $"{randomNumber}.png"; // เพิ่มหมายเลขสุ่มในชื่อไฟล์
                string filePath = Path.Combine(imgpath, fileName);
                try
                {
                    new ToastContentBuilder()
                        .AddAppLogoOverride(new Uri(filePath), ToastGenericAppLogoCrop.Circle)
                        .AddText(WindowInput.Text)
                        .AddText($"[ {gameMode} ] ดำเนินการเสร็จสิ้น!")
                        .AddAttributionText("การแจ้งเตือนนี้จะโดนลบหลังจาก 30 นาที~")
                        //.Show();
                        .Show(toast =>
                        {
                            toast.ExpirationTime = DateTime.Now.AddMinutes(30);
                        });
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

        }

        private void UpdateFileContent()
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            bool isFileLocked = IsFileLocked(filePath);
            if (isFileLocked)
            {
                Console.WriteLine("The file is currently being used by another process.");
                return;
            }

            string fileContent;
            try
            {
                fileContent = File.ReadAllText(filePath);
                this.totalinfile = fileContent;
            }
            catch (IOException)
            {
                Console.WriteLine("Failed to read file content.");
                return;
            }

            Invoke((MethodInvoker)delegate
            {
                int fileContentValue;
                if (int.TryParse(fileContent, out fileContentValue))
                {
                    int incrementedValue = fileContentValue + 1;
                    InputRound.Text = $"{incrementedValue} / {origintotal}";
                }
                else
                {
                    // หากไม่สามารถแปลง fileContent เป็นตัวเลขได้
                    // จะใส่ค่าเดิมของ fileContent และ origintotal
                    InputRound.Text = $"{fileContent} / {origintotal}";
                }
            });

            // ตรวจสอบเงื่อนไขอื่น ๆ และดำเนินการตามที่ต้องการ
            if (fileContent == origintotal && Shutdown.Checked)
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "shutdown",
                    Arguments = "-s -f -t 10",
                    CreateNoWindow = true,
                    UseShellExecute = false
                };

                Process.Start(psi);
                this.beforetotal = "0";
                InputRound.Text = origintotal;
            }
            if (fileContent == origintotal && Closegame.Checked)
            {
                IntPtr hwnd = hwd;
                uint processId;
                GetWindowThreadProcessId(hwnd, out processId);
                try
                {
                    Notificationcompleted();
                    Process process = Process.GetProcessById((int)processId);
                    process.Kill();
                    Console.WriteLine("Process killed successfully.");
                    this.beforetotal = "0";
                    InputRound.Text = origintotal;
                }
                catch (Win32Exception ex)
                {
                    Console.WriteLine($"Failed to kill process: {ex.Message}");
                    // การประมวลผลข้อผิดพลาดที่เกิดขึ้นที่นี่
                }
            }
            else if (fileContent == origintotal && Closegame.Checked == false)
            {
                try
                {
                    Notificationcompleted();
                    int processId = pid;
                    Process process = Process.GetProcessById(processId);
                    process.Kill();
                    this.beforetotal = "0";
                    InputRound.Text = origintotal;
                }
                catch (Win32Exception ex)
                {
                    Console.WriteLine($"Failed to kill process: {ex.Message}");
                    // การประมวลผลข้อผิดพลาดที่เกิดขึ้นที่นี่
                }
            }
        }

        private bool IsFileLocked(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return true;
            }
        }

        private void StopMonitoringFile()
        {
            fileReadTimer?.Stop();
            fileReadTimer?.Dispose();

            Invoke((MethodInvoker)delegate
            {
                if (ResetRound.Checked == true)
                {
                    InputRound.Text = origintotal;
                }
                if (KeepRound.Checked == true)
                {
                    int totalinfileValue;
                    int origintotalValue;
                    if (int.TryParse(totalinfile, out totalinfileValue) && int.TryParse(origintotal, out origintotalValue))
                    {
                        int incrementedValue = origintotalValue - totalinfileValue;
                        //InputRound.Text = $"{incrementedValue} / {origintotal}";
                    }
                    else
                    {
                        // หากไม่สามารถแปลง fileContent เป็นตัวเลขได้
                        // จะใส่ค่าเดิมของ fileContent และ origintotal
                        InputRound.Text = $"{totalinfile} / {origintotal}";
                    }
                }

            });
        }

        #endregion Check Temp File, Notificationcompleted

        #region Check Wanted File
        private FileSystemWatcher fileWatcher;
        private void StartMonitoringFile()
        {
            string programDirectoryPath = AppDomain.CurrentDomain.BaseDirectory; // เส้นทางไปยังโฟลเดอร์ของโปรแกรม
            string runprocessDirectoryPath = Path.Combine(programDirectoryPath, "runprocess"); // เส้นทางไปยังโฟลเดอร์ runprocess
            string fileName = $"wanted{pid}.txt";
            string filePath = Path.Combine(runprocessDirectoryPath, fileName);

            // สร้างไฟล์ wanted{pid}.txt หากยังไม่มี
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            fileWatcher = new FileSystemWatcher(runprocessDirectoryPath, fileName);
            fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            fileWatcher.Changed += WantefWatcher_Changed;
            fileWatcher.EnableRaisingEvents = true;
        }


        private void WantefWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                // แสดง MessageBox ในเธรดของ UI
                StopMonitoringFile2();
                Tiptext1.Text = String.Empty;
                string wantedfileName = $"wanted{pid}.txt";
                string wantedPath = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "runprocess"), wantedfileName);
                string wantedContent;
                try
                {
                    wantedContent = File.ReadAllText(wantedPath);
                    string imgName = wantedContent;
                    string imagePath = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "คนเหลี่ยมๆ"), imgName);
                    Invoke(new Action(() =>
                    {
                        Form targetForm = this; // หรือเป็นชื่อของ Form ที่ต้องการเป็น topmost

                        // ตั้งค่า Form เป็น topmost
                        targetForm.Invoke(new Action(() =>
                        {
                            targetForm.TopMost = true;
                            targetForm.TopMost = false;
                            NSLaunch.CustomMessageBox.Showwanted(imagePath, themename);
                        }));
                    }));

                    StartMonitoringFile();
                }
                catch (IOException)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        Tiptext1.Text = "Failed to read file content.";
                    });
                    StartMonitoringFile();
                    return;
                }
            }
        }

        private void StopMonitoringFile2()
        {
            if (fileWatcher != null)
            {
                fileWatcher.Changed -= WantefWatcher_Changed;
                fileWatcher.EnableRaisingEvents = false;
                fileWatcher.Dispose();
                fileWatcher = null;
            }
        }
        #endregion Check Wanted File

        #region Setup UI Code
        private void EnableGroupBoxes()
        {
            transparentPanel1.SendToBack();
            transparentPanel2.SendToBack();
            transparentPanel3.SendToBack();
            transparentPanel5.SendToBack();
        }

        private void DisableGroupBoxes()
        {
            transparentPanel1.BringToFront();
            transparentPanel2.BringToFront();
            transparentPanel3.BringToFront();
            transparentPanel5.BringToFront();
        }

        private void onMainBox()
        {
            MainBox.Visible = true;
            BondlingSettingsBox.Visible = false;
            SettingBox1.Visible = false;
            AboutBox.Visible = false;
            DevBox.Visible = false;
        }

        private void onBondlingSettingsBox()
        {
            MainBox.Visible = false;
            BondlingSettingsBox.Visible = true;
            SettingBox1.Visible = false;
            AboutBox.Visible = false;
            DevBox.Visible = false;
        }

        private void onSettingBox1()
        {
            MainBox.Visible = false;
            BondlingSettingsBox.Visible = false;
            SettingBox1.Visible = true;
            AboutBox.Visible = false;
            DevBox.Visible = false;
        }

        private void onAboutBox()
        {
            MainBox.Visible = false;
            BondlingSettingsBox.Visible = false;
            SettingBox1.Visible = false;
            AboutBox.Visible = true;
            DevBox.Visible = false;
        }

        private void onDevBox()
        {
            MainBox.Visible = false;
            BondlingSettingsBox.Visible = false;
            SettingBox1.Visible = false;
            AboutBox.Visible = false;
            DevBox.Visible = true;
        }

        #endregion Setup UI Code

        #region ส่วนบนของ UI : default size button (wnd_defsize), RadioButton เลือก Server
        private void FindWindow()
        {
            string windowName = WindowInput.Text;
            IntPtr windowHandle = NativeMethods.FindWindow(null, windowName);
            this.hwd = windowHandle;
        }

        private void resize_Click(object sender, EventArgs e)
        {
            FindWindow();
            string windowHandleStr = hwd.ToString();
            IntPtr windowHandle = IntPtr.Zero;
            if (!string.IsNullOrEmpty(windowHandleStr))
            {
                windowHandle = IntPtr.Parse(windowHandleStr);
            }

            if (windowHandle != IntPtr.Zero)
            {
                RECT rct = new RECT();
                GetWindowRect(windowHandle, ref rct);

                // เปลี่ยนขนาดหน้าต่าง
                int currentWidth = rct.Right - rct.Left;
                int currentHeight = rct.Bottom - rct.Top;
                int targetX = rct.Left; // ใช้ตำแหน่ง X เดิม
                int targetY = rct.Top; // ใช้ตำแหน่ง Y เดิม

                if (currentHeight != 679)
                {
                    SetWindowPos(windowHandle, IntPtr.Zero, targetX, targetY, 1493, 679, SWP_SHOWWINDOW);
                }

            }

        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton radioButton = (System.Windows.Forms.RadioButton)sender;

            if (radioButton.Checked)
            {
                string selected = "";

                switch (radioButton.Name)
                {
                    case "radioButtonGB":
                        selected = "GB";
                        WindowInput.Text = "陰陽師Onmyoji";
                        break;
                    case "radioButtonJP":
                        selected = "JP";
                        WindowInput.Text = "陰陽師Onmyoji";
                        break;
                    case "radioButtonCN":
                        selected = "CN";
                        WindowInput.Text = "阴阳师-网易游戏";
                        break;
                }

                this.selectedValue = selected;
            }
        }

        #endregion ส่วนบนของ UI : default size button (wnd_defsize), RadioButton เลือก Server

        #region Start Button and Stop Button
        private void button1_Click(object sender, EventArgs e)
        {
            Tiptext1.Text = string.Empty;
            wt_saveconfig();
            FindWindow();
            if (hwd != IntPtr.Zero)
            {
                Notify_state = false;
                SetThreadExecutionState(ES_CONTINUOUS | ES_DISPLAY_REQUIRED);
                LockWindowResize(hwd);
                int result;
                if (!int.TryParse(total, out result) && ResetRound.Checked == true)
                {
                    timer = new System.Windows.Forms.Timer();
                    timer.Interval = 5000;
                    timer.Tick += Timer_Tick;
                    timer.Start();
                    Tiptext1.Text = "กรุณาตรวจสอบว่าภายในช่อง Total Round มีเฉพาะตัวเลข และต้องไม่มีตัวอักษร หรือเป็นช่องว่าง";
                    return;
                }
                if (KeepRound.Checked == true)
                {
                    string input = total;
                    string[] values = input.Split('/');

                    if (input.Contains("/"))
                    {
                        beforetotal = values[0].Trim();
                        total = values[1].Trim();

                        if (!string.IsNullOrEmpty(beforetotal) && int.TryParse(beforetotal, out int beforeValue))
                        {
                            beforeValue -= 1;
                            this.beforetotal = beforeValue.ToString();
                        }
                    }
                }

                RoundBox.Text = "⨠ In Process";
                button1.Enabled = false;
                button2.Visible = true;
                string gettotal = total;
                this.origintotal = total;
                string programDirectoryPath = AppDomain.CurrentDomain.BaseDirectory; // เส้นทางไปยังโฟลเดอร์ของโปรแกรม
                string exePath = Path.Combine(programDirectoryPath, "runprocess\\runprocess.exe"); // เส้นทางไปยังโฟลเดอร์ runprocess
                string[] arguments = { gameModeselected, selectedValue, hwd.ToString(), beforetotal, total, Wantedselected, bondlingMode, disc, crystal_use, tomb, snowball, azure, kuro };
                string argumentsString = string.Join(" ", arguments);
                //MessageBox.Show(argumentsString);


                runningProcess = new Process();
                runningProcess.StartInfo.FileName = exePath;
                runningProcess.StartInfo.Arguments = argumentsString;
                runningProcess.StartInfo.CreateNoWindow = true; // ไม่แสดงหน้าต่าง
                runningProcess.Start();


                runningProcess.EnableRaisingEvents = true;
                runningProcess.Exited += RunningProcess_Exited;
                DisableGroupBoxes();

                int processId = runningProcess.Id;
                this.pid = processId;

                string runprocessDirectoryPath = Path.Combine(programDirectoryPath, "runprocess"); // เส้นทางไปยังโฟลเดอร์ runprocess
                string fileName = $"temp{pid}.txt";
                string filePath = Path.Combine(runprocessDirectoryPath, fileName);

                using (StreamWriter file = new StreamWriter(filePath))
                {
                    file.Write("0");
                }
                StartUpdatingFileContent();
                StartMonitoringFile();
            }
            else
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 5000;
                timer.Tick += Timer_Tick;
                timer.Start();
                Tiptext1.Text = "ไม่พบหน้าต่างเกม กรุณาตรวจสอบชื่อหน้าต่าง และปุ่มเลือก Server";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int processId = pid;
            Process process = Process.GetProcessById(processId);
            process.Kill();
            SetThreadExecutionState(ES_CONTINUOUS);
            EnableWindowResize(hwd);
            //button2.Visible = false;
            //button1.Visible = true;
            //EnableGroupBoxes();
        }

        #endregion Start Button and Stop Button

        #region Backgroud Process Code
        private void RunningProcess_Exited(object sender, EventArgs e)
        {
            string programDirectoryPath = AppDomain.CurrentDomain.BaseDirectory; // เส้นทางไปยังโฟลเดอร์ของโปรแกรม
            string runprocessDirectoryPath = Path.Combine(programDirectoryPath, "runprocess"); // เส้นทางไปยังโฟลเดอร์ runprocess
            string fileName = $"temp{pid}.txt";
            string filePath = Path.Combine(runprocessDirectoryPath, fileName);


            string wantedFileName = $"wanted{pid}.txt";
            string wantedFilePath = Path.Combine(runprocessDirectoryPath, wantedFileName);

            UpdateFileContent();

            StopMonitoringFile();
            StopMonitoringFile2();
            EnableWindowResize(hwd);

            // ตรวจสอบว่าไฟล์มีอยู่จริงก่อนทำการลบ
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            if (File.Exists(wantedFilePath))
            {
                File.Delete(wantedFilePath);
            }

            if (InvokeRequired)
            {
                // เรียกใช้ Invoke เพื่อเข้าถึง controls ในเธรด UI หลัก
                Invoke(new Action(() =>
                {
                    button2.Visible = false;
                    button1.Enabled = true;
                    RoundBox.Text = "Total Round";
                    EnableGroupBoxes();
                    SetThreadExecutionState(ES_CONTINUOUS);
                }));
            }
            else
            {
                button2.Visible = false;
                button1.Enabled = true;
                RoundBox.Text = "Total Round";
                EnableGroupBoxes();
                SetThreadExecutionState(ES_CONTINUOUS);
            }

        }

        private void LockWindowResize(IntPtr windowHandle)
        {
            int currentStyle = GetWindowLong(windowHandle, GWL_STYLE);
            int newStyle = currentStyle & ~WS_THICKFRAME;

            SetWindowLong(windowHandle, GWL_STYLE, newStyle);
        }

        private void EnableWindowResize(IntPtr windowHandle)
        {
            int currentStyle = GetWindowLong(windowHandle, GWL_STYLE);
            int newStyle = currentStyle | WS_THICKFRAME;

            SetWindowLong(windowHandle, GWL_STYLE, newStyle);

        }
        #endregion Backgroud Process Code

        #region MainPage : GameMode and Etc.
        private void radioGameMode_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton radioButton = (System.Windows.Forms.RadioButton)sender;
            BondlingExp.Checked = true;
            crystal_uncheck();
            crystal.Enabled = false;
            this.beforetotal = "0";

            string gameMode = "";
            Solo.Checked = true;
            RaidAll.Checked = true;
            Tiptext1.Text = string.Empty;
            teamtext.Text = "Single";

            if (SoulEvo.Checked)
            {
                TeamBox.Visible = true;
                RaidOption.Visible = false;
                BondlingOption.Visible = false;
                Team.Enabled = true;
                gameMode = "SingleSoul";
                InputRound.Text = "500";
            }
            else if (Explore.Checked)
            {
                TeamBox.Visible = true;
                RaidOption.Visible = false;
                BondlingOption.Visible = false;
                Team.Enabled = true;
                gameMode = "SingleExplore";
                InputRound.Text = "500";
            }
            else if (ExploreRealm.Checked)
            {
                TeamBox.Visible = false;
                MainBox.Controls.Add(RaidOption);
                RaidOption.Location = TeamBox.Location;
                RaidOption.Visible = true;
                RaidOption.BringToFront();
                BondlingOption.Visible = false;
                Solo.Select();
                Team.Enabled = false;
                gameMode = "Explor3Realm";
                this.bondlingMode = "AllRaid";
                InputRound.Text = "4";
            }
            else if (RealmRaid.Checked)
            {
                TeamBox.Visible = false;
                MainBox.Controls.Add(RaidOption);
                RaidOption.Location = TeamBox.Location;
                RaidOption.Visible = true;
                RaidOption.BringToFront();
                BondlingOption.Visible = false;
                Solo.Select();
                Team.Enabled = false;
                gameMode = "RealmRaid";
                this.bondlingMode = "AllRaid";
                InputRound.Text = "30";
            }
            else if (GuildRealm.Checked)
            {
                TeamBox.Visible = true;
                RaidOption.Visible = false;
                BondlingOption.Visible = false;
                Solo.Select();
                Team.Enabled = false;
                gameMode = "GuildRealmRaid";
                InputRound.Text = "80";
            }
            else if (Event.Checked)
            {
                TeamBox.Visible = true;
                RaidOption.Visible = false;
                BondlingOption.Visible = false;
                Solo.Select();
                Team.Enabled = false;
                gameMode = "Event";
                InputRound.Text = "300";
            }
            else if (Bondling.Checked)
            {
                TeamBox.Visible = false;
                MainBox.Controls.Add(BondlingOption);
                BondlingOption.Location = TeamBox.Location;
                BondlingOption.BringToFront();
                RaidOption.Visible = false;
                BondlingOption.Visible = true;
                Solo.Select();
                Team.Enabled = false;
                gameMode = "Bondling";
                this.bondlingMode = "Explore";
                InputRound.Text = "100";
            }

            this.gameModeselected = gameMode;
        }
        private void radioTeam_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.RadioButton radioButton = (System.Windows.Forms.RadioButton)sender;

            Tiptext1.Text = string.Empty;
            string gameMode = "";
            if (SoulEvo.Checked && Solo.Checked)
            {
                gameMode = "SingleSoul";
                teamtext.Text = "Single";
            }
            else if (SoulEvo.Checked && Team.Checked)
            {
                gameMode = "Soul";
                teamtext.Text = "Team";
            }
            else if (Explore.Checked && Solo.Checked)
            {
                gameMode = "SingleExplore";
                teamtext.Text = "Single";
            }
            else if (Explore.Checked && Team.Checked)
            {
                gameMode = "Explore";
                teamtext.Text = "Team";
            }
            else if (RealmRaid.Checked && RaidAll.Checked)
            {
                gameMode = "RealmRaid";
                this.bondlingMode = "AllRaid";
                teamtext.Text = "Single";
            }
            else if (RealmRaid.Checked && Win3.Checked)
            {
                gameMode = "RealmRaid";
                this.bondlingMode = "Explore";
                teamtext.Text = "Single";
            }
            else if (RealmRaid.Checked && Win3Fail3.Checked)
            {
                gameMode = "RealmRaidW3F3";
                this.bondlingMode = "Explore";
                teamtext.Text = "Single";
            }
            else if (ExploreRealm.Checked && RaidAll.Checked)
            {
                gameMode = "Explor3Realm";
                this.bondlingMode = "AllRaid";
                teamtext.Text = "Single";
            }
            else if (ExploreRealm.Checked && Win3.Checked)
            {
                gameMode = "Explor3Realm";
                this.bondlingMode = "Explore";
                teamtext.Text = "Single";
            }
            else if (ExploreRealm.Checked && Win3Fail3.Checked)
            {
                gameMode = "Explor3RealmW3F3";
                this.bondlingMode = "Explore";
                teamtext.Text = "Single";
            }
            this.gameModeselected = gameMode;
        }

        private void BondlingMode_CheckedChanged(object sender, EventArgs e)
        {
            if (BondlingExp.Checked == true)
            {
                this.bondlingMode = "Explore";
                Tiptext1.Text = string.Empty;
                crystal_uncheck();
                crystal.Enabled = false;
            }
            else if (BondlingPact.Checked == true && button2.Visible != true)
            {
                this.bondlingMode = "Pact";
                crystal.Enabled = true;
                Tiptext1.Text = "สามารถตั้งค่า Disc และสัตว์ที่ต้องการจับ ได้ที่แท็บ Bondling Settings หรือปุม Config";
            }
            else if (BondlingBoth.Checked == true && button2.Visible != true)
            {
                this.bondlingMode = "Both";
                Tiptext1.Text = "สามารถตั้งค่า Disc และสัตว์ที่ต้องการจับ ได้ที่แท็บ Bondling Settings หรือปุม Config";
                crystal_uncheck();
                crystal.Enabled = false;
            }

        }

        private void InputRound_TextChanged(object sender, EventArgs e)
        {
            this.total = InputRound.Text.ToString();
        }

        #endregion MainPage : GameMode and Etc.

        #region MainPage : Wanted Quest CheckBox And SaveConfig
        private void wt_CheckedChanged(object sender, EventArgs e)
        {
            wt_saveconfig();
        }

        private void wt_saveconfig()
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            string jsonContent = File.ReadAllText(jsonPath);

            dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);

            if (wt_jade.Checked)
            {
                jsonData.VALUE.WQ_JADE = true;
            }
            else
            {
                jsonData.VALUE.WQ_JADE = false;
            }
            if (wt_coin.Checked)
            {
                jsonData.VALUE.WQ_COIN = true;
            }
            else
            {
                jsonData.VALUE.WQ_COIN = false;
            }
            if (wt_sushi.Checked)
            {
                jsonData.VALUE.WQ_SUSHI = true;
            }
            else
            {
                jsonData.VALUE.WQ_SUSHI = false;
            }
            if (wt_food.Checked)
            {
                jsonData.VALUE.WQ_FOOD = true;
            }
            else
            {
                jsonData.VALUE.WQ_FOOD = false;
            }

            string updatedJsonContent = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

            File.WriteAllText(jsonPath, updatedJsonContent);
        }

        #endregion MainPage : Wanted Quest CheckBox And SaveConfig

        #region DEV Options

        private void ArgGen_Click(object sender, EventArgs e)
        {
            FindWindow();
            if (hwd != IntPtr.Zero)
            {
                int result;
                if (!int.TryParse(total, out result) && ResetRound.Checked == true)
                {
                    Tiptext1.Text = "กรุณาตรวจสอบว่าภายในช่อง Total Round มีเฉพาะตัวเลข และต้องไม่มีตัวอักษร หรือเป็นช่องว่าง";
                    return;
                }
                if (KeepRound.Checked == true)
                {
                    string input = total;
                    string[] values = input.Split('/');

                    if (input.Contains("/"))
                    {
                        beforetotal = values[0].Trim();
                        total = values[1].Trim();

                        if (!string.IsNullOrEmpty(beforetotal) && int.TryParse(beforetotal, out int beforeValue))
                        {
                            beforeValue -= 1;
                            this.beforetotal = beforeValue.ToString();
                        }
                    }
                }

                string[] arguments = { gameModeselected, selectedValue, hwd.ToString(), beforetotal, total, Wantedselected, bondlingMode, disc, crystal_use, tomb, snowball, azure, kuro };
                string argumentsString = string.Join(" ", arguments);
                this.argumentsString = argumentsString;
                textBox1.Text = "python runprocess.py " + argumentsString;
                ArgCopyState.Text = "Generate Success, Click TextBox to Copy";
                ArgCopyState.ForeColor = Color.DarkCyan;
            }
            else
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 5000;
                timer.Tick += Timer_Tick;
                timer.Start();
                Tiptext1.Text = "ไม่พบหน้าต่างเกม กรุณาตรวจสอบชื่อหน้าต่าง และปุ่มเลือก Server";
            }
        }

        private void runpython_Click(object sender, EventArgs e)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "cmd.exe"; // กำหนดชื่อโปรแกรมที่ใช้เปิดหน้าต่าง Shell
            start.Arguments = "/C " + textBox1.Text; // กำหนดคำสั่ง Python ที่ต้องการรัน

            // ตัวอย่างการกำหนด working directory (โดยใช้ตำแหน่งปัจจุบันของโปรแกรม C#)
            start.WorkingDirectory = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

            start.UseShellExecute = false;
            start.CreateNoWindow = false;

            using (Process process = new Process())
            {
                process.StartInfo = start;
                process.Start();
            }
        }
        #endregion DEV Options

        #region Main UI Box Page
        private void GameMode_Click(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                //MainBox.BringToFront();
                onMainBox();
                Button_to_front();
            });
        }

        private void Setting1_Click(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                //SettingBox1.BringToFront();
                onSettingBox1();
                Button_to_front();
            });
        }

        private void About_Click(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                //AboutBox.BringToFront();
                onAboutBox();
                Button_to_front();
            });
        }

        private void BondlingSt_Click(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                //BondlingSettingsBox.BringToFront();
                onBondlingSettingsBox();
                Button_to_front();
            });
        }

        private void Tools_Click(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                //DevBox.BringToFront();
                onDevBox();
                Button_to_front();
            });
        }

        private void Button_to_front()
        {
            Invoke((MethodInvoker)delegate
            {
                GameMode.BringToFront();
                Setting1.BringToFront();
                About.BringToFront();
                Tools.BringToFront();
                BondlingSt.BringToFront();
            });
        }
        #endregion Main UI Box Page

        #region Bondling Page CheckBox
        private void DiscSelect_CheckedChanged(object sender, EventArgs e)
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json");
            string jsonContent = File.ReadAllText(jsonPath);

            dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);

            if (Basic.Checked)
            {
                this.disc = "1";
                jsonData["disc"] = "1";
            }
            else if (Great.Checked)
            {
                this.disc = "2";
                jsonData["disc"] = "2";
            }
            else if (Ultra.Checked)
            {
                this.disc = "3";
                jsonData["disc"] = "3";
            }

            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(jsonData, Formatting.Indented));
        }

        private void pact_CheckedChanged(object sender, EventArgs e)
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json");
            string jsonContent = File.ReadAllText(jsonPath);

            dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);

            bool tombChecked = Tomb.Checked;
            bool snowballChecked = Snowball.Checked;
            bool azureChecked = Azure.Checked;
            bool kuroChecked = Kuro.Checked;

            if (tombChecked != (this.tomb == "true"))
            {
                this.tomb = tombChecked ? "true" : "false";
                jsonData["tomb"] = tombChecked;
            }
            if (snowballChecked != (this.snowball == "true"))
            {
                this.snowball = snowballChecked ? "true" : "false";
                jsonData["snowball"] = snowballChecked;
            }
            if (azureChecked != (this.azure == "true"))
            {
                this.azure = azureChecked ? "true" : "false";
                jsonData["azure"] = azureChecked;
            }
            if (kuroChecked != (this.kuro == "true"))
            {
                this.kuro = kuroChecked ? "true" : "false";
                jsonData["kuro"] = kuroChecked;
            }

            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(jsonData, Formatting.Indented));
        }

        private void crystal_CheckedChanged(object sender, EventArgs e)
        {
            if (crystal.Checked)
            {
                this.crystal_use = "true";
                Tomb.Visible = false;
                Snowball.Visible = false;
                Azure.Visible = false;
                Kuro.Visible = false;

                rTomb.Checked = true;
                rTomb.Visible = true;
                rSnowBall.Visible = true;
                rAzure.Visible = true;
                rKuro.Visible = true;
            }
            if (crystal.Checked == false)
            {
                crystal_uncheck();
            }
        }

        private void crystal_uncheck()
        {
            this.crystal_use = "false";
            crystal.Checked = false;
            Tomb.Visible = true;
            Snowball.Visible = true;
            Azure.Visible = true;
            Kuro.Visible = true;

            rTomb.Checked = false;
            rSnowBall.Checked = false;
            rAzure.Checked = false;
            rKuro.Checked = false;

            rTomb.Visible = false;
            rSnowBall.Visible = false;
            rAzure.Visible = false;
            rKuro.Visible = false;
        }

        private void crystal_pact_CheckedChanged(object sender, EventArgs e)
        {
            this.Tomb.Checked = false;
            this.Snowball.Checked = false;
            this.Azure.Checked = false;
            this.Kuro.Checked = false;
            if (rTomb.Checked == true)
            {
                this.crystal_use = "1";
                this.Tomb.Checked = true;
            }
            if (rSnowBall.Checked == true)
            {
                this.crystal_use = "2";
                this.Snowball.Checked = true;
            }
            if (rAzure.Checked == true)
            {
                this.crystal_use = "3";
                this.Azure.Checked = true;
            }
            if (rKuro.Checked == true)
            {
                this.crystal_use = "4";
                this.Kuro.Checked = true;
            }
        }
        #endregion Bondling Page CheckBox

        #region Settings Page CheckBox
        private void Kill_process_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("runprocess");

            foreach (Process process in processes)
            {
                process.Kill();
            }
        }

        public static void DeleteDirectory(string directoryPath)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
                    Console.WriteLine("โฟลเดอร์ถูกลบเรียบร้อยแล้ว");
                }
                else
                {
                    Console.WriteLine("ไม่พบโฟลเดอร์ที่ต้องการลบ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("เกิดข้อผิดพลาดในการลบโฟลเดอร์: " + ex.Message);
            }
        }

        private void dl_konleam_Click(object sender, EventArgs e)
        {
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "คนเหลี่ยมๆ");
            if (Directory.Exists(directoryPath))
            {
                DeleteDirectory(directoryPath);
                MessageBox.Show("ลบโฟลเดอร์แล้ว!");
            }
        }

        private void openfolder_Click(object sender, EventArgs e)
        {
            string folderName = "คนเหลี่ยมๆ";
            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folderName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            System.Diagnostics.Process.Start("explorer.exe", directoryPath);
        }

        private void KeepRound_CheckedChanged(object sender, EventArgs e)
        {
            this.ResetRound.CheckedChanged += radioGameMode_CheckedChanged;
            this.beforetotal = "0";

            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json");
            string jsonContent = File.ReadAllText(jsonPath);

            dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);
            jsonData.roundoption = "keep";

            string updatedJsonContent = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

            File.WriteAllText(jsonPath, updatedJsonContent);
        }

        private void ResetRound_CheckedChanged(object sender, EventArgs e)
        {
            this.ResetRound.CheckedChanged += radioGameMode_CheckedChanged;
            this.beforetotal = "0";

            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json");
            string jsonContent = File.ReadAllText(jsonPath);

            dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);
            jsonData.roundoption = "reset";

            string updatedJsonContent = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

            File.WriteAllText(jsonPath, updatedJsonContent);
        }

        private void themesys_CheckedChanged(object sender, EventArgs e)
        {
            ThemeMode();
        }

        private void Notify_CheckedChanged(object sender, EventArgs e)
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.json");
            string jsonContent = File.ReadAllText(jsonPath);

            dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);


            if (Notify.Checked == false)
            {
                jsonData["notify"] = false;
            }
            if (Notify.Checked == true)
            {
                jsonData["notify"] = true;
            }

            File.WriteAllText(jsonPath, JsonConvert.SerializeObject(jsonData, Formatting.Indented));
        }

        private void imgdelaysave_Click(object sender, EventArgs e)
        {
            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            string jsonContent = File.ReadAllText(jsonPath);

            dynamic jsonData = JsonConvert.DeserializeObject(jsonContent);

            // ตรงนี้คุณสามารถตั้งค่าเป็นค่าทศนิยมโดยตรงโดยไม่ใช้ ""
            jsonData.VALUE.FIND_IMG_DELAY = float.Parse(domainUpDown1.Text);

            string updatedJsonContent = JsonConvert.SerializeObject(jsonData, Formatting.Indented);

            File.WriteAllText(jsonPath, updatedJsonContent);
        }



        #endregion Settings Page CheckBox

        #region Form Closing
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            EnableWindowResize(hwd);

            int processId = pid;
            if (processId != 0)
            {
                Process process = Process.GetProcessById(processId);
                process.Kill();

                string programDirectoryPath = AppDomain.CurrentDomain.BaseDirectory; // เส้นทางไปยังโฟลเดอร์ของโปรแกรม
                string runprocessDirectoryPath = Path.Combine(programDirectoryPath, "runprocess"); // เส้นทางไปยังโฟลเดอร์ runprocess
                string fileName = $"temp{pid}.txt";
                string filePath = Path.Combine(runprocessDirectoryPath, fileName);


                string wantedFileName = $"wanted{pid}.txt";
                string wantedFilePath = Path.Combine(runprocessDirectoryPath, wantedFileName);

                // ตรวจสอบว่าไฟล์มีอยู่จริงก่อนทำการลบ
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                if (File.Exists(wantedFilePath))
                {
                    File.Delete(wantedFilePath);
                }

            }
        }

        #endregion Form Closing

        #region อื่นๆ

        private double GetDisplayScale()
        {
            using (Graphics g = this.CreateGraphics())
            {
                float dpiX = g.DpiX;
                float dpiY = g.DpiY;

                return dpiX / 96.0; // 96 DPI คือ DPI ที่มีขนาดเท่ากับ 100%
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Tiptext1.Text = string.Empty;
            timer.Stop();
            timer.Dispose();
        }

        #endregion อื่นๆ

    }

    public class TransparentPanel : Panel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return cp;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }
    }


}
