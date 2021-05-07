using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SettingsApplication.Views
{
    public class SendFileView : UserControl
    {
        public SendFileView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
