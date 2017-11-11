using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;


namespace BitHeat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        readonly Calculations _calculations = new Calculations();
        private ObservableCollection<KeyValuePair<string, double>> collection = new ObservableCollection<KeyValuePair<string, double>>();
        private const double schoolArea = 1500, houseArea = 200;

        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            collection.Add(new KeyValuePair<string, double>("", 0));
            ShowColumnChart();
            //collection.RemoveAt(0);
        }

        private void ShowColumnChart()
        {

            this.collection = _calculations.GetList();
            Chart.DataContext = collection;
            //    Chart.Series.Add(new ColumnSeries(collection));
        }

        private void inputCost_TextChanged(object sender, TextChangedEventArgs e)
        {

            inputValue.Clear();
            double value;
            if (Double.TryParse(inputCost.Text, out value))
                _calculations.UpdateCost(value);
            ShowColumnChart();
            double persentSchool = _calculations.Area / schoolArea * 100;
            double persentHouse = _calculations.Area / houseArea * 100;
            schoolText.Content = $"{persentSchool}%";
            homeText.Content = $"{persentHouse}%";
        }

        private void inputValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            inputCost.Clear();
            double value;
            if (Double.TryParse(inputValue.Text, out value))
                _calculations.UpdateTHS(value);
            ShowColumnChart();
            var persentSchool = _calculations.Area / schoolArea * 100;
            var persentHouse = _calculations.Area / houseArea * 100;
            schoolText.Content = $"{persentSchool}%";
            homeText.Content = $"{persentHouse}%";
        }
    }
}
