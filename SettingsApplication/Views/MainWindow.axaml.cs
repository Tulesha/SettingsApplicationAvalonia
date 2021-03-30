using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Diagnostics;

namespace SettingsApplication.Views
{
    public class MainWindow : Window
    {
        private TextBox chooseFileBox;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public void ChooseFileOnClickCommand(object sender, RoutedEventArgs e)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/usr/bin/zenity",
                    Arguments = "--file-selection --tile \"Choose the file\" --file-filter = '*. cs * .sh * .txt'",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            chooseFileBox.Text = result;

            Console.WriteLine(result);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            chooseFileBox = this.FindControl<TextBox>("pathToFileBox");
        }
    }
}
