using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
// СКАЖЕМ НЕТ СТРУКТУРНОМУ ПРОГРАММИРОВАНИЮ
namespace LittleDiskCleaner
{
    public partial class MainForm : Form
    {
        public MainForm() => InitializeComponent();
        //////////////////////////////////////////////////
        private bool IsShowMenu; // Флаг для определения какую функцию выполнять при нажатии на B_SearchOptions
        private static List<FileInfo> ListFiles = new List<FileInfo>(1000); // Найденные файлы
        private static long NumSize = 0;    // Общий размер всех файлов
        private static bool DontGoAnywhere; // Флаг, что нужно искать только в той папке, которая указана
        private struct DataSearch // Структура, в которой необходимые данные для поискаы
        {
            public string PathDir;
            public string[] Extensions;
        }
        //////////////////////////////////////////////////
        private void MainForm_Load(object sender, EventArgs e)
        {
            WindowsReStyle();
            CheckForIllegalCrossThreadCalls = false;
            for (int i = 0; i < CLB_OptionsSearch.Items.Count; ++i)
            {
                if (!CLB_OptionsSearch.GetItemChecked(i))
                {
                    CLB_OptionsSearch.SetItemChecked(i, true);
                }
            }
        }
        //////////////////////////////////////////////////
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0xA1, 0x2, 0);
        }
        //////////////////////////////////////////////////
        private void ShowOptionsSearch()
        {
            Point
                p1 = new Point(CLB_OptionsSearch.Location.X, CLB_OptionsSearch.Location.Y),
                p2 = new Point(B_StartSearch.Location.X, B_StartSearch.Location.Y),
                p3 = new Point(B_SearchOptions.Location.X, B_SearchOptions.Location.Y);
            B_StartSearch.Enabled = false;
            for (; p1.X < 50; p1.X += 4)
            {
                CLB_OptionsSearch.Location = p1;
                if (B_StartSearch.Location.X < 450)
                {
                    ++p2.X;
                    ++p3.X;
                    B_StartSearch.Location = p2;
                    B_SearchOptions.Location = p3;
                }
            }
            IsShowMenu = true;
        }
        //////////////////////////////////////////////////
        /// <summary>
        /// Поиск файлов в каталоге и в его подкаталогах (флаг DontGoAnywhere)
        /// </summary>
        /// <param name="data">Запакованная структура DataSearch</param>
        private static void SearchFiles(object data)
        {
            DirectoryInfo CurrentDir;
            FileInfo[] FilesInCurrentDir;
            DirectoryInfo[] DirsInCurrentDir;
            DataSearch CurrentData = (DataSearch)data;
            try // Проверяем доступ к файлам и папке
            {
                CurrentDir = new DirectoryInfo(CurrentData.PathDir);
                FilesInCurrentDir = CurrentDir.GetFiles();
                DirsInCurrentDir = CurrentDir.GetDirectories();
            }
            catch { return; }
            FileInfo tempFile;
            for (int i = 0; FilesInCurrentDir.Length > 0 && i < FilesInCurrentDir.Length; ++i)
            {
                tempFile = FilesInCurrentDir[i];
                foreach (string ext in CurrentData.Extensions)
                {
                    if (ext == "*" || tempFile.Extension == ext)
                    {
                        NumSize += (tempFile.Length / 1024);
                        ListFiles.Add(tempFile);
                        break;
                    }
                }
            }
            if (DontGoAnywhere) return; // Нельзя идти в подкаталоги - выходим
            DataSearch NewData = new DataSearch() { Extensions = CurrentData.Extensions };
            for (int i = 0; DirsInCurrentDir.Length > 0 && i < DirsInCurrentDir.Length; ++i)
            {
                NewData.PathDir = DirsInCurrentDir[i].FullName;
                SearchFiles(NewData);
            }
        }
        //////////////////////////////////////////////////
        private void ClearListFiles() => ListFiles.Clear();
        //////////////////////////////////////////////////
        /// <summary>
        /// Инициализация начала и конца поиска файлов с выводом в DGW_Files
        /// </summary>
        /// <param name="pathDir">Путь к папке откуда начинается поиск</param>
        /// <param name="extensions">Расширения файлов, которые мы ищем</param>
        /// <param name="name">Название категории поиска (1-я колонка)</param>
        /// <param name="_DontGoAnywhere">Флаг, обозначающий, что поиск не будет происходить в подкаталогах</param>
        private void CallSearchFunc(string pathDir, string[] extensions, string name, bool _DontGoAnywhere = false)
        {
            DontGoAnywhere = _DontGoAnywhere;
            DataSearch s = new DataSearch { PathDir = pathDir, Extensions = extensions };
            Thread DirThread = new Thread(SearchFiles);
            DirThread.Start(s);
            while (DirThread.IsAlive)
            {
                Application.DoEvents();
                Thread.Sleep(0);
                Application.DoEvents();
            }
            for (int i = 0; ListFiles.Count > 0 && i < ListFiles.Count; ++i)
                DGW_Files.Rows.Add(name, ListFiles[i].FullName, (ListFiles[i].Length / 1024) + " кб.", false);
            if (DontGoAnywhere)
                DontGoAnywhere = false;
            ClearListFiles(); // Очищаем список файлов
        }
        //////////////////////////////////////////////////
        private void B_StartSearch_Click(object sender, EventArgs e)
        {
            // Проверяем, что выбрана хоть одна категория
            bool NoOneMarked = true;
            for (int i = 0; i < CLB_OptionsSearch.Items.Count; ++i)
            {
                if (CLB_OptionsSearch.GetItemChecked(i))
                {
                    NoOneMarked = false;
                    break;
                }
            }
            if (NoOneMarked)
            {
                CllShrtMsg("Вы не выбрали ни одной категории поиска.", Icon: MessageBoxIcon.Stop, Buttons: MessageBoxButtons.OK);
                return;
            }
            // Прячем кнопочки и прочее
            B_SearchOptions.Visible = false;
            B_StartSearch.Visible = false;
            SearchProgressBar.Visible = true;
            DGW_Files.Visible = false;

            NumSize = 0;

            string winDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string localApplicationDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string commonApplicationDataDir = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string applicationDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Начинаем проверять что активно и соответственно запускать процессы поиска
            if (CLB_OptionsSearch.GetItemChecked(0))
            {
                string name = "Временные файлы";
                CallSearchFunc(winDir + @"\Temp\", new string[] { "*" }, name);
                CallSearchFunc(localApplicationDataDir + @"\Temp\", new string[] { "*" }, name);
                string fntcacheFile = winDir + @"\system32\FNTCACHE.dat";
                if (File.Exists(fntcacheFile))
                {
                    FileInfo f = new FileInfo(fntcacheFile);
                    DGW_Files.Rows.Add(name, fntcacheFile, (f.Length / 1024) + " кб.", false);
                }
            }
            if (CLB_OptionsSearch.GetItemChecked(1))
            {
                string name = "Старые Prefetch-данные";
                CallSearchFunc(winDir + @"\Prefetch\", new string[] { ".pf" }, name);
            }
            if (CLB_OptionsSearch.GetItemChecked(2))
            {
                string name = "Отчёты об ошибках";
                CallSearchFunc(commonApplicationDataDir + @"\Microsoft\Windows\WER\", new string[] { ".wer" }, name);
            }
            if (CLB_OptionsSearch.GetItemChecked(3))
            {
                string name = "Кэш эскизов проводника";
                CallSearchFunc(localApplicationDataDir + @"\Microsoft\Windows\Explorer\", new string[] { ".db" }, name);
            }
            if (CLB_OptionsSearch.GetItemChecked(4))
            {
                string name = "Дампы памяти";
                CallSearchFunc(winDir + @"\LiveKernelReports\", new string[] { ".dmp" }, name);
                CallSearchFunc(winDir + @"\MiniDump\", new string[] { ".dmp" }, name);
            }
            if (CLB_OptionsSearch.GetItemChecked(5))
            {
                string name = "Папка недавних документов";
                CallSearchFunc(applicationDataDir + @"\Roaming\Microsoft\Windows\Recent\", new[] { ".lnk" }, name);
            }
            if (CLB_OptionsSearch.GetItemChecked(6))
            {
                string name = "Cookie-файлы";
                CallSearchFunc(localApplicationDataDir + @"\Packages\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\AC\MicrosoftEdge\Cookies\", new string[] { "*" }, name);
                CallSearchFunc(localApplicationDataDir + @"\Packages\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\AC\#!001\MicrosoftEdge\Cookies\", new string[] { "*" }, name);
                CallSearchFunc(localApplicationDataDir + @"\Packages\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\AC\#!002\\MicrosoftEdge\Cookies\", new string[] { "*" }, name);
                CallSearchFunc(localApplicationDataDir + @"\\Packages\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\AC\#!001\MicrosoftEdge\User\Default\DOMStore\", new string[] { "*" }, name);
                CallSearchFunc(localApplicationDataDir + @"\Microsoft\Windows\INetCookies\", new string[] { "*" }, name);
                CallSearchFunc(localApplicationDataDir + @"\Microsoft\Internet Explorer\DOMStore\", new string[] { "*" }, name);
            }
            if (CLB_OptionsSearch.GetItemChecked(7))
            {
                string name = "Кэш Adobe Flash Player";
                CallSearchFunc(applicationDataDir + @"\Macromedia\Flash Player\", new string[] { "*" }, name);
            }
            if (CLB_OptionsSearch.GetItemChecked(8))
            {
                string name = "Логи";
                CallSearchFunc(winDir, new string[] { ".log" }, name, true);
                CallSearchFunc(winDir + @"\security\logs\", new string[] { "*" }, name, true);
                CallSearchFunc(winDir + @"\logs\", new string[] { "*" }, name);
                CallSearchFunc(winDir + @"\Microsoft.NET\Framework\", new string[] { ".log" }, name);
                CallSearchFunc(winDir + @"\Microsoft.NET\Framework64\", new string[] { ".log" }, name);
                CallSearchFunc(winDir + @"\ServiceProfiles\LocalService\AppData\Local\", new string[] { ".log" }, name);
                CallSearchFunc(winDir + @"\inf\", new string[] { ".log" }, name);
                CallSearchFunc(winDir + @"\system32\LogFiles\", new string[] { ".log" }, name);
                CallSearchFunc(winDir + @"\Microsoft\Windows\WebCache\", new string[] { ".log" }, name);
            }

            L_Result.Text = string.Format("Файлов: {0} | Размер: {1} мб. ({2} кб.)", DGW_Files.RowCount, NumSize / 1024, NumSize);

            // Делаем анимации
            Point p = new Point(PB_BackToMainMenu.Location.X, PB_BackToMainMenu.Location.Y);
            Point p2 = new Point(PB_RemoveFiles.Location.X, PB_BackToMainMenu.Location.Y);
            Point p3 = new Point(PB_MarkAll.Location.X, PB_BackToMainMenu.Location.Y + 4);
            Point p4 = new Point(PB_UnMarkAll.Location.X, PB_BackToMainMenu.Location.Y + 4);
            Point p5 = new Point(L_Result.Location.X, PB_BackToMainMenu.Location.Y + 5);
            for (; p.Y != 8; ++p.Y, ++p2.Y, ++p3.Y, ++p4.Y, ++p5.Y)
            {
                PB_BackToMainMenu.Location = p;
                PB_RemoveFiles.Location = p2;
                PB_MarkAll.Location = p3;
                PB_UnMarkAll.Location = p4;
                L_Result.Location = p5;

                PB_BackToMainMenu.Refresh();
                PB_RemoveFiles.Refresh();
                PB_MarkAll.Refresh();
                PB_UnMarkAll.Refresh();
                L_Result.Refresh();
                Thread.Sleep(3);
            }
            // Показываем элементы
            SearchProgressBar.Visible = false;
            DGW_Files.Visible = true;
            CllShrtMsg("Поиск файлов успешно завершён!", Icon: MessageBoxIcon.Information, Buttons: MessageBoxButtons.OK);
        }
        //////////////////////////////////////////////////
        private void DGW_Files_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3)
                CllShrtMsg(DGW_Files[e.ColumnIndex, e.RowIndex].Value.ToString(), Icon: MessageBoxIcon.None, Buttons: MessageBoxButtons.OK);
        }
        //////////////////////////////////////////////////
        private void HideOptionsSearch()
        {
            Point
                p1 = new Point(CLB_OptionsSearch.Location.X, CLB_OptionsSearch.Location.Y),
                p2 = new Point(B_StartSearch.Location.X, B_StartSearch.Location.Y),
                p3 = new Point(B_SearchOptions.Location.X, B_SearchOptions.Location.Y);
            B_StartSearch.Enabled = true;
            for (; p1.X > -199; p1.X -= 3)
            {
                CLB_OptionsSearch.Location = p1;
                if (B_StartSearch.Location.X > 327)
                {
                    --p2.X;
                    --p3.X;
                    B_StartSearch.Location = p2;
                    B_SearchOptions.Location = p3;
                }
            }
            IsShowMenu = false;
        }
        //////////////////////////////////////////////////
        private void PB_BackToMainMenu_MouseHover(object sender, EventArgs e) => ((PictureBox)sender).BackColor = Color.FromArgb(90, 90, 90);
        //////////////////////////////////////////////////
        private void PB_BackToMainMenu_MouseLeave(object sender, EventArgs e) => ((PictureBox)sender).BackColor = Color.FromArgb(250, 250, 250);
        //////////////////////////////////////////////////
        private void B_MinimizeApp_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        //////////////////////////////////////////////////
        private void B_CloseApp_Click(object sender, EventArgs e) => Application.Exit();
        //////////////////////////////////////////////////
        private void B_SearchOptions_Click(object sender, EventArgs e) => BGW_ShowAndHideMenu.RunWorkerAsync();
        //////////////////////////////////////////////////
        private void PB_RemoveFiles_Click(object sender, EventArgs e)
        {
            var dialogResult = CllShrtMsg("Вы уверены, что хотите удалить выбранные файлы?");
            if (dialogResult == DialogResult.No) return;
            string fileFullName;
            bool marked;
            FileInfo file;
            button1.PerformClick(); // фикс изменения флажков
            for (int i = 0; DGW_Files.RowCount > 0 && i < DGW_Files.RowCount; ++i)
            {
                fileFullName = (string)DGW_Files[1, i].Value;
                marked = DGW_Files[3, i].Value.Equals(true);
                file = new FileInfo(fileFullName);
                if (!string.IsNullOrEmpty(fileFullName) && File.Exists(fileFullName) && marked)
                {
                    if (File.GetAttributes(fileFullName) != FileAttributes.System)
                       
                    {
                        NumSize -= (file.Length / 1024);
                        try // Пытаемся удалить файл
                        {
                            File.Delete(fileFullName);
                        }
                        catch { } // Если не выходит удалить, то ничо не делаем
                        DGW_Files.Rows.RemoveAt(i); // Удаляем запись из DGW_Files
                        --i;   
                    }
                }
            }
            L_Result.Text = string.Format("Файлов: {0} | Размер: {1} мб. ({2} кб.)", DGW_Files.RowCount, NumSize / 1024, NumSize);
            CllShrtMsg("Выбранные файлы были удалены!", Icon: MessageBoxIcon.Information, Buttons : MessageBoxButtons.OK);
        }
        //////////////////////////////////////////////////
        private void MarkAllButton_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < DGW_Files.RowCount; ++i)
            {
                if (DGW_Files[3, i].Value.Equals(false))
                    DGW_Files[3, i].Value = true;
            }
            button1.PerformClick(); // фикс изменения флажков
        }
        //////////////////////////////////////////////////
        private void UnMarkAllButton_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < DGW_Files.RowCount; ++i)
            {
                if (DGW_Files[3, i].Value.Equals(true))
                    DGW_Files[3, i].Value = false;
            }
            button1.PerformClick(); // фикс изменения флажков
        }
        //////////////////////////////////////////////////
        private void BGW_HideTools_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            // Возвращаем все элементы на места
            Point p = new Point(PB_BackToMainMenu.Location.X, PB_BackToMainMenu.Location.Y);
            Point p2 = new Point(PB_RemoveFiles.Location.X, PB_RemoveFiles.Location.Y);
            Point p3 = new Point(PB_MarkAll.Location.X, PB_BackToMainMenu.Location.Y - 4);
            Point p4 = new Point(PB_UnMarkAll.Location.X, PB_BackToMainMenu.Location.Y - 4);
            Point p5 = new Point(L_Result.Location.X, PB_BackToMainMenu.Location.Y - 5);
            for (; p.Y != -35; --p.Y, --p2.Y, --p3.Y, --p4.Y, --p5.Y)
            {
                PB_BackToMainMenu.Location = p;
                PB_RemoveFiles.Location = p2;
                PB_MarkAll.Location = p3;
                PB_UnMarkAll.Location = p4;
                L_Result.Location = p5;
                Thread.Sleep(1);
            }
            DGW_Files.Rows.Clear();
            B_StartSearch.Visible = true;
            B_SearchOptions.Visible = true;
        }
        //////////////////////////////////////////////////
        private void PB_BackToMainMenu_Click(object sender, EventArgs e) => BGW_HideTools.RunWorkerAsync();
        //////////////////////////////////////////////////
        private void BGW_ShowAndHideMenu_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (IsShowMenu)
                HideOptionsSearch();
            else
                ShowOptionsSearch();
        }
        //////////////////////////////////////////////////
        private void WindowsReStyle()
        {
            const int GWL_STYLE = -16;
            const int WS_BORDER = 0x00800000; 
            const int WS_CAPTION = WS_BORDER | 0x00400000;  

            IntPtr pFoundWindow = Handle;

            int style = GetWindowLong(pFoundWindow, GWL_STYLE);
            RemoveMenu(GetMenu(pFoundWindow), 0, (0x400 | 0x1000));

            SetWindowLong(pFoundWindow, GWL_STYLE, (style & ~WS_BORDER));
            SetWindowLong(pFoundWindow, GWL_STYLE, (style & ~WS_CAPTION));

            DrawMenuBar(pFoundWindow);
        }
        //////////////////////////////////////////////////
        private DialogResult CllShrtMsg(string Msg, string Title = "", MessageBoxIcon Icon = MessageBoxIcon.Question, MessageBoxButtons Buttons = MessageBoxButtons.YesNo)
        {
            return MessageBox.Show(this, Msg, Title, Buttons, Icon);
        }
        //////////////////////////////////////////////////
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr GetMenu(IntPtr hWnd);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool DrawMenuBar(IntPtr hWnd);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);
    }
}
