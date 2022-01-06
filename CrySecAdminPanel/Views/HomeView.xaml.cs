using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
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

namespace CrySecAdminPanel.Views
{
    /// <summary>
    /// Lógica de interacción para HomeView.xaml
    /// </summary>
    public partial class HomeView : Page
    {
        public ISeries[] Series { get; set; }
           = {
            new LineSeries<double>
            {
                Name = "Serie",
                Values = new double[] { 2, 1, 3, 5, 3, 4, 6 },
                Fill =  null,
                LineSmoothness = 1,
            }
        };

        public String FrameContentHeight = "100";

        public HomeView()
        {
            InitializeComponent();
            Chart.Series = Series;
            Chart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Top; 
        }
    }
}
