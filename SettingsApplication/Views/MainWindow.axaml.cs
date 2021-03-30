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

        public async void ChooseFileOnClickCommand(object sender, RoutedEventArgs e)
        {
            /*
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/usr/bin/zenity",
                    Arguments = "--file-selection --title \"Choose the file\" --file-filter=\"*.cs *.sh *.txt\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };

            process.Start();
            string result = process.StandardOutput.ReadToEnd().Replace(Environment.NewLine, "");
            process.WaitForExit();

            chooseFileBox.Text = result;
            */

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter() {Name = ".cs, .txt, .sh", Extensions = {"cs", "txt", "sh"}});

            string[] result = await dialog.ShowAsync(this);

            chooseFileBox.Text = string.Join(" ", result);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            chooseFileBox = this.FindControl<TextBox>("pathToFileBox");
        }
    }
}
