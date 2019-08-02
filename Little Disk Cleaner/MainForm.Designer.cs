namespace LittleDiskCleaner
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.B_StartSearch = new System.Windows.Forms.Button();
            this.BGW_ShowAndHideMenu = new System.ComponentModel.BackgroundWorker();
            this.DGW_Files = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CLB_OptionsSearch = new System.Windows.Forms.CheckedListBox();
            this.BGW_HideTools = new System.ComponentModel.BackgroundWorker();
            this.L_Result = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SearchProgressBar = new MetroFramework.Controls.MetroProgressSpinner();
            this.B_SearchOptions = new System.Windows.Forms.Button();
            this.PB_UnMarkAll = new System.Windows.Forms.PictureBox();
            this.PB_MarkAll = new System.Windows.Forms.PictureBox();
            this.PB_RemoveFiles = new System.Windows.Forms.PictureBox();
            this.B_MinimizeApp = new System.Windows.Forms.Button();
            this.PB_BackToMainMenu = new System.Windows.Forms.PictureBox();
            this.B_CloseApp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Files)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_UnMarkAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_MarkAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_RemoveFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_BackToMainMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // B_StartSearch
            // 
            this.B_StartSearch.BackColor = System.Drawing.Color.RoyalBlue;
            this.B_StartSearch.FlatAppearance.BorderSize = 0;
            this.B_StartSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.B_StartSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.B_StartSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_StartSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.B_StartSearch.ForeColor = System.Drawing.Color.White;
            this.B_StartSearch.Location = new System.Drawing.Point(327, 272);
            this.B_StartSearch.Name = "B_StartSearch";
            this.B_StartSearch.Size = new System.Drawing.Size(159, 44);
            this.B_StartSearch.TabIndex = 77;
            this.B_StartSearch.Text = "Поиск";
            this.B_StartSearch.UseVisualStyleBackColor = false;
            this.B_StartSearch.Click += new System.EventHandler(this.B_StartSearch_Click);
            // 
            // BGW_ShowAndHideMenu
            // 
            this.BGW_ShowAndHideMenu.WorkerSupportsCancellation = true;
            this.BGW_ShowAndHideMenu.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_ShowAndHideMenu_DoWork);
            // 
            // DGW_Files
            // 
            this.DGW_Files.AllowUserToAddRows = false;
            this.DGW_Files.AllowUserToDeleteRows = false;
            this.DGW_Files.AllowUserToResizeColumns = false;
            this.DGW_Files.AllowUserToResizeRows = false;
            this.DGW_Files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGW_Files.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGW_Files.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.DGW_Files.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGW_Files.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.DGW_Files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGW_Files.ColumnHeadersVisible = false;
            this.DGW_Files.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4});
            this.DGW_Files.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.DGW_Files.Location = new System.Drawing.Point(12, 41);
            this.DGW_Files.Name = "DGW_Files";
            this.DGW_Files.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGW_Files.RowHeadersVisible = false;
            this.DGW_Files.RowHeadersWidth = 71;
            this.DGW_Files.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGW_Files.ShowCellErrors = false;
            this.DGW_Files.ShowCellToolTips = false;
            this.DGW_Files.ShowEditingIcon = false;
            this.DGW_Files.ShowRowErrors = false;
            this.DGW_Files.Size = new System.Drawing.Size(746, 540);
            this.DGW_Files.TabIndex = 87;
            this.DGW_Files.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGW_Files_CellDoubleClick);
            // 
            // Column2
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.FillWeight = 112.404F;
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.FillWeight = 251.937F;
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.FillWeight = 52.4567F;
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(125)))), ((int)(((byte)(210)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.NullValue = false;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column4.FillWeight = 22.28864F;
            this.Column4.HeaderText = "Column4";
            this.Column4.Name = "Column4";
            // 
            // CLB_OptionsSearch
            // 
            this.CLB_OptionsSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CLB_OptionsSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CLB_OptionsSearch.FormattingEnabled = true;
            this.CLB_OptionsSearch.Items.AddRange(new object[] {
            "Временные файлы",
            "Старые Prefetch-данные",
            "Отчёты об ошибках",
            "Кэш эскизов проводника",
            "Дампы памяти",
            "Папка недавних документов",
            "Cookie-файлы",
            "Кэш Adobe Flash Player",
            "Логи"});
            this.CLB_OptionsSearch.Location = new System.Drawing.Point(-196, 176);
            this.CLB_OptionsSearch.Name = "CLB_OptionsSearch";
            this.CLB_OptionsSearch.Size = new System.Drawing.Size(195, 200);
            this.CLB_OptionsSearch.TabIndex = 90;
            // 
            // BGW_HideTools
            // 
            this.BGW_HideTools.WorkerSupportsCancellation = true;
            this.BGW_HideTools.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_HideTools_DoWork);
            // 
            // L_Result
            // 
            this.L_Result.AutoSize = true;
            this.L_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.L_Result.Location = new System.Drawing.Point(252, -18);
            this.L_Result.Name = "L_Result";
            this.L_Result.Size = new System.Drawing.Size(41, 15);
            this.L_Result.TabIndex = 97;
            this.L_Result.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, -24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 1);
            this.button1.TabIndex = 102;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SearchProgressBar
            // 
            this.SearchProgressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SearchProgressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.SearchProgressBar.CustomBackground = true;
            this.SearchProgressBar.Location = new System.Drawing.Point(304, 216);
            this.SearchProgressBar.Maximum = 100;
            this.SearchProgressBar.Name = "SearchProgressBar";
            this.SearchProgressBar.Size = new System.Drawing.Size(160, 160);
            this.SearchProgressBar.Speed = 4F;
            this.SearchProgressBar.Style = MetroFramework.MetroColorStyle.Magenta;
            this.SearchProgressBar.TabIndex = 103;
            this.SearchProgressBar.UseCustomBackColor = true;
            this.SearchProgressBar.UseSelectable = true;
            this.SearchProgressBar.Value = 30;
            this.SearchProgressBar.Visible = false;
            // 
            // B_SearchOptions
            // 
            this.B_SearchOptions.BackgroundImage = global::LittleDiskCleaner.Properties.Resources.Settings;
            this.B_SearchOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_SearchOptions.FlatAppearance.BorderSize = 0;
            this.B_SearchOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.B_SearchOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.B_SearchOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_SearchOptions.Location = new System.Drawing.Point(277, 272);
            this.B_SearchOptions.Name = "B_SearchOptions";
            this.B_SearchOptions.Size = new System.Drawing.Size(44, 44);
            this.B_SearchOptions.TabIndex = 86;
            this.B_SearchOptions.UseVisualStyleBackColor = false;
            this.B_SearchOptions.Click += new System.EventHandler(this.B_SearchOptions_Click);
            // 
            // PB_UnMarkAll
            // 
            this.PB_UnMarkAll.BackgroundImage = global::LittleDiskCleaner.Properties.Resources.UnMarkAll;
            this.PB_UnMarkAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PB_UnMarkAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_UnMarkAll.Location = new System.Drawing.Point(123, -25);
            this.PB_UnMarkAll.Name = "PB_UnMarkAll";
            this.PB_UnMarkAll.Size = new System.Drawing.Size(20, 20);
            this.PB_UnMarkAll.TabIndex = 101;
            this.PB_UnMarkAll.TabStop = false;
            this.PB_UnMarkAll.Click += new System.EventHandler(this.UnMarkAllButton_Click);
            this.PB_UnMarkAll.MouseLeave += new System.EventHandler(this.PB_BackToMainMenu_MouseLeave);
            this.PB_UnMarkAll.MouseHover += new System.EventHandler(this.PB_BackToMainMenu_MouseHover);
            // 
            // PB_MarkAll
            // 
            this.PB_MarkAll.BackgroundImage = global::LittleDiskCleaner.Properties.Resources.MarkAll;
            this.PB_MarkAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PB_MarkAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_MarkAll.Location = new System.Drawing.Point(96, -25);
            this.PB_MarkAll.Name = "PB_MarkAll";
            this.PB_MarkAll.Size = new System.Drawing.Size(20, 20);
            this.PB_MarkAll.TabIndex = 100;
            this.PB_MarkAll.TabStop = false;
            this.PB_MarkAll.Click += new System.EventHandler(this.MarkAllButton_Click);
            this.PB_MarkAll.MouseLeave += new System.EventHandler(this.PB_BackToMainMenu_MouseLeave);
            this.PB_MarkAll.MouseHover += new System.EventHandler(this.PB_BackToMainMenu_MouseHover);
            // 
            // PB_RemoveFiles
            // 
            this.PB_RemoveFiles.BackgroundImage = global::LittleDiskCleaner.Properties.Resources.RemoveMarked;
            this.PB_RemoveFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PB_RemoveFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_RemoveFiles.Location = new System.Drawing.Point(51, -36);
            this.PB_RemoveFiles.Name = "PB_RemoveFiles";
            this.PB_RemoveFiles.Size = new System.Drawing.Size(30, 27);
            this.PB_RemoveFiles.TabIndex = 96;
            this.PB_RemoveFiles.TabStop = false;
            this.PB_RemoveFiles.Click += new System.EventHandler(this.PB_RemoveFiles_Click);
            this.PB_RemoveFiles.MouseLeave += new System.EventHandler(this.PB_BackToMainMenu_MouseLeave);
            this.PB_RemoveFiles.MouseHover += new System.EventHandler(this.PB_BackToMainMenu_MouseHover);
            // 
            // B_MinimizeApp
            // 
            this.B_MinimizeApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_MinimizeApp.BackgroundImage = global::LittleDiskCleaner.Properties.Resources.AppMinimize;
            this.B_MinimizeApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_MinimizeApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.B_MinimizeApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_MinimizeApp.Location = new System.Drawing.Point(702, 10);
            this.B_MinimizeApp.Name = "B_MinimizeApp";
            this.B_MinimizeApp.Size = new System.Drawing.Size(25, 25);
            this.B_MinimizeApp.TabIndex = 95;
            this.B_MinimizeApp.UseVisualStyleBackColor = true;
            this.B_MinimizeApp.Click += new System.EventHandler(this.B_MinimizeApp_Click);
            // 
            // PB_BackToMainMenu
            // 
            this.PB_BackToMainMenu.BackgroundImage = global::LittleDiskCleaner.Properties.Resources.Back;
            this.PB_BackToMainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PB_BackToMainMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_BackToMainMenu.Location = new System.Drawing.Point(13, -36);
            this.PB_BackToMainMenu.Name = "PB_BackToMainMenu";
            this.PB_BackToMainMenu.Size = new System.Drawing.Size(30, 27);
            this.PB_BackToMainMenu.TabIndex = 94;
            this.PB_BackToMainMenu.TabStop = false;
            this.PB_BackToMainMenu.Click += new System.EventHandler(this.PB_BackToMainMenu_Click);
            this.PB_BackToMainMenu.MouseLeave += new System.EventHandler(this.PB_BackToMainMenu_MouseLeave);
            this.PB_BackToMainMenu.MouseHover += new System.EventHandler(this.PB_BackToMainMenu_MouseHover);
            // 
            // B_CloseApp
            // 
            this.B_CloseApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_CloseApp.BackgroundImage = global::LittleDiskCleaner.Properties.Resources.AppExit;
            this.B_CloseApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.B_CloseApp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.B_CloseApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_CloseApp.Location = new System.Drawing.Point(733, 10);
            this.B_CloseApp.Name = "B_CloseApp";
            this.B_CloseApp.Size = new System.Drawing.Size(25, 25);
            this.B_CloseApp.TabIndex = 91;
            this.B_CloseApp.UseVisualStyleBackColor = true;
            this.B_CloseApp.Click += new System.EventHandler(this.B_CloseApp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(769, 593);
            this.Controls.Add(this.B_SearchOptions);
            this.Controls.Add(this.B_StartSearch);
            this.Controls.Add(this.SearchProgressBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PB_UnMarkAll);
            this.Controls.Add(this.PB_MarkAll);
            this.Controls.Add(this.L_Result);
            this.Controls.Add(this.PB_RemoveFiles);
            this.Controls.Add(this.B_MinimizeApp);
            this.Controls.Add(this.PB_BackToMainMenu);
            this.Controls.Add(this.B_CloseApp);
            this.Controls.Add(this.CLB_OptionsSearch);
            this.Controls.Add(this.DGW_Files);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(785, 632);
            this.MinimumSize = new System.Drawing.Size(785, 632);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Little Disk Cleaner";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGW_Files)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_UnMarkAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_MarkAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_RemoveFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_BackToMainMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_StartSearch;
        private System.Windows.Forms.Button B_SearchOptions;
        private System.ComponentModel.BackgroundWorker BGW_ShowAndHideMenu;
        private System.Windows.Forms.DataGridView DGW_Files;
        private System.Windows.Forms.CheckedListBox CLB_OptionsSearch;
        private System.Windows.Forms.Button B_CloseApp;
        private System.Windows.Forms.PictureBox PB_BackToMainMenu;
        private System.Windows.Forms.Button B_MinimizeApp;
        private System.Windows.Forms.PictureBox PB_RemoveFiles;
        private System.ComponentModel.BackgroundWorker BGW_HideTools;
        private System.Windows.Forms.Label L_Result;
        private System.Windows.Forms.PictureBox PB_UnMarkAll;
        private System.Windows.Forms.PictureBox PB_MarkAll;
        private System.Windows.Forms.Button button1;
        private MetroFramework.Controls.MetroProgressSpinner SearchProgressBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
    }
}

