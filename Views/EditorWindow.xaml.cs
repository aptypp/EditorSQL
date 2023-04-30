using System.Windows;
using EditorSQL.ViewModels;

namespace EditorSQL.Views
{
    public partial class EditorWindow : Window
    {
        private readonly EditorViewModel _context;

        public EditorWindow()
        {
            InitializeComponent();
            _context = (EditorViewModel)DataContext;
        }

        private void PushButtonOnClick(object sender, RoutedEventArgs e)
        {
            _context.PushData(InputField.Text);
            _context.PullData();

            InputField.Text = string.Empty;
        }

        private void PullButtonOnClick(object sender, RoutedEventArgs e)
        {
            _context.PullData();
        }

        private void RemoveButtonOnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}