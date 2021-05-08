using System;
using ReactiveUI;
using System.Windows.Input;
using Avalonia.Controls;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SettingsApplication.ViewModels
{
    class SendFileViewModel : ViewModelBase
    {
        public SendFileViewModel()
        {
            FileCommand = ReactiveCommand.Create(async (Window window) =>
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filters.Add(new FileDialogFilter() { Name = ".cs, .txt, .sh", Extensions = { "cs", "txt", "sh" } });
                string[] result = await dialog.ShowAsync(window);

                if (result.Length != 0)
                    FileName = string.Join(" ", result);
            });

            FolderCommand = ReactiveCommand.Create(async (Window window) =>
            {
                OpenFolderDialog dialog = new OpenFolderDialog();
                string result = await dialog.ShowAsync(window);

                if (result.Length != 0)
                    FolderName = result;
            });

            GoToUrl = ReactiveCommand.Create((string url) =>
            {
                try
                {
                    Process.Start(url);
                }
                catch
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        url = url.Replace("&", "^&");
                        Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true});
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        Process.Start("xdg-open", url);
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        Process.Start("open", url);
                    }
                    else
                    {
                        throw;
                    }
                }
            });
        }

        public ICommand FileCommand { get; }
        public ICommand FolderCommand { get; }

        public ICommand GoToUrl { get; }

        private string fileName;
        private string folderName;
        public string FileName 
        {
            get => fileName; 
            set => this.RaiseAndSetIfChanged(ref fileName, value); 
        }

        public string FolderName
        {
            get => folderName;
            set => this.RaiseAndSetIfChanged(ref folderName, value);
        }

    }
}
