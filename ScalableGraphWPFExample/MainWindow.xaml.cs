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
        private Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
            CustomGraph = new GI(128, 64, Plot);
            CustomGraph.SetHMarkup(20);

            Demo();
        }

        public void DisplayValue(short next) => CustomGraph.Display(next);

        public async Task Demo(int span = 500)
        {
            while (true)
            {
                DisplayValue((short)rand.Next(-30, 90));
                await Task.Delay(span);
            }
        }
    }
}
