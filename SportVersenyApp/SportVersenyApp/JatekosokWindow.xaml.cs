using System.Windows;
using System.Text.RegularExpressions;

namespace SportVersenyApp
{
    public partial class JatekosokWindow : Window
    {
        private MainWindow mainWindow;

        public JatekosokWindow(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
            dgJatekosok.ItemsSource = mainWindow.Jatekosok;
            cmbCsapat.ItemsSource = mainWindow.Csapatok;
        }

        private void Hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJatekosNev.Text) ||
                string.IsNullOrWhiteSpace(txtMezszam.Text) ||
                cmbCsapat.SelectedItem == null)
            {
                MessageBox.Show("Kérjük, töltse ki az összes mezőt!");
                return;
            }

            // Mezszám ellenőrzése
            if (!int.TryParse(txtMezszam.Text, out int mezszam) || mezszam < 1 || mezszam > 99)
            {
                MessageBox.Show("A mezszám 1 és 99 közötti szám lehet!");
                return;
            }

            var jatekos = new Jatekos
            {
                Nev = txtJatekosNev.Text,
                Mezszam = mezszam,
                Csapat = (Csapat)cmbCsapat.SelectedItem
            };

            mainWindow.Jatekosok.Add(jatekos);

            txtJatekosNev.Clear();
            txtMezszam.Clear();
            cmbCsapat.SelectedIndex = -1;
        }

        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            if (dgJatekosok.SelectedItem is Jatekos jatekos)
            {
                mainWindow.Jatekosok.Remove(jatekos);
            }
        }

        private void Bezaras_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}