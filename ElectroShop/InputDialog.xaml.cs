using System.Windows;

namespace ElectroShop
{
    public partial class InputDialog : Window
    {
        public string ResultText { get; private set; }

        public InputDialog(string title, string prompt)
        {
            InitializeComponent();
            Title = title;
            tbPrompt.Text = prompt;
            txtValue.Focus();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            ResultText = txtValue.Text;
            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}