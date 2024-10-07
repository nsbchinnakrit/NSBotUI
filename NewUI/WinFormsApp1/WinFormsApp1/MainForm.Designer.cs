using System.ComponentModel;

namespace WinFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            imgdelaysave = new Button();
            WindowInput = new TextBox();
            ServerSelectBox = new GroupBox();
            radioButtonCN = new RadioButton();
            radioButtonJP = new RadioButton();
            radioButtonGB = new RadioButton();
            wnd_defsize = new Button();
            transparentPanel3 = new TransparentPanel();
            Tiptext1 = new Label();
            WantedBox = new GroupBox();
            wt_food = new CheckBox();
            wt_sushi = new CheckBox();
            wt_coin = new CheckBox();
            wt_jade = new CheckBox();
            RoundBox = new GroupBox();
            InputRound = new TextBox();
            button2 = new Button();
            button1 = new Button();
            TeamBox = new GroupBox();
            teamtext = new Label();
            splitter3 = new Splitter();
            Team = new RadioButton();
            Solo = new RadioButton();
            GameModeBox = new GroupBox();
            Bondling = new RadioButton();
            Event = new RadioButton();
            GuildRealm = new RadioButton();
            RealmRaid = new RadioButton();
            ExploreRealm = new RadioButton();
            Explore = new RadioButton();
            SoulEvo = new RadioButton();
            transparentPanel1 = new TransparentPanel();
            transparentPanel2 = new TransparentPanel();
            panel2 = new Panel();
            FindIMGBox = new GroupBox();
            domainUpDown1 = new DomainUpDown();
            RoundOption = new GroupBox();
            ResetRound = new RadioButton();
            KeepRound = new RadioButton();
            konleambox = new GroupBox();
            openfolder = new Button();
            dl_konleam = new Button();
            groupBox2 = new GroupBox();
            Kill_process = new Button();
            AfterFinishBox = new GroupBox();
            Notify = new CheckBox();
            Closegame = new CheckBox();
            Shutdown = new CheckBox();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            changelog = new Label();
            NSBotVer = new Label();
            textBox1 = new TextBox();
            runpython = new Button();
            ArgCopyState = new Label();
            ArgGen = new Button();
            BondlingOption = new GroupBox();
            BondlingExp = new RadioButton();
            BondlingBoth = new RadioButton();
            BondlingPact = new RadioButton();
            RaidOption = new GroupBox();
            RaidAll = new RadioButton();
            Win3Fail3 = new RadioButton();
            Win3 = new RadioButton();
            splitContainer1 = new SplitContainer();
            Ultra = new RadioButton();
            Great = new RadioButton();
            Basic = new RadioButton();
            splitter2 = new Splitter();
            DiscSelect = new Label();
            crystal = new CheckBox();
            pactselect = new Label();
            rTomb = new RadioButton();
            Tomb = new CheckBox();
            rSnowBall = new RadioButton();
            Snowball = new CheckBox();
            rAzure = new RadioButton();
            Azure = new CheckBox();
            rKuro = new RadioButton();
            Kuro = new CheckBox();
            splitter1 = new Splitter();
            transparentPanel5 = new TransparentPanel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            ServerSelectBox.SuspendLayout();
            WantedBox.SuspendLayout();
            RoundBox.SuspendLayout();
            TeamBox.SuspendLayout();
            GameModeBox.SuspendLayout();
            panel2.SuspendLayout();
            FindIMGBox.SuspendLayout();
            RoundOption.SuspendLayout();
            konleambox.SuspendLayout();
            groupBox2.SuspendLayout();
            AfterFinishBox.SuspendLayout();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            BondlingOption.SuspendLayout();
            RaidOption.SuspendLayout();
            ((ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            SuspendLayout();
            // 
            // imgdelaysave
            // 
            imgdelaysave.Location = new Point(111, 21);
            imgdelaysave.Name = "imgdelaysave";
            imgdelaysave.Size = new Size(75, 23);
            imgdelaysave.TabIndex = 1;
            imgdelaysave.Text = "Save";
            imgdelaysave.UseVisualStyleBackColor = true;
            imgdelaysave.Click += imgdelaysave_Click;
            // 
            // WindowInput
            // 
            WindowInput.AllowDrop = true;
            WindowInput.Anchor = AnchorStyles.None;
            WindowInput.BackColor = SystemColors.ControlLightLight;
            WindowInput.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            WindowInput.Location = new Point(12, 17);
            WindowInput.MaxLength = 30;
            WindowInput.Name = "WindowInput";
            WindowInput.RightToLeft = RightToLeft.No;
            WindowInput.Size = new Size(132, 25);
            WindowInput.TabIndex = 2;
            WindowInput.Text = "陰陽師Onmyoji";
            // 
            // ServerSelectBox
            // 
            ServerSelectBox.Controls.Add(radioButtonCN);
            ServerSelectBox.Controls.Add(radioButtonJP);
            ServerSelectBox.Controls.Add(radioButtonGB);
            ServerSelectBox.Controls.Add(wnd_defsize);
            ServerSelectBox.Controls.Add(WindowInput);
            ServerSelectBox.Controls.Add(transparentPanel3);
            ServerSelectBox.Location = new Point(15, 11);
            ServerSelectBox.Name = "ServerSelectBox";
            ServerSelectBox.Size = new Size(484, 49);
            ServerSelectBox.TabIndex = 3;
            ServerSelectBox.TabStop = false;
            ServerSelectBox.Text = "Server Select";
            // 
            // radioButtonCN
            // 
            radioButtonCN.AutoSize = true;
            radioButtonCN.Location = new Point(398, 19);
            radioButtonCN.Name = "radioButtonCN";
            radioButtonCN.Size = new Size(77, 19);
            radioButtonCN.TabIndex = 6;
            radioButtonCN.TabStop = true;
            radioButtonCN.Text = "CN Server";
            radioButtonCN.UseVisualStyleBackColor = true;
            radioButtonCN.Click += radioButton_CheckedChanged;
            // 
            // radioButtonJP
            // 
            radioButtonJP.AutoSize = true;
            radioButtonJP.Location = new Point(319, 19);
            radioButtonJP.Name = "radioButtonJP";
            radioButtonJP.Size = new Size(71, 19);
            radioButtonJP.TabIndex = 5;
            radioButtonJP.TabStop = true;
            radioButtonJP.Text = "JP Server";
            radioButtonJP.UseVisualStyleBackColor = true;
            radioButtonJP.Click += radioButton_CheckedChanged;
            // 
            // radioButtonGB
            // 
            radioButtonGB.AutoSize = true;
            radioButtonGB.Checked = true;
            radioButtonGB.Location = new Point(236, 19);
            radioButtonGB.Name = "radioButtonGB";
            radioButtonGB.Size = new Size(75, 19);
            radioButtonGB.TabIndex = 4;
            radioButtonGB.TabStop = true;
            radioButtonGB.Text = "GB Server";
            radioButtonGB.UseVisualStyleBackColor = true;
            radioButtonGB.Click += radioButton_CheckedChanged;
            // 
            // wnd_defsize
            // 
            wnd_defsize.FlatAppearance.BorderColor = Color.Gainsboro;
            wnd_defsize.FlatStyle = FlatStyle.Flat;
            wnd_defsize.Location = new Point(147, 17);
            wnd_defsize.Margin = new Padding(0);
            wnd_defsize.Name = "wnd_defsize";
            wnd_defsize.Size = new Size(77, 25);
            wnd_defsize.TabIndex = 3;
            wnd_defsize.Text = "default size";
            wnd_defsize.UseVisualStyleBackColor = true;
            wnd_defsize.Click += resize_Click;
            // 
            // transparentPanel3
            // 
            transparentPanel3.Location = new Point(9, 14);
            transparentPanel3.Name = "transparentPanel3";
            transparentPanel3.Size = new Size(463, 30);
            transparentPanel3.TabIndex = 7;
            // 
            // Tiptext1
            // 
            Tiptext1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Tiptext1.AutoSize = true;
            Tiptext1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            Tiptext1.ForeColor = Color.Brown;
            Tiptext1.Location = new Point(15, 239);
            Tiptext1.Name = "Tiptext1";
            Tiptext1.Size = new Size(54, 17);
            Tiptext1.TabIndex = 6;
            Tiptext1.Text = "Tiptext1";
            Tiptext1.TextAlign = ContentAlignment.BottomLeft;
            Tiptext1.UseMnemonic = false;
            // 
            // WantedBox
            // 
            WantedBox.Controls.Add(wt_food);
            WantedBox.Controls.Add(wt_sushi);
            WantedBox.Controls.Add(wt_coin);
            WantedBox.Controls.Add(wt_jade);
            WantedBox.Location = new Point(6, 97);
            WantedBox.Name = "WantedBox";
            WantedBox.Size = new Size(274, 46);
            WantedBox.TabIndex = 10;
            WantedBox.TabStop = false;
            WantedBox.Text = "Wanted Quest";
            // 
            // wt_food
            // 
            wt_food.AutoSize = true;
            wt_food.Location = new Point(210, 19);
            wt_food.Name = "wt_food";
            wt_food.Size = new Size(53, 19);
            wt_food.TabIndex = 3;
            wt_food.Text = "Food";
            wt_food.UseVisualStyleBackColor = true;
            wt_food.CheckedChanged += wt_CheckedChanged;
            // 
            // wt_sushi
            // 
            wt_sushi.AutoSize = true;
            wt_sushi.Location = new Point(140, 19);
            wt_sushi.Name = "wt_sushi";
            wt_sushi.Size = new Size(54, 19);
            wt_sushi.TabIndex = 2;
            wt_sushi.Text = "Sushi";
            wt_sushi.UseVisualStyleBackColor = true;
            wt_sushi.CheckedChanged += wt_CheckedChanged;
            // 
            // wt_coin
            // 
            wt_coin.AutoSize = true;
            wt_coin.Location = new Point(74, 19);
            wt_coin.Name = "wt_coin";
            wt_coin.Size = new Size(51, 19);
            wt_coin.TabIndex = 1;
            wt_coin.Text = "Coin";
            wt_coin.UseVisualStyleBackColor = true;
            wt_coin.CheckedChanged += wt_CheckedChanged;
            // 
            // wt_jade
            // 
            wt_jade.AutoSize = true;
            wt_jade.Location = new Point(11, 19);
            wt_jade.Name = "wt_jade";
            wt_jade.Size = new Size(49, 19);
            wt_jade.TabIndex = 0;
            wt_jade.Text = "Jade";
            wt_jade.UseVisualStyleBackColor = true;
            wt_jade.CheckedChanged += wt_CheckedChanged;
            // 
            // RoundBox
            // 
            RoundBox.Controls.Add(InputRound);
            RoundBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            RoundBox.Location = new Point(287, 97);
            RoundBox.Margin = new Padding(0);
            RoundBox.Name = "RoundBox";
            RoundBox.Size = new Size(90, 46);
            RoundBox.TabIndex = 13;
            RoundBox.TabStop = false;
            RoundBox.Text = "Total Round";
            // 
            // InputRound
            // 
            InputRound.Anchor = AnchorStyles.Bottom;
            InputRound.Location = new Point(10, 16);
            InputRound.Margin = new Padding(0);
            InputRound.MaxLength = 10;
            InputRound.Name = "InputRound";
            InputRound.Size = new Size(70, 23);
            InputRound.TabIndex = 0;
            InputRound.Text = "500";
            InputRound.TextAlign = HorizontalAlignment.Center;
            InputRound.TextChanged += InputRound_TextChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderColor = Color.DarkGray;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button2.Location = new Point(384, 105);
            button2.Name = "button2";
            button2.Size = new Size(85, 38);
            button2.TabIndex = 5;
            button2.Text = "Stop";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.Gainsboro;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button1.Location = new Point(384, 105);
            button1.Name = "button1";
            button1.Size = new Size(85, 38);
            button1.TabIndex = 22;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TeamBox
            // 
            TeamBox.Controls.Add(teamtext);
            TeamBox.Controls.Add(splitter3);
            TeamBox.Controls.Add(Team);
            TeamBox.Controls.Add(Solo);
            TeamBox.Location = new Point(6, 6);
            TeamBox.Name = "TeamBox";
            TeamBox.Size = new Size(96, 90);
            TeamBox.TabIndex = 12;
            TeamBox.TabStop = false;
            TeamBox.Text = "Team Option";
            // 
            // teamtext
            // 
            teamtext.Anchor = AnchorStyles.None;
            teamtext.BackColor = SystemColors.ControlLight;
            teamtext.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            teamtext.Location = new Point(6, 67);
            teamtext.Name = "teamtext";
            teamtext.Size = new Size(84, 17);
            teamtext.TabIndex = 12;
            teamtext.Text = "Single";
            teamtext.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitter3
            // 
            splitter3.BackColor = SystemColors.InactiveBorder;
            splitter3.Cursor = Cursors.IBeam;
            splitter3.Dock = DockStyle.Bottom;
            splitter3.Location = new Point(3, 65);
            splitter3.Name = "splitter3";
            splitter3.Size = new Size(90, 22);
            splitter3.TabIndex = 11;
            splitter3.TabStop = false;
            // 
            // Team
            // 
            Team.AutoSize = true;
            Team.Location = new Point(12, 40);
            Team.Margin = new Padding(0);
            Team.Name = "Team";
            Team.Size = new Size(54, 19);
            Team.TabIndex = 10;
            Team.TabStop = true;
            Team.Text = "Team";
            Team.UseVisualStyleBackColor = true;
            Team.CheckedChanged += radioTeam_CheckedChanged;
            // 
            // Solo
            // 
            Solo.AutoSize = true;
            Solo.Checked = true;
            Solo.Location = new Point(12, 21);
            Solo.Margin = new Padding(0);
            Solo.Name = "Solo";
            Solo.Size = new Size(57, 19);
            Solo.TabIndex = 9;
            Solo.TabStop = true;
            Solo.Text = "Single";
            Solo.UseVisualStyleBackColor = true;
            Solo.CheckedChanged += radioTeam_CheckedChanged;
            // 
            // GameModeBox
            // 
            GameModeBox.Controls.Add(Bondling);
            GameModeBox.Controls.Add(Event);
            GameModeBox.Controls.Add(GuildRealm);
            GameModeBox.Controls.Add(RealmRaid);
            GameModeBox.Controls.Add(ExploreRealm);
            GameModeBox.Controls.Add(Explore);
            GameModeBox.Controls.Add(SoulEvo);
            GameModeBox.Location = new Point(113, 6);
            GameModeBox.Margin = new Padding(0);
            GameModeBox.Name = "GameModeBox";
            GameModeBox.Size = new Size(356, 90);
            GameModeBox.TabIndex = 11;
            GameModeBox.TabStop = false;
            GameModeBox.Text = "Select Game Mode";
            // 
            // Bondling
            // 
            Bondling.AutoSize = true;
            Bondling.Location = new Point(123, 25);
            Bondling.Name = "Bondling";
            Bondling.Size = new Size(124, 19);
            Bondling.TabIndex = 19;
            Bondling.TabStop = true;
            Bondling.Text = "Bondling Fairyland";
            Bondling.UseVisualStyleBackColor = true;
            // 
            // Event
            // 
            Event.AutoSize = true;
            Event.Location = new Point(286, 57);
            Event.Name = "Event";
            Event.Size = new Size(54, 19);
            Event.TabIndex = 18;
            Event.TabStop = true;
            Event.Text = "Event";
            Event.UseVisualStyleBackColor = true;
            Event.CheckedChanged += radioGameMode_CheckedChanged;
            // 
            // GuildRealm
            // 
            GuildRealm.AutoSize = true;
            GuildRealm.Location = new Point(107, 57);
            GuildRealm.Name = "GuildRealm";
            GuildRealm.Size = new Size(83, 19);
            GuildRealm.TabIndex = 17;
            GuildRealm.TabStop = true;
            GuildRealm.Text = "Guild Ralm";
            GuildRealm.UseVisualStyleBackColor = true;
            GuildRealm.CheckedChanged += radioGameMode_CheckedChanged;
            // 
            // RealmRaid
            // 
            RealmRaid.AutoSize = true;
            RealmRaid.Location = new Point(16, 57);
            RealmRaid.Name = "RealmRaid";
            RealmRaid.Size = new Size(75, 19);
            RealmRaid.TabIndex = 16;
            RealmRaid.TabStop = true;
            RealmRaid.Text = "RalmRaid";
            RealmRaid.UseVisualStyleBackColor = true;
            RealmRaid.CheckedChanged += radioGameMode_CheckedChanged;
            // 
            // ExploreRealm
            // 
            ExploreRealm.AutoSize = true;
            ExploreRealm.Location = new Point(252, 25);
            ExploreRealm.Name = "ExploreRealm";
            ExploreRealm.Size = new Size(101, 19);
            ExploreRealm.TabIndex = 15;
            ExploreRealm.TabStop = true;
            ExploreRealm.Text = "Explore/Realm";
            ExploreRealm.UseVisualStyleBackColor = true;
            ExploreRealm.CheckedChanged += radioGameMode_CheckedChanged;
            // 
            // Explore
            // 
            Explore.AutoSize = true;
            Explore.Location = new Point(206, 57);
            Explore.Name = "Explore";
            Explore.Size = new Size(63, 19);
            Explore.TabIndex = 14;
            Explore.TabStop = true;
            Explore.Text = "Explore";
            Explore.UseVisualStyleBackColor = true;
            Explore.CheckedChanged += radioGameMode_CheckedChanged;
            // 
            // SoulEvo
            // 
            SoulEvo.AutoSize = true;
            SoulEvo.Checked = true;
            SoulEvo.Location = new Point(9, 25);
            SoulEvo.Name = "SoulEvo";
            SoulEvo.Size = new Size(111, 19);
            SoulEvo.TabIndex = 13;
            SoulEvo.TabStop = true;
            SoulEvo.Text = "Soul/Evo/Totem";
            SoulEvo.UseVisualStyleBackColor = true;
            SoulEvo.CheckedChanged += radioGameMode_CheckedChanged;
            // 
            // transparentPanel1
            // 
            transparentPanel1.Location = new Point(0, 0);
            transparentPanel1.Name = "transparentPanel1";
            transparentPanel1.Size = new Size(382, 143);
            transparentPanel1.TabIndex = 15;
            // 
            // transparentPanel2
            // 
            transparentPanel2.Location = new Point(366, 0);
            transparentPanel2.Name = "transparentPanel2";
            transparentPanel2.Size = new Size(105, 93);
            transparentPanel2.TabIndex = 15;
            // 
            // panel2
            // 
            panel2.Controls.Add(FindIMGBox);
            panel2.Controls.Add(RoundOption);
            panel2.Controls.Add(konleambox);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(AfterFinishBox);
            panel2.Location = new Point(4, 8);
            panel2.Name = "panel2";
            panel2.Size = new Size(467, 136);
            panel2.TabIndex = 19;
            // 
            // FindIMGBox
            // 
            FindIMGBox.Controls.Add(imgdelaysave);
            FindIMGBox.Controls.Add(domainUpDown1);
            FindIMGBox.Location = new Point(6, 9);
            FindIMGBox.Name = "FindIMGBox";
            FindIMGBox.Size = new Size(213, 55);
            FindIMGBox.TabIndex = 2;
            FindIMGBox.TabStop = false;
            FindIMGBox.Text = "Find Image Delay Setting";
            // 
            // domainUpDown1
            // 
            domainUpDown1.Items.Add("0.2");
            domainUpDown1.Items.Add("0.19");
            domainUpDown1.Items.Add("0.18");
            domainUpDown1.Items.Add("0.17");
            domainUpDown1.Items.Add("0.16");
            domainUpDown1.Items.Add("0.15");
            domainUpDown1.Items.Add("0.14");
            domainUpDown1.Items.Add("0.13");
            domainUpDown1.Items.Add("0.12");
            domainUpDown1.Items.Add("0.11");
            domainUpDown1.Items.Add("0.1");
            domainUpDown1.Items.Add("0.09");
            domainUpDown1.Items.Add("0.08");
            domainUpDown1.Items.Add("0.07");
            domainUpDown1.Items.Add("0.06");
            domainUpDown1.Items.Add("0.05");
            domainUpDown1.Items.Add("0.04");
            domainUpDown1.Items.Add("0.03");
            domainUpDown1.Items.Add("0.02");
            domainUpDown1.Items.Add("0.01");
            domainUpDown1.Location = new Point(36, 22);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new Size(64, 23);
            domainUpDown1.TabIndex = 0;
            domainUpDown1.Text = "0.08";
            // 
            // RoundOption
            // 
            RoundOption.Controls.Add(ResetRound);
            RoundOption.Controls.Add(KeepRound);
            RoundOption.Location = new Point(227, 9);
            RoundOption.Name = "RoundOption";
            RoundOption.Size = new Size(214, 55);
            RoundOption.TabIndex = 18;
            RoundOption.TabStop = false;
            RoundOption.Text = "After press stop button";
            // 
            // ResetRound
            // 
            ResetRound.AutoSize = true;
            ResetRound.Location = new Point(119, 24);
            ResetRound.Name = "ResetRound";
            ResetRound.Size = new Size(91, 19);
            ResetRound.TabIndex = 1;
            ResetRound.Text = "Reset Round";
            ResetRound.UseVisualStyleBackColor = true;
            ResetRound.CheckedChanged += ResetRound_CheckedChanged;
            // 
            // KeepRound
            // 
            KeepRound.AutoSize = true;
            KeepRound.Checked = true;
            KeepRound.Location = new Point(16, 24);
            KeepRound.Name = "KeepRound";
            KeepRound.Size = new Size(89, 19);
            KeepRound.TabIndex = 0;
            KeepRound.TabStop = true;
            KeepRound.Text = "Keep Round";
            KeepRound.UseVisualStyleBackColor = true;
            KeepRound.CheckedChanged += KeepRound_CheckedChanged;
            // 
            // konleambox
            // 
            konleambox.Controls.Add(openfolder);
            konleambox.Controls.Add(dl_konleam);
            konleambox.Location = new Point(91, 138);
            konleambox.Name = "konleambox";
            konleambox.Size = new Size(279, 55);
            konleambox.TabIndex = 0;
            konleambox.TabStop = false;
            konleambox.Text = "Wanted Quest Image Folder";
            // 
            // openfolder
            // 
            openfolder.Location = new Point(19, 21);
            openfolder.Name = "openfolder";
            openfolder.Size = new Size(111, 23);
            openfolder.TabIndex = 1;
            openfolder.Text = "Open Folder";
            openfolder.UseVisualStyleBackColor = true;
            openfolder.Click += openfolder_Click;
            // 
            // dl_konleam
            // 
            dl_konleam.Location = new Point(152, 21);
            dl_konleam.Name = "dl_konleam";
            dl_konleam.Size = new Size(106, 23);
            dl_konleam.TabIndex = 0;
            dl_konleam.Text = "Delete Folder";
            dl_konleam.UseVisualStyleBackColor = true;
            dl_konleam.Click += dl_konleam_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Kill_process);
            groupBox2.Location = new Point(228, 71);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(213, 55);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Kill AutoClick Process";
            // 
            // Kill_process
            // 
            Kill_process.Location = new Point(67, 21);
            Kill_process.Name = "Kill_process";
            Kill_process.Size = new Size(75, 23);
            Kill_process.TabIndex = 0;
            Kill_process.Text = "Kill Process";
            Kill_process.UseVisualStyleBackColor = true;
            Kill_process.Click += Kill_process_Click;
            // 
            // AfterFinishBox
            // 
            AfterFinishBox.Controls.Add(Notify);
            AfterFinishBox.Controls.Add(Closegame);
            AfterFinishBox.Controls.Add(Shutdown);
            AfterFinishBox.Location = new Point(6, 71);
            AfterFinishBox.Name = "AfterFinishBox";
            AfterFinishBox.Size = new Size(213, 55);
            AfterFinishBox.TabIndex = 15;
            AfterFinishBox.TabStop = false;
            AfterFinishBox.Text = "After completion";
            // 
            // Notify
            // 
            Notify.AutoSize = true;
            Notify.Location = new Point(140, 22);
            Notify.Name = "Notify";
            Notify.Size = new Size(66, 19);
            Notify.TabIndex = 2;
            Notify.Text = "แจ้งเตือน";
            Notify.UseVisualStyleBackColor = true;
            Notify.CheckedChanged += Notify_CheckedChanged;
            // 
            // Closegame
            // 
            Closegame.AutoSize = true;
            Closegame.Location = new Point(83, 22);
            Closegame.Name = "Closegame";
            Closegame.Size = new Size(57, 19);
            Closegame.TabIndex = 1;
            Closegame.Text = "ปิดเกม";
            Closegame.UseVisualStyleBackColor = true;
            // 
            // Shutdown
            // 
            Shutdown.AutoSize = true;
            Shutdown.Location = new Point(17, 22);
            Shutdown.Name = "Shutdown";
            Shutdown.Size = new Size(66, 19);
            Shutdown.TabIndex = 0;
            Shutdown.Text = "ปิดเครื่อง";
            Shutdown.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel1);
            groupBox1.Location = new Point(1, 29);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(0);
            groupBox1.Size = new Size(472, 118);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(changelog);
            panel1.Location = new Point(7, 14);
            panel1.Name = "panel1";
            panel1.Size = new Size(460, 98);
            panel1.TabIndex = 4;
            // 
            // changelog
            // 
            changelog.AutoSize = true;
            changelog.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            changelog.Location = new Point(5, 5);
            changelog.Name = "changelog";
            changelog.Size = new Size(64, 19);
            changelog.TabIndex = 1;
            changelog.Text = "Loading..";
            // 
            // NSBotVer
            // 
            NSBotVer.AutoSize = true;
            NSBotVer.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            NSBotVer.Location = new Point(0, 4);
            NSBotVer.Name = "NSBotVer";
            NSBotVer.Size = new Size(213, 25);
            NSBotVer.TabIndex = 0;
            NSBotVer.Text = "Unable to load version";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(7, 9);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(462, 23);
            textBox1.TabIndex = 5;
            // 
            // runpython
            // 
            runpython.Location = new Point(9, 34);
            runpython.Name = "runpython";
            runpython.Size = new Size(75, 23);
            runpython.TabIndex = 3;
            runpython.Text = "Run";
            runpython.UseVisualStyleBackColor = true;
            runpython.Click += runpython_Click;
            // 
            // ArgCopyState
            // 
            ArgCopyState.AutoSize = true;
            ArgCopyState.ForeColor = Color.SteelBlue;
            ArgCopyState.Location = new Point(171, 39);
            ArgCopyState.Name = "ArgCopyState";
            ArgCopyState.Size = new Size(216, 15);
            ArgCopyState.TabIndex = 2;
            ArgCopyState.Text = "Click Button to Generate command line";
            // 
            // ArgGen
            // 
            ArgGen.Location = new Point(90, 34);
            ArgGen.Name = "ArgGen";
            ArgGen.Size = new Size(75, 23);
            ArgGen.TabIndex = 1;
            ArgGen.Text = "generate";
            ArgGen.UseVisualStyleBackColor = true;
            ArgGen.Click += ArgGen_Click;
            // 
            // BondlingOption
            // 
            BondlingOption.Controls.Add(BondlingExp);
            BondlingOption.Controls.Add(BondlingBoth);
            BondlingOption.Controls.Add(BondlingPact);
            BondlingOption.Location = new Point(502, 17);
            BondlingOption.Name = "BondlingOption";
            BondlingOption.Size = new Size(96, 90);
            BondlingOption.TabIndex = 18;
            BondlingOption.TabStop = false;
            BondlingOption.Text = "Select Mode";
            // 
            // BondlingExp
            // 
            BondlingExp.AutoSize = true;
            BondlingExp.Checked = true;
            BondlingExp.Location = new Point(12, 21);
            BondlingExp.Margin = new Padding(0);
            BondlingExp.Name = "BondlingExp";
            BondlingExp.Size = new Size(63, 19);
            BondlingExp.TabIndex = 11;
            BondlingExp.TabStop = true;
            BondlingExp.Text = "Explore";
            BondlingExp.UseVisualStyleBackColor = true;
            BondlingExp.Click += BondlingMode_CheckedChanged;
            // 
            // BondlingBoth
            // 
            BondlingBoth.AutoSize = true;
            BondlingBoth.Location = new Point(12, 59);
            BondlingBoth.Margin = new Padding(0);
            BondlingBoth.Name = "BondlingBoth";
            BondlingBoth.Size = new Size(50, 19);
            BondlingBoth.TabIndex = 10;
            BondlingBoth.Text = "Both";
            BondlingBoth.UseVisualStyleBackColor = true;
            BondlingBoth.Click += BondlingMode_CheckedChanged;
            // 
            // BondlingPact
            // 
            BondlingPact.AutoSize = true;
            BondlingPact.Location = new Point(12, 40);
            BondlingPact.Margin = new Padding(0);
            BondlingPact.Name = "BondlingPact";
            BondlingPact.Size = new Size(48, 19);
            BondlingPact.TabIndex = 9;
            BondlingPact.Text = "Pact";
            BondlingPact.UseVisualStyleBackColor = true;
            BondlingPact.Click += BondlingMode_CheckedChanged;
            // 
            // RaidOption
            // 
            RaidOption.Controls.Add(RaidAll);
            RaidOption.Controls.Add(Win3Fail3);
            RaidOption.Controls.Add(Win3);
            RaidOption.Location = new Point(604, 17);
            RaidOption.Name = "RaidOption";
            RaidOption.Size = new Size(96, 90);
            RaidOption.TabIndex = 17;
            RaidOption.TabStop = false;
            RaidOption.Text = "Raid Option";
            RaidOption.Visible = false;
            // 
            // RaidAll
            // 
            RaidAll.AutoSize = true;
            RaidAll.Checked = true;
            RaidAll.Location = new Point(12, 21);
            RaidAll.Margin = new Padding(0);
            RaidAll.Name = "RaidAll";
            RaidAll.Size = new Size(65, 19);
            RaidAll.TabIndex = 11;
            RaidAll.TabStop = true;
            RaidAll.Text = "Raid All";
            RaidAll.UseVisualStyleBackColor = true;
            RaidAll.Click += radioTeam_CheckedChanged;
            // 
            // Win3Fail3
            // 
            Win3Fail3.AutoSize = true;
            Win3Fail3.Location = new Point(12, 59);
            Win3Fail3.Margin = new Padding(0);
            Win3Fail3.Name = "Win3Fail3";
            Win3Fail3.Size = new Size(82, 19);
            Win3Fail3.TabIndex = 10;
            Win3Fail3.Text = "Win3, Fail3";
            Win3Fail3.UseVisualStyleBackColor = true;
            Win3Fail3.Click += radioTeam_CheckedChanged;
            // 
            // Win3
            // 
            Win3.AutoSize = true;
            Win3.Location = new Point(12, 40);
            Win3.Margin = new Padding(0);
            Win3.Name = "Win3";
            Win3.Size = new Size(52, 19);
            Win3.TabIndex = 9;
            Win3.Text = "Win3";
            Win3.UseVisualStyleBackColor = true;
            Win3.Click += radioTeam_CheckedChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(8, 13);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ControlLight;
            splitContainer1.Panel1.Controls.Add(Ultra);
            splitContainer1.Panel1.Controls.Add(Great);
            splitContainer1.Panel1.Controls.Add(Basic);
            splitContainer1.Panel1.Controls.Add(splitter2);
            splitContainer1.Panel1.Controls.Add(DiscSelect);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.GradientInactiveCaption;
            splitContainer1.Panel2.Controls.Add(crystal);
            splitContainer1.Panel2.Controls.Add(pactselect);
            splitContainer1.Panel2.Controls.Add(rTomb);
            splitContainer1.Panel2.Controls.Add(Tomb);
            splitContainer1.Panel2.Controls.Add(rSnowBall);
            splitContainer1.Panel2.Controls.Add(Snowball);
            splitContainer1.Panel2.Controls.Add(rAzure);
            splitContainer1.Panel2.Controls.Add(Azure);
            splitContainer1.Panel2.Controls.Add(rKuro);
            splitContainer1.Panel2.Controls.Add(Kuro);
            splitContainer1.Panel2.Controls.Add(splitter1);
            splitContainer1.Size = new Size(457, 125);
            splitContainer1.SplitterDistance = 96;
            splitContainer1.TabIndex = 4;
            // 
            // Ultra
            // 
            Ultra.AutoSize = true;
            Ultra.BackColor = SystemColors.GradientInactiveCaption;
            Ultra.Location = new Point(42, 88);
            Ultra.Name = "Ultra";
            Ultra.Size = new Size(50, 19);
            Ultra.TabIndex = 3;
            Ultra.Text = "Ultra";
            Ultra.TextAlign = ContentAlignment.MiddleRight;
            Ultra.UseVisualStyleBackColor = false;
            Ultra.CheckedChanged += DiscSelect_CheckedChanged;
            // 
            // Great
            // 
            Great.AutoSize = true;
            Great.BackColor = SystemColors.GradientInactiveCaption;
            Great.Location = new Point(42, 53);
            Great.Name = "Great";
            Great.Size = new Size(53, 19);
            Great.TabIndex = 2;
            Great.Text = "Great";
            Great.UseVisualStyleBackColor = false;
            Great.CheckedChanged += DiscSelect_CheckedChanged;
            // 
            // Basic
            // 
            Basic.AutoSize = true;
            Basic.BackColor = SystemColors.GradientInactiveCaption;
            Basic.Checked = true;
            Basic.Location = new Point(42, 18);
            Basic.Name = "Basic";
            Basic.Size = new Size(52, 19);
            Basic.TabIndex = 1;
            Basic.TabStop = true;
            Basic.Text = "Basic";
            Basic.UseVisualStyleBackColor = false;
            Basic.CheckedChanged += DiscSelect_CheckedChanged;
            // 
            // splitter2
            // 
            splitter2.BackColor = SystemColors.GradientInactiveCaption;
            splitter2.Dock = DockStyle.Right;
            splitter2.Location = new Point(36, 0);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(60, 125);
            splitter2.TabIndex = 0;
            splitter2.TabStop = false;
            // 
            // DiscSelect
            // 
            DiscSelect.AutoSize = true;
            DiscSelect.BackColor = SystemColors.MenuHighlight;
            DiscSelect.Font = new Font("Forte", 20F, FontStyle.Bold, GraphicsUnit.Point);
            DiscSelect.ForeColor = SystemColors.ButtonHighlight;
            DiscSelect.ImageAlign = ContentAlignment.TopCenter;
            DiscSelect.Location = new Point(4, 3);
            DiscSelect.Margin = new Padding(0);
            DiscSelect.Name = "DiscSelect";
            DiscSelect.RightToLeft = RightToLeft.Yes;
            DiscSelect.Size = new Size(32, 120);
            DiscSelect.TabIndex = 0;
            DiscSelect.Text = "D\r\ni\r\ns\r\nc";
            DiscSelect.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // crystal
            // 
            crystal.AutoSize = true;
            crystal.BackColor = SystemColors.GradientInactiveCaption;
            crystal.Location = new Point(36, 54);
            crystal.Name = "crystal";
            crystal.Padding = new Padding(4, 2, 0, 0);
            crystal.Size = new Size(284, 21);
            crystal.TabIndex = 6;
            crystal.Text = "[Pact Mode Only] Use Crystal Summon Bonding";
            crystal.UseVisualStyleBackColor = false;
            crystal.CheckedChanged += crystal_CheckedChanged;
            // 
            // pactselect
            // 
            pactselect.AutoSize = true;
            pactselect.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            pactselect.Location = new Point(72, 19);
            pactselect.Name = "pactselect";
            pactselect.Size = new Size(205, 30);
            pactselect.TabIndex = 5;
            pactselect.Text = "Select  Pact-forming";
            // 
            // rTomb
            // 
            rTomb.AutoSize = true;
            rTomb.BackColor = SystemColors.GradientActiveCaption;
            rTomb.Location = new Point(13, 94);
            rTomb.Name = "rTomb";
            rTomb.Size = new Size(91, 19);
            rTomb.TabIndex = 21;
            rTomb.TabStop = true;
            rTomb.Text = "Tomb Guard";
            rTomb.UseVisualStyleBackColor = false;
            rTomb.CheckedChanged += crystal_pact_CheckedChanged;
            // 
            // Tomb
            // 
            Tomb.AutoSize = true;
            Tomb.BackColor = SystemColors.GradientActiveCaption;
            Tomb.Checked = true;
            Tomb.CheckState = CheckState.Checked;
            Tomb.Location = new Point(13, 95);
            Tomb.Name = "Tomb";
            Tomb.Size = new Size(92, 19);
            Tomb.TabIndex = 0;
            Tomb.Text = "Tomb Guard";
            Tomb.UseVisualStyleBackColor = false;
            Tomb.CheckedChanged += pact_CheckedChanged;
            // 
            // rSnowBall
            // 
            rSnowBall.AutoSize = true;
            rSnowBall.BackColor = SystemColors.GradientActiveCaption;
            rSnowBall.Location = new Point(112, 94);
            rSnowBall.Name = "rSnowBall";
            rSnowBall.Size = new Size(73, 19);
            rSnowBall.TabIndex = 22;
            rSnowBall.TabStop = true;
            rSnowBall.Text = "Snowball";
            rSnowBall.UseVisualStyleBackColor = false;
            rSnowBall.CheckedChanged += crystal_pact_CheckedChanged;
            // 
            // Snowball
            // 
            Snowball.AutoSize = true;
            Snowball.BackColor = SystemColors.GradientActiveCaption;
            Snowball.Checked = true;
            Snowball.CheckState = CheckState.Checked;
            Snowball.Location = new Point(112, 95);
            Snowball.Name = "Snowball";
            Snowball.Size = new Size(74, 19);
            Snowball.TabIndex = 1;
            Snowball.Text = "Snowball";
            Snowball.UseVisualStyleBackColor = false;
            Snowball.CheckedChanged += pact_CheckedChanged;
            // 
            // rAzure
            // 
            rAzure.AutoSize = true;
            rAzure.BackColor = SystemColors.GradientActiveCaption;
            rAzure.Location = new Point(194, 94);
            rAzure.Name = "rAzure";
            rAzure.Size = new Size(89, 19);
            rAzure.TabIndex = 23;
            rAzure.TabStop = true;
            rAzure.Text = "Azure Basan";
            rAzure.UseVisualStyleBackColor = false;
            rAzure.CheckedChanged += crystal_pact_CheckedChanged;
            // 
            // Azure
            // 
            Azure.AutoSize = true;
            Azure.BackColor = SystemColors.GradientActiveCaption;
            Azure.Checked = true;
            Azure.CheckState = CheckState.Checked;
            Azure.Location = new Point(194, 95);
            Azure.Name = "Azure";
            Azure.Size = new Size(90, 19);
            Azure.TabIndex = 2;
            Azure.Text = "Azure Basan";
            Azure.UseVisualStyleBackColor = false;
            Azure.CheckedChanged += pact_CheckedChanged;
            // 
            // rKuro
            // 
            rKuro.AutoSize = true;
            rKuro.BackColor = SystemColors.GradientActiveCaption;
            rKuro.Location = new Point(292, 94);
            rKuro.Name = "rKuro";
            rKuro.Size = new Size(50, 19);
            rKuro.TabIndex = 24;
            rKuro.TabStop = true;
            rKuro.Text = "Kuro";
            rKuro.UseVisualStyleBackColor = false;
            rKuro.CheckedChanged += crystal_pact_CheckedChanged;
            // 
            // Kuro
            // 
            Kuro.AutoSize = true;
            Kuro.BackColor = SystemColors.GradientActiveCaption;
            Kuro.Checked = true;
            Kuro.CheckState = CheckState.Checked;
            Kuro.Location = new Point(292, 95);
            Kuro.Name = "Kuro";
            Kuro.Size = new Size(51, 19);
            Kuro.TabIndex = 3;
            Kuro.Text = "Kuro";
            Kuro.UseVisualStyleBackColor = false;
            Kuro.CheckedChanged += pact_CheckedChanged;
            // 
            // splitter1
            // 
            splitter1.BackColor = SystemColors.GradientActiveCaption;
            splitter1.Dock = DockStyle.Bottom;
            splitter1.Location = new Point(0, 80);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(357, 45);
            splitter1.TabIndex = 4;
            splitter1.TabStop = false;
            // 
            // transparentPanel5
            // 
            transparentPanel5.Location = new Point(2, 10);
            transparentPanel5.Name = "transparentPanel5";
            transparentPanel5.Size = new Size(468, 134);
            transparentPanel5.TabIndex = 21;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(15, 63);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(18, 3);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(484, 178);
            tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(BondlingOption);
            tabPage1.Controls.Add(RaidOption);
            tabPage1.Controls.Add(WantedBox);
            tabPage1.Controls.Add(TeamBox);
            tabPage1.Controls.Add(RoundBox);
            tabPage1.Controls.Add(GameModeBox);
            tabPage1.Controls.Add(transparentPanel1);
            tabPage1.Controls.Add(transparentPanel2);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(button1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(476, 150);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Game Mode";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(splitContainer1);
            tabPage2.Controls.Add(transparentPanel5);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(476, 150);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Bondling Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel2);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(476, 150);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Settings";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(groupBox1);
            tabPage4.Controls.Add(NSBotVer);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(476, 150);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "About";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(textBox1);
            tabPage5.Controls.Add(ArgGen);
            tabPage5.Controls.Add(runpython);
            tabPage5.Controls.Add(ArgCopyState);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(476, 150);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "DEV";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(514, 257);
            Controls.Add(ServerSelectBox);
            Controls.Add(tabControl1);
            Controls.Add(Tiptext1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NSLaunch";
            TopMost = true;
            ServerSelectBox.ResumeLayout(false);
            ServerSelectBox.PerformLayout();
            WantedBox.ResumeLayout(false);
            WantedBox.PerformLayout();
            RoundBox.ResumeLayout(false);
            RoundBox.PerformLayout();
            TeamBox.ResumeLayout(false);
            TeamBox.PerformLayout();
            GameModeBox.ResumeLayout(false);
            GameModeBox.PerformLayout();
            panel2.ResumeLayout(false);
            FindIMGBox.ResumeLayout(false);
            RoundOption.ResumeLayout(false);
            RoundOption.PerformLayout();
            konleambox.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            AfterFinishBox.ResumeLayout(false);
            AfterFinishBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            BondlingOption.ResumeLayout(false);
            BondlingOption.PerformLayout();
            RaidOption.ResumeLayout(false);
            RaidOption.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button imgdelaysave;
        private TextBox WindowInput;
        private GroupBox ServerSelectBox;
        private Button wnd_defsize;
        private RadioButton radioButtonCN;
        private RadioButton radioButtonJP;
        private RadioButton radioButtonGB;
        private Label Tiptext1;
        private GroupBox AfterFinishBox;
        private CheckBox Closegame;
        private CheckBox Shutdown;
        private GroupBox groupBox2;
        private Button Kill_process;
        private GroupBox konleambox;
        private Button openfolder;
        private Button dl_konleam;
        private GroupBox groupBox1;
        private Panel panel1;
        private Label NSBotVer;
        private Button runpython;
        private Label ArgCopyState;
        private Button ArgGen;
        private GroupBox RaidOption;
        private RadioButton Win3Fail3;
        private RadioButton Win3;
        private GroupBox BondlingOption;
        private RadioButton BondlingExp;
        private RadioButton BondlingBoth;
        private RadioButton BondlingPact;
        private GroupBox RoundBox;
        private TextBox InputRound;
        private Button button2;
        private Button button1;
        private GroupBox TeamBox;
        private RadioButton Team;
        private RadioButton Solo;
        private TransparentPanel transparentPanel1;
        private TransparentPanel transparentPanel3;
        private TransparentPanel transparentPanel2;
        private CheckBox Kuro;
        private CheckBox Azure;
        private CheckBox Snowball;
        private CheckBox Tomb;
        private SplitContainer splitContainer1;
        private Label pactselect;
        private Splitter splitter1;
        private Splitter splitter2;
        private RadioButton Ultra;
        private RadioButton Great;
        private RadioButton Basic;
        private Label DiscSelect;
        private CheckBox crystal;
        private RadioButton rSnowBall;
        private RadioButton rKuro;
        private RadioButton rAzure;
        private RadioButton rTomb;
        private TransparentPanel transparentPanel5;
        private TextBox textBox1;
        private RadioButton RaidAll;
        private GroupBox RoundOption;
        private RadioButton ResetRound;
        private RadioButton KeepRound;
        private Panel panel2;
        private Splitter splitter3;
        private GroupBox GameModeBox;
        private RadioButton Bondling;
        private RadioButton Event;
        private RadioButton GuildRealm;
        private RadioButton RealmRaid;
        private RadioButton ExploreRealm;
        private RadioButton Explore;
        private RadioButton SoulEvo;
        private GroupBox WantedBox;
        private CheckBox wt_food;
        private CheckBox wt_sushi;
        private CheckBox wt_coin;
        private CheckBox wt_jade;
        private Label teamtext;
        private CheckBox Notify;
        private GroupBox FindIMGBox;
        private DomainUpDown domainUpDown1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Label changelog;
    }
}