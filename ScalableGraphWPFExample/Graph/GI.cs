using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ScalableGraphWPFExample.Graph
{
    ///  The GraphImplementation(GI) class repeats the AdafruitGFX class with its constructor.
    ///  The GI class is implemented purely to simulatethe use of the AdafruitGFX library in order to make the following refactoring easier for C++
    public class GI
    {
        private Canvas mainPlot = null;
        private ushort chartWidth = 0,
                       chartHeight = 0;

        /// <param name="display">is a missing parameter in the AdafruitGFX library. It is needed to specify on which user control to display the graphics.</param>
        public GI(ushort chartWidth, ushort chartHeight, Canvas display)
        {
            this.mainPlot = display;
            this.mainPlot.Width = this.chartWidth = chartWidth;
            this.mainPlot.Height = this.chartHeight = chartHeight;
        }

        private short[] HMarkup = new short[0];

        public void SetHMarkup(ushort size) => Array.Resize<short>(ref HMarkup, size);

        public void NewValue(short value)
        {
            for (ushort x = Convert.ToUInt16(HMarkup.Length); x - 2 >= 0; x--)
                HMarkup[x - 1] = HMarkup[x - 2];
            HMarkup[0] = value;
        }

        public void Display(short newValue)
        {
            NewValue(newValue);
            ClearGraph();
            Draw();
        }

        public void Draw()
        {
            short min = HMarkup.Min();
            short max = HMarkup.Max();
            min = min > 0 ? (short)0 : min;

            ushort Range = Convert.ToUInt16(max - min);
            ushort VStep = Convert.ToUInt16(Range / chartHeight);
            ushort HStep = Convert.ToUInt16(chartWidth / HMarkup.Length);

            for (ushort x = 0; x < HMarkup.Length - 2; x++)
            {
                if (HMarkup[x + 1] == 0)
                    continue;

                ushort x0 = Convert.ToUInt16((HMarkup.Length - x) * HStep),
                       y0 = Convert.ToUInt16((Range / HMarkup[x]) * VStep),
                       x1 = Convert.ToUInt16((HMarkup.Length - x - 1) * HStep),
                       y1 = Convert.ToUInt16((Range / HMarkup[x + 1]) * VStep);

                WriteLine(x0, y0, x1, y1);
            }
        }

        /// Use "writeLine" function to draw lines "void writeLine(int16_t x0, int16_t y0, int16_t x1, int16_t y1, uint16_t color);"
        public void WriteLine(ushort x0, ushort y0, ushort x1, ushort y1) => mainPlot.Children.Add(new Line() { X1 = x0, Y1 = y0, X2 = x1, Y2 = y1, Stroke = Brushes.Black });

        /// Use the "fillscreen" function to update the graph "void fillScreen(uint16_t color);"
        public void ClearGraph() => mainPlot.Children.Clear();
    }
}
