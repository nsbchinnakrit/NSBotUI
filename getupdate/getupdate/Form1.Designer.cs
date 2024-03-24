namespace getupdate
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            listBox1 = new ListBox();
            Getver_button = new Button();
            Download_button = new Button();
            CN = new RadioButton();
            JP = new RadioButton();
            GB = new RadioButton();
            label1 = new Label();
            Extract_button = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 69);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(465, 154);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // Getver_button
            // 
            Getver_button.Location = new Point(402, 233);
            Getver_button.Name = "Getver_button";
            Getver_button.Size = new Size(75, 23);
            Getver_button.TabIndex = 1;
            Getver_button.Text = "Get Version";
            Getver_button.UseVisualStyleBackColor = true;
            Getver_button.Click += Getver_Button_Click;
            // 
            // Download_button
            // 
            Download_button.Location = new Point(321, 233);
            Download_button.Name = "Download_button";
            Download_button.Size = new Size(75, 23);
            Download_button.TabIndex = 2;
            Download_button.Text = "Download";
            Download_button.UseVisualStyleBackColor = true;
            Download_button.Visible = false;
            Download_button.Click += Download_button_Click;
            // 
            // CN
            // 
            CN.AutoSize = true;
            CN.Checked = true;
            CN.Location = new Point(12, 12);
            CN.Name = "CN";
            CN.Size = new Size(77, 19);
            CN.TabIndex = 3;
            CN.TabStop = true;
            CN.Text = "CN Server";
            CN.UseVisualStyleBackColor = true;
            CN.Click += ServerSelect;
            // 
            // JP
            // 
            JP.AutoSize = true;
            JP.Location = new Point(122, 12);
            JP.Name = "JP";
            JP.Size = new Size(71, 19);
            JP.TabIndex = 4;
            JP.Text = "JP Server";
            JP.UseVisualStyleBackColor = true;
            JP.Click += ServerSelect;
            // 
            // GB
            // 
            GB.AutoSize = true;
            GB.Location = new Point(232, 12);
            GB.Name = "GB";
            GB.Size = new Size(75, 19);
            GB.TabIndex = 5;
            GB.Text = "GB Server";
            GB.UseVisualStyleBackColor = true;
            GB.Click += ServerSelect;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveBorder;
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(465, 19);
            label1.TabIndex = 6;
            label1.Text = "Select Server and Click \"Get Version\" to get file version";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Extract_button
            // 
            Extract_button.Location = new Point(240, 233);
            Extract_button.Name = "Extract_button";
            Extract_button.Size = new Size(75, 23);
            Extract_button.TabIndex = 7;
            Extract_button.Text = "Extract";
            Extract_button.UseVisualStyleBackColor = true;
            Extract_button.Visible = false;
            Extract_button.Click += Extract_button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 264);
            Controls.Add(Extract_button);
            Controls.Add(label1);
            Controls.Add(GB);
            Controls.Add(JP);
            Controls.Add(CN);
            Controls.Add(Download_button);
            Controls.Add(Getver_button);
            Controls.Add(listBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "patch_dxt downloader";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Button Getver_button;
        private Button Download_button;
        private RadioButton CN;
        private RadioButton JP;
        private RadioButton GB;
        private Label label1;
        private Button Extract_button;
    }
}