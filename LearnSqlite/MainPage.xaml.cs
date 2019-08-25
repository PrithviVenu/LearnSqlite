using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LearnSqlite
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public class Stock
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Symbol { get; set; }
    }
    public class ItemViewModel : INotifyPropertyChanged
    {
        // Properties  
        private int _manufacturer;
        private string _model;
        private string _color;
        private int _year;

        [PrimaryKey, AutoIncrement]

        public int manufacturer
        {
            get { return _manufacturer; }

            set
            {
                _manufacturer = value;
                NotifyPropertyChanged("manufacturer");
            }
        }

        public string model
        {
            get { return _model; }

            set
            {
                _model = value;
                NotifyPropertyChanged("model");
            }
        }

        public string color
        {
            get { return _color; }
            set
            {
                _color = value;
                NotifyPropertyChanged("color");
            }
        }

        public int year
        {
            get { return _year; }
            set
            {
                _year = value;
                NotifyPropertyChanged("year");
            }
        }

        // Property Change Logic  
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class Valuation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int StockId { get; set; }
        public DateTime Time { get; set; }
        public decimal Price { get; set; }
    }
    public class Valuationn
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int StockId { get; set; }
        public DateTime Time { get; set; }
        public decimal Price { get; set; }
    }
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            string path = Path.Combine(Windows.Storage.ApplicationData.
  Current.LocalFolder.Path, "learn.db");
            var db = new SQLiteConnection(path);

            db.CreateTable<Stock>();
            db.CreateTable<Valuation>();
            db.CreateTable<Valuationn>();
            db.CreateTable<ItemViewModel>();



        }
    }
}
