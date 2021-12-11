using ScalableGraphWPFExample.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ScalableGraphWPFExample
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GI CustomGraph;

        public MainWindow()
        {
            InitializeComponent();
            CustomGraph = new GI(64, 32, Plot);
            CustomGraph.SetHMarkup(10);

            Demo();
        }

        public void DisplayValue(short next) => CustomGraph.Display(next);

        public async Task Demo()
        {
            DisplayValue(20);
            await Task.Delay(1000);

            DisplayValue(100);
            await Task.Delay(1000);

            DisplayValue(50);
            await Task.Delay(1000);

            DisplayValue(10);
            await Task.Delay(1000);

            DisplayValue(30);
            await Task.Delay(1000);

            DisplayValue(80);
            await Task.Delay(1000);

            DisplayValue(10);
            await Task.Delay(1000);

            DisplayValue(15);
            await Task.Delay(1000);

            DisplayValue(10);
            await Task.Delay(1000);

            DisplayValue(5);
            await Task.Delay(1000);

            DisplayValue(95);
            await Task.Delay(1000);

            DisplayValue(40);
        }
    }
}
