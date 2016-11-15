using BarChart;
using System;
using Android.App;
using Android.OS;

namespace Project
{
    [Activity(Theme = "@style/DetailsTheme", Label = "Late Orders", Icon = "@drawable/launcher")]
    public class LateOrders : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Graph);
            string lip = Intent.GetStringExtra("DataFromOrder") ?? "Data not available";

            int lateOrderY = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("lateOrderYear")).Result);
            int lateOrderM = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("lateOrderMonth")).Result);
            int lateOrderD = Convert.ToInt16(NetHttp.FetchWaitAsync(App.Instance.GetUrl("lateOrderToday")).Result);

            var data = new[] { lateOrderD, lateOrderM, lateOrderY };
            var color = new Android.Graphics.Color[3] { Android.Graphics.Color.DarkGoldenrod, Android.Graphics.Color.Chocolate, Android.Graphics.Color.ForestGreen };
            var leg = new[] { "Today", "Current Month", "Current Year" };
            BarModel[] datab = new BarModel[3];
            for (int i = 0; i < 3; i++)
            {
                datab[i] = new BarModel() { Value = data[i], Legend = leg[i], Color = color[i] };
            }
            var chart = new BarChartView(this);

            chart = FindViewById<BarChart.BarChartView>(Resource.Id.barChart);
            chart.ItemsSource = datab;
            chart.Invalidate();
            chart.BarWidth = 150;
            chart.LegendColor = Android.Graphics.Color.Black;
            chart.LegendFontSize = 24;            
        }
    }
}


