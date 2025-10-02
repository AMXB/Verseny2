using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SportVersenyApp
{
    public class Csapat : INotifyPropertyChanged
    {
        private string _nev = string.Empty;
        private int _pontok;

        public string Nev
        {
            get => _nev;
            set
            {
                _nev = value;
                OnPropertyChanged(nameof(Nev));
            }
        }

        public int Pontok
        {
            get => _pontok;
            set
            {
                _pontok = value;
                OnPropertyChanged(nameof(Pontok));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Jatekos : INotifyPropertyChanged
    {
        private string _nev = string.Empty;
        private Csapat _csapat;
        private int _mezszam;

        public string Nev
        {
            get => _nev;
            set
            {
                _nev = value;
                OnPropertyChanged(nameof(Nev));
            }
        }

        public Csapat Csapat
        {
            get => _csapat;
            set
            {
                _csapat = value;
                OnPropertyChanged(nameof(Csapat));
            }
        }

        public int Mezszam
        {
            get => _mezszam;
            set
            {
                _mezszam = value;
                OnPropertyChanged(nameof(Mezszam));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Verseny : INotifyPropertyChanged
    {
        private string _nev = string.Empty;
        private Csapat _csapat1;
        private Csapat _csapat2;
        private string _eredmeny = string.Empty;

        public string Nev
        {
            get => _nev;
            set
            {
                _nev = value;
                OnPropertyChanged(nameof(Nev));
            }
        }

        public Csapat Csapat1
        {
            get => _csapat1;
            set
            {
                _csapat1 = value;
                OnPropertyChanged(nameof(Csapat1));
            }
        }

        public Csapat Csapat2
        {
            get => _csapat2;
            set
            {
                _csapat2 = value;
                OnPropertyChanged(nameof(Csapat2));
            }
        }

        public string Eredmeny
        {
            get => _eredmeny;
            set
            {
                _eredmeny = value;
                OnPropertyChanged(nameof(Eredmeny));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}