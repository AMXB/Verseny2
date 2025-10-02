using System.Windows;

namespace SportVersenyApp
{
    public partial class CsapatokWindow : Window
    {
        private MainWindow mainWindow;

        public CsapatokWindow(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
            dgCsapatok.ItemsSource = mainWindow.Csapatok;
        }

        private void Hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCsapatNev.Text))
            {
                mainWindow.Csapatok.Add(new Csapat { Nev = txtCsapatNev.Text });
                txtCsapatNev.Clear();
            }
        }

        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            if (dgCsapatok.SelectedItem is Csapat csapat)
            {
                mainWindow.Csapatok.Remove(csapat);
            }
        }

        private void Bezaras_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}