using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Owin.Hosting;
using Microsoft.Win32;
using Path = System.IO.Path;

namespace OwinWPFHost
{
    public partial class MainWindow : Window
    {
        private string _currentFileName;
        private IDisposable _disposableServer;
        private const string Url = "http://localhost:11000";
          private const string FileName = "Sample.html";

        public MainWindow()
        {
            InitializeComponent();
            MainEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("HTML");
        }

        private void OpenFileClick(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                CheckFileExists = true,
                Filter = "HTML Files | *.html; *.htm"
            };
            if (dlg.ShowDialog().Value)
            {
                _currentFileName = dlg.FileName;
                MainEditor.Load(_currentFileName);
                MainEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension(Path.GetExtension(_currentFileName));
            }
        }

        private void ExitClick(object sender, EventArgs e)
        {
            if (_disposableServer != null)
            {
                _disposableServer.Dispose();
            }
            Application.Current.Shutdown();
        }

        private void Launch_Button_Click(object sender, RoutedEventArgs e)
        {
            if (_disposableServer != null) return;

            Task.Factory.StartNew(() =>
            {
                var startup = new StartOptions();
                startup.Urls.Add(Url);
                _disposableServer = WebApp.Start<StartupInternal>(Url);
            
            }, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveFileClick(object sender, RoutedEventArgs e)
        {
            Environment.CurrentDirectory = Environment.CurrentDirectory + @"..\..\..";
            var filePath = Environment.CurrentDirectory + "\\" + FileName;
            MainEditor.Save(filePath);
        }
    }
}
