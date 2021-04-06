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
        private TextBox chooseFolderBox;

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        public async void ChooseFileOnClickCommand(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter() {Name = ".cs, .txt, .sh", Extensions = {"cs", "txt", "sh"}});

            string[] result = await dialog.ShowAsync(this);

            chooseFileBox.Text = string.Join(" ", result);
        }

        public async void ChooseFolderOnClickCommand(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog dialog = new OpenFolderDialog();

            string result = await dialog.ShowAsync(this);

            chooseFolderBox.Text = result;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            chooseFileBox = this.FindControl<TextBox>("pathToFileBox");
            chooseFolderBox = this.FindControl<TextBox>("pathToFolderBox");
        }
    }
}
