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
            CustomGraph = new GI(128, 64, Plot);
            CustomGraph.SetHMarkup(6);

            DisplayValue(20);
            DisplayValue(100);
            DisplayValue(50);
            DisplayValue(10);
            DisplayValue(30);
            DisplayValue(80);
        }

        public void DisplayValue(short next)
        {
            CustomGraph.Display(next);
        }
    }
}
