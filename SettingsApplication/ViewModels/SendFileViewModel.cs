using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia;

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
        }

        public ICommand FileCommand { get; }
        public ICommand FolderCommand { get; }

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
