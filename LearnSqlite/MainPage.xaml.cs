using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public class ItemViewModel1 : INotifyPropertyChangedBase
    {
        // Properties  
        private string _manufacturer;
        private string _model;
        private string _color;
        private int _year;

        public string manufacturer
        {
            get { return _manufacturer; }

            set { this.SetProperty(ref this._manufacturer, value); }
        }

        public string model
        {
            get { return _model; }

            set { this.SetProperty(ref this._model, value); }
        }

        public string color
        {
            get { return _color; }

            set { this.SetProperty(ref this._color, value); }
        }

        public int year
        {
            get { return _year; }

            set { this.SetProperty(ref this._year, value); }
        }


        // Property Change Logic  





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
            Insert();


        }
        public async void Insert()
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.
  Current.LocalFolder.Path, "learn.db");
            var db = new SQLiteAsyncConnection(path);

            await db.CreateTableAsync<Stock>();
            await db.CreateTableAsync<Valuation>();
            await db.CreateTableAsync<Valuationn>();
            await db.CreateTableAsync<ItemViewModel>();
            await db.CreateTableAsync<ItemViewModel1>();
            var stock = new Stock()
            {
                Symbol = "AAPL"
            };

            await db.InsertAsync(stock);

            await db.InsertAsync(new Valuationn());

            Debug.WriteLine("Auto stock id: {0}", stock.Id);
        }
    }
}
