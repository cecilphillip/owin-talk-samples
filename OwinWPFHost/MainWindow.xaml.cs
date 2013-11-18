using System;
using System.Windows;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using Microsoft.Win32;
using Path = System.IO.Path;

namespace OwinWPFHost
{
    public partial class MainWindow : Window
    {
        private string _currentFileName;

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
            Application.Current.Shutdown();
        }
    }
}
