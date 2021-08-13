using System;
using System.IO;
using System.Windows.Forms;
using ClearCache.Properties;

namespace ClearCache
{
    public partial class Form1 : Form
    {
        private string _formFolder = "";
        private string _cacheFolder = "";
        readonly private string _trackFiles;
        readonly private string[] _clearFiles;
        readonly private string _cacheFolderName;
        private FileSystemWatcher _watcher;

        public Form1()
        {
            InitializeComponent();
            textBox_formFolder.Text = _formFolder = Settings.Default.FormFolder;
            textBox_cacheFolder.Text = _cacheFolder = Settings.Default.CacheFolder;
            _trackFiles = Settings.Default.TrackFiles;
            _clearFiles = Settings.Default.ClearFiles.Split(';', StringSplitOptions.RemoveEmptyEntries);
            _cacheFolderName = Settings.Default.CacheFolderName;
            CheckAllDirectoryExists();
        }

        private void Button_formFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = _formFolder;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK &&
                !string.IsNullOrEmpty(folderBrowserDialog1.SelectedPath))
            {
                _formFolder = folderBrowserDialog1.SelectedPath;
                textBox_formFolder.Text = _formFolder;

                var newCachePath = GetCachePath(_formFolder);
                if (!string.IsNullOrEmpty(newCachePath))
                {
                    _cacheFolder = newCachePath;
                    textBox_cacheFolder.Text = _cacheFolder;
                }
            }

            CheckAllDirectoryExists();
        }

        private void CheckBox_enabled_CheckedChanged(object sender, EventArgs e)
        {
            var en = checkBox_enabled.Checked;
            WatcherStart(en);
            button_formFolder.Enabled = !en;
            textBox_formFolder.Enabled = !en;
        }

        private bool WatcherStart(bool en)
        {
            if (_watcher != null)
            {
                _watcher.Dispose();
            }

            if (!en)
            {
                notifyIcon1.Text = "Inactive";
                return true;
            }

            notifyIcon1.Text = "Active";
            try
            {
                _watcher = new FileSystemWatcher(_formFolder);

                _watcher.NotifyFilter = NotifyFilters.DirectoryName
                                        | NotifyFilters.FileName
                                        | NotifyFilters.LastWrite
                                        | NotifyFilters.Size;

                _watcher.Changed += ClearCache;
                _watcher.Created += ClearCache;
                _watcher.Deleted += ClearCache;
                _watcher.Renamed += ClearCache;
                _watcher.Error += WatcherError;

                _watcher.Filter = _trackFiles;
                _watcher.IncludeSubdirectories = true;
                _watcher.EnableRaisingEvents = true;
                _watcher.InternalBufferSize *= 10;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't start watcher: " + ex);
                return false;
            }

            return true;
        }

        private void TextBox_formFolder_Leave(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox_formFolder.Text))
            {
                _formFolder = textBox_formFolder.Text;
            }

            var newCachePath = GetCachePath(_formFolder);
            if (!string.IsNullOrEmpty(newCachePath))
            {
                _cacheFolder = newCachePath;
                textBox_cacheFolder.Text = _cacheFolder;
            }

            CheckAllDirectoryExists();
        }


        private bool CheckAllDirectoryExists()
        {
            var result = Directory.Exists(_formFolder); // && Directory.Exists(_cacheFolder);
            checkBox_enabled.Enabled = result;
            if (!result)
            {
                checkBox_enabled.Checked = false;
            }

            return result;
        }

        private void ClearCache(object sender, FileSystemEventArgs e)
        {
            try
            {
                foreach (var file in _clearFiles)
                {
                    foreach (var f in Directory.EnumerateFiles(_cacheFolder, file))
                    {
                        File.Delete(f);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't delete files: " + ex);
            }
        }

        private static void WatcherError(object sender, ErrorEventArgs ex)
        {
            MessageBox.Show("Error watching files: " + ex);
        }

        private string GetCachePath(string dirPath)
        {
            var cachePath = dirPath.Trim('\\') + "\\" + _cacheFolderName.Trim('\\') + "\\";
            //if (Directory.Exists(cachePath)) //&& dirPath.Contains("\\Deployment\\Server\\Apps\\"))
            return cachePath;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WatcherStart(false);
            Settings.Default.FormFolder = _formFolder;
            Settings.Default.CacheFolder = _cacheFolder;
            Settings.Default.Save();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }
    }
}
