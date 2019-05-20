using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using Chart.Models;
using GraphicChart = System.Windows.Forms.DataVisualization.Charting.Chart;

namespace Chart.Utils
{
    public static class ChartDrawerExtensions
    {
        public static void DrawChart( this GraphicChart chart, List<Point> points )
        {
            const string chartAreaName = "ChartArea";

            chart.ChartAreas.Clear();
            chart.Series.Clear();
            chart.ChartAreas.Add( new ChartArea( chartAreaName ) );
            var series = new Series
            {
                ChartType = SeriesChartType.Line,
                ChartArea = chartAreaName
            };

            foreach ( Point point in points )
            {
                series.Points.AddXY( point.X, point.Y );
            }

            chart.Series.Add( series );
        }
    }
}
