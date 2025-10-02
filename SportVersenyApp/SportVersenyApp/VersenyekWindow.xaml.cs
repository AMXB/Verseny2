using System.Windows;
using System.Windows.Controls;

namespace SportVersenyApp
{
    public partial class VersenyekWindow : Window
    {
        private MainWindow mainWindow;

        public VersenyekWindow(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
            dgVersenyek.ItemsSource = mainWindow.Versenyek;

            cmbCsapat1.ItemsSource = mainWindow.Csapatok;
            cmbCsapat2.ItemsSource = mainWindow.Csapatok;
            cmbEredmeny.SelectedIndex = 0;
        }

        private void VersenyHozzaadas_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVersenyNev.Text) ||
                cmbCsapat1.SelectedItem == null ||
                cmbCsapat2.SelectedItem == null)
            {
                MessageBox.Show("Kérjük, töltse ki az összes mezőt!");
                return;
            }

            if (cmbCsapat1.SelectedItem == cmbCsapat2.SelectedItem)
            {
                MessageBox.Show("A két csapat nem lehet ugyanaz!");
                return;
            }

            var verseny = new Verseny
            {
                Nev = txtVersenyNev.Text,
                Csapat1 = (Csapat)cmbCsapat1.SelectedItem,
                Csapat2 = (Csapat)cmbCsapat2.SelectedItem,
                Eredmeny = ((ComboBoxItem)cmbEredmeny.SelectedItem).Content.ToString()
            };

            mainWindow.Versenyek.Add(verseny);

            // Pontok kiszámolása
            SzamolPontokat(verseny);

            txtVersenyNev.Clear();
            cmbCsapat1.SelectedIndex = -1;
            cmbCsapat2.SelectedIndex = -1;
            cmbEredmeny.SelectedIndex = 0;
        }

        private void SzamolPontokat(Verseny verseny)
        {
            // Pontok visszaállítása a verseny hozzáadása előtt (ha már voltak pontok)
            // Ez egyszerűsített megoldás, egy valós alkalmazásban komplexebb logika kellene

            string eredmeny = ((ComboBoxItem)cmbEredmeny.SelectedItem).Content.ToString();

            switch (eredmeny)
            {
                case "Csapat 1 győz":
                    verseny.Csapat1.Pontok += 3;
                    verseny.Csapat2.Pontok += 0;
                    break;
                case "Csapat 2 győz":
                    verseny.Csapat1.Pontok += 0;
                    verseny.Csapat2.Pontok += 3;
                    break;
                case "Döntetlen":
                    verseny.Csapat1.Pontok += 1;
                    verseny.Csapat2.Pontok += 1;
                    break;
            }
        }

        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            if (dgVersenyek.SelectedItem is Verseny verseny)
            {
                // Pontok visszavonása a verseny törlésekor
                VondVisszaPontokat(verseny);
                mainWindow.Versenyek.Remove(verseny);
            }
        }

        private void VondVisszaPontokat(Verseny verseny)
        {
            switch (verseny.Eredmeny)
            {
                case "Csapat 1 győz":
                    verseny.Csapat1.Pontok -= 3;
                    break;
                case "Csapat 2 győz":
                    verseny.Csapat2.Pontok -= 3;
                    break;
                case "Döntetlen":
                    verseny.Csapat1.Pontok -= 1;
                    verseny.Csapat2.Pontok -= 1;
                    break;
            }
        }

        private void Bezaras_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}