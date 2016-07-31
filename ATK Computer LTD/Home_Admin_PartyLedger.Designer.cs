namespace ATK_Computer_LTD
{
    partial class Home_Admin_PartyLedger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.right_pnl = new System.Windows.Forms.Panel();
            this.pnlRightMain = new System.Windows.Forms.Panel();
            this.minimized_pnl = new System.Windows.Forms.PictureBox();
            this.exit_pnl = new System.Windows.Forms.PictureBox();
            this.lock_pnl = new System.Windows.Forms.PictureBox();
            this.home_pnl = new System.Windows.Forms.PictureBox();
            this.right_option_timer = new System.Windows.Forms.Timer(this.components);
            this.calendarClock1 = new CalendarClock.CalendarClock();
            this.memberFirstNameMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.memberLastNameMetroLabel = new MetroFramework.Controls.MetroLabel();
            this.home_admin_main_panel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_search_Direct = new System.Windows.Forms.Button();
            this.button_EditLedger_direct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_NewLedgerDirect = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button_UnpaidInv = new System.Windows.Forms.Button();
            this.button_GeneralLedger = new System.Windows.Forms.Button();
            this.button_Add = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bsDevices = new System.Windows.Forms.BindingSource(this.components);
            this.devicesBinidingSource = new System.Windows.Forms.BindingSource(this.components);
            this.right_pnl.SuspendLayout();
            this.pnlRightMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimized_pnl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_pnl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lock_pnl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.home_pnl)).BeginInit();
            this.home_admin_main_panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDevices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.devicesBinidingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // right_pnl
            // 
            this.right_pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.right_pnl.Controls.Add(this.pnlRightMain);
            this.right_pnl.Location = new System.Drawing.Point(1209, -14);
            this.right_pnl.Name = "right_pnl";
            this.right_pnl.Size = new System.Drawing.Size(92, 644);
            this.right_pnl.TabIndex = 195;
            // 
            // pnlRightMain
            // 
            this.pnlRightMain.Controls.Add(this.minimized_pnl);
            this.pnlRightMain.Controls.Add(this.exit_pnl);
            this.pnlRightMain.Controls.Add(this.lock_pnl);
            this.pnlRightMain.Controls.Add(this.home_pnl);
            this.pnlRightMain.Location = new System.Drawing.Point(3, 66);
            this.pnlRightMain.Name = "pnlRightMain";
            this.pnlRightMain.Size = new System.Drawing.Size(89, 513);
            this.pnlRightMain.TabIndex = 155;
            // 
            // minimized_pnl
            // 
            this.minimized_pnl.BackColor = System.Drawing.Color.Transparent;
            this.minimized_pnl.BackgroundImage = global::ATK_Computer_LTD.Properties.Resources.appbar_arrow_down;
            this.minimized_pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minimized_pnl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.minimized_pnl.Location = new System.Drawing.Point(6, 35);
            this.minimized_pnl.Name = "minimized_pnl";
            this.minimized_pnl.Size = new System.Drawing.Size(76, 76);
            this.minimized_pnl.TabIndex = 6;
            this.minimized_pnl.TabStop = false;
            this.minimized_pnl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Ctrl_MouseClick);
            this.minimized_pnl.MouseLeave += new System.EventHandler(this.Ctrl_MouseLeave);
            this.minimized_pnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ctrl_MouseMove);
            // 
            // exit_pnl
            // 
            this.exit_pnl.BackColor = System.Drawing.Color.Transparent;
            this.exit_pnl.BackgroundImage = global::ATK_Computer_LTD.Properties.Resources.appbar_power;
            this.exit_pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit_pnl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.exit_pnl.Location = new System.Drawing.Point(6, 401);
            this.exit_pnl.Name = "exit_pnl";
            this.exit_pnl.Size = new System.Drawing.Size(76, 76);
            this.exit_pnl.TabIndex = 5;
            this.exit_pnl.TabStop = false;
            this.exit_pnl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Ctrl_MouseClick);
            this.exit_pnl.MouseLeave += new System.EventHandler(this.Ctrl_MouseLeave);
            this.exit_pnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ctrl_MouseMove);
            // 
            // lock_pnl
            // 
            this.lock_pnl.BackColor = System.Drawing.Color.Transparent;
            this.lock_pnl.BackgroundImage = global::ATK_Computer_LTD.Properties.Resources.appbar_lock;
            this.lock_pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lock_pnl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lock_pnl.Location = new System.Drawing.Point(6, 279);
            this.lock_pnl.Name = "lock_pnl";
            this.lock_pnl.Size = new System.Drawing.Size(76, 76);
            this.lock_pnl.TabIndex = 4;
            this.lock_pnl.TabStop = false;
            this.lock_pnl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Ctrl_MouseClick);
            this.lock_pnl.MouseLeave += new System.EventHandler(this.Ctrl_MouseLeave);
            this.lock_pnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ctrl_MouseMove);
            // 
            // home_pnl
            // 
            this.home_pnl.BackColor = System.Drawing.Color.Transparent;
            this.home_pnl.BackgroundImage = global::ATK_Computer_LTD.Properties.Resources.appbar_home;
            this.home_pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.home_pnl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.home_pnl.Location = new System.Drawing.Point(6, 157);
            this.home_pnl.Name = "home_pnl";
            this.home_pnl.Size = new System.Drawing.Size(76, 76);
            this.home_pnl.TabIndex = 3;
            this.home_pnl.TabStop = false;
            this.home_pnl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Ctrl_MouseClick);
            this.home_pnl.MouseLeave += new System.EventHandler(this.Ctrl_MouseLeave);
            this.home_pnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ctrl_MouseMove);
            // 
            // right_option_timer
            // 
            this.right_option_timer.Interval = 1;
            this.right_option_timer.Tick += new System.EventHandler(this.right_option_timer_Tick);
            // 
            // calendarClock1
            // 
            this.calendarClock1.BackColor = System.Drawing.Color.Transparent;
            this.calendarClock1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendarClock1.Location = new System.Drawing.Point(909, 92);
            this.calendarClock1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.calendarClock1.Name = "calendarClock1";
            this.calendarClock1.Size = new System.Drawing.Size(256, 245);
            this.calendarClock1.TabIndex = 88;
            // 
            // memberFirstNameMetroLabel
            // 
            this.memberFirstNameMetroLabel.AutoSize = true;
            this.memberFirstNameMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.memberFirstNameMetroLabel.ForeColor = System.Drawing.Color.White;
            this.memberFirstNameMetroLabel.Location = new System.Drawing.Point(1073, 10);
            this.memberFirstNameMetroLabel.Name = "memberFirstNameMetroLabel";
            this.memberFirstNameMetroLabel.Size = new System.Drawing.Size(51, 19);
            this.memberFirstNameMetroLabel.TabIndex = 85;
            this.memberFirstNameMetroLabel.Text = "sadasd";
            this.memberFirstNameMetroLabel.UseCustomBackColor = true;
            this.memberFirstNameMetroLabel.UseCustomForeColor = true;
            // 
            // memberLastNameMetroLabel
            // 
            this.memberLastNameMetroLabel.AutoSize = true;
            this.memberLastNameMetroLabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.memberLastNameMetroLabel.ForeColor = System.Drawing.Color.White;
            this.memberLastNameMetroLabel.Location = new System.Drawing.Point(1073, 39);
            this.memberLastNameMetroLabel.Name = "memberLastNameMetroLabel";
            this.memberLastNameMetroLabel.Size = new System.Drawing.Size(59, 19);
            this.memberLastNameMetroLabel.TabIndex = 84;
            this.memberLastNameMetroLabel.Text = "dasdasd";
            this.memberLastNameMetroLabel.UseCustomBackColor = true;
            this.memberLastNameMetroLabel.UseCustomForeColor = true;
            // 
            // home_admin_main_panel
            // 
            this.home_admin_main_panel.BackColor = System.Drawing.Color.Transparent;
            this.home_admin_main_panel.Controls.Add(this.panel3);
            this.home_admin_main_panel.Controls.Add(this.calendarClock1);
            this.home_admin_main_panel.Controls.Add(this.memberFirstNameMetroLabel);
            this.home_admin_main_panel.Controls.Add(this.memberLastNameMetroLabel);
            this.home_admin_main_panel.Controls.Add(this.pictureBox);
            this.home_admin_main_panel.Controls.Add(this.label3);
            this.home_admin_main_panel.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.home_admin_main_panel.Location = new System.Drawing.Point(0, 0);
            this.home_admin_main_panel.Name = "home_admin_main_panel";
            this.home_admin_main_panel.Size = new System.Drawing.Size(1214, 750);
            this.home_admin_main_panel.TabIndex = 196;
            this.home_admin_main_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.home_admin_main_panel_MouseMove);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(32, 114);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(886, 522);
            this.panel3.TabIndex = 89;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button_search_Direct);
            this.panel1.Controls.Add(this.button_EditLedger_direct);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button_NewLedgerDirect);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button_UnpaidInv);
            this.panel1.Controls.Add(this.button_GeneralLedger);
            this.panel1.Controls.Add(this.button_Add);
            this.panel1.Location = new System.Drawing.Point(12, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(844, 412);
            this.panel1.TabIndex = 17;
            // 
            // button_search_Direct
            // 
            this.button_search_Direct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.button_search_Direct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_search_Direct.Font = new System.Drawing.Font("Segoe WP", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search_Direct.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_search_Direct.Image = global::ATK_Computer_LTD.Properties.Resources.View_File_Filled_501;
            this.button_search_Direct.Location = new System.Drawing.Point(637, 274);
            this.button_search_Direct.Name = "button_search_Direct";
            this.button_search_Direct.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_search_Direct.Size = new System.Drawing.Size(184, 115);
            this.button_search_Direct.TabIndex = 14;
            this.button_search_Direct.Text = "Search Ledger";
            this.button_search_Direct.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button_search_Direct.UseVisualStyleBackColor = false;
            this.button_search_Direct.Click += new System.EventHandler(this.button_search_Direct_Click);
            // 
            // button_EditLedger_direct
            // 
            this.button_EditLedger_direct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.button_EditLedger_direct.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_EditLedger_direct.Font = new System.Drawing.Font("Segoe WP", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EditLedger_direct.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_EditLedger_direct.Image = global::ATK_Computer_LTD.Properties.Resources.Edit_File_Filled_50;
            this.button_EditLedger_direct.Location = new System.Drawing.Point(637, 149);
            this.button_EditLedger_direct.Name = "button_EditLedger_direct";
            this.button_EditLedger_direct.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_EditLedger_direct.Size = new System.Drawing.Size(184, 119);
            this.button_EditLedger_direct.TabIndex = 13;
            this.button_EditLedger_direct.Text = "Edit Ledger";
            this.button_EditLedger_direct.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button_EditLedger_direct.UseVisualStyleBackColor = false;
            this.button_EditLedger_direct.Click += new System.EventHandler(this.button_EditLedger_direct_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.label1.Font = new System.Drawing.Font("Segoe WP", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(386, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Latest Notification";
            // 
            // button_NewLedgerDirect
            // 
            this.button_NewLedgerDirect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.button_NewLedgerDirect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_NewLedgerDirect.Font = new System.Drawing.Font("Segoe WP", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_NewLedgerDirect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_NewLedgerDirect.Image = global::ATK_Computer_LTD.Properties.Resources.Add_File_Filled_50;
            this.button_NewLedgerDirect.Location = new System.Drawing.Point(637, 25);
            this.button_NewLedgerDirect.Name = "button_NewLedgerDirect";
            this.button_NewLedgerDirect.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_NewLedgerDirect.Size = new System.Drawing.Size(184, 118);
            this.button_NewLedgerDirect.TabIndex = 8;
            this.button_NewLedgerDirect.Text = "New Ledger";
            this.button_NewLedgerDirect.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button_NewLedgerDirect.UseVisualStyleBackColor = false;
            this.button_NewLedgerDirect.Click += new System.EventHandler(this.button_NewLedgerDirect_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Segoe WP", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Image = global::ATK_Computer_LTD.Properties.Resources.Comments_96;
            this.button4.Location = new System.Drawing.Point(382, 25);
            this.button4.Name = "button4";
            this.button4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button4.Size = new System.Drawing.Size(249, 366);
            this.button4.TabIndex = 7;
            this.button4.Text = "button4";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button_UnpaidInv
            // 
            this.button_UnpaidInv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.button_UnpaidInv.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_UnpaidInv.Font = new System.Drawing.Font("Segoe WP", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_UnpaidInv.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_UnpaidInv.Image = global::ATK_Computer_LTD.Properties.Resources.Paid_Parking_Filled_100;
            this.button_UnpaidInv.Location = new System.Drawing.Point(16, 211);
            this.button_UnpaidInv.Name = "button_UnpaidInv";
            this.button_UnpaidInv.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_UnpaidInv.Size = new System.Drawing.Size(360, 180);
            this.button_UnpaidInv.TabIndex = 6;
            this.button_UnpaidInv.Text = "Unpaid Invoice";
            this.button_UnpaidInv.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button_UnpaidInv.UseVisualStyleBackColor = false;
            this.button_UnpaidInv.Click += new System.EventHandler(this.button_UnpaidInv_Click);
            // 
            // button_GeneralLedger
            // 
            this.button_GeneralLedger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.button_GeneralLedger.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_GeneralLedger.Font = new System.Drawing.Font("Segoe WP", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_GeneralLedger.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_GeneralLedger.Image = global::ATK_Computer_LTD.Properties.Resources.Page_Overview_2_104;
            this.button_GeneralLedger.Location = new System.Drawing.Point(199, 25);
            this.button_GeneralLedger.Name = "button_GeneralLedger";
            this.button_GeneralLedger.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_GeneralLedger.Size = new System.Drawing.Size(177, 180);
            this.button_GeneralLedger.TabIndex = 5;
            this.button_GeneralLedger.Text = "General Ledger";
            this.button_GeneralLedger.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button_GeneralLedger.UseVisualStyleBackColor = false;
            this.button_GeneralLedger.Click += new System.EventHandler(this.button_GeneralLedger_Click);
            // 
            // button_Add
            // 
            this.button_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.button_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Add.Font = new System.Drawing.Font("Segoe WP", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_Add.Image = global::ATK_Computer_LTD.Properties.Resources.Guest_Male_Filled_100;
            this.button_Add.Location = new System.Drawing.Point(16, 25);
            this.button_Add.Name = "button_Add";
            this.button_Add.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_Add.Size = new System.Drawing.Size(177, 180);
            this.button_Add.TabIndex = 4;
            this.button_Add.Text = "Add New Client";
            this.button_Add.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button_Add.UseVisualStyleBackColor = false;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe WP", 33.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(86, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(550, 61);
            this.label2.TabIndex = 15;
            this.label2.Text = "ACCOUNT MANAGEMENT";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(12, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(629, 79);
            this.panel2.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ATK_Computer_LTD.Properties.Resources.Accounting_100;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(26, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.Location = new System.Drawing.Point(992, 9);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(75, 75);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 83;
            this.pictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 40);
            this.label3.TabIndex = 74;
            this.label3.Text = "ATK COMPUTER LTD.";
            // 
            // Home_Admin_PartyLedger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1300, 741);
            this.Controls.Add(this.right_pnl);
            this.Controls.Add(this.home_admin_main_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home_Admin_PartyLedger";
            this.Text = "Home_Admin_PartyLedger";
            this.Load += new System.EventHandler(this.Home_Admin_PartyLedger_Load);
            this.SizeChanged += new System.EventHandler(this.Home_Admin_PartyLedger_SizeChanged);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Home_Admin_PartyLedger_MouseMove);
            this.right_pnl.ResumeLayout(false);
            this.pnlRightMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minimized_pnl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_pnl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lock_pnl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.home_pnl)).EndInit();
            this.home_admin_main_panel.ResumeLayout(false);
            this.home_admin_main_panel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDevices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.devicesBinidingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bsDevices;
        private System.Windows.Forms.Panel right_pnl;
        private System.Windows.Forms.Panel pnlRightMain;
        private System.Windows.Forms.PictureBox minimized_pnl;
        private System.Windows.Forms.PictureBox exit_pnl;
        private System.Windows.Forms.PictureBox lock_pnl;
        private System.Windows.Forms.PictureBox home_pnl;
        private System.Windows.Forms.Timer right_option_timer;
        private System.Windows.Forms.BindingSource devicesBinidingSource;
        private CalendarClock.CalendarClock calendarClock1;
        private MetroFramework.Controls.MetroLabel memberFirstNameMetroLabel;
        private MetroFramework.Controls.MetroLabel memberLastNameMetroLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel home_admin_main_panel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_search_Direct;
        private System.Windows.Forms.Button button_EditLedger_direct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_NewLedgerDirect;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button_UnpaidInv;
        private System.Windows.Forms.Button button_GeneralLedger;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}