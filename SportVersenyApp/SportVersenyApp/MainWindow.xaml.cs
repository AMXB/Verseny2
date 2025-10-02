using System.Windows;
using System.Collections.ObjectModel;

namespace SportVersenyApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Csapat> Csapatok { get; set; }
        public ObservableCollection<Jatekos> Jatekosok { get; set; }
        public ObservableCollection<Verseny> Versenyek { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Csapatok = new ObservableCollection<Csapat>();
            Jatekosok = new ObservableCollection<Jatekos>();
            Versenyek = new ObservableCollection<Verseny>();
        }

        private void Csapatok_Click(object sender, RoutedEventArgs e)
        {
            CsapatokWindow window = new CsapatokWindow(this);
            window.ShowDialog();
            FrissitStatisztika();
        }

        private void Jatekosok_Click(object sender, RoutedEventArgs e)
        {
            JatekosokWindow window = new JatekosokWindow(this);
            window.ShowDialog();
            FrissitStatisztika();
        }

        private void Versenyek_Click(object sender, RoutedEventArgs e)
        {
            VersenyekWindow window = new VersenyekWindow(this);
            window.ShowDialog();
            FrissitStatisztika();
        }

        private void Eredmenyek_Click(object sender, RoutedEventArgs e)
        {
            EredmenyekWindow window = new EredmenyekWindow(this);
            window.ShowDialog();
        }

        private void FrissitStatisztika()
        {
            tbCsapatokSzama.Text = Csapatok.Count.ToString();
            tbJatekosokSzama.Text = Jatekosok.Count.ToString();
            tbVersenyekSzama.Text = Versenyek.Count.ToString();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            FrissitStatisztika();
        }
    }
}