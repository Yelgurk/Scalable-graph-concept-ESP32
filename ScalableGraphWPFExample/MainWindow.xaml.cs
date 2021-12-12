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
        private bool beeep = true;

        public MainWindow()
        {
            this.KeyDown += (object sender, KeyEventArgs e) => {
                if (e.Key == Key.Space)
                    beeep = !beeep;
            };

            InitializeComponent();
            CustomGraph = new GI(256, 128, Plot, TablePresenter);
            CustomGraph.SetHMarkup(20);

            Demo(1000);
        }

        public void DisplayValue(short next) => CustomGraph.Display(next);

        public async Task Demo(int span = 500)
        {
            while (true)
            {
                if (beeep)
                    DisplayValue((short)rand.Next(-100, 100));
                await Task.Delay(span);
            }
        }
    }
}
