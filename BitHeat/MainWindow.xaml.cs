using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
using MahApps.Metro.Controls;


namespace BitHeat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        Calculations calculations = new Calculations();
        public ObservableCollection<KeyValuePair<string, double>> collection = new ObservableCollection<KeyValuePair<string, double>>();

        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            collection.Add(new KeyValuePair<string, double>("", 0));
            //Chart.DataContext = collection;
            ShowColumnChart();
        }

        private void ShowColumnChart()
        {

            this.collection = calculations.GetList();
            Chart.DataContext = collection;
            //    Chart.Series.Add(new ColumnSeries(collection));
        }

        private void inputCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            inputValue.Clear();
            double value;
            if (Double.TryParse(inputCost.Text, out value))
                calculations.UpdateCost(value);
            ShowColumnChart();
        }

        private void inputValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            inputCost.Clear();
            double value;
            if (Double.TryParse(inputValue.Text, out value))
                calculations.UpdateTHS(value);
            ShowColumnChart();
        }
    }
}
