using System.Windows;
using System.Linq;
using System.Collections.ObjectModel;

namespace SportVersenyApp
{
    public partial class EredmenyekWindow : Window
    {
        private MainWindow mainWindow;

        public class Eredmeny
        {
            public int Helyezes { get; set; }
            public Csapat Csapat { get; set; }
        }

        public EredmenyekWindow(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
            FrissitEredmenyek();
        }

        private void FrissitEredmenyek()
        {
            var rendezettCsapatok = mainWindow.Csapatok
                .OrderByDescending(c => c.Pontok)
                .Select((csapat, index) => new Eredmeny
                {
                    Helyezes = index + 1,
                    Csapat = csapat
                })
                .ToList();

            dgEredmenyek.ItemsSource = rendezettCsapatok;
        }

        private void Bezaras_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}