using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NSLaunch
{
    public partial class CustomMessageBox : Form
    {
        private Label messageLabel;
        private Splitter splitter1;
        private Button okbutton;
        //private static object file;
        string imagePath = string.Empty;
        string theme = null;

        public CustomMessageBox(string message)
        {
            InitializeComponent();
            messageLabel.Text = message;
            open_button.Visible = false;
            imagePath = message;
        }

        private void InitializeComponent()
        {
            messageLabel = new Label();
            splitter1 = new Splitter();
            okbutton = new Button();
            open_button = new Button();
            ChangeDPI = new Button();
            SuspendLayout();
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            messageLabel.Location = new Point(15, 13);
            messageLabel.Margin = new Padding(3, 0, 3, 40);
            messageLabel.Name = "messageLabel";
            messageLabel.Padding = new Padding(0, 0, 10, 0);
            messageLabel.Size = new Size(63, 15);
            messageLabel.TabIndex = 0;
            messageLabel.Text = "Message";
            // 
            // splitter1
            // 
            splitter1.BackColor = SystemColors.ControlLight;
            splitter1.Dock = DockStyle.Bottom;
            splitter1.Cursor = Cursors.Arrow;
            splitter1.Location = new Point(0, 40);
            splitter1.Name = "splitter1";
            splitter1.RightToLeft = RightToLeft.No;
            splitter1.Size = new Size(317, 30);
            splitter1.TabIndex = 1;
            splitter1.TabStop = false;
            // 
            // okbutton
            // 
            okbutton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okbutton.Location = new Point(236, 43);
            okbutton.Margin = new Padding(0, 0, 5, 5);
            okbutton.Name = "okbutton";
            okbutton.Size = new Size(75, 23);
            okbutton.TabIndex = 2;
            okbutton.Text = "OK";
            okbutton.UseVisualStyleBackColor = true;
            okbutton.Click += okbutton_Click;
            // 
            // open_button
            // 
            open_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            open_button.Location = new Point(149, 43);
            open_button.Margin = new Padding(0, 0, 5, 5);
            open_button.Name = "open_button";
            open_button.Size = new Size(82, 23);
            open_button.TabIndex = 3;
            open_button.Text = "Open Image";
            open_button.UseVisualStyleBackColor = true;
            open_button.Visible = false;
            open_button.Click += open_button_Click;
            // 
            // ChangeDPI
            // 
            ChangeDPI.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ChangeDPI.Location = new Point(130, 43);
            ChangeDPI.Margin = new Padding(0, 0, 5, 5);
            ChangeDPI.Name = "ChangeDPI";
            ChangeDPI.Size = new Size(101, 23);
            ChangeDPI.TabIndex = 4;
            ChangeDPI.Text = "Open Settings";
            ChangeDPI.UseVisualStyleBackColor = true;
            ChangeDPI.Visible = false;
            ChangeDPI.Click += ChangeDPI_Click;
            // 
            // CustomMessageBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(317, 70);
            Controls.Add(ChangeDPI);
            Controls.Add(open_button);
            Controls.Add(okbutton);
            Controls.Add(splitter1);
            Controls.Add(messageLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomMessageBox";
            StartPosition = FormStartPosition.CenterParent;
            Text = "NSBot";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        [DllImport("DwmApi")] //System.Runtime.InteropServices
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);
        private void Check_Theme()
        {
            if (theme == "Dark")
            {
                ForeColor = Color.DarkGray;
                BackColor = Color.FromArgb(43, 45, 49);
                okbutton.FlatStyle = FlatStyle.Flat;
                okbutton.FlatAppearance.BorderSize = 1;
                okbutton.FlatAppearance.BorderColor = BackColor;
                open_button.FlatStyle = FlatStyle.Flat;
                open_button.FlatAppearance.BorderSize = 1;
                open_button.FlatAppearance.BorderColor = BackColor;
                ChangeDPI.FlatStyle = FlatStyle.Flat;
                ChangeDPI.FlatAppearance.BorderSize = 1;
                ChangeDPI.FlatAppearance.BorderColor = BackColor;
                splitter1.BackColor = Color.FromArgb(28, 28, 28);

                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
            }
        }

        public static void Showok(string message)
        {
            using (CustomMessageBox customMessageBox = new CustomMessageBox(message))
            {
                customMessageBox.TopMost = false;
                customMessageBox.open_button.Visible = false;
                customMessageBox.ChangeDPI.Visible = false;
                customMessageBox.Check_Theme();
                customMessageBox.ShowDialog();
            }
        }

        public static void Showwanted(string message)
        {
            using (CustomMessageBox customMessageBox = new CustomMessageBox("ตรวจพบการส่ง Co-op Quest กรุณาตรวจสอบ หลังจากดำเนินการเสร็จ.."))
            {
                customMessageBox.TopMost = false;
                customMessageBox.Check_Theme();
                customMessageBox.imagePath = message;
                customMessageBox.open_button.Visible = true;
                customMessageBox.ChangeDPI.Visible = false;
                customMessageBox.ShowDialog();
            }
        }

        public static void SettingDPI(string message)
        {
            using (CustomMessageBox customMessageBox = new CustomMessageBox(message))
            {
                customMessageBox.TopMost = false;
                customMessageBox.Check_Theme();
                //customMessageBox.okbutton.Text = "ปิด";
                customMessageBox.open_button.Visible = false;
                customMessageBox.ChangeDPI.Visible = true;
                customMessageBox.ShowDialog();
            }
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void open_button_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", imagePath);
        }

        private void LinkLabelDpiSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            {
                Process.Start(new ProcessStartInfo { FileName = @"ms-settings:display", UseShellExecute = true });
            }

        }

        private void ChangeDPI_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo { FileName = @"ms-settings:display", UseShellExecute = true });
            }
            catch
            {
                messageLabel.Text = "ไม่สามารถเปิดหน้า Settings สามารถหาวิธีตั้งค่าใน Internet หรือ\nเปิด Windows Settings > Display Settings มองหา 'Scale && layout'";
            }
        }
    }

}